using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HPSocket;
using HPSocket.Tcp;
using Models;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using RobotControl.SHUTools;

namespace RobotControl
{

    public class CameraSvr
    {


#pragma warning disable IDE0069 // 应释放可释放的字段
        private readonly ITcpClient _client = new TcpClient();
#pragma warning restore IDE0069 // 应释放可释放的字段

        /// <summary>
        /// 封包, 做粘包用
        /// </summary>
        private readonly List<byte> _packetData = new List<byte>();

        /// <summary>
        /// 最大封包长度
        /// </summary>
        private const int MaxPacketSize = 4096;
        

        /*以下回调函数中不要做耗时操作*/
        /// <summary>
        /// 接收到完整数据包回调函数
        /// </summary>
        public EventHandler<Packet> OnReceiveCallback;
        /// <summary>
        /// 断开连接回调函数
        /// </summary>
        public EventHandler<EventArgs> OnCloseCallback;
        /// <summary>
        /// 连接成功回调函数
        /// </summary>
        public EventHandler<EventArgs> OnConnectCallback;

        private static  NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private bool _isConnect = false;
        public bool IsConnect()
        {
            return _isConnect;
        }

        public CameraSvr(string IP, ushort port)
        {
            _client.Address = IP;
            _client.Port = port;

            _client.Async = true;

            // 事件绑定
            _client.OnPrepareConnect += OnPrepareConnect;
            _client.OnConnect += OnConnect;
            _client.OnReceive += OnReceive;
            _client.OnClose += OnClose;
            logger.Info("Camera init..");
        }
        ~CameraSvr()
        {

            if (_client.HasStarted)
            {
                _client.Stop();
            }

            // 停止并释放客户端
            _client.Dispose();
            NLog.LogManager.Shutdown();
        }
        public bool ConnectSvr()
        {
            bool rtn = false;
            try
            {
                if (_client.Connect())
                {
                    //await _client.WaitAsync();
                    rtn = true;
                }


            }
            catch (Exception e)
            {

                //throw;
                logger.Fatal(e.Message);
            }

            return rtn;
        }
        public bool ConnectSvr(string ip, ushort port)
        {
            bool rtn = false;
            try
            {
                if (_client.Connect(ip,port))
                {
                    rtn = true;
                }


            }
            catch (Exception)
            {

                //throw;
            }

            return rtn;
        }

        // ReSharper disable once InconsistentNaming
        private HandleResult OnPrepareConnect(IClient sender, IntPtr socket)
        {
            //AddLog($"OnPrepareConnect({sender.Address}:{sender.Port}), socket handle: {socket}, hp-socket version: {sender.Version}");
            
            return HandleResult.Ok;
        }

        // ReSharper disable once InconsistentNaming
        private HandleResult OnConnect(IClient sender)
        {
            //AddLog("OnConnect()");
            _packetData.Clear();
            _isConnect = true;
            OnConnectCallback?.Invoke(this, EventArgs.Empty);
            return HandleResult.Ok;
        }

        // ReSharper disable once InconsistentNaming
        private HandleResult OnReceive(IClient sender, byte[] data)
        {
            _packetData.AddRange(data);

            // 总长度小于包头
            if (_packetData.Count < sizeof(int))
            {
                return HandleResult.Ok;
            }
            HandleResult result;
            const int headerLength = sizeof(int);
            do
            {
                // 取头部字节得到包头
                var packetHeader = _packetData.GetRange(0, headerLength).ToArray();

                // 两端字节序要保持一致
                // 如果当前环境不是小端字节序
                if (!BitConverter.IsLittleEndian)
                {
                    // 翻转字节数组, 变为小端字节序
                    Array.Reverse(packetHeader);
                }

                // 得到包头指向的数据长度
                var dataLength = BitConverter.ToInt32(packetHeader, 0);

                // 完整的包长度(含包头和完整数据的大小)
                var fullLength = dataLength + headerLength;

                if (dataLength < 0 || fullLength > MaxPacketSize)
                {
                    result = HandleResult.Error;
                    break;
                }

                // 如果来的数据小于一个完整的包
                if (_packetData.Count < fullLength)
                {
                    // 下次数据到达处理
                    result = HandleResult.Ignore;
                    break;
                }

                // 是不是一个完整的包(包长 = 实际数据长度 + 包头长度)
                if (_packetData.Count == fullLength)
                {
                    // 得到完整包并处理
                    var fullData = _packetData.GetRange(headerLength, dataLength).ToArray();
                    result = OnProcessFullPacket(fullData);
                    // 清空缓存
                    _packetData.Clear();
                    break;
                }

                // 如果来的数据比一个完整的包长
                if (_packetData.Count > fullLength)
                {
                    // 先得到完整包并处理
                    var fullData = _packetData.GetRange(headerLength, dataLength).ToArray();
                    result = OnProcessFullPacket(fullData);
                    if (result == HandleResult.Error)
                    {
                        break;
                    }
                    // 再移除已经读了的数据
                    _packetData.RemoveRange(0, fullLength);

                    // 剩余的数据下个循环处理
                }

            } while (true);


            return result;
        }

        // ReSharper disable once InconsistentNaming
        private HandleResult OnClose(IClient sender, SocketOperation socketOperation, int errorCode)
        {
            _packetData.Clear();
            _isConnect = false;
            OnCloseCallback?.Invoke(this,EventArgs.Empty);

            //AddLog($"OnClose(), socket operation: {socketOperation}, error code: {errorCode}");
            return HandleResult.Ok;
        }

        // ReSharper disable once InconsistentNaming
        private HandleResult OnProcessFullPacket(byte[] data)
        {
            // 这里来的都是完整的包
            var packet = JsonConvert.DeserializeObject<Packet>(Encoding.UTF8.GetString(data));
            var result = HandleResult.Ok;
            //switch (packet.Type)
            //{
            //    case PacketType.Echo: // 回显是个字符串显示操作
            //        {
            //            //AddLog($"OnProcessFullPacket(), type: {packet.Type}, content: {packet.Data}");
            //            CallbackEcho?.Invoke(this, packet);
            //            break;
            //        }
            //    case PacketType.Time: // 获取服务器时间依然是个字符串操作^_^
            //        {
            //            //AddLog($"OnProcessFullPacket(), type: {packet.Type}, time: {packet.Data}");
            //            CallbackTime?.Invoke(this, packet);
            //            break;
            //        }
            //    default:
            //        result = HandleResult.Error;
            //        break;
            //}
            OnReceiveCallback?.Invoke(this, packet);
            return result;
        }

        /// <summary>
        /// 发送包头
        /// <para>固定包头网络字节序</para>
        /// </summary>
        /// <param name="dataLength">实际数据长度</param>
        /// <returns></returns>
        private bool SendPacketHeader(int dataLength)
        {
            // 包头转字节数组
            var packetHeaderBytes = BitConverter.GetBytes(dataLength);

            // 两端字节序要保持一致
            // 如果当前环境不是小端字节序
            if (!BitConverter.IsLittleEndian)
            {
                //logger.Error("翻转字节数组, 变为小端字节序");
                //翻转字节数组, 变为小端字节序
                Array.Reverse(packetHeaderBytes);
            }

            return _client.Send(packetHeaderBytes, packetHeaderBytes.Length);
        }

        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="type"></param>
        /// <param name="data"></param>
        //public void Send(PacketType type, string data)
        public void Send(Packet packet)
        {

            if (!_client.HasStarted)
            {
                return;
            }

            // 组织封包, 取得要发送的数据
            //var packet = new Packet
            //{
            //    Type = type,
            //    Data = data,
            //};

            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(packet));

            // 发送包头, 发送失败断开连接
            if (!SendPacketHeader(bytes.Length))
            {
                logger.Error("发送包头, 发送失败断开连接");
                //MessageBox.Show("发送包头");
                _client.Stop();
                return;
            }

            // 发送实际数据, 发送失败断开连接
            if (!_client.Send(bytes, bytes.Length))
            {
                logger.Error("发送实际数据, 发送失败断开连接");
                //MessageBox.Show("发送实际数据");
                _client.Stop();
            }
        }
    }//end of class
}

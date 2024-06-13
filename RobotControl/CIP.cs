using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml.Serialization;
using OMRON.Compolet.CIPCompolet64;




namespace FinsCom
{
    //FINS收发函数
    public class CIP
    {
        private static CIP _instance;
        private Thread _recvThread = null;
        //private TrigFromCIP _FrameRecv = new TrigFromCIP();
        
        //private ResultToCIP resultToCIP = new ResultToCIP();
        //private CamStatusToCIP camStatus = new CamStatusToCIP();
        //private CCDtoPLC_Answer Answer = new CCDtoPLC_Answer();
        //private MaterialResultToCIP MaterialResultToCIP = new MaterialResultToCIP();
        //private ElectEarMeasureResultToCIP ElectEarMeasureResultToCIP = new ElectEarMeasureResultToCIP();
        //private JudgmentRangeToCIP ResultRangeToCIP = new JudgmentRangeToCIP();
        private Boolean _recvLoop = false;
        //private UInt16 _RecvByteLen = 0;
        //private UInt16 _EarRecvByteLen = 0;
        //private UInt16 _SendByteLen = 0;//发送帧长度
        //private ushort _startSendAddr = 3550;//发送给PLC数据
        //private ushort _startRecvAddr = 3500;//接收PLC数据
        //private UInt16  _AnswerLen = 0;
        private UInt16 AutoMcahineToAOI_DataLen = 0;
        private UInt16 AOIToAutoMcahine_DataLen = 0;

        //public byte _currTOk = 255;

        private NXCompolet _nxCompolet1;

        //public static int NodeNumber = 1;

        public object _lockSend = new object();

        // 相机通讯标签定义
        //public string Trig_A = "TrigData";//相机触发数据 A侧
        //public string Trig_B = "TrigData_B";//相机触发数据 B侧

        public static string AutoMcahineTo_AOI = "AutoMcahine_AOI";
        public static string AOITo_AutoMcahine = "AOI_AutoMcahine";
        private st_AutoMcahine_AOI AutoMcahineToAOI_Data = new st_AutoMcahine_AOI();
        private st_AOI_AutoMcahine AOIToAutoMcahine_Data = new st_AOI_AutoMcahine();



        private CIP()
        {
            //resultToCIP.Init();
            //camStatus.Init();
            //Answer.Init();
            //MaterialResultToCIP.Init();
            //ElectEarMeasureResultToCIP.Init();
            //ResultRangeToCIP.Init();
            //_RecvByteLen = (ushort)(Marshal.SizeOf(_FrameRecv));
            AutoMcahineToAOI_Data.Init();
            AOIToAutoMcahine_Data.Init();

             //_AnswerLen = (ushort)(Marshal.SizeOf(Answer));
            AutoMcahineToAOI_DataLen = (ushort)(Marshal.SizeOf(AutoMcahineToAOI_Data));
            AOIToAutoMcahine_DataLen = (ushort)(Marshal.SizeOf(AOIToAutoMcahine_Data));
            this._nxCompolet1 = new OMRON.Compolet.CIPCompolet64.NXCompolet(null);
        }

        public static CIP GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CIP();
            }
            return _instance;
        }

        #region 公用方法

      
        public delegate void CIPReceivedMessageEventHandler(CIPRecvInfoArgs recvMsg);
        public event CIPReceivedMessageEventHandler Trig_Callback = null;

       
        /// <summary>
        /// 1:相机完成信号 4:相机打开失败 8:发送结果完成信号
        /// </summary>
        /// <param name="status"></param>
        //public void SetPCStatus(UInt16 status)
        //{
        //    try
        //    {
        //        camStatus.Status = status;
        //        Byte[] data = Memcpy.StructToBytes(camStatus, _camStatusByteLen);

        //        if (this._nxCompolet1 != null)
        //            this._nxCompolet1.WriteRawData(CamStatusTag, data);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("SetPCStatus Fail" + ex.Message);
        //        LogMgr.CipErrorLog(true, "SetCam1Status Fail： " + ex.Message);
        //    }
        //}
        /// <summary>
        /// 出料相机 1:相机完成信号
        /// </summary>
        /// <param name="status"></param>
        //public void SetCamStatus(UInt16 status)
        //{
        //    try
        //    {
        //        camStatus.Status = status;
        //        Byte[] data = Memcpy.StructToBytes(camStatus, _camStatusByteLen);

        //        if (this._nxCompolet1 != null)
        //            this._nxCompolet1.WriteRawData(CamStatusTag2, data);
        //    }
        //    catch (Exception ex)
        //    {
        //        //Console.WriteLine("SetCamStatus Fail" + ex.Message);
        //        LogMgr.CipErrorLog(true, "SetCam2Status Fail： " + ex.Message);
        //    }
        //}

        //public void SetAnswer(int status)
        //{
        //    try
        //    {
        //        Answer.Answer = status;
        //        Byte[] data = Memcpy.StructToBytes(Answer, _AnswerLen);

        //        if (this._nxCompolet1 != null)
        //            this._nxCompolet1.WriteRawData(CCDtoPLC_answerTag, data);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogMgr.CipErrorLog(true, "心跳信号发送失败： " + ex.Message);
        //        //Console.WriteLine("SetCCD_PLC Fail" + ex.Message);
        //    }
        //}

        //public int GetCodeState()
        //{
        //    lock (_lockSend)
        //    {
        //        try
        //        {
        //            object data = this._nxCompolet1.ReadVariable(CodeAndPhotoCompleteStatus);
        //            return (int)data;
        //        }
        //        catch(Exception ex)
        //        {
        //            LogMgr.CipErrorLog(true, "获取拍照扫码状态失败： " + ex.Message);
        //            return 0;
        //        }
        //    }
        //}
        //public void SetCodeState(string ID_Tag, object status)
        //{
        //    lock (_lockSend)
        //    {
        //        try
        //        {
        //            if (this._nxCompolet1 != null)
        //                this._nxCompolet1.WriteVariable(ID_Tag, status);
        //        }
        //        catch (Exception ex)
        //        {
        //            LogMgr.CipErrorLog(true, "拍照扫码状态置0失败： " + ex.Message);
        //        }

        //    }
        //}

        //public void SetVirtual_ElectCellID(string ID)
        //{
        //    try
        //    {
        //        byte[] data = System.Text.Encoding.UTF8.GetBytes(ID);
        //        if (this._nxCompolet1 != null)
        //            this._nxCompolet1.WriteRawData(Virtual_ElectCellID, data);
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}

        //public string GetVirtual_ElectCellID(string ID_Tag = Virtual_ElectCellIDTemp)
        //{
        //    try
        //    {
        //        byte[] data = this._nxCompolet1.ReadRawData(ID_Tag);
        //        string ID = System.Text.Encoding.Default.GetString(data);
        //        return ID;
        //    }
        //    catch(Exception ex)
        //    {
        //        return null;
        //    }
        //}

        //public string GetElectCellID(string ID_Tag = ElectCellID)
        //{
        //    try
        //    {
        //        byte[] data = this._nxCompolet1.ReadRawData(ID_Tag);
        //        string ID = System.Text.Encoding.Default.GetString(data);
        //        return ID;
        //    }
        //    catch(Exception ex)
        //    {
        //        return null;
        //    }
        //}

        public bool Connect(string ipPLC, int portPLC, bool enableRecvThread)
        {
            
            _nxCompolet1.PeerAddress = ipPLC;
            _nxCompolet1.LocalPort = portPLC;
            _nxCompolet1.ConnectionType = ConnectionType.UCMM;
            _nxCompolet1.ReceiveTimeLimit = 750;
            _nxCompolet1.Active = true;

            //this._nxCompolet1.Active = true;
            if (this._nxCompolet1.IsConnected)
            {
                Connected = true;
              
                if (enableRecvThread)
                {
                    startRecvThread();
                }
                return true;
            }
            return false;
        }

        /*关闭连接*/
        public void Close()
        {
            _recvLoop = false;      //关闭线程   
        }

        public bool Connected { get; private set; } = false;

        #endregion

        //启动接收线程
        private void startRecvThread()
        {
            if (false == _recvLoop)
            {
                _recvLoop = true;
                _recvThread = new Thread(new ThreadStart(tcpRecvThread));
                _recvThread.Start();
            }
        }

        public void StopRecvThread()
        {
            _recvLoop = false;
        }

        private void tcpRecvThread()
        {
            int count = 0;
            bool flag = false;
            while (_recvLoop)
            {
                count++;
                if (_recvLoop == false)
                {
                    Close();
                    Connected = false;
                    return;
                }

                try
                {
                   
                    byte[] Bytes = GetReadBytes(AutoMcahineTo_AOI);
                    AutoMcahineToAOI_Data = (st_AutoMcahine_AOI)Memcpy.ByteToStruct(Bytes, typeof(st_AutoMcahine_AOI));
                   
                   
                    if (AutoMcahineToAOI_Data.CameraTrig == 1)
                    {
                      
                        if (Trig_Callback != null)
                        {
                            Trig_Callback(new CIPRecvInfoArgs(AutoMcahineToAOI_Data));
                            
                            AutoMcahineToAOI_Data.CameraTrig = 1;
                            
                            Byte[] data = Memcpy.StructToBytes(AutoMcahineToAOI_Data, AutoMcahineToAOI_DataLen);
                            
                            Write_data(AutoMcahineTo_AOI, data);
                        }
                    }
                   
                    if (count > 80)
                    {
                        count = 0;
                        if(!flag)
                        {
                            flag = true;
                            Bytes = GetReadBytes(AOITo_AutoMcahine);
                            AOIToAutoMcahine_Data = (st_AOI_AutoMcahine)Memcpy.ByteToStruct(Bytes, typeof(st_AOI_AutoMcahine));
                            AOIToAutoMcahine_Data.Heartbeat = 0;
                            Byte[] data = Memcpy.StructToBytes(AOIToAutoMcahine_Data, AOIToAutoMcahine_DataLen);
                            lock (_lockSend)
                            {
                                this._nxCompolet1.WriteRawData(AOITo_AutoMcahine, data);
                            }
                        }
                        else
                        {
                            flag = false;
                            Bytes = GetReadBytes(AOITo_AutoMcahine);
                            AOIToAutoMcahine_Data = (st_AOI_AutoMcahine)Memcpy.ByteToStruct(Bytes, typeof(st_AOI_AutoMcahine));
                            AOIToAutoMcahine_Data.Heartbeat = 1;
                            Byte[] data = Memcpy.StructToBytes(AOIToAutoMcahine_Data, AOIToAutoMcahine_DataLen);
                            lock (_lockSend)
                            {
                                this._nxCompolet1.WriteRawData(AOITo_AutoMcahine, data);
                            }
                        }

                        
                        
                    }
                    
                    Thread.Sleep(10);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ReciveDate Fail" + ex.Message);
                }
            }
        }

        private void Write_data(string label,byte[] data)
        {
            lock (_lockSend)
            {
                this._nxCompolet1.WriteRawData(label, data);
            }
        }

      
        private byte[] GetReadBytes(string lable)
        {
            lock (_lockSend)
            {
                return this._nxCompolet1.ReadRawData(lable);
            }
        }

       

    }
    public class CIPRecvInfoArgs : EventArgs
    {
      
        public Int16 TrigFlag;
        

        public CIPRecvInfoArgs(st_AutoMcahine_AOI recvMsg)
        {
            TrigFlag = recvMsg.CameraTrig;
           
        }

        
    }


}

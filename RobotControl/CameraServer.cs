using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SimpleTCP;

namespace RobotControl
{
    /// <summary>
    /// 用于与视觉上位机通讯及命令解析，上报error
    /// </summary>
    public class CameraServer
    {
        string _IP;
        int _port;
        SimpleTcpClient client = new SimpleTcpClient();
        //callback function
        public EventHandler<Message> CallBackFcn;
        Thread _th_heart_beat;// =new Thread ( new ThreadStart (HeatBeatDetection));
        bool IsConnected = false;

        public CameraServer(string IP, int port)
        {
            _IP = IP;
            _port = port;
            client.DataReceived += Client_DataReceived;
            _th_heart_beat  = new Thread(new ThreadStart(HeatBeatDetection));
            _th_heart_beat.IsBackground = false;
        }
        public bool Connect2Server()
        {
           if (null!= client.Connect(_IP, _port))
           {
                IsConnected = true;
                _th_heart_beat.Start();
                return true;
           }
           return false;
        }
        public void Send2Sever(string data)
        {
            client.Write(data);
        }
        public void Send2Sever(byte[] data)
        {
            client.Write(data);
        }
        private void Client_DataReceived(object sender, Message e)
        {
            //throw new NotImplementedException();
            CallBackFcn?.Invoke(this, e);//
        }
        private void HeatBeatDetection()
        {
            while(true)
            {
                try
                {
                    if(IsConnected)
                    {
                        client.Write("");
                        Thread.Sleep(10 * 1000);
                    }
                    else
                    {
                        client.Connect(_IP, _port);
                        IsConnected = true;
                        Thread.Sleep(1 * 1000);
                    }
                }
                catch(Exception)
                {
                    IsConnected = false;
                    client.Disconnect();
                }
            }
        }
        ~CameraServer()
        {
            client.Disconnect();
            if(null!= _th_heart_beat)
            {
                _th_heart_beat.Abort();
            }
        }






        //private void OnReceive(Message arg)
        //{
        //    CallBackFcn?.Invoke(this, arg);
        //}
    }
    //public enum HandleMethod
    //{
    //    Inhale,
    //    Take
    //}
    //public class MotionPrmEvt: EventArgs
    //{
    //    public Point position;
    //    public HandleMethod hm;
    //}
    
}

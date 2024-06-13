using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControl
{
    public enum PLCStatus
    {
        Running,
        Pause,
        Stop
    }
    /// <summary>
    /// 用于获取PLC的状态
    /// </summary>
    public class PLCInfo
    {

        public PLCInfo()
        {

        }
        ~PLCInfo()
        {

        }

        //要实现的接口
        public PLCStatus CurrentStatus()
        {
            return PLCStatus.Running;
        }
    }
}

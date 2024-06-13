
using RobotControl;
using System.Drawing;

namespace Models
{

    public class Packet
    {
        /// <summary>
        /// 封包类型
        /// </summary>
        public PacketType Type { get; set; }

        /// <summary>
        /// 发送给客户端执行机械臂的指令
        /// </summary>
        public RobotCommand Commd{get; set;}

        /// <summary>
        /// 要取的东西的位置坐标信息，用于上位机给客户端发送
        /// </summary>
        public PointXYZF Posi { get; set; }

        /// <summary>
        /// 机械臂的运动状态,用于机械臂给视觉上位机反馈
        /// </summary>
        public RobotSts Status { get;  set; }

        /// <summary>
        /// 额外的信息,可以用于机械臂上位机给视觉上位机反馈报错等信息
        /// </summary>
        public string Info { get; set; }
    }
    /// <summary>
    /// 封包类型
    /// </summary>
    public enum PacketType:uint
    {
        /// <summary>
        /// 执行运动指令
        /// </summary>
        Exec = 1,

        /// <summary>
        /// 交互信息
        /// </summary>
        Info = 2
    }
    /// <summary>
    /// 发送给机械臂运行指令的类型
    /// </summary>
    public enum RobotCommand:uint
    {
        Stop = 1,  //机械臂停止运动
        Pause = 2, //暂停
        Take = 3   //机械臂取东西
    }
    /// <summary>
    /// 机械臂忙碌状态
    /// </summary>
    public enum RobotSts:uint 
    {
        Running = 1,
        Idle = 0
    }

}

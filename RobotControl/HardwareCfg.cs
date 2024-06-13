using RobotControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOI_FragmentCheck
{
    public class HardwareCfg
    {
        /// <summary>
        /// 轴参数
        /// </summary>
        public AxisParam[] AxisArr = new AxisParam[6]
        {
                new AxisParam(),
                new AxisParam(),
                new AxisParam(),
                new AxisParam(),
                new AxisParam(),
                new AxisParam()
        };

        /// <summary>
        /// 待机点，保存后用于运动到待机点
        /// </summary>
        public PointXYZF PIdle =new PointXYZF();
        /// <summary>
        /// 初始点，保存后用于运动到待机点
        /// </summary>
        public PointXYZF PInit =new PointXYZF();

        /// <summary>
        /// IO口
        /// </summary>
        public IO myIO=new IO();


        /// <summary>
        /// End of Arm Tooling机械手末端工具参数修改
        /// </summary>
        public EOAT myEOAT=new EOAT();

        /// <summary>
        /// 运动控制算法参数
        /// </summary>


        public string PLCAddress { get; set; }

        public int PLCPort { get; set; }

        public string TCP_IP { get; set; }
        public int TCP_Port { get; set; }

        public MotionControl myMotionControl = new MotionControl();






        public static HardwareCfg Read(string xmlPath)
        {
            try
            {
                HardwareCfg cfg = (HardwareCfg)XmlHelper.Deserialize(typeof(HardwareCfg), xmlPath);
                return cfg;
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to read " + xmlPath + ". \r\n Error message :" + ex.Message);
            }
        }

        public static void Write(HardwareCfg cfg, string xmlPath)
        {
            try
            {
                XmlHelper.Serialize<HardwareCfg>(cfg, xmlPath);
            }
            catch (Exception ex)
            {
                throw new Exception("Fail to write " + xmlPath + ". \r\n Error message :" + ex.Message);
            }
        }
    }
    /// <summary>
    /// 轴参数
    /// </summary>
    public class AxisParam
    {
        //public AxisParam(int n)
        //{
        //    Num = n;
        //}
        //public AxisParam()
        //{

        //}
        /// <summary>
        /// 轴号
        /// </summary>
        public int Num{ get; set; }
        /// <summary>
        /// 脉冲当量
        /// </summary>
        public float Units{ get; set; }
        /// <summary>
        /// 速度
        /// </summary>
        public float Speed{ get; set; }
        /// <summary>
        /// 正向加速度
        /// </summary>
        public float Accel{ get; set; }
        /// <summary>
        /// 反向加速度
        /// </summary>
        public float Decel{ get; set; }
        /// <summary>
        /// 正限位
        /// </summary>
        public float FsLimit{ get; set; }
        /// <summary>
        /// 负限位
        /// </summary>
        public float RsLimit{ get; set; }
        /// <summary>
        /// 初始化位置
        /// </summary>
        public float Init{ get; set; }
        /// <summary>
        /// 轴状态
        /// </summary>
        public int Type{ get; set; }

    }
    /// <summary>
    /// IO 口
    /// </summary>
    public class IO
    {
        /// <summary>
        /// 吸盘IO口
        /// </summary>
        public int Suctioncup { get; set; }
        /// <summary>
        /// 吹嘴IO口
        /// </summary>
        public int Bolwtorch { get; set; }
        /// <summary>
        /// 急停IO口
        /// </summary>
        public int emstop { get; set; }
    }
    /// <summary>
    /// End of Arm Tooling机械手末端工具参数修改
    /// </summary>
    public class EOAT
    {
        /// <summary>
        /// 吸盘相对于最后一个电机偏移量
        /// </summary>
        public PointXYZF SuctioncupDeflection =new PointXYZF();
        /// <summary>
        /// 吹嘴相对于最后一个电机偏移量
        /// </summary>
        public PointXYZF BolwtorchDeflection = new PointXYZF();
        /// <summary>
        /// 希望吸盘底面到产线间的距离
        /// </summary>
        public float mode1_height { get; set; }
        /// <summary>
        ///  希望吹嘴底面到产线间的距离
        /// </summary>
        public float mode2_height { get; set; }
        /// <summary>
        /// 升降自由度位于零点时吸盘底面到产线的距离
        /// </summary>
        public float axis5zero { get; set; }
        /// <summary>
        /// 定义产线所在z平面的高度
        /// </summary>
        public float Productionline_height { get; set; }

    }
    /// <summary>
    /// 运动控制算法参数
    /// </summary>
    public class MotionControl
    {
        /// <summary>
        /// 运动绝对位置偏移，在运动控制算法运动到坐标时减去偏移量
        /// </summary>
        public PointXYZF AbsDeflection = new PointXYZF();
        /// <summary>
        /// 工作空间X正限位
        /// </summary>
        public double workspaceXPlus { get; set; }
        /// <summary>
        /// 工作空间X负限位
        /// </summary>
        public double workspaceXMinus { get; set; }
        /// <summary>
        /// 工作空间Y正限位
        /// </summary>
        public double workspaceYPlus { get; set; }
        /// <summary>
        /// 工作空间Y负限位
        /// </summary>
        public double workspaceYMinus { get; set; }


    }

}

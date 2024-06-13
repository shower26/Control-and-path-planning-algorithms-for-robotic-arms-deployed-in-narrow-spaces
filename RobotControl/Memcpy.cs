using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace FinsCom
{
    //PLC根EL通信
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct FinsRecv
    {
        public byte TRG;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11)]
        public byte[] WaferID;
    }


    //[StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    //public struct TransOK
    //{
    //    public byte TOK;
    //    public byte CAMId;
    //}

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct FinsSend
    {
        public byte TOK;
        public byte Recv1;
        public byte RES;
        public byte Recv2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] Class;
        //public byte Reserved;
        //public Byte CamId;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] WaferID;
    }

  
  
   


    /// <summary>
    /// 卷绕设备触发数据
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct TrigFromCIP
    {
        /// <summary>
        /// 相机触发状态 0初始状态，1拍照
        /// </summary>
        public Int16 Trig;
        public Int16 CameraOk;//相机拍照完成信号
        public Int16 IsFragment;//是否有碎片
        public Int16 Heart;//心跳信号
    }

   

    /// <summary>
    /// 检测结果
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ResultToCIP
    {
        public void Init()
        {
            CamStatus = 1;
            OutToPositive = 0;
            OutToNegative = 0;
            ExPosToNegative = 0;
            InToRight = 0;
            InToNegative = 0;
            PosToNegative = 0;
            AT9 = 0;
            //ex_base2ZJ = 0;
            ex_base2FJ = 0;
            in_base2ZJ = 0;
            in_base2FJ = 0;

        }

        /// <summary>
        /// 相机状态 1拍照ok，-1为拍照NG       
        /// </summary>
        public double CamStatus;

        /// <summary>
        /// 外隔膜到正极
        /// </summary>
        public double OutToPositive;

        /// <summary>
        /// 外隔膜到负极
        /// </summary>
        public double OutToNegative;

        /// <summary>
        /// 外正极到负极
        /// </summary>
        public double ExPosToNegative;

        /// <summary>
        /// 内隔膜到正极
        /// </summary>
        public double InToRight;

        /// <summary>
        /// 内隔膜到负极
        /// </summary>
        public double InToNegative;

        /// <summary>
        /// 内正极到负极
        /// </summary>
        public double PosToNegative;

        /// <summary>
        /// AT9
        /// </summary>
        public double AT9;

        /// <summary>
        /// 备用
        /// </summary>
        //public double ex_base2ZJ;
        public double ex_base2FJ;
        public double in_base2ZJ;
        public double in_base2FJ;
    }
    /// <summary>
    /// 检测结果
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct MaterialResultToCIP //入料检测结果
    {
        public void Init()
        {
            OutWidth = 0;
            OutIsdiscount = 0;
            OutIsdiscount = 0;
            IntWidth = 0;
            IntIsdiscount = 0;
            IntIsCorner = 0;
        }

        /// <summary>
        /// 外侧宽度 overhang
        /// </summary>
        public double OutWidth;

        /// <summary>
        /// 外侧是否打折
        /// </summary>
        public double OutIsdiscount;

        /// <summary>
        /// 外侧是否有倒角
        /// </summary>
        public double OutIsCorner;

        /// <summary>
        /// 内侧宽度
        /// </summary>
        public double IntWidth;

        /// <summary>
        /// 内侧是否打折
        /// </summary>
        public double IntIsdiscount;

        /// <summary>
        /// 内侧是否有倒角
        /// </summary>
        public double IntIsCorner;

       
    }
    /// <summary>
    /// 检测结果
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ElectEarMeasureResultToCIP //极耳检测结果
    {
        public void Init()
        {
            WidthEar_Left = 0;
            WidthEar_Right = 0;
            GapEars = 0;
            EarNegativeToEdge = 0;
            EarPositiveToEdge = 0;
            EarNegativeInToEdge = 0;
            EarPositiveInToEdge = 0;
        }
        public double WidthEar_Left;//左极耳宽

        public double WidthEar_Right;//右极耳宽

        public double GapEars;//极耳间距

        public double EarNegativeToEdge;//负极极耳外侧到电芯边缘距离

        public double EarPositiveToEdge;//正极极耳外侧到电芯边缘距离

        public double EarNegativeInToEdge;//负极极耳外侧到电芯边缘距离

        public double EarPositiveInToEdge;//正极极耳外侧到电芯边缘距离
    }

    public struct JudgmentRangeToCIP
    {
        public void Init()
        {
            OutWidthMin = 0;
            OutWidthMax = 0;

            OutToPositiveMin = 0;
            OutToNegativeMin = 0;
            ExPosToNegativeMin = 0;
            InToRightMin = 0;
            InToNegativeMin = 0;
            PosToNegativeMin = 0;
            AT9Min = 0;
            OutToPositiveMax = 0;
            OutToNegativeMax = 0;
            ExPosToNegativeMax = 0;
            InToRightMax = 0;
            InToNegativeMax = 0;
            PosToNegativeMax = 0;
            AT9Max = 0;

            EarNegativeToEdgeMin = 0;
            EarPositiveToEdgeMin = 0;
            EarNegativeInToEdgeMin = 0;
            EarPositiveInToEdgeMin = 0;
            EarNegativeToEdgeMax = 0;
            EarPositiveToEdgeMax = 0;
            EarNegativeInToEdgeMax = 0;
            EarPositiveInToEdgeMax = 0;
        }
        /// <summary>
        /// 外隔膜到正极
        /// </summary>
        public double OutToPositiveMin;
        public double OutToPositiveMax;

        /// <summary>
        /// 外隔膜到负极
        /// </summary>
        public double OutToNegativeMin;
        public double OutToNegativeMax;

        /// <summary>
        /// 外正极到负极
        /// </summary>
        public double ExPosToNegativeMin;
        public double ExPosToNegativeMax;

        /// <summary>
        /// 内隔膜到正极
        /// </summary>
        public double InToRightMin;
        public double InToRightMax;

        /// <summary>
        /// 内隔膜到负极
        /// </summary>
        public double InToNegativeMin;
        public double InToNegativeMax;

        /// <summary>
        /// 内正极到负极
        /// </summary>
        public double PosToNegativeMin;
        public double PosToNegativeMax;

        /// <summary>
        /// AT9
        /// </summary>
        public double AT9Min;
        public double AT9Max;

        /// <summary>
        /// 外侧宽度 overhang
        /// </summary>
        public double OutWidthMin;
        public double OutWidthMax;

        /// <summary>
        /// 外侧是否有倒角
        /// </summary>
        public double OutIsCorner;

        public double EarNegativeToEdgeMin;//负极极耳外侧到电芯边缘距离
        public double EarNegativeToEdgeMax;//负极极耳外侧到电芯边缘距离

        public double EarPositiveToEdgeMin;//正极极耳外侧到电芯边缘距离
        public double EarPositiveToEdgeMax;//正极极耳外侧到电芯边缘距离

        public double EarNegativeInToEdgeMin;//负极极耳外侧到电芯边缘距离
        public double EarNegativeInToEdgeMax;//负极极耳外侧到电芯边缘距离

        public double EarPositiveInToEdgeMin;//正极极耳外侧到电芯边缘距离
        public double EarPositiveInToEdgeMax;//正极极耳外侧到电芯边缘距离
    }
    /// <summary>
    /// 相机状态
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CamStatusToCIP
    {
        //相机状态 1为可拍照，2繁忙，8拍照结果已发送， 4 故障
        public UInt16 Status;

        internal void Init()
        {
            Status = 1;
        }
    }

    ///上位机读设备信息结构体
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct st_AutoMcahine_AOI
    {
        public byte Heartbeat;
        public byte Shield;
        public byte LightTrig;
        public byte CameraTrig;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Reserve_Bool;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public int[] Reserve_Int;
        internal void Init()
        {
            Heartbeat = 0;
            Shield = 0;
            LightTrig = 0;
            CameraTrig = 0;
            Reserve_Bool = new byte[16];
            Reserve_Int = new int[16];
        }
    }

    ///设备读上位机信息结构体
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct st_AOI_AutoMcahine
    {
        public byte Heartbeat;
        public int ErrMesssge;
        public int StopAutoMachine;
        public int StartAutoMachine;
        public int Result;
        public byte PC_Ready;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] Reserve_Bool;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public int[] Reserve_Int;
        internal void Init()
        {
            Heartbeat = 0;
            ErrMesssge = 0;
            StopAutoMachine = 0;
            StartAutoMachine = 0;
            Result = 0;
            PC_Ready = 0;
            Reserve_Bool = new byte[16];
            Reserve_Int = new int[16];
        }
    }

    /// <summary>
    /// CCD应答信号
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CCDtoPLC_Answer
    {
        public int Answer;
        internal void Init()
        {
            Answer = 1;
        }
    }


    public class Memcpy
    {
        public static object ByteToStruct(byte[] bytes, Type type)
        {
            int size = Marshal.SizeOf(type);
            if (size > bytes.Length)
            {
                return null;
            }
            //分配结构体内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷贝到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return obj;
        }

        //将Byte转换为结构体类型
        public static byte[] StructToBytes(object structObj, int size)
        {
            byte[] bytes = new byte[size];
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷贝到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷贝到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            ///释放内存空间
            Marshal.FreeHGlobal(structPtr);
            return bytes;

        }
    }
}

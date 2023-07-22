using System.ComponentModel.DataAnnotations;
using FFXIVClientStructs.FFXIV.Client.System.String;
using Unknown = nint;

namespace FFXIVClientStructs.FFXIV.Client.Network;

[StructLayout(LayoutKind.Explicit, Size = 0xAF8)]
public unsafe partial struct NetworkModule
{
    //Filled from Config
    [FieldOffset(0x02C)] public int Unk02C;
    [FieldOffset(0x030)] public int Unk030;
    [FieldOffset(0x034)] public int Unk034;
    [FieldOffset(0x038)] public int Unk038;
    [FieldOffset(0x03C)] public int Unk03C;
    [FieldOffset(0x040)] public int Unk040;
    [FieldOffset(0x044)] public int Unk044;
    [FieldOffset(0x048)] public int Unk048;
    [FieldOffset(0x04C)] public int Unk04C;
    [FieldOffset(0x050)] public int Unk050;
    [FieldOffset(0x054)] public int Unk054;

    //Thesed all hold dns names to neolobbyxx.ffxiv.com coiming from the config
    [FixedSizeArray<Utf8String>(0xC)] [FieldOffset(0x060)]
    public fixed byte LobbyServerNames[0xC * 0x68];

    //0x10 bytes
    [FieldOffset(0x540)] public int Unk540;

    [FieldOffset(0x544)] public short Unk544;

    //These are all filled with information from config
    [FieldOffset(0x548)] public int Unk548; //ServerPort
    [FieldOffset(0x550)] public Utf8String UnkString550; //config-dl.ffxiv.com
    [FieldOffset(0x5B8)] public int Unk5B8;
    [FieldOffset(0x5BC)] public int Unk5BC; //ServerPort
    [FieldOffset(0x5C0)] public Utf8String UnkString5C0; //dctravel.ffxiv.com
    [FieldOffset(0x628)] public int Unk628; //ServerPort
    [FieldOffset(0x630)] public Utf8String UnkString630; //Related to 940 Seen: neolobby01.ffxiv.com
    [FieldOffset(0x698)] public int Unk698; //ServerPort
    [FieldOffset(0x6A0)] public Utf8String UnkString6A0; //Seen: neolobby03.ffxiv.com
    [FieldOffset(0x708)] public int Unk708;
    [FieldOffset(0x70C)] public int Unk70C;
    [FieldOffset(0x710)] public int Unk710;
    [FieldOffset(0x714)] public int Unk714;
    [FieldOffset(0x718)] public Utf8String UnkString718;
    [FieldOffset(0x780)] public Utf8String Protocol780; //Seen: TCP
    [FieldOffset(0x7E8)] public int Unk7E8; //Seen: 0
    [FieldOffset(0x7F0)] public Utf8String UnkString7F0; //Seen: "00000"
    [FieldOffset(0x858)] public Utf8String UnkString858;
    [FieldOffset(0x8C0)] public Utf8String UnkString8C0;
    [FieldOffset(0x928)] public byte Unk928;
    [FieldOffset(0x92C)] public int Unk92C;

    //This region seems to generally hold references to other objects
    [FieldOffset(0x930)] public Unk930Obj* Unk930; //seen in getting FC info
    [FieldOffset(0x938)] public void* Unk938; //Struct is similar to 930Obj
    [FieldOffset(0x940)] public Unk940Obj* Unk940;
    [FieldOffset(0x948)] public void* Unk948;
    [FieldOffset(0x950)] public void* Unk950;
    [FieldOffset(0x958)] public void* Unk958;
    [FieldOffset(0x960)] public byte Unk960; //Related to 940
    [FieldOffset(0x961)] public bool WinSockInitialized;
    [FieldOffset(0x968)] public NetworkModulePacketReceiverCallback* PacketReceiverCallback;
    [FieldOffset(0x970)] public void* Unk970;
    [FieldOffset(0x978)] public void* Unk978;

    [FieldOffset(0x980)] public int Unk980;

    //OVERLAP!!
    [FieldOffset(0x984)] public int Unk984; //State related to Unk940
    [FieldOffset(0x988)] public byte Unk988; //guessing bool

    [FieldOffset(0x990)] public TimeStruct Unk990;
    [FieldOffset(0x9A8)] public int Unk9A8;

    [FieldOffset(0x9D8)] public int Unk9D8; //Init = 30 (0x1e)
    [FieldOffset(0x9E0)] public TimeStruct Unk9E0;
    [FieldOffset(0x9F8)] public int Unk9F8; //Init = 60 (0x3C)
    [FieldOffset(0xA00)] public void* UnkA00;
    [FieldOffset(0xA08)] public int UnkA08;
    [FieldOffset(0xA0C)] public int UnkA0C; //Timestamp
    [FieldOffset(0xA10)] public void* UnkA10;
    [FieldOffset(0xA18)] public void* UnkA18;
    [FieldOffset(0xA20)] public TimeStruct UnkA20;
    [FieldOffset(0xA38)] public byte UnkA38;
    [FieldOffset(0xA40)] public TimeStruct UnkA40;
    [FieldOffset(0xA58)] public void* UnkA58;
    [FieldOffset(0xA60)] public void* UnkA60;
    [FieldOffset(0xA68)] public TimeStruct UnkA68;
    [FieldOffset(0xA80)] public void* UnkA80;
    [FieldOffset(0xA88)] public TimeStruct UnkA88;
    [FieldOffset(0xAA0)] public TimeStruct UnkAA0;
    [FieldOffset(0xAB8)] public int UnkAB8; //Init 0x42c80000
    [FieldOffset(0xABC)] public byte UnkABC;
    [FieldOffset(0xAC0)] public byte UnkAC0;
    [FieldOffset(0xAC4)] public int UnkAC4; //Init 0xFFFFFFFF
    [FieldOffset(0xAC8)] public int UnkAC8; //From Config
    [FieldOffset(0xACC)] public int UnkACC; //From Config
    [FieldOffset(0xAD0)] public int UnkAD0; //From Config
    [FieldOffset(0xAD4)] public int UnkAD4; //From Config
    [FieldOffset(0xAD8)] public TimeStruct UnkAD8;

    [FieldOffset(0xAF0)] public byte UnkAF0; //guessing bool

    //FUN_14157e450 is probably init
    //FUN_14157f880 proxies Unk930.FUN_1415858f0(...)

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct TimeStruct
    {
        [FieldOffset(0x00)] public int TimeStamp;
        [FieldOffset(0x08)] public ulong CpuMilliSeconds;
        [FieldOffset(0x10)] public ulong CpuNanoSeconds;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct Unk930Obj
    {
        [FieldOffset(0x00)] public Utf8String ServerIp;

        [FieldOffset(0x68)] public short Unk68;
        [FieldOffset(0x6C)] public int Unk6C;
        [FieldOffset(0x70)] public short Unk70;
        [FieldOffset(0x72)] public short Unk72;

        //Stays the same for eacch character
        //Neither ContentID nor LodestoneID
        [FieldOffset(0x78)] public StdVector<byte> Unk78;
        [FieldOffset(0x90)] public int Unk90;
        [FieldOffset(0x94)] public int Unk94;
        [FieldOffset(0x98)] public Unk98Obj* Unk098;

        //FUN_1415858f0 proxies Unk098.FUN_1415ea880(...)
        [StructLayout(LayoutKind.Explicit, Size = 0x118)]
        public partial struct Unk98Obj
        {
            [FieldOffset(0x00)] public void** vtbl;
            [FieldOffset(0x008)] public Unk008Obj* Unk008; //Some struct
            [FieldOffset(0x010)] public Unk010Obj* Unk010;
            [FieldOffset(0x040)] public Unknown* Unk040; //Looks like a self referenceing empty vector
            [FieldOffset(0x048)] public Unknown* Unk048;
            [FieldOffset(0x088)] public void* Unk088;
            [FieldOffset(0x090)] public void* Unk090; //Maybe a fucntion pointer

            //vtbl at 141c161e8
            [FieldOffset(0x098)] public void* Unk098; //Maybe a fucntion pointer

            //vtbl at 141c16280
            [FieldOffset(0x0C8)] public void* Unk0C8;

            [FieldOffset(0x108)] public uint Unk108;

            [FieldOffset(0x110)]
            public uint Unk110; //Very likely a state (4 seems special). Set based on Unk010Obj.UnkD8

            [FieldOffset(0x114)] public ushort Unk114;


            public struct Unk008Obj
            {
            }

            [StructLayout(LayoutKind.Explicit, Size = 0x270)]
            public struct Unk010Obj
            {
                [FieldOffset(0x000)] public void** vtbl;
                [FieldOffset(0x008)] public Unk008Obj2 Unk008;
                [FieldOffset(0x010)] public Unknown* Unk010; //Looks like a self referenceing empty vector
                [FieldOffset(0x030)] public uint PacketNumber1; //Counts up (packet #)?
                [FieldOffset(0x034)] public uint PacketNumber2; //counts up (packet #)?
                [FieldOffset(0x038)] public ulong Unk038; //Counts up and resets (.. since last ...)
                [FieldOffset(0x040)] public ulong Unk040; //Timestamp in ms

                [FieldOffset(0x048)]
                public ulong Unk048; //Seen values between 140 and 200 (changes each tick) (maybe ns since last ...)

                [FieldOffset(0x050)] public ulong Unk050; //Timestamp in ms
                [FieldOffset(0x080)] public void* Unk080; //CriticalSection
                [FieldOffset(0x0A8)] public void* Unk0A8; //CriticalSection
                [FieldOffset(0x0D8)] public int Unk0D8; //State
                [FieldOffset(0x0E0)] public Utf8String IpAddress;
                [FieldOffset(0x148)] public int ServerPort;
                [FieldOffset(0x150)] public Unknown Unk150;
                [FieldOffset(0x158)] public StdVector<byte> Unk158; //Holds character specific number
                [FieldOffset(0x170)] public Unknown Unk170;
                [FieldOffset(0x178)] public void* Unk178;

                [FieldOffset(0x190)] public void* Unk190; //CriticalSection
                [FieldOffset(0x200)] public void* Unk200; //CriticalSection

                [StructLayout(LayoutKind.Explicit)]
                public struct Unk008Obj2
                {
                    [FieldOffset(0x000)] public void** vtbl;
                }
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x7C8)]
    public struct Unk940Obj
    {
        //ctor FUN_141586030
        [FieldOffset(0x28)] public int Unk028;
        [FieldOffset(0x2C)] public short Unk02C;
        [FieldOffset(0x30)] public int Unk030;
        [FieldOffset(0x038)] public TimeStruct Unk038;
        [FieldOffset(0x050)] public int Unk050;
        [FieldOffset(0x070)] public Unk070Obj Unk070;
        [FieldOffset(0x0E0)] public short Unk0E0;
        [FieldOffset(0x0E8)] public Utf8String Unk0E8;
        [FieldOffset(0x150)] public Utf8String Unk150;
        [FieldOffset(0x1B8)] public fixed byte Unk1B8[0x50]; //MemSet to 0x0
        [FieldOffset(0x208)] public byte Unk208;
        [FieldOffset(0x210)] public Unknown Unk210;
        [FieldOffset(0x218)] public Unknown Unk218;
        [FieldOffset(0x220)] public short Unk220;
        [FieldOffset(0x222)] public byte Unk222;
        [FieldOffset(0x228)] public void* Unk228;
        [FieldOffset(0x230)] public Unknown Unk230;
        [FieldOffset(0x238)] public void* Unk238; //Same as 228
        [FieldOffset(0x240)] public Unknown Unk240;
        [FieldOffset(0x248)] public Unknown Unk248;
        [FieldOffset(0x250)] public Unknown Unk250;
        [FieldOffset(0x258)] public Unknown Unk258;
        [FieldOffset(0x260)] public Unk260Obj Unk260;
        [FieldOffset(0x278)] public Unknown Unk278;
        [FieldOffset(0x280)] public Unknown Unk280;
        [FieldOffset(0x288)] public Unknown Unk288;
        [FieldOffset(0x290)] public Unknown Unk290;
        [FieldOffset(0x298)] public Unknown Unk298;
        [FieldOffset(0x2A0)] public Unknown Unk2A0;
        [FieldOffset(0x2A8)] public Unk2A8Obj Unk2A8;
        [FieldOffset(0x2C8)] public Unk2C8Obj Unk2C8;
        [FieldOffset(0x328)] public Unk260Obj Unk328;
        [FieldOffset(0x240)] public Utf8String Unk340;
        [FieldOffset(0x3B0)] public Utf8String Unk3B0;
        [FieldOffset(0x418)] public Utf8String Unk418;
        [FieldOffset(0x480)] public Unknown Unk480;
        [FieldOffset(0x488)] public int Unk488; //Init to 30(0x1e)
        [FieldOffset(0x48C)] public int Unk48C; //Init to 30(0x1e)
        [FieldOffset(0x490)] public int Unk490; //Init to 30(0x1e)
        [FieldOffset(0x498)] public Unknown Unk498; //Copied from param_5
        [FieldOffset(0x4A0)] public Unknown Unk4A0;
        [FieldOffset(0x4A8)] public Unknown Unk4A8;
        [FieldOffset(0x4B0)] public Unknown Unk4B0;
        [FieldOffset(0x4B8)] public Unknown Unk4B8;
        [FieldOffset(0x4C0)] public Unknown Unk4C0;
        [FieldOffset(0x4C8)] public Unk070Obj Unk4C8; //Ip copied from param_2; short copied from param_3
        [FieldOffset(0x538)] public Unk538Obj* Unk538;
        [FieldOffset(0x540)] public int Unk540;
        [FieldOffset(0x548)] public Utf8String Unk548; //Copied from param_4
        [FieldOffset(0x5B0)] public Utf8String Unk5B0;
        [FieldOffset(0x618)] public Utf8String Unk618;
        [FieldOffset(0x680)] public Utf8String Unk680;
        [FieldOffset(0x6E8)] public short Unk6E8;
        [FieldOffset(0x6EC)] public Unknown Unk6EC;
        [FieldOffset(0x6F8)] public Utf8String Unk6F8;
        [FieldOffset(0x760)] public Utf8String Unk760;

        [StructLayout(LayoutKind.Explicit, Size = 0x70)]
        public struct Unk070Obj
        {
            [FieldOffset(0x00)] public Utf8String Unk00;
            [FieldOffset(0x68)] public short Unk068; //Init to 54999
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x130)]
        public struct Unk538Obj
        {
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct Unk260Obj
        {
            [FieldOffset(0x00)] public Unknown Unk00;
            [FieldOffset(0x08)] public Unknown Unk08;
            [FieldOffset(0x10)] public Unknown Unk10;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x20)]
        public struct Unk2A8Obj
        {
            [FieldOffset(0x00)] public Unknown Unk00;
            [FieldOffset(0x08)] public Unknown Unk08;
            [FieldOffset(0x10)] public Unknown Unk10;
            [FieldOffset(0x18)] public Unknown Unk18;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x5B)]
        public struct Unk2C8Obj
        {
        }
    }
}
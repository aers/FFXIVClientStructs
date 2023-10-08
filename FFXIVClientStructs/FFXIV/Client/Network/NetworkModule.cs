using System.ComponentModel.DataAnnotations;
using FFXIVClientStructs.FFXIV.Application.Network;
using FFXIVClientStructs.FFXIV.Client.System.String;
using Unknown = nint;

namespace FFXIVClientStructs.FFXIV.Client.Network;

[StructLayout(LayoutKind.Explicit, Size = 0xB60)]
public unsafe partial struct NetworkModule {
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

    [FieldOffset(0x540)] public Utf8String Unk540;

    [FieldOffset(0x5A8)] public int Unk5A8; //Set by FUN_14021be20, Os related
    [FieldOffset(0x5AC)] public int OperatingSystemTypeAndVersion; //Most likely this si an enum
    //These are all filled with information from config
    [FieldOffset(0x5B0)] public int Unk548; //ServerPort
    //4 bytes padding
    [FieldOffset(0x5B8)] public Utf8String ConfigServerName; //config-dl.ffxiv.com
    [FieldOffset(0x620)] public int Unk620; //0
    [FieldOffset(0x624)] public int ConfigServerPort; //ServerPort (443)
    [FieldOffset(0x628)] public Utf8String DcTravelServerName; //dctravel.ffxiv.com
    [FieldOffset(0x690)] public short DcTravelServerPort; //ServerPort 54994
    //6 bytes padding
    [FieldOffset(0x698)] public Utf8String UnkString698; //Related to 9A8 Seen: neolobby01.ffxiv.com
    [FieldOffset(0x700)] public short Unk700; //ServerPort 54992
    //6 bytes padding
    [FieldOffset(0x708)] public Utf8String UnkString708; //Seen: neolobby03.ffxiv.com
    [FieldOffset(0x770)] public int Unk770;
    [FieldOffset(0x774)] public int Unk774;
    [FieldOffset(0x778)] public int Unk778;
    [FieldOffset(0x77C)] public int Unk77C; //Sever Port 54992
    [FieldOffset(0x780)] public Utf8String UnkString780; //Empty
    [FieldOffset(0x7E8)] public Utf8String Protocol7E8; //Seen: TCP
    [FieldOffset(0x850)] public long Unk850; //Seen: 0
    [FieldOffset(0x858)] public Utf8String UnkString858; //Seen: "00000"
    [FieldOffset(0x8C0)] public Utf8String UnkString8C0; //Empty
    [FieldOffset(0x928)] public Utf8String UnkString928; //Empty
    [FieldOffset(0x990)] public long Unk990;
    //This region seems to generally hold references to other objects
    [FieldOffset(0x998)] public Unk930Obj* Unk998; //seen in getting FC info


    [FieldOffset(0x9A0)] public void* Unk9A0; //Struct is similar to 930Obj
    [FieldOffset(0x9A8)] public Unk940Obj* Unk9A8;
    [FieldOffset(0x9B0)] public void* Unk9B0;
    [FieldOffset(0x9B8)] public void* Unk9B8;
    [FieldOffset(0x9C0)] public Unk9C0Struct* Unk9C0; //Has vtbl
    [FieldOffset(0x9C8)] public byte Unk9C8; //Related to 940
    [FieldOffset(0x9C9)] public bool WinSockInitialized;
    [FieldOffset(0x9D0)] public NetworkModulePacketReceiverCallback* PacketReceiverCallback;
    [FieldOffset(0x9D8)] public void* Unk9D8;
    [FieldOffset(0x9E0)] public void* Unk9E0;

    [FieldOffset(0x9E8)] public int Unk9E8; //Compared to 4

    //OVERLAP!!
    [FieldOffset(0x9EC)] public int Unk9EC; //State related to Unk940
    [FieldOffset(0x9F0)] public byte Unk9F0; //guessing bool

    //TODO: Offsets (+0x68)

    [FieldOffset(0x9F8)] public TimeStruct Unk9F8;
    [FieldOffset(0xA10)] public int UnkA10;

    [FieldOffset(0xA40)] public int UnkA40; //Init = 30 (0x1e)
    [FieldOffset(0xA44)] public int UnkA44;
    [FieldOffset(0xA48)] public TimeStruct UnkA48;
    [FieldOffset(0xA60)] public int UnkA60; //Init = 60 (0x3C)
    [FieldOffset(0xA68)] public void* UnkA68;
    [FieldOffset(0xA70)] public int UnkA70;
    [FieldOffset(0xA74)] public int UnkA74; //Timestamp
    [FieldOffset(0xA78)] public void* UnkA78;
    [FieldOffset(0xA80)] public void* UnkA80;
    [FieldOffset(0xA88)] public TimeStruct UnkA88;
    [FieldOffset(0xAA0)] public byte UnkAA0;
    [FieldOffset(0xAA8)] public TimeStruct UnkAA8;

    [FieldOffset(0xAC0)] public void* UnkAC0;
    [FieldOffset(0xAC8)] public void* UnkAC8;
    [FieldOffset(0xAD0)] public TimeStruct UnkAD0;
    [FieldOffset(0xAE8)] public void* UnkAE8;
    [FieldOffset(0xAF0)] public TimeStruct UnkAF0;
    [FieldOffset(0xB08)] public TimeStruct UnkB08;
    [FieldOffset(0xB20)] public int UnkB20; //Init 0x42c80000
    [FieldOffset(0xB24)] public byte UnkB24;
    [FieldOffset(0xB28)] public byte UnkB28;
    [FieldOffset(0xB2C)] public int UnkB2C; //Init 0xFFFFFFFF
    [FieldOffset(0xB30)] public int UnkB30; //From Config
    [FieldOffset(0xB34)] public int UnkB34; //From Config
    [FieldOffset(0xB38)] public int UnkB38; //From Config
    [FieldOffset(0xB3C)] public int UnkB3C; //From Config
    [FieldOffset(0xB40)] public TimeStruct UnkB40;

    [FieldOffset(0xB58)] public byte UnkB58; //guessing bool


    //FUN_14021c0b0

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct Unk9C0Struct {
        [FieldOffset(0x0)] public LobbyClient.LobbyRequestCallback LobbyRequestCallback;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct TimeStruct {
        [FieldOffset(0x00)] public int TimeStamp;
        [FieldOffset(0x08)] public ulong CpuMilliSeconds;
        [FieldOffset(0x10)] public ulong CpuNanoSeconds;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0xA0)]
    public partial struct Unk930Obj {
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
        public partial struct Unk98Obj {
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


            public struct Unk008Obj {
            }

            [StructLayout(LayoutKind.Explicit, Size = 0x270)]
            public struct Unk010Obj {
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
                public struct Unk008Obj2 {
                    [FieldOffset(0x000)] public void** vtbl;
                }
            }
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x7C8)]
    public struct Unk940Obj {
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
        public struct Unk070Obj {
            [FieldOffset(0x00)] public Utf8String Unk00;
            [FieldOffset(0x68)] public short Unk068; //Init to 54999
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x130)]
        public struct Unk538Obj {
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct Unk260Obj {
            [FieldOffset(0x00)] public Unknown Unk00;
            [FieldOffset(0x08)] public Unknown Unk08;
            [FieldOffset(0x10)] public Unknown Unk10;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x20)]
        public struct Unk2A8Obj {
            [FieldOffset(0x00)] public Unknown Unk00;
            [FieldOffset(0x08)] public Unknown Unk08;
            [FieldOffset(0x10)] public Unknown Unk10;
            [FieldOffset(0x18)] public Unknown Unk18;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x5B)]
        public struct Unk2C8Obj {
        }
    }
}

using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Configuration;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Common.Component.BGCollision;
using FFXIVClientStructs.FFXIV.Common.Lua;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Exd;
using FFXIVClientStructs.FFXIV.Client.Network;
using FFXIVClientStructs.FFXIV.Client.System.Timer;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework;
// Client::System::Framework::Framework

// size=0x35C8
// ctor E8 ?? ?? ?? ?? 48 8B C8 48 89 05 ?? ?? ?? ?? EB 0A 48 8B CE 
[StructLayout(LayoutKind.Explicit, Size = 0x35C8)]
public unsafe partial struct Framework {
    [FieldOffset(0x10)] public SystemConfig SystemConfig;
    [FieldOffset(0x460)] public DevConfig DevConfig;

    [FieldOffset(0x570)] public SavedAppearanceManager* SavedAppearanceData;

    [FieldOffset(0x1670)] public NetworkModuleProxy* NetworkModuleProxy;
    [FieldOffset(0x1678)] public bool IsNetworkModuleInitialized;
    [FieldOffset(0x1679)] public bool EnableNetworking;
    [FieldOffset(0x1680)] public uint ServerTime;
    //4bytes
    [FieldOffset(0x1688)] public long PerformanceCounterInMilliSeconds;
    [FieldOffset(0x1688)] public long PerformanceCounterInMicroSeconds;
    [FieldOffset(0x1698)] public uint TimerResolutionMillis;
    [FieldOffset(0x16A0)] public long PerformanceCounterFrequency;
    [FieldOffset(0x16A8)] public long PerformanceCounterValue;
    [FieldOffset(0x16F8)] public TaskManager TaskManager;
    [FieldOffset(0x16B8)] public float FrameDeltaTime;
    [FieldOffset(0x16C8)] public uint FrameCounter;
    [FieldOffset(0x1768)] public ClientTime ClientTime;
    [FieldOffset(0x1770)] public long EorzeaTime;
    [FieldOffset(0x1798)] public long EorzeaTimeOverride;
    [FieldOffset(0x17A0)] public bool IsEorzeaTimeOverridden;
    [FieldOffset(0x17C4)] public float FrameRate;
    [FieldOffset(0x17D0)] public bool WindowInactive;

    [FieldOffset(0x220C)] private fixed char userPath[260]; // WideChar Array

    [FieldOffset(0x2B30)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0x2B38)] public ExdModule* ExdModule;
    [FieldOffset(0x2B50)] public BGCollisionModule* BGCollisionModule;
    [FieldOffset(0x2B60)] public UIModule* UIModule;
    [FieldOffset(0x2B68)] public UIClipboard* UIClipboard;
    [FieldOffset(0x2BC8)] public LuaState LuaState;

    [FieldOffset(0x2BF0)] public GameVersion GameVersion;

    [StaticAddress("44 0F B6 C0 48 8B 0D ?? ?? ?? ??", 7, true)]
    public static partial Framework* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 80 7B 1D 01")]
    public partial UIModule* GetUiModule();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 44 24 ?? 48 8B C8 48 8B D3")]
    public partial UIClipboard* GetUIClipboard();

    [MemberFunction("80 B9 ?? ?? ?? ?? 00 74 ?? 48 8B 81 ?? ?? ?? ?? C3")]
    public partial NetworkModuleProxy* GetNetworkModuleProxy();

    [MemberFunction("E8 ?? ?? ?? ?? 89 47 2C")]
    public static partial long GetServerTime();

    public string UserPath {
        get {
            fixed (char* p = userPath) {
                return new string(p);
            }
        }
    }
}

using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Network;
using FFXIVClientStructs.FFXIV.Client.Sound;
using FFXIVClientStructs.FFXIV.Client.System.Configuration;
using FFXIVClientStructs.FFXIV.Client.System.File;
using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.System.Timer;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Common;
using FFXIVClientStructs.FFXIV.Common.Component.BGCollision;
using FFXIVClientStructs.FFXIV.Common.Lua;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Exd;
using FFXIVClientStructs.FFXIV.Component.SteamApi;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

// Client::System::Framework::Framework
// ctor "E8 ?? ?? ?? ?? 48 8B C8 48 89 05 ?? ?? ?? ?? EB 0A 48 8B CE"
[StructLayout(LayoutKind.Explicit, Size = 0x35C8)]
public unsafe partial struct Framework {
    [FieldOffset(0x0010)] public SystemConfig SystemConfig;
    [FieldOffset(0x0460)] public DevConfig DevConfig;
    [FieldOffset(0x0570)] public SavedAppearanceManager* SavedAppearanceData;
    [FieldOffset(0x0580)] public byte ClientLanguage;
    [FieldOffset(0x0581)] public byte Region;
    [FieldOffset(0x0588)] public Cursor* Cursor;
    [FieldOffset(0x0590)] public nint CallerWindow;
    [FieldOffset(0x0598)] public FileAccessPath ConfigPath;
    [FieldOffset(0x07A8)] public GameWindow* GameWindow;
    //584 byte
    [FieldOffset(0x09F8)] public int CursorPosX;
    [FieldOffset(0x09FC)] public int CursorPosY;

    [FieldOffset(0x1104)] public int CursorPosX2;
    [FieldOffset(0x1108)] public int CursorPosY2;

    [FieldOffset(0x1670)] public NetworkModuleProxy* NetworkModuleProxy;
    [FieldOffset(0x1678)] public bool IsNetworkModuleInitialized;
    [FieldOffset(0x1679)] public bool EnableNetworking;
    [FieldOffset(0x1680)] public TimePoint UtcTime;
    [Obsolete("Use UtcTime.Timestamp")][FieldOffset(0x1680)] public long ServerTime; // TODO: change to uint
    [Obsolete("Use UtcTime.CpuMilliSeconds")][FieldOffset(0x1688)] public long PerformanceCounterInMilliSeconds;
    [Obsolete("Use UtcTime.CpuMicroSeconds")][FieldOffset(0x1688)] public long PerformanceCounterInMicroSeconds;
    [FieldOffset(0x1698)] public uint TimerResolutionMillis;
    [FieldOffset(0x16A0)] public long PerformanceCounterFrequency;
    [FieldOffset(0x16A8)] public long PerformanceCounterValue;
    /// <summary>
    /// Frame time (in seconds) to use for calculating animations, tasks, game logic and such. This is not necessarily the real time since the last frame.
    /// </summary>
    [FieldOffset(0x16B8)] public float FrameDeltaTime;
    /// <summary>
    /// Holds the unaltered real time since last frame in seconds.
    /// </summary>
    [FieldOffset(0x16BC)] public float RealFrameDeltaTime;
    /// <summary>
    /// If set to anything non-zero, overrides <see cref="FrameDeltaTime"/>. Has lower precedence than <see cref="FrameDeltaTimeOverride2"/>.
    /// </summary>
    [FieldOffset(0x16C0)] public float FrameDeltaTimeOverride;
    /// <summary>
    /// If non-zero <see cref="FrameDeltaTime"/> is multiplied with this.
    /// </summary>
    [FieldOffset(0x16C4)] public float FrameDeltaFactor;
    [FieldOffset(0x16C8)] public uint FrameCounter;
    [FieldOffset(0x16F8)] public TaskManager TaskManager;
    [FieldOffset(0x1768)] public ClientTime ClientTime;
    [FieldOffset(0x1770)]
    [Obsolete("Use ClientTime.EorzeaTime")]
    public long EorzeaTime;
    [FieldOffset(0x1798)]
    [Obsolete("Use ClientTime.EorzeaTimeOverride")]
    public long EorzeaTimeOverride;
    [FieldOffset(0x17A0)]
    [Obsolete("Use ClientTime.IsEorzeaTimeOverridden")]
    public bool IsEorzeaTimeOverridden;
    [FieldOffset(0x17C4)] public float FrameRate;
    /// <summary>
    /// If true <see cref="FrameDeltaTime"/> is set to 0.
    /// </summary>
    [FieldOffset(0x17C8)] public bool DiscardFrame;
    /// <summary>
    /// If set to anything non-zero, overrides <see cref="FrameDeltaTime"/>. If negative <see cref="FrameDeltaTimeOverride"/> is used and 60fps as a fallback.
    /// </summary>
    [FieldOffset(0x17CC)] public float FrameDeltaTimeOverride2;
    [FieldOffset(0x17D0)] public bool WindowInactive;

    [FieldOffset(0x17E0)] public int DataPathType;

    [FieldOffset(0x19EC)] private fixed char gamePath[260]; // WideChar Array
    [FieldOffset(0x1DFC)] private fixed char sqPackPath[260]; // WideChar Array
    [FieldOffset(0x220C)] private fixed char userPath[260]; // WideChar Array

    [FieldOffset(0x2B30)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0x2B38)] public ExdModule* ExdModule;
    [FieldOffset(0x2B50)] public BGCollisionModule* BGCollisionModule;
    [FieldOffset(0x2B60)] public UIModule* UIModule;
    [FieldOffset(0x2B68)] public UIClipboard* UIClipboard;
    [FieldOffset(0x2B78)] public EnvironmentManager* EnvironmentManager;
    [FieldOffset(0x2B80)] public SoundManager* SoundManager;
    [FieldOffset(0x2BC8)] public LuaState LuaState;

    [FieldOffset(0x2BF0)] public GameVersion GameVersion;

    [FieldOffset(0x3500)] public bool UseWatchDogThread;

    [FieldOffset(0x3510)] public int FramesUntilDebugCheck;
    /// <summary>
    /// Set if <c>IsSteam</c> was set for this instance as part of <c>SetupSteamApi</c>. Set even if loading the Steam API
    /// fails for some reason.
    /// </summary>
    [FieldOffset(0x35B4)] public bool IsSteamGame;

    /// <summary>
    /// Access the Steam API wrapper/interface.
    /// </summary>
    /// <remarks>
    /// The struct backed by this API should not be considered stable. If you use this, you are signing up for API breakage.
    /// </remarks>
    [FieldOffset(0x35B8)] public SteamApi* SteamApi;

    /// <summary>
    /// Handle (type HMODULE) of steam_api64.dll
    /// </summary>
    [FieldOffset(0x35C0)] public nint SteamApiLibraryHandle;

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

    /// <summary>
    /// Checks if the Steam API has been initialized by checking whether the <see cref="SteamApi"/> pointer is valid,
    /// and whether the sub-struct reports itself as ready.
    /// </summary>
    /// <returns>Returns true if the API is ready, false otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 43 08 84 C0 74 16")]
    public partial bool IsSteamApiInitialized();

    public string GamePath {
        get {
            fixed (char* p = gamePath)
                return new string(p);
        }
    }
    public string SqPackPath {
        get {
            fixed (char* p = sqPackPath)
                return new string(p);
        }
    }
    public string UserPath {
        get {
            fixed (char* p = userPath)
                return new string(p);
        }
    }
}

using System.Runtime.CompilerServices;
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
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x35D0)]
public unsafe partial struct Framework {
    [StaticAddress("49 8B DC 48 89 1D ?? ?? ?? ??", 6, true)]
    public static partial Framework* Instance();

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
    [FieldOffset(0x09FC)] public int CursorPosX;
    [FieldOffset(0x0A00)] public int CursorPosY;

    [FieldOffset(0x110C)] public int CursorPosX2;
    [FieldOffset(0x1110)] public int CursorPosY2;

    [FieldOffset(0x1678)] public NetworkModuleProxy* NetworkModuleProxy;
    [FieldOffset(0x1680)] public bool IsNetworkModuleInitialized;
    [FieldOffset(0x1681)] public bool EnableNetworking;
    [FieldOffset(0x1688)] public TimePoint UtcTime;
    [FieldOffset(0x16A0)] public uint TimerResolutionMillis;
    [FieldOffset(0x16A8)] public long PerformanceCounterFrequency;
    [FieldOffset(0x16B0)] public long PerformanceCounterValue;
    /// <summary>
    /// Frame time (in seconds) to use for calculating animations, tasks, game logic and such. This is not necessarily the real time since the last frame.
    /// </summary>
    [FieldOffset(0x16C0)] public float FrameDeltaTime;
    /// <summary>
    /// Holds the unaltered real time since last frame in seconds.
    /// </summary>
    [FieldOffset(0x16C4)] public float RealFrameDeltaTime;
    /// <summary>
    /// If set to anything non-zero, overrides <see cref="FrameDeltaTime"/>. Has lower precedence than <see cref="NextFrameDeltaTimeOverride"/>.
    /// </summary>
    [FieldOffset(0x16C8)] public float FrameDeltaTimeOverride;
    /// <summary>
    /// If non-zero <see cref="FrameDeltaTime"/> is multiplied with this.
    /// </summary>
    [FieldOffset(0x16CC)] public float FrameDeltaFactor;
    [FieldOffset(0x16D0)] public uint FrameCounter;
    [FieldOffset(0x16D8)] public long FrameDeltaTimeMSInt; // FrameDeltaTime in milliseconds, rounded to integer
    [FieldOffset(0x16E0)] public float FrameDeltaTimeMSRem; // sub-millisecond difference between real and rounded dt, added to the next frame
    [FieldOffset(0x16E8)] public long FrameDeltaTimeUSInt; // FrameDeltaTime in microseconds, rounded to integer
    [FieldOffset(0x16F0)] public float FrameDeltaTimeUSRem; // sub-microsecond difference between real and rounded dt, added to the next frame
    [FieldOffset(0x1700)] public TaskManager TaskManager;
    [FieldOffset(0x1770)] public ClientTime ClientTime;
    [FieldOffset(0x17B8)] public float GameSpeedMultiplier; // usually 1, but during recording replay could be different
    [FieldOffset(0x17CC)] public float FrameRate;
    [FieldOffset(0x17D0)] public int PauseFrameTicksCounter; // if non-zero, FrameDeltaTime is forced to 0 during ticks; used while displaying message boxes
    /// <summary>
    /// If true <see cref="FrameDeltaTime"/> is set to 0.
    /// </summary>
    [FieldOffset(0x17D0), Obsolete("Use PauseFrameTicksCounter != 0")] public bool DiscardFrame;
    /// <summary>
    /// If set to anything non-zero, overrides <see cref="FrameDeltaTime"/>. If negative <see cref="FrameDeltaTimeOverride"/> is used and 60fps as a fallback.
    /// Unlike <see cref="FrameDeltaTimeOverride"/>, this applies only to the next frame, and is reset to zero on next tick.
    /// </summary>
    [FieldOffset(0x17D4)] public float NextFrameDeltaTimeOverride;
    [FieldOffset(0x17D8)] public bool WindowInactive;

    [FieldOffset(0x17E8)] public int DataPathType;

    [FieldOffset(0x19F4), FixedSizeArray(isString: true)] internal FixedSizeArray260<char> _gamePath;
    [FieldOffset(0x1E04), FixedSizeArray(isString: true)] internal FixedSizeArray260<char> _sqPackPath;
    [FieldOffset(0x2214), FixedSizeArray(isString: true)] internal FixedSizeArray260<char> _userPath;

    [FieldOffset(0x2B38)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0x2B40)] public ExdModule* ExdModule;
    [FieldOffset(0x2B58)] public BGCollisionModule* BGCollisionModule;
    [FieldOffset(0x2B68)] public UIModule* UIModule;
    [FieldOffset(0x2B70)] public UIClipboard* UIClipboard;
    [FieldOffset(0x2B80)] public EnvironmentManager* EnvironmentManager;
    [FieldOffset(0x2B88)] public SoundManager* SoundManager;
    [FieldOffset(0x2BD0)] public LuaState LuaState;

    [FieldOffset(0x2BF8), FixedSizeArray(isString: true)] internal FixedSizeArray256<byte> _gameVersion;
    // TODO: convert to array of 64 strings each 32 bytes long if possible
    [FieldOffset(0x2CF8 + 0 * 0x20), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _ex1Version; // Heavensward
    [FieldOffset(0x2CF8 + 1 * 0x20), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _ex2Version; // Stormblood
    [FieldOffset(0x2CF8 + 2 * 0x20), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _ex3Version; // Shadowbringers
    [FieldOffset(0x2CF8 + 3 * 0x20), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _ex4Version; // Endwalker
    [FieldOffset(0x2CF8 + 4 * 0x20), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _ex5Version; // Dawntrail

    [FieldOffset(0x3508)] public bool UseWatchDogThread;

    [FieldOffset(0x3518)] public int FramesUntilDebugCheck;
    /// <summary>
    /// Set if <c>IsSteam</c> was set for this instance as part of <c>SetupSteamApi</c>. Set even if loading the Steam API
    /// fails for some reason.
    /// </summary>
    [FieldOffset(0x35BC)] public bool IsSteamGame;

    /// <summary>
    /// Access the Steam API wrapper/interface.
    /// </summary>
    /// <remarks>
    /// The struct backed by this API should not be considered stable. If you use this, you are signing up for API breakage.
    /// </remarks>
    [FieldOffset(0x35C0)] public SteamApi* SteamApi;

    /// <summary>
    /// Handle (type HMODULE) of steam_api64.dll
    /// </summary>
    [FieldOffset(0x35C8)] public nint SteamApiLibraryHandle;

    [MemberFunction("E8 ?? ?? ?? ?? 80 7B 1D 01")]
    public partial UIModule* GetUIModule();

    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 44 24 ?? 48 8B C8 48 8B D3")]
    public partial UIClipboard* GetUIClipboard();

    [MemberFunction("80 B9 ?? ?? ?? ?? 00 74 ?? 48 8B 81 ?? ?? ?? ?? C3")]
    public partial NetworkModuleProxy* GetNetworkModuleProxy();

    [MemberFunction("E8 ?? ?? ?? ?? 03 07")]
    public static partial long GetServerTime();

    /// <summary>
    /// Checks if the Steam API has been initialized by checking whether the <see cref="SteamApi"/> pointer is valid,
    /// and whether the sub-struct reports itself as ready.
    /// </summary>
    /// <returns>Returns true if the API is ready, false otherwise.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 88 43 08 84 C0 74 16")]
    public partial bool IsSteamApiInitialized();
}

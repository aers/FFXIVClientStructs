using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::Control
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x76C0)]
public unsafe partial struct Control {
    [FieldOffset(0x00)] public CameraManager CameraManager;
    [FieldOffset(0x180)] public TargetSystem TargetSystem;

    [FieldOffset(0x7603)] public bool IsWalking;
    [FieldOffset(0x7668)] public uint LocalPlayerEntityId;
    [FieldOffset(0x7670)] public BattleChara* LocalPlayer;
    [FieldOffset(0x7680)] public Matrix4x4 ViewProjectionMatrix;

    public static bool CanFly => GetFlightAllowedStatus() == FlightAllowedStatus.CanFly;

    [StaticAddress("4C 8D 35 ?? ?? ?? ?? 48 8B 09", 3)]
    public static partial Control* Instance();

    [StaticAddress("48 8B 2D ?? ?? ?? ?? 75", 3, true)]
    public static partial BattleChara* GetLocalPlayer(); // g_Client::Game::Control::Control_LocalPlayer

    /// <summary>
    /// Checks if the player can take off at a given moment, i.e. player is mounted and has flight unlocked in the zone
    /// </summary>
    /// <returns>See <see cref="FlightAllowedStatus"/></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 85 C0 74 ?? 32 C0 48 83 C4 38")]
    public static partial FlightAllowedStatus GetFlightAllowedStatus();
    public enum FlightAllowedStatus : int {
        CanFly = 0,
        Unk1 = 1, // something with certain territories
        Unk2 = 2, // UIState.Instance() + 0x184C5 != 0
        NotMounted = 3,
        MountedButCannotFly = 4, // !(PlayerState.Instance() + 0x5D1)
        IncompleteMountFlyingConditionQuest = 5,
        DefaultCase = 7,
        PlayerOrMountNull = 8
    }
}

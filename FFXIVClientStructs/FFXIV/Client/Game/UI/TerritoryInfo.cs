namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

/// <summary>
/// Contains the PlaceName values of where the player is currently located.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct TerritoryInfo {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? BA ?? ?? ?? ?? F3 0F 5C 05", 3)]
    public static partial TerritoryInfo* Instance();
    
    [FieldOffset(0x08)] public float FlyingHeightMaxErrTimer;
    [FieldOffset(0x0C)] public float DismountTimer;
    [FieldOffset(0x10)] public float LalafellOnlyAreaTeleportTimer;
    /// <summary>For example, used for housing subdivisions.</summary>
    [FieldOffset(0x14)] public uint MapIdOverride;
    [FieldOffset(0x18)] public uint ChatLinkMapIdOverride;
    [FieldOffset(0x1C)] public bool InSanctuary; // MapRangeFlag1.RestBonusEffective
    [FieldOffset(0x1D)] public bool LiftEnabled; // MapRangeFlag2.LiftEnabled
    [FieldOffset(0x1E)] public bool FlyingDisabled; // MapRangeFlag2.FlyingDisabled
    [FieldOffset(0x1F)] public bool MountsAndOrnamentsDisabled; // MapRangeFlag3.MountsAndOrnamentsDisabled
    [FieldOffset(0x20)] public bool LalafellOnly; // MapRangeFlag3.LalafellOnly

    [FieldOffset(0x24)] public uint AreaPlaceNameId;
    [FieldOffset(0x28)] public uint SubAreaPlaceNameId;

    [MemberFunction("48 89 5C 24 ?? 56 48 83 EC 40 48 83 79 ?? ?? 8B F2")]
    public partial void LoadAreaVFXToLocalPlayer(uint areaVFX);
}

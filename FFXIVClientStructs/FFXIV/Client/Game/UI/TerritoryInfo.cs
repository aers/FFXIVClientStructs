namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

/// <summary>
/// Contains the PlaceName values of where the player is currently located.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct TerritoryInfo {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? BA ?? ?? ?? ?? F3 0F 5C 05", 3)]
    public static partial TerritoryInfo* Instance();

    [FieldOffset(0x1C)] public bool InSanctuary;

    [FieldOffset(0x24)] public uint AreaPlaceNameId;
    [FieldOffset(0x28)] public uint SubAreaPlaceNameId;
}

namespace FFXIVClientStructs.FFXIV.Component.SteamApi.Interface;

[StructLayout(LayoutKind.Explicit, Size = SteamTypes.SteamInterfaceContext.Size)]
public unsafe partial struct ISteamUtils {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? FF 15 ?? ?? ?? ?? 48 8B 08 48 8B 01 48 83 C4 28 48 FF A0 10 01 00 00", 3)]
    public static partial ISteamUtils* Instance();
    
    public static nint GetInterface() => Instance()->SteamInterfaceContext.GetInterface();
    
    [FieldOffset(0x0)] public SteamTypes.SteamInterfaceContext SteamInterfaceContext;
}

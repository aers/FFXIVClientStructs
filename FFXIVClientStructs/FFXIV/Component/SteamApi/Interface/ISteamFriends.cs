namespace FFXIVClientStructs.FFXIV.Component.SteamApi.Interface;

[StructLayout(LayoutKind.Explicit, Size = SteamTypes.SteamInterfaceContext.Size)]
public unsafe partial struct ISteamFriends {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 48 8B 10 48 89 93", 3)]
    public static partial ISteamFriends* Instance();
    
    public static nint GetInterface() => Instance()->SteamInterfaceContext.GetInterface();
    
    [FieldOffset(0x0)] public SteamTypes.SteamInterfaceContext SteamInterfaceContext;
}

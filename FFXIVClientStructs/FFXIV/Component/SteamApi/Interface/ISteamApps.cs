namespace FFXIVClientStructs.FFXIV.Component.SteamApi.Interface;

[StructLayout(LayoutKind.Explicit, Size = SteamTypes.SteamInterfaceContext.Size)]
public unsafe partial struct ISteamApps {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? FF 15 ?? ?? ?? ?? C7 44 24", 3)]
    public static partial ISteamApps* Instance();

    public static nint GetInterface() => Instance()->SteamInterfaceContext.GetInterface();
    
    [FieldOffset(0x0)] public SteamTypes.SteamInterfaceContext SteamInterfaceContext;
}

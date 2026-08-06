namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::ServerRequestCallbackManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct ServerRequestCallbackManager {
    [StaticAddress("48 83 3D ?? ?? ?? ?? 00 0F 85 ?? ?? ?? ?? 48 89 5C 24 ?? B9", 3, isPointer: true)]
    public static partial ServerRequestCallbackManager* Instance();

    [FieldOffset(0x00)] public StdVector<Pointer<ServerRequestCallbackInterface>> Callbacks;

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 48 8B CE E8 ?? ?? ?? ?? 83 F8")]
    public partial bool RequestSimple(ServerRequestCallbackInterface* callback, int commandId, int arg1, int arg2);

    /// <remarks> Falls back to RequestSimple when <c>argCount &lt;= 2</c>. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? EB ?? E8 ?? ?? ?? ?? 48 8D 88 ?? ?? ?? ?? E8 ?? ?? ?? ?? ?? ?? ?? 49 8B CF")]
    public partial bool Request(ServerRequestCallbackInterface* callback, int commandId, int* args, nuint argCount);

    [MemberFunction("48 8B 01 4D 8B D1 8B D2")]
    public partial void ProcessPacket(int callbackIndex, int commandId, void* payload, nuint payloadSize);
}

// Client::Game::ServerRequestCallbackInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ServerRequestCallbackInterface {
    [VirtualFunction(0)]
    public partial ServerRequestCallbackInterface* Dtor();

    [VirtualFunction(1)]
    public partial void OnReceivePacket(int commandId, void* payload, nuint payloadSize);
}

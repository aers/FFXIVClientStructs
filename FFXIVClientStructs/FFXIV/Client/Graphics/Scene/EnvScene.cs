using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::EnvScene
// Created by the LayoutEnvironment
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x8F0)]
public unsafe partial struct EnvScene {
    [FieldOffset(0x30), FixedSizeArray] internal FixedSizeArray32<byte> _weatherIds;

    [FieldOffset(0xF0), FixedSizeArray] internal FixedSizeArray8<EnvSpace> _envSpaces;

    [FieldOffset(0x880)] public EnvLocation** Locations; // array that can store 32 pointers
    [FieldOffset(0x888)] public uint LocationCount; // How many valid EnvLocation pointers in Locations
    [FieldOffset(0x8D0)] public Texture* CubemapArray;
    [FieldOffset(0x8D8)] public ConstantBuffer* ConstantBuffer; // constant buffer size: 0x10

    // Returns true but does nothing if the given location is already in this scene.
    [MemberFunction("4C 8B D1 48 85 D2 74 3F")]
    public partial bool AddLocation(EnvLocation* location);

    [MemberFunction("4C 8B D1 48 85 D2 74 25 44 8B 81")]
    public partial bool RemoveLocation(EnvLocation* location);
}

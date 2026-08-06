using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::CharacterLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//     Client::System::Common::NonCopyable
[GenerateInterop(isInherited: true)]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct CharacterLayoutInstance {
    [FieldOffset(0x30)] public Character* Character;
    [FieldOffset(0x38)] public QuantizedCharacterPosition QuantizedPosition;
    [FieldOffset(0x40)] public Transform Transform;
    [FieldOffset(0x70)] public uint BaseId;
    [FieldOffset(0x74)] public uint NameId;
    [FieldOffset(0x78)] private uint Unk78;

    [VirtualFunction(78)]
    public partial QuantizedCharacterPosition* GetQuantizedPosition();

    [VirtualFunction(79)]
    public partial uint GetBaseId();

    [VirtualFunction(80)]
    public partial uint GetNameId();

    [VirtualFunction(81)]
    public partial int GetObjectIndex();

    [VirtualFunction(82)]
    public partial Character* GetCharacter();
}

[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public struct QuantizedCharacterPosition {
    [FieldOffset(0x00)] public QuantizedVector3 Translation;
    [FieldOffset(0x06)] public ushort Rotation;
}

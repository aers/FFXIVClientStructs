using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

// Client::LayoutEngine::Layer::GameObjectLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//     Client::System::Common::NonCopyable
[GenerateInterop(isInherited: true)]
[Inherits<ILayoutInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public partial struct GameObjectLayoutInstance {
    /// <remarks> Which sheet this RowId is part of most likely depends on <see cref="ILayoutInstance.Identifier.Type"/>. </remarks>
    [FieldOffset(0x30)] public uint BaseId;
    [FieldOffset(0x34)] public uint BoundInstanceId;
    [FieldOffset(0x38)] private int ObjectIndex;

    [FieldOffset(0x40)] public Transform Transform;
    [FieldOffset(0x70)] public Vector3 Translation;
    [FieldOffset(0x80)] public Quaternion Rotation;
    [FieldOffset(0x90)] public Vector3 Scale;
}

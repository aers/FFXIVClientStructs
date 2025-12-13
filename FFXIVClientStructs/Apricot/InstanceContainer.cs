using FFXIVClientStructs.Apricot.Instance;

namespace FFXIVClientStructs.Apricot;

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public struct InstanceContainer {
	[FieldOffset(0)] public unsafe DocumentInstance* Instance;
}

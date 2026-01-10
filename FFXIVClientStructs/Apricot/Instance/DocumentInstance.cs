using FFXIVClientStructs.Apricot.Data;

namespace FFXIVClientStructs.Apricot.Instance;

[StructLayout(LayoutKind.Explicit, Size = 0x500)]
public struct DocumentInstance {
	[FieldOffset(0)] public unsafe nint* _vfTable;
	
	[FieldOffset(0x1D4)] public float LocalTime;
	[FieldOffset(0x1DC)] public float TimeScale;

	[FieldOffset(0x1F8)] public unsafe DocumentInstance* Root;
	[FieldOffset(0x200)] public unsafe DocumentInstance* Parent;
	[FieldOffset(0x208)] public unsafe Document* Document;
	[FieldOffset(0x210)] public unsafe DocumentInstance* Child;
	[FieldOffset(0x218)] public unsafe DocumentInstance* ChildLast;
	[FieldOffset(0x220)] public unsafe DocumentInstance* Sibling;
	
	[FieldOffset(0x49D)] public byte State;
}

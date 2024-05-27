using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

[StructLayout(LayoutKind.Explicit, Size = 0x260)]
[GenerateInterop]
[Inherits<ResourceHandle>]
public partial struct ModelResourceHandle {
    [FieldOffset(0x208)] public StdMap<Pointer<byte>, short> Attributes;
    [FieldOffset(0x228)] public StdMap<Pointer<byte>, short> Shapes;

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B CD 48 89 44 24")]
    public unsafe partial byte* GetMaterialFileNameBySlot(uint slot);

    public unsafe ReadOnlySpan<byte> GetMaterialFileNameBySlotAsSpan(uint slot)
        => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(GetMaterialFileNameBySlot(slot));

    public string GetMaterialFileNameBySlotAsString(uint slot)
        => Encoding.UTF8.GetString(GetMaterialFileNameBySlotAsSpan(slot));
}

using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

[StructLayout(LayoutKind.Explicit, Size = 0x260)]
public partial struct ModelResourceHandle {
    [FieldOffset(0x00)] public ResourceHandle ResourceHandle;

    [FieldOffset(0x208)] public StdMap<Pointer<byte>, short> Attributes;
    [FieldOffset(0x228)] public StdMap<Pointer<byte>, short> Shapes;

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B CD 48 89 44 24")]
    public readonly unsafe partial byte* GetMaterialFileNameBySlot(uint slot);

    public readonly unsafe ReadOnlySpan<byte> GetMaterialFileNameBySlotAsSpan(uint slot)
        => MemoryMarshal.CreateReadOnlySpanFromNullTerminated(GetMaterialFileNameBySlot(slot));

    public readonly string GetMaterialFileNameBySlotAsString(uint slot)
        => Encoding.UTF8.GetString(GetMaterialFileNameBySlotAsSpan(slot));
}

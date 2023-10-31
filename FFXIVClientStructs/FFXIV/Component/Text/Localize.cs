using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

// this belongs into a Component::Text::Localize namespace but that causes namespace issues in TextModule
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct Localize {
    [FieldOffset(0x08)] public void* ExcelModuleInterface;
    [FieldOffset(0x10)] public void* ExcelSheet;
    [FieldOffset(0x18)] public StdMap<Utf8String, nint> UnkMap;
}

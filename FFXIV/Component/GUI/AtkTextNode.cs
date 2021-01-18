using FFXIVClientStructs.FFXIV.Client.Graphics;
using FFXIVClientStructs.FFXIV.Client.System.String;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    public enum TextFlags
    {
        Unk = 0x01,
        Bold = 0x02,
        Italic = 0x04,
        Edge = 0x08,
        Glare = 0x10,
        Emboss = 0x20,
        WordWrap = 0x40,
        MultiLine = 0x80
    }

    public enum TextFlags2
    {
        Ellipsis = 0x04
    }

    // Component::GUI::AtkTextNode
    //   Component::GUI::AtkResNode
    //     Component::GUI::AtkEventTarget

    // simple text node

    // size = 0x158
    // common CreateAtkNode function E8 ? ? ? ? 48 8B 4E 08 49 8B D5 
    // type 3
    [StructLayout(LayoutKind.Explicit, Size = 0x158)]
    public unsafe struct AtkTextNode
    {
        [FieldOffset(0x0)] public AtkResNode AtkResNode;
        [FieldOffset(0xA8)] public uint TextId;
        [FieldOffset(0xAC)] public ByteColor TextColor;
        [FieldOffset(0xB0)] public ByteColor EdgeColor;
        [FieldOffset(0xB4)] public ByteColor BackgroundColor;
        [FieldOffset(0xB8)] public Utf8String NodeText;
        // if text is "asdf" and you selected "sd" this is 2, 3
        [FieldOffset(0x128)] public uint SelectStart;
        [FieldOffset(0x12C)] public uint SelectEnd;
        [FieldOffset(0x14A)] public byte LineSpacing;
        [FieldOffset(0x14B)] public byte CharSpacing;
        // alignment bits 0-3 font type bits 4-7
        [FieldOffset(0x14C)] public byte AlignmentFontType;
        [FieldOffset(0x14D)] public byte FontSize;
        [FieldOffset(0x14E)] public byte SheetType;
        [FieldOffset(0x152)] public byte TextFlags;
        [FieldOffset(0x153)] public byte TextFlags2;
    }
}

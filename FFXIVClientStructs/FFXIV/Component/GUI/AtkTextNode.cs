using System.Text;
using FFXIVClientStructs.FFXIV.Client.Graphics;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[Flags]
public enum TextFlags
{
    AutoAdjustNodeSize = 0x01,
    Bold = 0x02,
    Italic = 0x04,
    Edge = 0x08,
    Glare = 0x10,
    Emboss = 0x20,
    WordWrap = 0x40,
    MultiLine = 0x80
}

[Flags]
public enum TextFlags2
{
    Ellipsis = 0x04
}

public enum FontType : byte
{
    Axis = 0x0,
    MiedingerMed = 0x1,
    Miedinger = 0x2,
    TrumpGothic = 0x3,
    Jupiter = 0x4,
    JupiterLarge = 0x5,
}

// Component::GUI::AtkTextNode
//   Component::GUI::AtkResNode
//     Component::GUI::AtkEventTarget

// simple text node

// size = 0x158
// common CreateAtkNode function E8 ?? ?? ?? ?? 48 8B 4E 08 49 8B D5 
// type 3
[StructLayout(LayoutKind.Explicit, Size = 0x158)]
public unsafe partial struct AtkTextNode : ICreatable
{
    [FieldOffset(0x0)] public AtkResNode AtkResNode;
    [FieldOffset(0xA8)] public uint TextId;
    [FieldOffset(0xAC)] public ByteColor TextColor;
    [FieldOffset(0xB0)] public ByteColor EdgeColor;
    [FieldOffset(0xB4)] public ByteColor BackgroundColor;

    [FieldOffset(0xB8)] public Utf8String NodeText;

    [FieldOffset(0x128)] public void* UnkPtr_1;

    // if text is "asdf" and you selected "sd" this is 2, 3
    [FieldOffset(0x138)] public uint SelectStart;
    [FieldOffset(0x13C)] public uint SelectEnd;
    [FieldOffset(0x14A)] public byte LineSpacing;

    [FieldOffset(0x14B)] public byte CharSpacing;

    // alignment bits 0-3 font type bits 4-7
    [FieldOffset(0x14C)] public byte AlignmentFontType;
    [FieldOffset(0x14D)] public byte FontSize;
    [FieldOffset(0x14E)] public byte SheetType;
    [FieldOffset(0x150)] public ushort FontCacheHandle;
    [FieldOffset(0x152)] public byte TextFlags;
    [FieldOffset(0x153)] public byte TextFlags2;

    [MemberFunction(
        "E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B C8 48 83 C4 20 5B E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B C8 48 83 C4 20 5B E9 ?? ?? ?? ?? 45 33 C9 4C 8B C0 33 D2 B9 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 5D")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 8D 4E 32")]
    public partial void SetText(byte* str);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 4E 5A")]
    public partial void SetNumber(int num, bool showCommaDelimiters = false, bool showPlusSign = false, byte digits = 0,
        bool addZeroPadding = false);

    [MemberFunction("E8 ?? ?? ?? ?? 48 83 C4 28 5F 5D")]
    public partial void ResizeNodeForCurrentText();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 6D 08")]
    public partial void GetTextDrawSize(ushort* outWidth, ushort* outHeight, byte* text = null, int start = 0,
        int end = -1, bool considerScale = false);
    
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 0E 48 8B 9E")]
    public partial void SetAlignment(AlignmentType alignmentType);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 C0 B2 18")]
    public partial void SetFont(FontType fontType);
    
    public void SetText(Span<byte> span) {
        fixed (byte* ptr = span) SetText(ptr);
    }
    
    public void SetText(ReadOnlySpan<byte> span) {
        fixed (byte* ptr = span) SetText(ptr);
    }
    
    public void SetText(string str)
    {
        var bytes = Encoding.UTF8.GetBytes(str);
        SetText(bytes);
    }

    public void SetText(byte[] bytes)
    {
        var charPtr = Marshal.AllocHGlobal(bytes.Length + 1);
        Marshal.Copy(bytes, 0, charPtr, bytes.Length);
        Marshal.WriteByte(charPtr, bytes.Length, 0);
        SetText((byte*) charPtr.ToPointer());
        Marshal.FreeHGlobal(charPtr);
    }
}
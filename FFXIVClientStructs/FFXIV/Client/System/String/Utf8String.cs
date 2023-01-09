using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Client.System.String;
// Client::System::String::Utf8String

// size = 0x68
// ctor E8 ?? ?? ?? ?? 44 2B F7 
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct Utf8String : ICreatable
{
    [FieldOffset(0x0)] public byte* StringPtr; // pointer to null-terminated string
    [FieldOffset(0x8)] public long BufSize; // default buffer = 0x40
    [FieldOffset(0x10)] public long BufUsed;
    [FieldOffset(0x18)] public long StringLength; // string length not including null terminator
    [FieldOffset(0x20)] public byte IsEmpty;
    [FieldOffset(0x21)] public byte IsUsingInlineBuffer;
    [FieldOffset(0x22)] public fixed byte InlineBuffer[0x40]; // inline buffer used until strlen > 0x40

    public static Utf8String* FromString(string str)
    {
        return FromString(str, IMemorySpace.GetDefaultSpace());
    }

    public static Utf8String* FromString(string str, IMemorySpace* memorySpace)
    {
        var newString = memorySpace->Create<Utf8String>();

        var strBytes = Encoding.UTF8.GetBytes(str + '\0');
        fixed (byte* strPointer = strBytes)
        {
            newString->SetString(strPointer);
        }

        return newString;
    }

    public override string ToString()
    {
        if (StringPtr == null || BufUsed <= 1)
            return string.Empty;
        return Encoding.UTF8.GetString(StringPtr, (int) BufUsed - 1);
    }

    [MemberFunction("E8 ?? ?? ?? ?? 44 2B F7")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 49 83 6E")]
    public partial void Dtor();

    [MemberFunction("E8 ?? ?? ?? ?? 3B DF 7D")]
    public partial void SetString(byte* cStr);
}
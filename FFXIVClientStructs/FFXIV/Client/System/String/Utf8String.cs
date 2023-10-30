using System.Runtime.CompilerServices;
using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Client.System.String;
// Client::System::String::Utf8String

// size = 0x68
// ctor E8 ?? ?? ?? ?? 44 2B F7 
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct Utf8String : ICreatable, IDisposable {
    [FieldOffset(0x0)] public byte* StringPtr; // pointer to null-terminated string
    [FieldOffset(0x8)] public long BufSize; // default buffer = 0x40
    [FieldOffset(0x10)] public long BufUsed;
    [FieldOffset(0x18)] public long StringLength; // string length not including null terminator
    [FieldOffset(0x20)] public byte IsEmpty;
    [FieldOffset(0x21)] public byte IsUsingInlineBuffer;
    [FieldOffset(0x22)] public fixed byte InlineBuffer[0x40]; // inline buffer used until strlen > 0x40

    public ReadOnlySpan<byte> Span => new(StringPtr, Math.Max(0, (int)(BufUsed - 1)));

    public static Utf8String* CreateEmpty(IMemorySpace* memorySpace = null) {
        if (memorySpace == null) memorySpace = IMemorySpace.GetDefaultSpace();
        return memorySpace->Create<Utf8String>();
    }

    public static Utf8String* FromUtf8String(Utf8String* str) => FromUtf8String(str, IMemorySpace.GetDefaultSpace());
    public static Utf8String* FromUtf8String(Utf8String* str, IMemorySpace* memorySpace) {
        var newString = memorySpace->Create<Utf8String>();
        if (str != null)
            newString->Copy(str);
        return newString;
    }

    public static Utf8String* FromSequence(ReadOnlySpan<byte> str) => FromSequence((byte*)Unsafe.AsPointer(ref MemoryMarshal.GetReference(str)));
    public static Utf8String* FromSequence(byte* str) {
        var newString = IMemorySpace.GetDefaultSpace()->Create<Utf8String>();
        if (str != null)
            newString->SetString(str);
        return newString;
    }

    public static Utf8String* FromString(string str) => FromString(str, IMemorySpace.GetDefaultSpace());
    public static Utf8String* FromString(string str, IMemorySpace* memorySpace) {
        var newString = memorySpace->Create<Utf8String>();
        newString->SetString(str);
        return newString;
    }

    public override string ToString() {
        if (StringPtr == null || BufUsed <= 1)
            return string.Empty;
        return Encoding.UTF8.GetString(StringPtr, (int)BufUsed - 1);
    }

    public void Append(Utf8String* other) => Append((Utf8String*)Unsafe.AsPointer(ref this), other);
    public void Prepend(Utf8String* other) => Prepend((Utf8String*)Unsafe.AsPointer(ref this), other);

    public static void Append(Utf8String* str, Utf8String* value) {
        using var buffer = new Utf8String();
        var result = Concat(str, &buffer, value);
        str->Copy(result);
    }

    public static void Prepend(Utf8String* str, Utf8String* value) {
        using var buffer = new Utf8String();
        var result = Concat(value, &buffer, str);
        str->Copy(result);
    }

    public void Dtor(bool free) => Dispose(free);

    void IDisposable.Dispose() => Dispose(false);

    private void Dispose(bool free) {
        Dtor();
        if (free) IMemorySpace.Free((Utf8String*)Unsafe.AsPointer(ref this));
    }

    [MemberFunction("E8 ?? ?? ?? ?? 44 2B F7")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 49 83 6E")]
    public partial void Dtor();

    [MemberFunction("E8 ?? ?? ?? ?? EB 30 40 84 F6"), GenerateCStrOverloads]
    public partial void SetString(byte* cStr);

    [MemberFunction("E8 ?? ?? ?? ?? 48 3B DD")]
    public partial void Copy(Utf8String* other);

    [MemberFunction("E8 ?? ?? ?? ?? 85 ED 79")]
    public partial void Clear();

    [MemberFunction("E9 ?? ?? ?? ?? 48 2B D8")]
    public partial bool Equals(Utf8String* other);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 57 ?? 84 C0"), GenerateCStrOverloads]
    public partial bool EqualsString(byte* other);

    [MemberFunction("E8 ?? ?? ?? ?? 40 0F B6 C7 48 8D 35")]
    public static partial Utf8String* Concat(Utf8String* str, Utf8String* buffer, Utf8String* other);
}

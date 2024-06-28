using System.Runtime.CompilerServices;
using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.STD.Helper;

namespace FFXIVClientStructs.FFXIV.Client.System.String;

// Client::System::String::Utf8String
// ctor "E8 ?? ?? ?? ?? 44 2B F7"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct Utf8String : ICreatable, IDisposable, IStaticNativeObjectOperation<Utf8String> {
    [FieldOffset(0x0)] public byte* StringPtr; // pointer to null-terminated string
    [FieldOffset(0x8)] public long BufSize; // default buffer = 0x40
    /// <remarks>String length including null terminator.</remarks>
    [FieldOffset(0x10)] public long BufUsed;
    /// <remarks>String length not including null terminator.</remarks>
    [FieldOffset(0x18)] public long StringLength;
    [FieldOffset(0x20)] public bool IsEmpty;
    [FieldOffset(0x21)] public bool IsUsingInlineBuffer;
    [FieldOffset(0x22), FixedSizeArray] internal FixedSizeArray64<byte> _inlineBuffer; // inline buffer used until strlen > 0x40

    public static bool HasDefault => true;
    public static bool IsDisposable => true;
    public static bool IsCopyable => true;
    public static bool IsMovable => true;

    public readonly int Length => Math.Max(0, (int)(BufUsed - 1));

    public readonly ref readonly byte this[int index] => ref AsSpan()[index];

    public Utf8String() => Ctor();
    public Utf8String(byte* str) : this() => SetString(str);
    public Utf8String(string str) : this() => SetString(str);
    public Utf8String(ReadOnlySpan<byte> str) : this() => SetString(str);

    public readonly ReadOnlySpan<byte> AsSpan() => new(StringPtr, Length);

    public readonly ReadOnlySpan<byte> Slice(int start) => AsSpan().Slice(start);
    public readonly ReadOnlySpan<byte> Slice(int start, int length) => AsSpan().Slice(start, length);

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
        return AsSpan().IsEmpty ? string.Empty : Encoding.UTF8.GetString(AsSpan());
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

    public int ToInteger(int fromBase = 0) {
        return ToInteger((Utf8String*)Unsafe.AsPointer(ref this), fromBase);
    }

    [MemberFunction("E8 ?? ?? ?? ?? B2 E8")]
    public static partial int ToInteger(Utf8String* value, int fromBase = 0); // base 0 = detect format (0x hex, 0b bin, 0o oct)

    [MemberFunction("E8 ?? ?? ?? ?? 44 2B F7")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 48 83 6E ?? ?? 75 08")]
    public partial void Dtor();

    [MemberFunction("E8 ?? ?? ?? ?? EB 30 40 84 F6"), GenerateStringOverloads]
    public partial void SetString(byte* cStr);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 87 ?? ?? ?? ?? 48 83 EE 80")]
    public partial void Copy(Utf8String* other);

    [MemberFunction("E8 ?? ?? ?? ?? 85 ED 79")]
    public partial void Clear();

    [MemberFunction("E8 ?? ?? ?? ?? EB 17 45 85 E4")]
    public partial bool EqualTo(Utf8String* other);

    [MemberFunction("E8 ?? ?? ?? ?? EB 25 83 F9 03"), GenerateStringOverloads]
    public partial bool EqualToString(byte* other);

    [MemberFunction("45 33 C0 4C 8B C9 4C 39 41")]
    public partial Utf8String* ToLower();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B C8 EB A3")]
    public partial Utf8String* ToUpper(bool firstCharOnly = false, bool everyWord = false, bool normalizeVowels = false, byte* excludeWord = null);

    public Utf8String* ToTitleCase() => ToUpper(true, true);

    [MemberFunction("40 53 48 83 EC ?? B8 ?? ?? ?? ?? 48 8B DA 4C 3B C8")]
    public partial Utf8String* SubStr(nint destinationAdress, ulong start, ulong length);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 48 3B C3")]
    public partial Utf8String* CopySubStrTo(Utf8String* destination, int start, int length);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4D A7 E8 ?? ?? ?? ?? EB 18")]
    public partial Utf8String* Replace(Utf8String* toFind, Utf8String* replacement);

    [MemberFunction("E8 ?? ?? ?? ?? B9 ?? ?? ?? ?? 45 84 ED")]
    public partial int IndexOf(Utf8String* toFind, int startIdx = 0);

    [MemberFunction("44 88 4C 24 ?? 48 89 54 24 ?? 48 89 4C 24 ?? 53 41 54")]
    public partial int FindFirstOf(Utf8String* charsToFind, int startIdx, bool exclude = false);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 54 41 55 41 56 41 57 48 83 EC 20 48 8B F9 45 0F B6 E9")]
    public partial int FindLastOf(Utf8String* toFind, int startIdx, bool exclude = false);

    [MemberFunction("48 8B 01 0F B6 04")]
    public partial byte GetCharAt(ulong idx);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F B6 F0 E8 ?? ?? ?? ?? 48 8D 4D C0")]
    public partial void SanitizeString(ushort flags, Utf8String* characterList);

    public byte GetCharAt(int idx) => idx < 0 ? byte.MinValue : GetCharAt((ulong)idx);

    [MemberFunction("E8 ?? ?? ?? ?? 40 80 FF 03")]
    public static partial Utf8String* Concat(Utf8String* str, Utf8String* buffer, Utf8String* other);

    public static implicit operator ReadOnlySpan<byte>(in Utf8String value)
        => value.AsSpan();

    public static int Compare(in Utf8String left, in Utf8String right) => left.AsSpan().SequenceCompareTo(right.AsSpan());

    public static bool ContentEquals(in Utf8String left, in Utf8String right) => Unsafe.AsRef(in left).EqualTo((Utf8String*)Unsafe.AsPointer(ref Unsafe.AsRef(in right)));

    public static void ConstructDefaultInPlace(out Utf8String item) {
        item = default;
        item.Ctor();
    }

    public static void StaticDispose(ref Utf8String item) => item.Dtor();

    public static void ConstructCopyInPlace(in Utf8String source, out Utf8String target) {
        ConstructDefaultInPlace(out target);
        target.SetString(source);
    }

    public static void ConstructMoveInPlace(ref Utf8String source, out Utf8String target) {
        (target, source) = (source, default);
        if (target.IsUsingInlineBuffer)
            target.StringPtr = (byte*)Unsafe.AsPointer(ref target.InlineBuffer[0]);
    }

    public static void Swap(ref Utf8String item1, ref Utf8String item2) {
        (item1, item2) = (item2, item1);
        if (item1.IsUsingInlineBuffer)
            item1.StringPtr = (byte*)Unsafe.AsPointer(ref item1.InlineBuffer[0]);
        if (item2.IsUsingInlineBuffer)
            item2.StringPtr = (byte*)Unsafe.AsPointer(ref item2.InlineBuffer[0]);
    }
}

using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkArrayData>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct StringArrayData {
    [FieldOffset(0x28)] public byte** StringArray; // TODO: change this to CStringPointer*
    [FieldOffset(0x30)] public byte** ManagedStringArray;

    /// <summary>
    /// Set a value at the specified index of the StringArray.
    /// </summary>
    /// <param name="index"> The index in the array. </param>
    /// <param name="value">
    /// A pointer to a null terminated string.<br/>
    /// <b>Note:</b> When passing a C# string (made possible by the generator overload), make sure managed is set to <c>true</c>.
    /// </param>
    /// <param name="readBeforeWrite">
    /// If <c>true</c>, it compares the stored pointer with the passed pointer (not the text it points to) before setting it.<br/>
    /// If <c>false</c>, the stored pointer will always be replaced with the passed pointer.<br/><br/>
    /// In any way, it only has an effect if managed is <c>false</c>.
    /// </param>
    /// <param name="managed">
    /// Recommended to be set to <c>true</c> when using a temporary pointer.<br/>
    /// The game will allocate memory in the UI space and copy the text. The passed pointer can then be freed right after the SetValue call.<br/>
    /// Internally, the pointer to the allocated memory is (also) stored in ManagedStringArray to allow SetValue to reuse or reallocate the space as needed.
    /// </param>
    /// <param name="suppressUpdates">
    /// If <c>false</c> and the value was changed, <see cref="UpdateState"/> will be set to <c>1</c> to request an update on subscribed addons.
    /// </param>
    [MemberFunction("E8 ?? ?? ?? ?? 44 38 63 0E"), GenerateStringOverloads]
    public partial void SetValue(int index, CStringPointer value, bool readBeforeWrite = true, bool managed = true, bool suppressUpdates = false);

    /// <summary>
    /// Set a value at the specified index of the StringArray.
    /// </summary>
    /// <param name="index"> The index in the array. </param>
    /// <param name="value"> A pointer to an <see cref="Utf8String"/>. </param>
    /// <param name="readBeforeWrite">
    /// If <c>true</c>, it compares the stored pointer with the passed pointer (not the text it points to) before setting it.<br/>
    /// If <c>false</c>, the stored pointer will always be replaced with the passed pointer.<br/><br/>
    /// In any way, it only has an effect if managed is <c>false</c>.
    /// </param>
    /// <param name="managed">
    /// Recommended to be set to <c>true</c> when using a temporary pointer.<br/>
    /// The game will allocate memory in the UI space and copy the text. The passed pointer can then be freed right after the SetValue call.<br/>
    /// Internally, the pointer to the allocated memory is (also) stored in ManagedStringArray to allow SetValue to reuse or reallocate the space as needed.
    /// </param>
    /// <param name="suppressUpdates">
    /// If <c>false</c> and the value was changed, <see cref="UpdateState"/> will be set to <c>1</c> to request an update on subscribed addons.
    /// </param>
    [MemberFunction("E8 ?? ?? ?? ?? 40 84 FF 41 0F 95 C6")]
    public partial void SetValueUtf8(int index, Utf8String* value, bool readBeforeWrite = true, bool managed = true, bool suppressUpdates = false);

    /// <summary>
    /// Set a value at the specified index of the StringArray if it differs from the current value.
    /// </summary>
    /// <param name="index"> The index in the array. </param>
    /// <param name="value">
    /// A pointer to a null terminated string.<br/>
    /// This function must only be used when the value is unmanaged.
    /// </param>
    [MemberFunction("E8 ?? ?? ?? ?? 8D 56 5D")]
    public partial void SetValueIfDifferent(int index, byte* value);

    /// <summary>
    /// Set a value at the specified index of the StringArray if it differs from the current value.
    /// </summary>
    /// <param name="index"> The index in the array. </param>
    /// <param name="value"> A pointer to an <see cref="Utf8String"/>. </param>
    [MemberFunction("E8 ?? ?? ?? ?? FF C5 89 6C 24 70")]
    public partial void SetValueIfDifferentUtf8(int index, Utf8String* value);

    /// <summary>
    /// Force set a value at the specified index of the StringArray.
    /// </summary>
    /// <param name="index"> The index in the array. </param>
    /// <param name="value">
    /// A pointer to a null terminated string.<br/>
    /// <b>Note:</b> This function will not make a managed copy of the passed text. Only the pointer will be stored.
    /// </param>
    /// <param name="readBeforeWrite">
    /// If <c>true</c>, it compares the stored pointer with the passed pointer (not the text it points to) before setting it.<br/>
    /// If <c>false</c>, the stored pointer will always be replaced with the passed pointer, but <see cref="UpdateState"/> will still only be set to <c>1</c> when it was different.<br/>
    /// </param>
    [MemberFunction("3B 51 08 7D 29")]
    public partial void SetValueForced(int index, byte* value, bool readBeforeWrite = true);

    /// <summary>
    /// Force set a value at the specified index of the StringArray.
    /// </summary>
    /// <param name="index"> The index in the array. </param>
    /// <param name="value"> A pointer to an <see cref="Utf8String"/>. </param>
    /// <param name="readBeforeWrite">
    /// If <c>true</c>, it compares the stored pointer with the passed pointer (not the text it points to) before setting it.<br/>
    /// If <c>false</c>, the stored pointer will always be replaced with the passed pointer, but <see cref="UpdateState"/> will still only be set to <c>1</c> when it was different.<br/>
    /// </param>
    [MemberFunction("E8 ?? ?? ?? ?? 8B 44 24 50 8B 54 24 68")]
    public partial void SetValueForcedUtf8(int index, Utf8String* value, bool readBeforeWrite = true);

    /// <summary>
    /// Set a value at the specified index of the StringArray.
    /// </summary>
    /// <param name="index"> The index in the array. </param>
    /// <param name="value">
    /// A pointer to a null terminated string.<br/>
    /// <b>Note:</b> When passing a C# string (made possible by the generator overload), make sure managed is set to <c>true</c>.
    /// </param>
    /// <param name="readBeforeWrite">
    /// If <c>true</c>, it compares the stored pointer with the passed pointer (not the text it points to) before setting it.<br/>
    /// If <c>false</c>, the stored pointer will always be replaced with the passed pointer.<br/><br/>
    /// In any way, it only has an effect if managed is <c>false</c>.
    /// </param>
    /// <param name="managed">
    /// Recommended to be set to <c>true</c> when using a temporary pointer.<br/>
    /// The game will allocate memory in the UI space and copy the text. The passed pointer can then be freed right after the SetValue call.<br/>
    /// Internally, the pointer to the allocated memory is (also) stored in ManagedStringArray to allow SetValue to reuse or reallocate the space as needed.
    /// </param>
    /// <remarks>
    /// This calls <see cref="SetValue(int,CStringPointer,bool,bool,bool)"/> internally with suppressUpdates set to <c>false</c>.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 8D 56 5C"), GenerateStringOverloads]
    public partial void SetValueAndUpdate(int index, CStringPointer value, bool readBeforeWrite = true, bool managed = true);

    /// <summary>
    /// Set a value at the specified index of the StringArray.
    /// </summary>
    /// <param name="index"> The index in the array. </param>
    /// <param name="value"> A pointer to an <see cref="Utf8String"/>. </param>
    /// <param name="readBeforeWrite">
    /// If <c>true</c>, it compares the stored pointer with the passed pointer (not the text it points to) before setting it.<br/>
    /// If <c>false</c>, the stored pointer will always be replaced with the passed pointer.<br/><br/>
    /// In any way, it only has an effect if managed is <c>false</c>.
    /// </param>
    /// <param name="managed">
    /// Recommended to be set to <c>true</c> when using a temporary pointer.<br/>
    /// The game will allocate memory in the UI space and copy the text. The passed pointer can then be freed right after the SetValue call.<br/>
    /// Internally, the pointer to the allocated memory is (also) stored in ManagedStringArray to allow SetValue to reuse or reallocate the space as needed.
    /// </param>
    /// <remarks>
    /// This calls <see cref="SetValue(int,CStringPointer,bool,bool,bool)"/> internally with suppressUpdates set to <c>false</c>.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 45 8B A5 ?? ?? ?? ??")]
    public partial void SetValueAndUpdateUtf8(int index, Utf8String* value, bool readBeforeWrite = false, bool managed = true);
}

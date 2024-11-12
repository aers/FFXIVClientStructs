namespace FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[Inherits<AtkArrayData>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct StringArrayData {
    [FieldOffset(0x20)] public byte** StringArray;
    [FieldOffset(0x28)] public byte** ManagedStringArray;

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
    public partial void SetValue(int index, byte* value, bool readBeforeWrite = true, bool managed = true, bool suppressUpdates = false);

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
}

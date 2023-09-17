namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct NumberArrayData {
    [FieldOffset(0x0)] public AtkArrayData AtkArrayData;
    [FieldOffset(0x20)] public int* IntArray;

    /// <summary>Set a value at the specified index of the IntArray.</summary>
    /// <param name="index">The index in the array.</param>
    /// <param name="value">The integer value.</param>
    /// <param name="force">If <c>true</c> it bypasses the check if the value is different from what is stored (read before write).</param>
    /// <param name="silent">If <c>false</c> and the value was changed, UpdateState will be set to <c>1</c> to request an update on subscribed addons.</param>
    [MemberFunction("3B 51 08 7D 28")]
    public partial void SetValue(int index, int value, bool force, bool silent);

    public void SetValue(int index, int value) {
        SetValue(index, value, false, false);
    }
}

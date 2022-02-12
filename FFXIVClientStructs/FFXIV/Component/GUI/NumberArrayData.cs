namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct NumberArrayData
{
    [FieldOffset(0x0)] public AtkArrayData AtkArrayData;
    [FieldOffset(0x20)] public int* IntArray;

    public void SetValue(int index, int value)
    {
        if (index < AtkArrayData.Size)
            if (IntArray[index] != value)
            {
                IntArray[index] = value;
                AtkArrayData.HasModifiedData = 1;
            }
    }
}
namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size=0x18)]
public unsafe struct AtkLinkedList<T> where T : unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Node
    {
        public T Value;
        public Node* Next;
        public Node* Previous;
    }

    [FieldOffset(0x0)] public Node* End;
    [FieldOffset(0x8)] public Node* Start;
    [FieldOffset(0x10)] public uint Count;
}
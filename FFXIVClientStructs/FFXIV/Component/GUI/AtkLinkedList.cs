namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Sequential, Size=0x18)]
public unsafe struct AtkLinkedList<T> where T : unmanaged
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Node
    {
        public T Value;
        public Node* Next;
        public Node* Previous;
    }

    public Node* End;
    public Node* Start;
    public uint Count;
}
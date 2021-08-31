using System.Diagnostics;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.STD
{
    [StructLayout(LayoutKind.Sequential, Size = 0x10)]
    public unsafe struct StdMap<TKey, TValue>
        where TKey : unmanaged
        where TValue : unmanaged
    {
        public Node* Head;
        public ulong Count;

        public Node* SmallestValue
            => Head->Left;

        public Node* LargestValue
            => Head->Right;

        [StructLayout(LayoutKind.Sequential)]
        public struct Node
        {
            public Node*                 Left;
            public Node*                 Parent;
            public Node*                 Right;
            public byte                  Color;
            public bool                  IsNil;
            public byte                  _18;
            public byte                  _19;
            public StdPair<TKey, TValue> KeyValuePair;

            public Node* Next()
            {
                Debug.Assert(!IsNil, "Tried to increment a head node.");
                if (Right->IsNil)
                {
                    fixed (Node* thisPtr = &this)
                    {
                        var   ptr = thisPtr;
                        Node* node;
                        while (!(node = ptr->Parent)->IsNil && ptr == node->Right)
                            ptr = node;

                        return node;
                    }
                }

                var ret = Right;
                while (!ret->Left->IsNil)
                    ret = ret->Left;
                return ret;
            }

            public Node* Prev()
            {
                if (IsNil)
                    return Right;

                if (Left->IsNil)
                {
                    fixed (Node* thisPtr = &this)
                    {
                        var   ptr = thisPtr;
                        Node* node;
                        while (!(node = ptr->Parent)->IsNil && ptr == node->Left)
                            ptr = node;

                        return ptr->IsNil ? ptr : node;
                    }
                }

                var ret = Left;
                while (!ret->Right->IsNil)
                    ret = ret->Right;
                return ret;
            }
        }
    }
}

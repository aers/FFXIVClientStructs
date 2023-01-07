using System.Diagnostics;

namespace FFXIVClientStructs.STD; 

[StructLayout(LayoutKind.Sequential, Size = 0x10)]
public unsafe struct StdSet<TKey> where TKey : unmanaged {
	public Node* Head;
	public ulong Count;

	public Node* SmallestValue => Head->Left;
	public Node* LargestValue => Head->Right;

	public Enumerator GetEnumerator() => new(this);

	public ref struct Enumerator {
		private readonly Node* _head;
		private Node* _current;

		internal Enumerator(StdSet<TKey> set) {
			_head = _current = set.Head;
		}

		public bool MoveNext() {
			if (_current == null || _current == _head->Right)
				return false;
			_current = _current == _head ? _head->Left : _current->Next();
			return _current != null;
		}

		public ref readonly TKey Current => ref _current->Key;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct Node {
		public Node* Left;
		public Node* Parent;
		public Node* Right;
		public byte Color;
		public bool IsNil;
		public byte _18;
		public byte _19;
		public TKey Key;

		public Node* Next() {
			Debug.Assert(!IsNil, "Tried to increment a head node.");
			if (Right->IsNil) {
				fixed (Node* thisPtr = &this) {
					var ptr = thisPtr;
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

		public Node* Prev() {
			if (IsNil) return Right;

			if (Left->IsNil) {
				fixed (Node* thisPtr = &this) {
					var ptr = thisPtr;
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

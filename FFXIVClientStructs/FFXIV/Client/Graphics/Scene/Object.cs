using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Object
// base class for all graphics objects
// ctor inlined in all derived class ctors
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct Object {
    [FieldOffset(0x18)] public Object* ParentObject;
    [FieldOffset(0x20)] public Object* PreviousSiblingObject;
    [FieldOffset(0x28)] public Object* NextSiblingObject;
    [FieldOffset(0x30)] public Object* ChildObject; // for humans this is a weapon

    public SiblingEnumerator ChildObjects
        => new(ChildObject);

    [FieldOffset(0x50)] public Vector3 Position;
    [FieldOffset(0x60)] public Quaternion Rotation;
    [FieldOffset(0x70)] public Vector3 Scale;

    [VirtualFunction(0)]
    public partial void Dtor(DestroyMode mode);

    [VirtualFunction(1)]
    public partial void CleanupRender();
    
    [VirtualFunction(2)]
    public partial ObjectType GetObjectType();
    
    [VirtualFunction(4)]
    public partial void UpdateRender();

    public struct SiblingEnumerator {
        private Object* _first;
        private Object* _current;

        public Object* Current
            => _current;

        public SiblingEnumerator(Object* first) {
            _first = first;
            _current = null;
        }

        public bool MoveNext() {
            if (_current == null)
                _current = _first;
            else {
                _current = _current->NextSiblingObject;
                if (_current == _first)
                    _current = null;
            }

            return _current != null;
        }

        public SiblingEnumerator GetEnumerator()
            => this;
    }
}

public enum DestroyMode : byte
{
    /// <summary>
    /// Destroying the object doesn't automatically free its memory.
    /// </summary>
    /// <remarks>
    /// Use this if you created the object via a static Create helper and passed in an existing allocation.
    /// </remarks>
    None = 0,

    /// <summary>
    /// Frees the memory of this object from the graphics allocator while destroying it.
    /// </summary>
    /// <remarks>
    /// Use this if you created the object via a static Create helper and didn't pass in any existing allocation.
    /// </remarks>
    FreeMemory = (1 << 0),

    /// <summary>
    /// Rather than freeing via the graphics allocator, directly calls FreeMemory2 which
    /// appears to be empty.
    /// </summary>
    FreeRawMemory = FreeMemory | (1 << 2),
}

public enum ObjectType {
    Object = 0,
    Terrain = 1,
    BgObject = 2,
    CharacterBase = 3,
    VfxObject = 4,
    Light = 5,
    UnkType6 = 6,
    EnvSpace = 7,
    EnvLocation = 8,
    UnkType9 = 9,

    [Obsolete("Why are you using this without documenting it in CS?", true)]
    Unk_Type6 = 6,

    [Obsolete("Why are you using this without documenting it in CS?", true)]
    Unk_Type9 = 9,
}

using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene
{
    // Client::Graphics::Scene::Object
    // base class for all graphics objects

    // size = 0x80
    // ctor - inlined in all derived class ctors
    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public unsafe struct Object
    {
        [FieldOffset(0x30)] public Object* ChildObject; // for humans this is a weapon
    }
}

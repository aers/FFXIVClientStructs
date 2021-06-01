using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.Graphics.Physics;
using FFXIVClientStructs.FFXIV.Client.Graphics.Render;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene
{
    // Client::Graphics::Scene::CharacterBase
    //   Client::Graphics::Scene::DrawObject
    //     Client::Graphics::Scene::Object
    // base class for graphics objects representing characters (human, demihuman, monster, and weapons)

    // size = 0x8F0
    // ctor - E8 ? ? ? ? 48 8D 05 ? ? ? ? 45 33 C0 48 89 03 BA ? ? ? ? 
    [StructLayout(LayoutKind.Explicit, Size = 0x8F0)]
    public unsafe struct CharacterBase
    {
        [FieldOffset(0x0)] public DrawObject DrawObject;
        [FieldOffset(0x90)] public byte UnkFlags_01; // bit 8 - has visor
        [FieldOffset(0x98)] public int SlotCount; // model slots
        [FieldOffset(0xA0)] public Skeleton* Skeleton; // Client::Graphics::Render::Skeleton
        [FieldOffset(0xA8)] public void** ModelArray; // array of Client::Graphics::Render::Model ptrs size = SlotCount
        [FieldOffset(0x148)] public void* PostBoneDeformer; // Client::Graphics::Scene::PostBoneDeformer ptr

        [FieldOffset(0x150)]
        public BonePhysicsModule* BonePhysicsModule; // Client::Graphics::Physics::BonePhysicsModule ptr

        [FieldOffset(0x240)]
        public void*
            CharacterDataCB; // Client::Graphics::Kernel::ConstantBuffer ptr, this CB includes stuff like hair color

        // next few fields are used temporarily when loading the render object and cleared after load
        [FieldOffset(0x2C8)] public uint HasModelInSlotLoaded; // tracks which slots have loaded models into staging

        [FieldOffset(0x2CC)]
        public uint HasModelFilesInSlotLoaded; // tracks which slots have loaded materials, etc into staging

        [FieldOffset(0x2D0)] public void* TempData; // struct with temporary data (size = 0x88)

        [FieldOffset(0x2D8)]
        public void* TempSlotData; // struct with temporary data for each slot (size = 0x88 * slot count)

        //
        [FieldOffset(0x2E8)]
        public void**
            MaterialArray; // array of Client::Graphics::Render::Material ptrs size = SlotCount * 4 (4 material per model max)

        [FieldOffset(0x2F0)]
        public void* EID; // Client::System::Resource::Handle::ElementIdResourceHandle - EID file for base skeleton

        [FieldOffset(0x2F8)]
        public void**
            IMCArray; // array of Client::System::Resource::Handle::ImageChangeDataResourceHandle ptrs size = SlotCount - IMC file for model in slot
    }
}
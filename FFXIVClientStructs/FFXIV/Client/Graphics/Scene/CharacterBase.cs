using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Graphics.Physics;
using FFXIVClientStructs.FFXIV.Client.Graphics.Render;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;
// Client::Graphics::Scene::CharacterBase
//   Client::Graphics::Scene::DrawObject
//     Client::Graphics::Scene::Object
// base class for graphics objects representing characters (human, demihuman, monster, and weapons)

// size = 0x8F0
// ctor - E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 45 33 C0 48 89 03 BA ?? ?? ?? ?? 
[StructLayout(LayoutKind.Explicit, Size = 0x8F0)]
public unsafe partial struct CharacterBase
{
    [FieldOffset(0x0)] public DrawObject DrawObject;
    [FieldOffset(0x90)] public byte UnkFlags_01; // bit 8 - has visor
    [FieldOffset(0x98)] public int SlotCount; // model slots
    [FieldOffset(0xA0)] public Skeleton* Skeleton; // Client::Graphics::Render::Skeleton
    [FieldOffset(0xA8)] public void** ModelArray; // array of Client::Graphics::Render::Model ptrs size = SlotCount
    [FieldOffset(0x148)] public void* PostBoneDeformer; // Client::Graphics::Scene::PostBoneDeformer ptr

    [FieldOffset(0x150)]
    public BonePhysicsModule* BonePhysicsModule; // Client::Graphics::Physics::BonePhysicsModule ptr

    [FieldOffset(0x224)] public float VfxScale;
    [FieldOffset(0x240)] public void*
        CharacterDataCB; // Client::Graphics::Kernel::ConstantBuffer ptr, this CB includes stuff like hair color

    // next few fields are used temporarily when loading the render object and cleared after load
    [FieldOffset(0x2C8)] public uint HasModelInSlotLoaded; // tracks which slots have loaded models into staging

    [FieldOffset(0x2CC)]
    public uint HasModelFilesInSlotLoaded; // tracks which slots have loaded materials, etc into staging

    [FieldOffset(0x2D0)] public void* TempData; // struct with temporary data (size = 0x88)

    [FieldOffset(0x2D8)]
    public void* TempSlotData; // struct with temporary data for each slot (size = 0x88 * slot count)

    //
    [FieldOffset(0x2E8)] public void**
        MaterialArray; // array of Client::Graphics::Render::Material ptrs size = SlotCount * 4 (4 material per model max)

    [FieldOffset(0x2F0)]
    public void* EID; // Client::System::Resource::Handle::ElementIdResourceHandle - EID file for base skeleton

    [FieldOffset(0x2F8)] public void**
        IMCArray; // array of Client::System::Resource::Handle::ImageChangeDataResourceHandle ptrs size = SlotCount - IMC file for model in slot

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 21 C7 40")]
    public static partial CharacterBase* Create(uint modelId, CustomizeData* customize, EquipmentModelId* equipData /* 10 times, 40 byte */, byte unk);

    [MemberFunction("E8 ?? ?? ?? ?? 40 F6 C7 01 74 3A 40 F6 C7 04 75 27 48 85 DB 74 2F 48 8B 05 ?? ?? ?? ?? 48 8B D3 48 8B 48 30")]
    public partial void Destroy();

    [VirtualFunction(50)]
    public partial ModelType GetModelType();

    public enum ModelType : byte
    {
        Human = 1,
        DemiHuman = 2,
        Monster = 3,
        Weapon = 4,
    }

    [VirtualFunction(67)]
    public partial ulong FlagSlotForUpdate(uint slot, EquipmentModelId* slotBytes);
}
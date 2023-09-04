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
[VTableAddress("48 8d 05 ?? ?? ?? ?? 48 89 07 48 8d 9f d0 00 00 00", 3)]
public unsafe partial struct CharacterBase {
    [FieldOffset(0x0)] public DrawObject DrawObject;
    [FieldOffset(0x90)] public byte UnkFlags_01;
    [FieldOffset(0x91)] public byte UnkFlags_02;
    [FieldOffset(0x92)] public byte UnkFlags_03;
    [FieldOffset(0x98)] public int SlotCount; // model slots
    [FieldOffset(0xA0)] public Skeleton* Skeleton; // Client::Graphics::Render::Skeleton

    [Obsolete("Use Models")]
    [FieldOffset(0xA8)] public void** ModelArray; // array of Client::Graphics::Render::Model ptrs size = SlotCount
    [FieldOffset(0xA8)] public Model** Models; // size = SlotCount
    [FieldOffset(0x148)] public void* PostBoneDeformer; // Client::Graphics::Scene::PostBoneDeformer ptr

    public bool IsChangingVisor {
        get => (UnkFlags_01 & 0x80) == 0x80;
        set => UnkFlags_01 = (byte)(value ? UnkFlags_01 | 0x80 : UnkFlags_01 & ~0x80);
    }

    public bool VisorToggled {
        get => (UnkFlags_01 & 0x40) == 0x40;
        set => UnkFlags_01 = (byte)(value ? UnkFlags_01 | 0x40 : UnkFlags_01 & ~0x40);
    }

    public bool HasUmbrella {
        get => (UnkFlags_03 & 0x01) == 0x01;
        set => UnkFlags_03 = (byte)(value ? UnkFlags_03 | 0x01 : UnkFlags_03 & ~0x01);
    }


    [FieldOffset(0x150)]
    public BonePhysicsModule* BonePhysicsModule; // Client::Graphics::Physics::BonePhysicsModule ptr

    [FieldOffset(0x224)] public float VfxScale;
    [FieldOffset(0x240)]
    public void*
        CharacterDataCB; // Client::Graphics::Kernel::ConstantBuffer ptr, this CB includes stuff like hair color

    [FieldOffset(0x2B0)] public float WeatherWetness;  // Set to 1.0f when raining and not covered or umbrella'd
    [FieldOffset(0x2B4)] public float SwimmingWetness; // Set to 1.0f when in water
    [FieldOffset(0x2B8)] public float WetnessDepth;    // Set to ~character height in GPose and higher values when swimming or diving.
    [FieldOffset(0x2BC)] public float ForcedWetness;   // Set by vfunc 51 when using GPose, gets set to 0 in UpdateWetness every frame.

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

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 74 21 C7 40")]
    public static partial CharacterBase* Create(uint modelId, CustomizeData* customize, EquipmentModelId* equipData /* 10 times, 40 byte */, byte unk);

    [MemberFunction("E8 ?? ?? ?? ?? 40 F6 C7 01 74 3A 40 F6 C7 04 75 27 48 85 DB 74 2F 48 8B 05 ?? ?? ?? ?? 48 8B D3 48 8B 48 30")]
    public partial void Destroy();

    [VirtualFunction(50)]
    public partial ModelType GetModelType();

    public enum ModelType : byte {
        Human = 1,
        DemiHuman = 2,
        Monster = 3,
        Weapon = 4,
    }

    [VirtualFunction(67)]
    public partial ulong FlagSlotForUpdate(uint slot, EquipmentModelId* slotBytes);
}

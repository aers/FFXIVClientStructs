using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::CharaView
//
// ClientObjectIndex:
//  0 used in Character, PvPCharacter
//  1 used in Inspect, CharaCard, Fashion, RetainerStatus
//  2 used in TryOn, GearSetPreview
//  3 used in Colorant
//  4 used in BannerList, BannerEdit, BannerUpdateView, FittingShop
//  0 - 7 used in BannerParty
//
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x318)]
public unsafe partial struct CharaView : ICreatable {
    [FieldOffset(0x8)] public uint State; // initialization state of KernelTexture, Camera etc. that happens in Render(), 6 = ready for use
    [FieldOffset(0xC)] public uint ClientObjectId; // ID of object in ClientObjectManager, basically ClientObjectIndex + 40
    [FieldOffset(0x10)] public uint ClientObjectIndex;
    [FieldOffset(0x14)] public uint CameraType; // turns portrait ambient/directional lighting on/off
    [FieldOffset(0x18)] public nint CameraManager;
    [FieldOffset(0x20)] public Camera* Camera;
    //[FieldOffset(0x28)] public nint Unk28; // float CharacterRotation?
    [FieldOffset(0x30)] public AgentInterface* Agent; // for example: AgentTryOn
    /// <remarks> (AgentInterface* agent, Texture* charaViewTexture) -> void </remarks>
    [FieldOffset(0x38)] public nint AgentCallbackReady; // if set, called when State changes to Ready
    /// <remarks> (AgentInterface* agent) -> Client::Game::Character::Character* </remarks>
    [FieldOffset(0x40)] public nint AgentCallbackGetCharacter;
    [FieldOffset(0x48)] public CharaViewModelData ModelData;
    [FieldOffset(0xE0)] public uint Race; // used to check EquipRestriction
    [FieldOffset(0xE4)] public uint Sex; // used to check EquipRestriction
    [FieldOffset(0xE8)] private uint UnkE8;
    [FieldOffset(0xEC)] public float ZoomRatio;

    [FieldOffset(0xF8), FixedSizeArray] internal FixedSizeArray14<CharaViewItem> _items;

    [FieldOffset(0x308)] public byte FreeCompanyCrestBitfield;
    [FieldOffset(0x309)] public bool CharacterDataCopied;
    [FieldOffset(0x30A)] public bool CharacterLoaded;

    public static CharaView* Create()
        => IMemorySpace.GetUISpace()->Create<CharaView>();

    [MemberFunction("E8 ?? ?? ?? ?? 33 ED C6 86 ?? ?? ?? ?? ?? 48 8D 05")]
    public partial void Ctor();

    [VirtualFunction(0)]
    public partial void Dtor(bool freeMemory);

    [VirtualFunction(1)]
    public partial void Initialize(AgentInterface* agent, uint clientObjectId, nint agentCallbackReady);

    [VirtualFunction(2)]
    public partial void Release(); // aka Finalize

    [VirtualFunction(3)]
    public partial void ResetPositions();

    [VirtualFunction(4)]
    public partial void SetCameraDistance(float deltaDistance);

    [VirtualFunction(5)]
    public partial void SetCameraYawAndPitch(float deltaRotation, float deltaPitch);

    [VirtualFunction(6)]
    public partial void SetCameraXAndY(float deltaX, float deltaY);

    [VirtualFunction(8)]
    public partial void OnReady();

    [VirtualFunction(10)]
    public partial void Update();

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8B CD 45 8B C4")]
    public partial void SetModelData(CharaViewModelData* data);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 4C 24 ?? 8B 51 04")]
    public partial void Render(uint frameIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 75 05 0F 57 C9")]
    public partial Character* GetCharacter();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 45 77 48 8D 4D 87")]
    public partial void UnequipGear(bool hasCharacterData = false, bool characterLoaded = true);

    [MemberFunction("E8 ?? ?? ?? ?? FF C5 48 83 C3 1C")]
    public partial void SetItemSlotData(byte slotId, uint itemId, byte stain0Id, byte stain1Id, uint glamourItemId = 0, bool applyCompanyCrest = true);

    [MemberFunction("E8 ?? ?? ?? ?? 45 0F B6 8E ?? ?? ?? ?? B0 01")]
    public partial void ToggleDrawWeapon(bool drawn);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct CharaViewModelData {
    [FieldOffset(0)] public CustomizeData CustomizeData;
    [FieldOffset(0x1A), FixedSizeArray] internal FixedSizeArray2<ushort> _glassesIds;
    [FieldOffset(0x20), FixedSizeArray] internal FixedSizeArray10<EquipmentModelId> _equipmentModelIds;
    [FieldOffset(0x70), FixedSizeArray] internal FixedSizeArray3<WeaponModelId> _weaponModelIds;
    [FieldOffset(0x88)] public bool HeadgearHidden;
    [FieldOffset(0x89)] public bool WeaponHidden;
    [FieldOffset(0x8A)] public bool VisorClosed;
    [FieldOffset(0x8B)] public byte FreeCompanyCrestBitfield;
    [FieldOffset(0x90)] public CrestData FreeCompanyCrestData;

    [MemberFunction("E8 ?? ?? ?? ?? 0F 28 55 87")]
    public partial void CopyFromCharacter(Character* character);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x78)]
public unsafe partial struct CharaViewCharacterData : ICreatable {
    [FieldOffset(0)] public CustomizeData CustomizeData;
    // Unk 2 bytes
    [FieldOffset(0x1C), FixedSizeArray] internal FixedSizeArray14<uint> _itemIds;
    [FieldOffset(0x54), FixedSizeArray] internal FixedSizeArray14<byte> _itemStain0Ids;
    [FieldOffset(0x62), FixedSizeArray] internal FixedSizeArray14<byte> _itemStain1Ids;
    [FieldOffset(0x70), FixedSizeArray] internal FixedSizeArray2<ushort> _glassesIds;
    [FieldOffset(0x74)] public byte ClassJobId;
    [FieldOffset(0x75)] public bool HeadgearHidden;
    [FieldOffset(0x76)] public bool WeaponHidden;
    [FieldOffset(0x77)] public bool VisorClosed;

    public static CharaViewCharacterData* Create()
        => IMemorySpace.GetUISpace()->Create<CharaViewCharacterData>();

    public static CharaViewCharacterData* CreateFromLocalPlayer() {
        var obj = Create();
        obj->ImportLocalPlayerEquipment();
        return obj;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8D 4E 30 49 8B D6")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 57 28 45 33 F6")]
    public partial void ImportLocalPlayerEquipment();
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public struct CharaViewItem {
    [FieldOffset(0x0)] public byte SlotId;
    [FieldOffset(0x1)] public byte EquipSlotCategory;
    [FieldOffset(0x2)] public byte GlamourEquipSlotCategory;
    [FieldOffset(0x3)] public byte Stain0Id;
    [FieldOffset(0x4)] public byte Stain1Id;
    [FieldOffset(0x5)] public byte GlamourStain0Id;
    [FieldOffset(0x6)] public byte GlamourStain1Id;
    //[FieldOffset(0x7)] public byte Unk7;
    [FieldOffset(0x8)] public uint ItemId;
    [FieldOffset(0xC)] public uint GlamourItemId;
    [FieldOffset(0x10)] public ulong ModelMain; // WeaponModelId or EquipmentModelId
    [FieldOffset(0x18)] public ulong ModelSub; // WeaponModelId or EquipmentModelId
}

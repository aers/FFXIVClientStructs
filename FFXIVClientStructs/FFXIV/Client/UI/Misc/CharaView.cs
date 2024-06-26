using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::CharaView
//
// ClientObjectIndex:
//  0 used in Character, PvPCharacter
//  1 used in Inspect, CharaCard
//  2 used in TryOn, GearSetPreview
//  3 used in Colorant
//  4 used in BannerList, BannerEdit
//  0 - 7 used in BannerParty
//
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x2C8)]
public unsafe partial struct CharaView : ICreatable {
    [FieldOffset(0x8)] public uint State; // initialization state of KernelTexture, Camera etc. that happens in Render(), 6 = ready for use
    [FieldOffset(0xC)] public uint ClientObjectId; // ID of object in ClientObjectManager, basically ClientObjectIndex + 40
    [FieldOffset(0x10)] public uint ClientObjectIndex;
    [FieldOffset(0x14)] public uint CameraType; // turns portrait ambient/directional lighting on/off
    [FieldOffset(0x18)] public nint CameraManager;
    [FieldOffset(0x20)] public Camera* Camera;
    //[FieldOffset(0x28)] public nint Unk28; // float CharacterRotation?
    [FieldOffset(0x30)] public AgentInterface* Agent; // for example: AgentTryOn
    //[FieldOffset(0x38)] public nint AgentCallbackReady; // if set, called when State changes to Ready
    //[FieldOffset(0x40)] public nint AgentCallback; // not investigated, used inside vf7 and vf11
    [FieldOffset(0x48)] public CharaViewCharacterData CharacterData;

    //[FieldOffset(0xB8)] public uint UnkB8;
    //[FieldOffset(0xBC)] public uint UnkBC;
    //[FieldOffset(0xC0)] public float UnkC0;
    [FieldOffset(0xC4)] public float ZoomRatio;

    [FieldOffset(0xD0), FixedSizeArray] internal FixedSizeArray14<CharaViewItem> _items;

    [FieldOffset(0x2B8)] public bool CharacterDataCopied;
    [FieldOffset(0x2B9)] public bool CharacterLoaded;

    public static CharaView* Create()
        => IMemorySpace.GetUISpace()->Create<CharaView>();

    [MemberFunction("E8 ?? ?? ?? ?? 89 B3 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ??")]
    public partial void Ctor();

    [VirtualFunction(0)]
    public partial void Dtor(bool freeMemory);

    [VirtualFunction(1)]
    public partial void Initialize(AgentInterface* agent, uint clientObjectId, nint agentCallbackReady);

    [VirtualFunction(2)]
    public partial void Release(); // aka Finalize

    [VirtualFunction(3)]
    public partial void ResetPositions();

    [MemberFunction("0F 10 02 0F 11 41 48")]
    public partial void SetCustomizeData(CharaViewCharacterData* data);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 4C 24 ?? 8B 51 04")]
    public partial void Render(uint frameIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 48 85 C0 75 05 0F 57 C9")]
    public partial Character* GetCharacter();

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 4F 10 88 85")]
    public partial bool IsAnimationPaused();

    [MemberFunction("E8 ?? ?? ?? ?? B2 01 48 8B CF E8 ?? ?? ?? ?? 32 C0")]
    public partial void ToggleAnimationPlayback(bool paused);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 45 77 48 8D 4D 87")]
    public partial void UnequipGear(bool hasCharacterData = false, bool characterLoaded = true);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 DB FF C3")]
    public partial void SetItemSlotData(byte slotId, uint itemId, byte stainId, uint glamourItemId = 0, byte a6 = 1);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 8D ?? ?? ?? ?? B0 01")]
    public partial void ToggleDrawWeapon(bool drawn);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct CharaViewCharacterData : ICreatable {
    [FieldOffset(0)] public CustomizeData CustomizeData;
    //[FieldOffset(0x1A)] public byte Unk1A;
    //[FieldOffset(0x1B)] public byte Unk1B;
    [FieldOffset(0x1C), FixedSizeArray] internal FixedSizeArray14<uint> _itemIds;
    [FieldOffset(0x54), FixedSizeArray] internal FixedSizeArray14<byte> _itemStains;
    [FieldOffset(0x62)] public byte ClassJobId;
    [FieldOffset(0x63)] public bool VisorHidden;
    [FieldOffset(0x64)] public bool WeaponHidden;
    [FieldOffset(0x65)] public bool VisorClosed;
    //[FieldOffset(0x66)] public byte Unk66;
    //[FieldOffset(0x67)] public byte Unk67;

    public static CharaViewCharacterData* Create()
        => IMemorySpace.GetUISpace()->Create<CharaViewCharacterData>();

    public static CharaViewCharacterData* CreateFromLocalPlayer() {
        var obj = Create();
        obj->ImportLocalPlayerEquipment();
        return obj;
    }

    [MemberFunction("E8 ?? ?? ?? ?? 4D 8D 4E 30")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 57 28 45 33 F6")]
    public partial void ImportLocalPlayerEquipment();
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct CharaViewItem {
    [FieldOffset(0x0)] public byte SlotId;
    [FieldOffset(0x1)] public byte EquipSlotCategory;
    [FieldOffset(0x2)] public byte GlamourEquipSlotCategory;
    [FieldOffset(0x3)] public byte StainId;
    [FieldOffset(0x4)] public byte GlamourStainId;
    //[FieldOffset(0x5)] public byte Unk5; // a6 of SetItemSlotData
    //[FieldOffset(0x6)] public byte Unk6;
    //[FieldOffset(0x7)] public byte Unk7;
    [FieldOffset(0x8)] public uint ItemId;
    [FieldOffset(0xC)] public uint GlamourItemId;
    [FieldOffset(0x10)] public ulong ModelMain; // WeaponModelId or EquipmentModelId
    [FieldOffset(0x18)] public ulong ModelSub; // WeaponModelId or EquipmentModelId
}

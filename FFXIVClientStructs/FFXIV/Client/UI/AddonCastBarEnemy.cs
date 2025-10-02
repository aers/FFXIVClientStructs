using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Component.GUI;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x530)]
public unsafe partial struct AddonCastBarEnemy {
    [FieldOffset(0x238), FixedSizeArray] internal FixedSizeArray10<CastBarPositionStruct> _castBarPositions;
    [FieldOffset(0x300), FixedSizeArray] internal FixedSizeArray10<CastBarInfoStruct> _castBarInfo;
    [FieldOffset(0x3F0), FixedSizeArray] internal FixedSizeArray10<CastBarNodeStruct> _castBarNodes;

    [StructLayout(LayoutKind.Explicit, Size = 0x14)]
    public unsafe partial struct CastBarPositionStruct {
        [FieldOffset(0x00)] public GameObjectId ObjectId;
        [FieldOffset(0x04)] public UIObjectKind NamePlateObjectKind;
        [FieldOffset(0x08)] public uint Size;  // 0 - 100, size of nameplate depending on distance to object
        [FieldOffset(0x0C)] public uint ScreenPosX;
        [FieldOffset(0x10)] public uint ScreenPosY;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public unsafe partial struct CastBarInfoStruct {
        [FieldOffset(0x00)] public GameObjectId ObjectId;
        [FieldOffset(0x04)] public byte Progress;  // 0 - 100, 0xFF if not active
        [FieldOffset(0x08)] public CStringPointer CastName;
        [FieldOffset(0x10)] public bool Interruptible;
        [FieldOffset(0x11)] public bool Unk11;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe partial struct CastBarNodeStruct {
        [FieldOffset(0x00)] public AtkResNode* CastBarNode;
        [FieldOffset(0x08)] public AtkTextNode* CastNameTextNode;
        [FieldOffset(0x10)] public AtkImageNode* ProgressBarNode;
        [FieldOffset(0x18)] public GameObjectId ObjectId;
    }
}

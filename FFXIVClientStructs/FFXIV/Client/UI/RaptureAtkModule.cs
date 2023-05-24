﻿using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::RaptureAtkModule
//   Component::GUI::AtkModule
//     Component::GUI::AtkModuleInterface
[StructLayout(LayoutKind.Explicit, Size = 0x289F8)]
public partial struct RaptureAtkModule
{
    [FieldOffset(0x0)] public AtkModule AtkModule;

    [FieldOffset(0x11690)] public RaptureAtkUnitManager RaptureAtkUnitManager;

    [FieldOffset(0x1B310)] public RaptureAtkModuleFlags Flags;
    
    [FieldOffset(0x1B8A0)] public int NameplateInfoCount;
    [FieldOffset(0x1B8A8)] public NamePlateInfo NamePlateInfoArray; // 0-50, &NamePlateInfoArray[i]

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 44 24 ?? 48 89 9F")]
    public partial bool ChangeUiMode(uint uiMode);

    [VirtualFunction(39)]
    public partial void SetUiVisibility(bool uiVisible);

    public bool IsUiVisible {
        get => !Flags.HasFlag(RaptureAtkModuleFlags.UiHidden);
        set => SetUiVisibility(value);
    }
    
    [StructLayout(LayoutKind.Explicit, Size = 0x248)]
    public struct NamePlateInfo
    {
        [FieldOffset(0x00)] public GameObjectID ObjectID;
        [FieldOffset(0x30)] public Utf8String Name;
        [FieldOffset(0x98)] public Utf8String FcName;
        [FieldOffset(0x100)] public Utf8String Title;
        [FieldOffset(0x168)] public Utf8String DisplayTitle;
        [FieldOffset(0x1D0)] public Utf8String LevelText;
        [FieldOffset(0x240)] public int Flags;

        public bool IsPrefixTitle => ((Flags >> (8 * 3)) & 0xFF) == 1;
    }
}

[Flags]
public enum RaptureAtkModuleFlags : byte {
    None = 0x00,
    Unk01 = 0x01,
    Unk02 = 0x02,
    UiHidden = 0x04,
    Unk08 = 0x08,
    Unk10 = 0x10,
    Unk20 = 0x20,
    Unk40 = 0x40,
    Unk80 = 0x80,
}
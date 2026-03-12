using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonTeleportTown
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("TelepotTown")] // yes, it's misspelled
[GenerateInterop]
[Inherits<AtkUnitBase>]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 03 48 8D 8B ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 89 BB ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 48 89 BB", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x5C0)]
public unsafe partial struct AddonTeleportTown {
    [FieldOffset(0x238)] public AtkComponentTreeList* List;
    [FieldOffset(0x240)] public AddonTeleportTownListCallback ListCallback;
    [FieldOffset(0x260)] public AtkComponentMap* ComponentMap;
    [FieldOffset(0x268)] public AtkComponentList* List2;
    [FieldOffset(0x270)] public AtkResNode* Node14;
    [FieldOffset(0x278)] public AtkTextNode* Node15;
    [FieldOffset(0x280)] public AtkResNode* Node11;
    [FieldOffset(0x288)] public AtkTextNode* Node12;
    [FieldOffset(0x290)] public Atk2DAreaMap AreaMap;
    // vector
    [FieldOffset(0x350)] private int Unk350;
    [FieldOffset(0x354)] private int Unk354;
    [FieldOffset(0x358)] private int Unk358;
    [FieldOffset(0x360)] private int Unk360;

    [FieldOffset(0x368)] public float MapTransitionTime;

    [FieldOffset(0x370)] public float MapTargetX;
    [FieldOffset(0x374)] public float MapTargetY;

    [FieldOffset(0x380)] public float MapCurrentX;
    [FieldOffset(0x384)] public float MapCurrentY;

    [FieldOffset(0x390), FixedSizeArray(isString: true)] internal FixedSizeArray512<byte> _tooltipText;
    [FieldOffset(0x590)] public AtkResNode* CurrentFocusNode;
    [FieldOffset(0x598)] private float Unk598;
    [FieldOffset(0x59C)] private float Unk59C;
    [FieldOffset(0x5A0)] private short Unk5A0;
    [FieldOffset(0x5A2)] private short Unk5A2;
    [FieldOffset(0x5A4)] private short Unk5A4;
    [FieldOffset(0x5A6)] private short Unk5A6;
    [FieldOffset(0x5A8)] private byte Unk5A8;
    [FieldOffset(0x5A9)] private byte Unk5A9;
    [FieldOffset(0x5AA)] private byte Unk5AA;
    [FieldOffset(0x5AB)] private byte Unk5AB; // IsPadModeEnabled
    [FieldOffset(0x5AC)] private byte Unk5AC;
    [FieldOffset(0x5AD)] private byte Unk5AD;
    [FieldOffset(0x5AE)] private byte Unk5AE;

    [FieldOffset(0x5B0)] private byte Unk5B0;
    [FieldOffset(0x5B1)] private byte Unk5B1;
}

[GenerateInterop]
[Inherits<ListComponentCallBackInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public partial struct AddonTeleportTownListCallback;

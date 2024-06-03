using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkToolTipManager
//      Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x150)]
public unsafe partial struct AtkTooltipManager {
    public enum AtkTooltipType : byte {
        Text = 1,
        Item = 2,
        TextItem = 3,
        Action = 4
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct AtkTooltipArgs : ICreatable {
        [FieldOffset(0x0)] public byte* Text;
        [FieldOffset(0x8)] public ulong TypeSpecificId;
        [FieldOffset(0x10)] public uint Flags;
        [FieldOffset(0x14)] public short Unk_14;
        [FieldOffset(0x16)] public byte Unk_16;

        [MemberFunction("E8 ?? ?? ?? ?? C1 FB 04")]
        public partial void Ctor();
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct AtkTooltipInfo {
        [FieldOffset(0x0)] public AtkTooltipArgs AtkTooltipArgs;
        [FieldOffset(0x18)] public ushort ParentId; // same as IDs in addons
        [FieldOffset(0x1A)] public AtkTooltipType Type;
    }

    [FieldOffset(0x8)] public StdMap<Pointer<AtkResNode>, Pointer<AtkTooltipInfo>> TooltipMap;
    [FieldOffset(0x18)] public AtkStage* AtkStage;

    [MemberFunction("E8 ?? ?? ?? ?? 44 85 F6")]
    public partial void AddTooltip(AtkTooltipType type, ushort parentId, AtkResNode* targetNode, AtkTooltipArgs* tooltipArgs);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 C9 45 8D 44 24")]
    public partial void RemoveTooltip(AtkResNode* targetNode);

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 EB 02")]
    public partial void ShowTooltip(
        AtkTooltipType type,
        ushort parentId,
        AtkResNode* targetNode,
        AtkTooltipArgs* tooltipArgs,
        delegate* unmanaged[Stdcall]<float*, float*, void*> unkDelegate = null,
        bool unk7 = false,
        bool unk8 = true);

    [GenerateStringOverloads] // cursed forced partial to make generator happy
    public partial void ShowTooltip(ushort parentId, AtkResNode* targetNode, byte* tooltipString);
    public partial void ShowTooltip(ushort parentId, AtkResNode* targetNode, byte* tooltipString) {
        var args = stackalloc AtkTooltipArgs[1];
        args->Ctor();
        args->Text = tooltipString;
        ShowTooltip(AtkTooltipType.Text, parentId, targetNode, args);
    }

    [MemberFunction("66 3B 91 ?? ?? ?? ?? 75 09")]
    public partial void HideTooltip(ushort parentId, bool unk = false);
}

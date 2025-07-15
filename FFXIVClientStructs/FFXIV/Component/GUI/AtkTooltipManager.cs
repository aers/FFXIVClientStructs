using FFXIVClientStructs.FFXIV.Client.Enums;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkToolTipManager
//      Component::GUI::AtkEventListener
[GenerateInterop]
[Inherits<AtkEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x150)]
public unsafe partial struct AtkTooltipManager {
    [FieldOffset(0x8)] public StdMap<Pointer<AtkResNode>, Pointer<AtkTooltipInfo>> TooltipMap;
    [FieldOffset(0x18)] public AtkStage* AtkStage;
    [FieldOffset(0x50), FixedSizeArray] internal FixedSizeArray5<AtkTimer> _timers;
    [FieldOffset(0x14C)] public byte Flag1; // Allows AddonItemDetail to be shown with Flag1 |= 2.

    [MemberFunction("E8 ?? ?? ?? ?? 44 85 F6")]
    public partial void AttachTooltip(AtkTooltipType type, ushort parentId, AtkResNode* targetNode, AtkTooltipArgs* tooltipArgs);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 75 DF")]
    public partial void DetachTooltip(AtkResNode* targetNode);

    [MemberFunction("E8 ?? ?? ?? ?? 45 33 C9 45 8D 44 24")]
    public partial void DetachTooltipByAddonId(ushort addonId, bool removeEvents = true);

    [MemberFunction("E8 ?? ?? ?? ?? 33 D2 EB 02")]
    public partial void ShowTooltip(
        AtkTooltipType type,
        ushort parentId,
        AtkResNode* targetNode,
        AtkTooltipArgs* tooltipArgs,
        delegate* unmanaged[Stdcall]<float*, float*, AtkResNode*, void> unkDelegate = null,
        bool unk7 = false,
        bool unk8 = true);

    [GenerateStringOverloads] // cursed forced partial to make generator happy
    public partial void ShowTooltip(ushort parentId, AtkResNode* targetNode, CStringPointer tooltipString);
    public partial void ShowTooltip(ushort parentId, AtkResNode* targetNode, CStringPointer tooltipString) {
        var args = stackalloc AtkTooltipArgs[1];
        args->Ctor();
        args->TextArgs.Text = tooltipString;
        ShowTooltip(AtkTooltipType.Text, parentId, targetNode, args);
    }

    [MemberFunction("66 3B 91 ?? ?? ?? ?? 75 09")]
    public partial void HideTooltip(ushort parentId, bool unk = false);

    // Values are passed around
    // from AtkTooltipManager.ShowTooltip/ShowNodeTooltip
    // to AtkManagedInterface of the addon
    // to RaptureAtkModule.HandleShowDetailAddon
    // to the specific agent
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct AtkTooltipArgs : ICreatable {
        /// <remarks> Args for <see cref="AtkTooltipType.Text"/> / AddonTooltip. </remarks>
        [FieldOffset(0), CExporterUnion("Args")] public AtkTooltipTextArgs TextArgs;
        /// <remarks> Args for <see cref="AtkTooltipType.Item"/> / AddonItemDetail. </remarks>
        [FieldOffset(0), CExporterUnion("Args")] public AtkTooltipItemArgs ItemArgs;
        /// <remarks> Args for <see cref="AtkTooltipType.Action"/> / AddonActionDetail. </remarks>
        [FieldOffset(0), CExporterUnion("Args")] public AtkTooltipActionArgs ActionArgs;
        /// <remarks> Args for <see cref="AtkTooltipType.LovmAction"/> / AddonLovmActionDetail. </remarks>
        [FieldOffset(0), CExporterUnion("Args")] public AtkTooltipLovmActionArgs LovmActionArgs;
        /// <remarks> Args for <see cref="AtkTooltipType.MiragePrismPrismItem"/> / AddonMiragePrismPrismItemDetail. </remarks>
        [FieldOffset(0), CExporterUnion("Args")] public AtkTooltipMiragePrismPrismItemArgs MiragePrismPrismItemArgs;

        [FieldOffset(0x00), Obsolete("Use TextArgs.Text")] public CStringPointer Text;
        [FieldOffset(0x08), Obsolete("Use type-specific sub-structs")] public ulong TypeSpecificId;
        [FieldOffset(0x10), Obsolete("Use type-specific sub-structs")] public uint Flags;
        [FieldOffset(0x14), Obsolete("Use type-specific sub-structs")] public short Unk_14;
        [FieldOffset(0x16), Obsolete("Use type-specific sub-structs")] public byte Unk_16;

        [MemberFunction("E8 ?? ?? ?? ?? C1 FB 04")]
        public partial void Ctor();

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct AtkTooltipTextArgs {
            [FieldOffset(0x00)] public CStringPointer Text;
            // [FieldOffset(0x08)] public int Field8;  // unused
            /// <remarks>
            /// Used in AddonTooltip's ManagedInterface vf0.<br/>
            /// Value:<br/>
            /// 0 = Nothing<br/>
            /// 1 = Subscribe to NumberArray Inventory<br/>
            /// 2 = Subscribe to NumberArray Character
            /// </remarks>
            [FieldOffset(0x0C)] public uint AtkArrayType;
            // [FieldOffset(0x10)] public int Field10; // unused
            // [FieldOffset(0x14)] public short Field14; // unused
            // [FieldOffset(0x16)] public byte Field16; // unused
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct AtkTooltipItemArgs {
            /// <remarks>
            /// Used when <see cref="Kind"/> is not <see cref="DetailKind.InventoryItem"/>.<br/>
            /// Set to <see cref="AgentItemDetail.TypeOrId"/>.
            /// </remarks>
            [FieldOffset(0x08), CExporterUnion("Id")] public int ItemId;
            /// <remarks>
            /// Used when <see cref="Kind"/> is <see cref="DetailKind.InventoryItem"/>.<br/>
            /// Set to <see cref="AgentItemDetail.TypeOrId"/>.
            /// </remarks>
            [FieldOffset(0x08), CExporterUnion("Id")] public InventoryType InventoryType;
            /// <remarks>
            /// Set to <see cref="AgentItemDetail.Flag1"/>.
            /// </remarks>
            [FieldOffset(0x0C)] public uint Flag1;
            /// <remarks>
            /// Set to <see cref="AgentItemDetail.BuyQuantity"/>.
            /// </remarks>
            [FieldOffset(0x10)] public int BuyQuantity;
            /// <remarks>
            /// Used when <see cref="Kind"/> is <see cref="DetailKind.InventoryItem"/>.<br/>
            /// Set to <see cref="AgentItemDetail.Index"/>.
            /// </remarks>
            [FieldOffset(0x14)] public short Slot;
            [FieldOffset(0x16)] public DetailKind Kind;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct AtkTooltipActionArgs {
            /// <remarks>
            /// Set to <see cref="AgentActionDetail.ActionId"/>/<see cref="AgentActionDetail.OriginalId"/>.
            /// </remarks>
            [FieldOffset(0x08)] public int Id;
            // [FieldOffset(0x0C)] public uint FieldC; // unused
            // [FieldOffset(0x10)] public int Field10; // unused
            /// <remarks>
            /// 1 = Adjust ActionId
            /// </remarks>
            [FieldOffset(0x14)] public short Flags;
            [FieldOffset(0x16)] public DetailKind Kind;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct AtkTooltipLovmActionArgs {
            [FieldOffset(0x08)] public int Id;
            // [FieldOffset(0x0C)] public uint FieldC; // unused
            // [FieldOffset(0x10)] public int Field10; // unused
            /// <remarks>
            /// 1 = Adjust ActionId
            /// </remarks>
            [FieldOffset(0x14)] public short Flags;
            [FieldOffset(0x16)] public DetailKind Kind;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct AtkTooltipMiragePrismPrismItemArgs {
            /// <remarks>
            /// Used for <see cref="DetailKind.MiragePrismItem"/> as ItemId.<br/>
            /// When this is a MirageStoreSetItem RowId (ItemId of the Set), then specify <see cref="SetItemSlot"/> for the slot.
            /// </remarks>
            [FieldOffset(0x08)] public int Id;
            // [FieldOffset(0x0C)] public uint FieldC; // unused
            /// <remarks>
            /// Used for <see cref="DetailKind.MiragePrismBoxItem"/>.
            /// </remarks>
            [FieldOffset(0x10)] public int SetItemSlot;
            /// <remarks>
            /// Used for <see cref="DetailKind.MiragePrismItem"/>, but unsure what for.<br/>
            /// Used for <see cref="DetailKind.MiragePrismBoxItem"/> as Index in <see cref="MirageManager.PrismBoxItemIds"/>/<see cref="MirageManager.PrismBoxStain0Ids"/>/<see cref="MirageManager.PrismBoxStain1Ids"/>.
            /// </remarks>
            [FieldOffset(0x14)] public short Index;
            /// <remarks>
            /// Either <see cref="DetailKind.MiragePrismItem"/> or <see cref="DetailKind.MiragePrismBoxItem"/>.
            /// </remarks>
            [FieldOffset(0x16)] public DetailKind Kind;
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct AtkTooltipInfo {
        [FieldOffset(0x0)] public AtkTooltipArgs AtkTooltipArgs;
        [FieldOffset(0x18)] public ushort ParentId; // same as IDs in addons
        [FieldOffset(0x1A)] public AtkTooltipType Type;
    }

    [Flags]
    public enum AtkTooltipType : byte {
        None = 0,
        Text = 1 << 0,
        Item = 1 << 1,
        [Obsolete("Use AtkTooltipType.Text | AtkTooltipType.Item")]
        TextItem = Text | Item,
        Action = 1 << 2,
        LovmAction = 1 << 3,
        MiragePrismPrismItem = 1 << 4,
    }
}

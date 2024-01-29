using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.MiragePrismMiragePlate)]
[StructLayout(LayoutKind.Explicit, Size = 0x350)]
public unsafe partial struct AgentMiragePrismMiragePlate {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x78)] public MiragePrismMiragePlateCharaView CharaView;

    [FixedSizeArray<MiragePlateItem>(14)]
    [Obsolete("Use MiragePlateCharaView.Base.Items")]
    [FieldOffset(0x148)] public unsafe fixed byte PlateItems[14 * 0x20]; // 14 * MiragePlateItem

    /// <remarks>
    /// The game checks <see cref="GameMain.IsInSanctuary"/> before calling this, and if false, it prints LogMessage 4316: "Unable to apply glamour plates here.".
    /// </remarks>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 8B FA 66 44 89 4C 24")]
    public partial void OpenForGearset(int gearsetId, int glamourSetLink, ushort openerAddonId = 0);

    // Client::UI::Agent::AgentMiragePrismMiragePlate::MiragePrismMiragePlateCharaView
    //   Client::UI::Misc::CharaView
    [StructLayout(LayoutKind.Explicit, Size = 0x2D8)]
    public unsafe partial struct MiragePrismMiragePlateCharaView {
        [FieldOffset(0)] public CharaView Base;
        [FieldOffset(0x2C8)] public bool IsUpdatePending;

        [FieldOffset(0x2CC)] public uint Flags;

        public bool IsOtherEquipmentHidden {
            get => (Flags & 0x01) == 0x01;
            set => Flags = (uint)(value ? Flags | 0x01 : Flags & ~0x01);
        }

        public bool IsHatHidden {
            get => (Flags & 0x02) == 0x02;
            set => Flags = (uint)(value ? Flags | 0x02 : Flags & ~0x02);
        }

        public bool IsWeaponHidden {
            get => (Flags & 0x04) == 0x04;
            set => Flags = (uint)(value ? Flags | 0x04 : Flags & ~0x04);
        }

        public bool IsVisorToggled {
            get => (Flags & 0x08) == 0x08;
            set => Flags = (uint)(value ? Flags | 0x08 : Flags & ~0x08);
        }

        public bool IsWeaponDrawn {
            get => (Flags & 0x10) == 0x10;
            set => Flags = (uint)(value ? Flags | 0x10 : Flags & ~0x10);
        }
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
[Obsolete("Same as CharaViewItem")]
public struct MiragePlateItem {
    [FieldOffset(0x00)] public byte EquipType;
    [FieldOffset(0x01)] public byte EquipSlotCategory;
    [FieldOffset(0x03)] public byte Stain;
    [FieldOffset(0x08)] public uint ItemId;
    [FieldOffset(0x10)] public ulong ModelMain;
    [FieldOffset(0x18)] public ulong ModelSub;
}

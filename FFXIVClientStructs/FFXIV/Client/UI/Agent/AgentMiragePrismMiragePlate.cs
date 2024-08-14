using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentMiragePrismMiragePlate
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.MiragePrismMiragePlate)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x3A8)]
public unsafe partial struct AgentMiragePrismMiragePlate {
    [FieldOffset(0x80)] public MiragePrismMiragePlateCharaView CharaView;

    /// <remarks>
    /// The game checks <see cref="GameMain.IsInSanctuary"/> before calling this, and if false, it prints LogMessage 4316: "Unable to apply glamour plates here.".
    /// </remarks>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 30 8B FA 66 44 89 4C 24")]
    public partial void OpenForGearset(int gearsetId, int glamourSetLink, ushort openerAddonId = 0);

    // Client::UI::Agent::AgentMiragePrismMiragePlate::MiragePrismMiragePlateCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x328)]
    public unsafe partial struct MiragePrismMiragePlateCharaView {
        [FieldOffset(0x318)] public bool IsUpdatePending;

        [FieldOffset(0x31C)] public uint Flags;

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

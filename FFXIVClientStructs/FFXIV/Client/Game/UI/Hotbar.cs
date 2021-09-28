using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI {
    [StructLayout(LayoutKind.Explicit, Size = 0xA38)]
    public unsafe partial struct Hotbar {
        [FieldOffset(0x10C)] public uint TargetBattleCharaId;
        [FieldOffset(0xA20)] public byte WeaponUnsheathed;
        [FieldOffset(0xA28)] public float AutoSheathDelayTimer;

        [MemberFunction("48 83 EC 38 33 D2 C7 44 24 ?? ?? ?? ?? ?? 45 33 C9")]
        public partial void CancelCast();

        [MemberFunction("E8 ?? ?? ?? ?? 88 45 80")]
        public partial bool IsActionUnlocked(uint actionId);
    }
}

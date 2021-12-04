using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI {
    //ctor 40 53 48 83 EC 20 48 8B D9 48 8D 81 ?? ?? ?? ?? BA
    [StructLayout(LayoutKind.Explicit, Size = 0x788)]
    public unsafe struct PlayerState {
        [FieldOffset(0x00)] public byte IsLoaded;
        [FieldOffset(0x01)] public fixed byte CharacterName[64];
        [FieldOffset(0x54)] public uint ObjectId;
        [FieldOffset(0x58)] public ulong ContentId;

        [FieldOffset(0x6A)] public byte CurrentClassJobId;
        [FieldOffset(0x78)] public short CurrentLevel;

        [FieldOffset(0x7A)] public fixed short ClassJobLevelArray[30];
        [FieldOffset(0xB8)] public fixed int ClassJobExpArray[30];

        [FieldOffset(0x130)] public short SyncedLevel;
        [FieldOffset(0x132)] public byte IsLevelSynced;

        [FieldOffset(0x154)] public int BaseStrength;
        [FieldOffset(0x158)] public int BaseDexterity;
        [FieldOffset(0x15C)] public int BaseVitality;
        [FieldOffset(0x160)] public int BaseIntelligence;
        [FieldOffset(0x164)] public int BaseMind;
        [FieldOffset(0x168)] public int BasePiety;
        
        [FieldOffset(0x16C)] public fixed int Attributes[74];

        [FieldOffset(0x294)] public byte GrandCompany;
        [FieldOffset(0x295)] public byte GCRankMaelstrom;
        [FieldOffset(0x296)] public byte GCRankTwinAdders;
        [FieldOffset(0x297)] public byte GCRankImmortalFlames;

        [FieldOffset(0x298)] public byte HomeAetheryteId;
        [FieldOffset(0x299)] public byte FavouriteAetheryteCount;
        [FieldOffset(0x29A)] public fixed byte FavouriteAetheryteArray[4];
        [FieldOffset(0x29E)] public byte FreeAetheryteId;

        [FieldOffset(0x2A0)] public uint BaseRestedExperience;

        [FieldOffset(0x454)] public short PlayerCommendations;

        [FieldOffset(0x6FE)] public fixed ushort DesynthesisLevels[8];

        public float GetDesynthesisLevel(uint classJobId) => classJobId is < 8 or > 15 ? 0 : DesynthesisLevels[classJobId - 8] / 100f;
    }
}

using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::Inspect
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2A0)]
public unsafe partial struct Inspect {
    [FieldOffset(0x0)] public bool IsInspectRequested;
    [FieldOffset(0x4)] public float RequestCooldown;
    [FieldOffset(0xC)] public uint EntityId;
    /// <remarks>0 = Not set/Retainer, 3 = Companion (Buddy), 4 = Player Character</remarks>
    [FieldOffset(0x10)] public byte Type;
    [FieldOffset(0x12)] public short WorldId;
    [FieldOffset(0x14), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _name;

    /// <remarks> PSN-Online-ID or Xbox-Gamertag </remarks>
    [FieldOffset(0x54), FixedSizeArray] internal FixedSizeArray17<byte> _onlineId; // this got bigger for the Gamertag, unsure about its size yet

    /// <remarks> Used for Grand Company rank. 0 = Male, 1 = Female </remarks>
    [FieldOffset(0x74)] public byte Sex;
    [FieldOffset(0x75)] public byte ClassJobId;
    [FieldOffset(0x76)] public byte Level;
    [FieldOffset(0x77)] public byte SyncedLevel;
    [FieldOffset(0x78)] public ushort AverageItemLevel;
    [FieldOffset(0x7A)] public ushort TitleId;
    [FieldOffset(0x7C)] public byte GrandCompanyIndex;
    [FieldOffset(0x7D)] public byte GrandCompanyRank;
    [FieldOffset(0x7E)] public CustomizeData CustomizeData;
    /// <remarks> Only valid when <see cref="Type"/> == 3. </remarks>
    [FieldOffset(0x98)] public byte BuddyEquipTop;
    /// <remarks> Only valid when <see cref="Type"/> == 3. </remarks>
    [FieldOffset(0x99)] public byte BuddyEquipBody;
    /// <remarks> Only valid when <see cref="Type"/> == 3. </remarks>
    [FieldOffset(0x9A)] public byte BuddyEquipLegs;

    [FieldOffset(0xA0), FixedSizeArray] internal FixedSizeArray2<WeaponModelId> _weaponModelIds;
    [FieldOffset(0xB0), FixedSizeArray] internal FixedSizeArray10<EquipmentModelId> _equipmentModelIds;
    [FieldOffset(0x100), FixedSizeArray] internal FixedSizeArray2<ushort> _glassesIds;
    [FieldOffset(0x104), FixedSizeArray] internal FixedSizeArray74<uint> _baseParams;
    [FieldOffset(0x22C)] private short UnkWord22C;
    [FieldOffset(0x22E)] public InspectGearVisibilityFlag GearVisibilityFlag;
    [FieldOffset(0x230)] public CrestData FreeCompanyCrestData;
    [FieldOffset(0x238)] public byte FreeCompanyCrestBitfield;
    [FieldOffset(0x239), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _buddyOwnerName;
    [FieldOffset(0x279)] public byte BuddyRank;
    [FieldOffset(0x27A)] public byte BuddyStain;
    [FieldOffset(0x27B)] public byte BuddyDefenderLevel;
    [FieldOffset(0x27C)] public byte BuddyAttackerLevel;
    [FieldOffset(0x27D)] public byte BuddyHealerLevel;

    /// <remarks> For easier access, use <see cref="GetContentValue"/>. </remarks>
    [FieldOffset(0x284), FixedSizeArray] internal FixedSizeArray3<StdPair<uint, uint>> _contentKeyValueData;

    /// <summary>
    /// Retrieves the value associated with the given key from ContentKeyValueData.<br/>
    /// Only loaded inside the relevant content.<br/>
    /// <br/>
    /// <code>
    /// |-----|-------------------|---------------------------|
    /// | Key | Content           | Usage                     |
    /// |-----|-------------------|---------------------------|
    /// |   1 | Eureka            | Elemental Level           |
    /// |   2 | Eureka            | Is Elemental Level Synced |
    /// |   3 | Eureka            | Time Remaining            |
    /// |   4 | Bozja             | Resistance Rank           |
    /// |   5 | Bozja             | Time Remaining            |
    /// |   6 | Occult Crescent   | Effective Knowledge Level |
    /// |   7 | Occult Crescent   | Knowledge Level           |
    /// |   8 | Occult Crescent   | Time Remaining            |
    /// |-----|-------------------|---------------------------|
    /// </code>
    /// </summary>
    public uint GetContentValue(uint key) {
        for (var i = 0; i < 3; i++) {
            var entry = ContentKeyValueData.GetPointer(i);
            if (entry->Item1 == key) {
                return entry->Item2;
            }
        }
        return 0;
    }
}

[Flags]
public enum InspectGearVisibilityFlag : byte {
    None = 0,
    VisorClosed = 1 << 0,
    HeadgearHidden = 1 << 1,
    WeaponHidden = 1 << 2,
}

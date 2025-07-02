namespace FFXIVClientStructs.FFXIV.Component.Text;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct MacroDecoder {
    [FieldOffset(0x08)] public StdVector<nint> DecoderFuncs; // idx is the macro code byte

    [FieldOffset(0x38)] public StdDeque<TextParameter> GlobalParameters;

    [StaticAddress("48 8D 1D ?? ?? ?? ?? 8B 43 20", 3)]
    public static partial Tm* GetMacroTime();
}

//
// GlobalParameters
// Note that the StdDeque (and this list) is zero-based, so you need to subtract 1 from gnum/gstr.
//
// |-------|----------------------|---------------------------------------------|
// | Index | Type                 | Label                                       |
// |-------|----------------------|---------------------------------------------|
// |     0 | ReferencedUtf8String | Player Name                                 |
// |     1 | String               | Temp Player 1 Name                          |
// |     2 | String               | Temp Player 2 Name                          |
// |     3 | Integer              | Player Sex                                  |
// |     4 | Integer              | Temp Player 1 Sex                           |
// |     5 | Integer              | Temp Player 2 Sex                           |
// |     6 | Integer              | Temp Player 1 Unk 1                         |
// |     7 | Integer              | Temp Player 2 Unk 1                         |
// |    10 | Integer              | Eorzea Time Hours                           |
// |    11 | Integer              | Eorzea Time Minutes                         |
// |    12 | Integer              | ColorSay                                    |
// |    13 | Integer              | ColorShout                                  |
// |    14 | Integer              | ColorTell                                   |
// |    15 | Integer              | ColorParty                                  |
// |    16 | Integer              | ColorAlliance                               |
// |    17 | Integer              | ColorLS1                                    |
// |    18 | Integer              | ColorLS2                                    |
// |    19 | Integer              | ColorLS3                                    |
// |    20 | Integer              | ColorLS4                                    |
// |    21 | Integer              | ColorLS5                                    |
// |    22 | Integer              | ColorLS6                                    |
// |    23 | Integer              | ColorLS7                                    |
// |    24 | Integer              | ColorLS8                                    |
// |    25 | Integer              | ColorFCompany                               |
// |    26 | Integer              | ColorPvPGroup                               |
// |    27 | Integer              | ColorPvPGroupAnnounce                       |
// |    28 | Integer              | ColorBeginner                               |
// |    29 | Integer              | ColorEmoteUser                              |
// |    30 | Integer              | ColorEmote                                  |
// |    31 | Integer              | ColorYell                                   |
// |    32 | Integer              | ColorFCAnnounce                             |
// |    33 | Integer              | ColorBeginnerAnnounce                       |
// |    34 | Integer              | ColorCWLS                                   |
// |    35 | Integer              | ColorAttackSuccess                          |
// |    36 | Integer              | ColorAttackFailure                          |
// |    37 | Integer              | ColorAction                                 |
// |    38 | Integer              | ColorItem                                   |
// |    39 | Integer              | ColorCureGive                               |
// |    40 | Integer              | ColorBuffGive                               |
// |    41 | Integer              | ColorDebuffGive                             |
// |    42 | Integer              | ColorEcho                                   |
// |    43 | Integer              | ColorSysMsg                                 |
// |    51 | Integer              | Player Grand Company Rank (Maelstrom)       |
// |    52 | Integer              | Player Grand Company Rank (Twin Adders)     |
// |    53 | Integer              | Player Grand Company Rank (Immortal Flames) |
// |    54 | ReferencedUtf8String | Companion Name                              |
// |    55 | ReferencedUtf8String | Content Name                                |
// |    56 | Integer              | ColorSysBattle                              |
// |    57 | Integer              | ColorSysGathering                           |
// |    58 | Integer              | ColorSysErr                                 |
// |    59 | Integer              | ColorNpcSay                                 |
// |    60 | Integer              | ColorItemNotice                             |
// |    61 | Integer              | ColorGrowup                                 |
// |    62 | Integer              | ColorLoot                                   |
// |    63 | Integer              | ColorCraft                                  |
// |    64 | Integer              | ColorGathering                              |
// |    65 | Integer              | Temp Player 1 Unk 2                         |
// |    66 | Integer              | Temp Player 2 Unk 2                         |
// |    67 | Integer              | Player ClassJobId                           |
// |    68 | Integer              | Player Level                                |
// |    70 | Integer              | Player Race                                 |
// |    71 | Integer              | Player Synced Level                         |
// |    77 | Integer              | Client/Plattform?                           |
// |    78 | Integer              | Player BirthMonth                           |
// |    82 | Integer              | Datacenter Region                           |
// |    83 | Integer              | ColorCWLS2                                  |
// |    84 | Integer              | ColorCWLS3                                  |
// |    85 | Integer              | ColorCWLS4                                  |
// |    86 | Integer              | ColorCWLS5                                  |
// |    87 | Integer              | ColorCWLS6                                  |
// |    88 | Integer              | ColorCWLS7                                  |
// |    89 | Integer              | ColorCWLS8                                  |
// |    91 | Integer              | Player Grand Company                        |
// |    92 | Integer              | TerritoryType Id                            |
// |    93 | Integer              | Is Soft Keyboard Enabled                    |
// |    94 | Integer              | LogSetRoleColor 1: LogColorRoleTank         |
// |    95 | Integer              | LogSetRoleColor 2: LogColorRoleTank         |
// |    96 | Integer              | LogSetRoleColor 1: LogColorRoleHealer       |
// |    97 | Integer              | LogSetRoleColor 2: LogColorRoleHealer       |
// |    98 | Integer              | LogSetRoleColor 1: LogColorRoleDPS          |
// |    99 | Integer              | LogSetRoleColor 2: LogColorRoleDPS          |
// |   100 | Integer              | LogSetRoleColor 1: LogColorOtherClass       |
// |   101 | Integer              | LogSetRoleColor 2: LogColorOtherClass       |
// |   102 | Integer              | Has Login Security Token                    |
// |   104 | Integer              | Is Pad Mouse Mode Enabled                   |
// |   107 | Integer              | Occult Crescent Support Job Level           |
// |-------|----------------------|---------------------------------------------|

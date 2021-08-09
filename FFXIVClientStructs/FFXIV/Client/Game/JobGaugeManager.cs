using System.Runtime.InteropServices;
using FFXIVClientStructs.Common;

namespace FFXIVClientStructs.FFXIV.Client.Game {
    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public unsafe partial struct JobGaugeManager {
        [FieldOffset(0x00)] public WhiteMageGauge* WhiteMage;
        [FieldOffset(0x00)] public ScholarGauge* Scholar;
        [FieldOffset(0x00)] public AstrologianGauge* Astrologian;

        [FieldOffset(0x00)] public BardGauge* Bard;
        [FieldOffset(0x00)] public MachinistGauge* Machinist;
        [FieldOffset(0x00)] public DancerGauge* Dancer;

        [FieldOffset(0x00)] public BlackMageGauge* BlackMage;
        [FieldOffset(0x00)] public SummonerGauge* Summoner;
        [FieldOffset(0x00)] public RedMageGauge* RedMage;

        [FieldOffset(0x00)] public MonkGauge* Monk;
        [FieldOffset(0x00)] public DragoonGauge* Dragoon;
        [FieldOffset(0x00)] public NinjaGauge* Ninja;
        [FieldOffset(0x00)] public SamuraiGauge* Samurai;
        
        [FieldOffset(0x00)] public DarkKnightGauge* DarkKnight;
        [FieldOffset(0x00)] public PaladinGauge* Paladin;
        [FieldOffset(0x00)] public WarriorGauge* Warrior;
        [FieldOffset(0x00)] public GunbreakerGauge* Gunbreaker;

        [FieldOffset(0x58)] public byte ClassJobID;

        [StaticAddress("48 8B 0D ?? ?? ?? ?? 48 85 C9 74 43")]
        public static partial JobGaugeManager* Instance();

        #region Healer

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct WhiteMageGauge {
            [FieldOffset(0x0A)] public short LilyTimer;
            [FieldOffset(0x0C)] public byte Lily;
            [FieldOffset(0x0D)] public byte BloodLily;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct ScholarGauge {
            [FieldOffset(0x08)] public short SeraphTimer;
            [FieldOffset(0x0A)] public byte Aetherflow;
            [FieldOffset(0x0B)] public byte FairyGauge;
            [FieldOffset(0x0E)] public byte DismissedFairy;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct AstrologianGauge {
            [FieldOffset(0x08)] public short Timer;
            [FieldOffset(0x0C)] public byte Card;
            [FieldOffset(0x0D)] public fixed byte Seals[3];
        }

        #endregion

        #region MagicDPS

        [StructLayout(LayoutKind.Explicit, Size = 0x30)]
        public struct BlackMageGauge {
            [FieldOffset(0x08)] public short EnochianTimer;
            [FieldOffset(0x0A)] public short ElementTimeRemaining;
            [FieldOffset(0x0C)] public byte ElementStance;
            [FieldOffset(0x0D)] public byte UmbralHearts;
            [FieldOffset(0x0E)] public byte PolyglotStacks;
            [FieldOffset(0x0F)] public byte Enochian;

            //ptr to the row in the Action sheet
            [FieldOffset(0x20)] public byte* BetweenTheLines; //7419
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct SummonerGauge {
            [FieldOffset(0x08)] public short TimerRemaining;
            [FieldOffset(0x0A)] public byte ReturnSummon;
            [FieldOffset(0x0B)] public byte ReturnSummonGlam;
            [FieldOffset(0x0C)] public byte AetherFlags;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x50)]
        public struct RedMageGauge {
            [FieldOffset(0x08)] public byte WhiteMana;
            [FieldOffset(0x09)] public byte BlackMana;

            //ptr to the row in the Action sheet
            [FieldOffset(0x10)] public byte* EnchantedRiposte; //7527
            [FieldOffset(0x18)] public byte* EnchantedZwerchhau; //7528
            [FieldOffset(0x20)] public byte* EnchantedRedoublement; //7529
            [FieldOffset(0x28)] public byte* EnchantedMoulinet; //7530
            [FieldOffset(0x30)] public byte* EnchantedReprise; //16528
            [FieldOffset(0x38)] public byte* Verholy; //9433
            [FieldOffset(0x40)] public byte* Verflare; //9434
            [FieldOffset(0x48)] public byte* EnchantedRiposte_PvP; //8887
        }

        #endregion

        #region RangeDPS

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct BardGauge {
            [FieldOffset(0x08)] public short SongTimer;
            [FieldOffset(0x0A)] public byte Repertoire;
            [FieldOffset(0x0B)] public byte SoulVoice;
            [FieldOffset(0x0C)] public byte Song;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct MachinistGauge {
            [FieldOffset(0x08)] public short OverheatTimeRemaining;
            [FieldOffset(0x0A)] public short SummonTimeRemaining;
            [FieldOffset(0x0C)] public byte Heat;
            [FieldOffset(0x0D)] public byte Battery;
            [FieldOffset(0x0E)] public byte LastSummonBatteryPower;
            [FieldOffset(0x0F)] public byte TimerActive;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct DancerGauge {
            [FieldOffset(0x08)] public byte Feathers;
            [FieldOffset(0x09)] public byte Esprit;
            [FieldOffset(0x0A)] public fixed byte DanceSteps[4];
            [FieldOffset(0x0E)] public byte StepIndex;
        }

        #endregion

        #region MeleeDPS

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct MonkGauge {
            [FieldOffset(0x08)] public byte Chakra;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct DragoonGauge {
            [FieldOffset(0x08)] public short BotdTimer;
            [FieldOffset(0x0A)] public byte BotdState;
            [FieldOffset(0x0B)] public byte EyeCount;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct NinjaGauge {
            [FieldOffset(0x08)] public int HutonTimer;
            [FieldOffset(0x0C)] public byte Ninki;
            [FieldOffset(0x0D)] public byte HutonManualCasts;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct SamuraiGauge {
            [FieldOffset(0x0B)] public byte Kenki;
            [FieldOffset(0x0C)] public byte MeditationStacks;
            [FieldOffset(0x0D)] public byte SenFlags;
        }

        #endregion

        #region Tanks

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct DarkKnightGauge {
            [FieldOffset(0x08)] public byte Blood;
            [FieldOffset(0x0A)] public short DarksideTimer;
            [FieldOffset(0x0C)] public byte DarkArtsState;
            [FieldOffset(0x0E)] public short ShadowTimer;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct PaladinGauge {
            [FieldOffset(0x08)] public byte OathGauge;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct WarriorGauge {
            [FieldOffset(0x08)] public byte BeastGauge;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct GunbreakerGauge {
            [FieldOffset(0x08)] public byte Ammo;
            [FieldOffset(0x0A)] public short MaxTimerDuration;
            [FieldOffset(0x0C)] public byte AmmoComboStep;
        }

        #endregion
    }
}
using System;
using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI {
    [Addon("_PartyList")]
    [StructLayout(LayoutKind.Explicit, Size = 0xFF8)]
    public unsafe struct AddonPartyList {
        [FieldOffset(0x000)] public AtkUnitBase AtkUnitBase;
        [FieldOffset(0x220)] public PartyMembers PartyMember;
        [FieldOffset(0xA20)] public PartyListMemberStruct Unknown08;
        [FieldOffset(0xB20)] public PartyListMemberStruct Unknown09;
        [FieldOffset(0xC20)] public PartyListMemberStruct Unknown10;
        [FieldOffset(0xD20)] public PartyListMemberStruct Chocobo;
        [FieldOffset(0xE20)] public PartyListMemberStruct Pet;
        
        [FieldOffset(0xF20)] public fixed uint PartyClassJobIconId[8];

        [FieldOffset(0xF8A)] public fixed short Edited[12]; //0X11 if edited? Need comfirm

        [FieldOffset(0xFA8)] public AtkNineGridNode* BackgroundNineGridNode; 
        [FieldOffset(0xFB0)] public AtkTextNode* PartyTypeTextNode; //Solo Light/Full Party
        [FieldOffset(0xFB8)] public AtkResNode* LeaderMarkResNode; 
        [FieldOffset(0xFC0)] public AtkResNode* MpBarSpecialResNode; 
        [FieldOffset(0xFC8)] public AtkTextNode* MpBarSpecialTextNode; 
        [FieldOffset(0xFD0)] public int MemberCount;
        [FieldOffset(0xFD4)] public int UnknownCount;
        [FieldOffset(0xFD8)] public int EnmityLeaderIndex; //Starts from 0 ,if no leader : -1
        [FieldOffset(0xFDC)] public int HideWhenSolo;
        
        [FieldOffset(0xFE0)] public int HoveredIndex;
        [FieldOffset(0xFE4)] public int TargetedIndex;
        [FieldOffset(0xFEC)] public int UnknownFEC;
        [FieldOffset(0xFE8)] public int UnknownFE8;
        [FieldOffset(0xFF0)] public byte UnknownFF0;
        [FieldOffset(0xFF1)] public byte PetCount; //or PetSummoned?
        [FieldOffset(0xFF2)] public byte ChocoboCount;//or ChocoboSummoned?

        [StructLayout(LayoutKind.Explicit, Size = 0x800)]
        public struct PartyMembers {
            [FieldOffset(0x000)] public PartyListMemberStruct PartyMember0;
            [FieldOffset(0x100)] public PartyListMemberStruct PartyMember1;
            [FieldOffset(0x200)] public PartyListMemberStruct PartyMember2;
            [FieldOffset(0x300)] public PartyListMemberStruct PartyMember3;
            [FieldOffset(0x400)] public PartyListMemberStruct PartyMember4;
            [FieldOffset(0x500)] public PartyListMemberStruct PartyMember5;
            [FieldOffset(0x600)] public PartyListMemberStruct PartyMember6;
            [FieldOffset(0x700)] public PartyListMemberStruct PartyMember7;

            public PartyListMemberStruct this[int i] {
                get {
                    return i switch {
                        0 => PartyMember0,
                        1 => PartyMember1,
                        2 => PartyMember2,
                        3 => PartyMember3,
                        4 => PartyMember4,
                        5 => PartyMember5,
                        6 => PartyMember6,
                        7 => PartyMember7,
                        _ => throw new IndexOutOfRangeException("Index should be in range of 0-7")
                    };
                }
            }
        }
        
        
        [StructLayout(LayoutKind.Explicit, Size = 0x100)]
        public struct PartyListMemberStruct {
            
            [FieldOffset(0x00)] public StatusIcons StatusIcon;
            [FieldOffset(0x50)] public AtkComponentBase* PartyMemberComponent;
            [FieldOffset(0x58)] public AtkTextNode* IconBottomLeftText;
            [FieldOffset(0x60)] public AtkResNode* NameAndBarsContainer;
            [FieldOffset(0x68)] public AtkTextNode* GroupSlotIndicator;
            [FieldOffset(0x70)] public AtkTextNode* Name;
            [FieldOffset(0x78)] public AtkTextNode* CastingActionName;
            [FieldOffset(0x80)] public AtkImageNode* CastingProgressBar;
            [FieldOffset(0x88)] public AtkImageNode* CastingProgressBarBackground;
            [FieldOffset(0x90)] public AtkResNode* EmnityBarContainer;
            [FieldOffset(0x98)] public AtkNineGridNode* EmnityBarFill;
            [FieldOffset(0xA0)] public AtkImageNode* ClassJobIcon;
            [FieldOffset(0xA8)] public void* UnknownA8;
            [FieldOffset(0xB0)] public AtkImageNode* UnknownImageB0;
            [FieldOffset(0xB8)] public void* UnknownB8;
            [FieldOffset(0xC0)] public AtkComponentBase* HPGaugeComponent;
            [FieldOffset(0xC8)] public AtkComponentGaugeBar* HPGaugeBar;
            [FieldOffset(0xD0)] public AtkComponentGaugeBar* MPGaugeBar;
            [FieldOffset(0xD8)] public AtkResNode* TargetGlowContainer;
            [FieldOffset(0xE0)] public AtkNineGridNode* ClickFlash;
            [FieldOffset(0xE8)] public AtkNineGridNode* TargetGlow;
            [FieldOffset(0xF0)] public AtkCollisionNode* CollisionNode;
            [FieldOffset(0xF8)] public byte EmnityByte;    //01 or 02 or FF 
            
            [StructLayout(LayoutKind.Explicit, Size = 0x50)]
            public struct StatusIcons {
                [FieldOffset(0x00)] public AtkComponentIconText* StatusIcon0;
                [FieldOffset(0x08)] public AtkComponentIconText* StatusIcon1;
                [FieldOffset(0x10)] public AtkComponentIconText* StatusIcon2;
                [FieldOffset(0x18)] public AtkComponentIconText* StatusIcon3;
                [FieldOffset(0x20)] public AtkComponentIconText* StatusIcon4;
                [FieldOffset(0x28)] public AtkComponentIconText* StatusIcon5;
                [FieldOffset(0x30)] public AtkComponentIconText* StatusIcon6;
                [FieldOffset(0x38)] public AtkComponentIconText* StatusIcon7;
                [FieldOffset(0x40)] public AtkComponentIconText* StatusIcon8;
                [FieldOffset(0x48)] public AtkComponentIconText* StatusIcon9;

                public AtkComponentIconText* this[int i] {
                    get {
                        return i switch {
                            0 => StatusIcon0,
                            1 => StatusIcon1,
                            2 => StatusIcon2,
                            3 => StatusIcon3,
                            4 => StatusIcon4,
                            5 => StatusIcon5,
                            6 => StatusIcon6,
                            7 => StatusIcon7,
                            8 => StatusIcon8,
                            9 => StatusIcon9,
                            _ => throw new IndexOutOfRangeException("Index should be in range of 0-9")
                        };
                    }
                }
            }
        }
    }
}

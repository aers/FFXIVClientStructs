using System;
using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Component::GUI::AddonWeeklyBingo
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x23C8)]
    public struct AddonWeeklyBingo
    {
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
        [FieldOffset(0x18E8)] public StringThing StringThing;
        [FieldOffset(0x1938)] public StickerSlotList StickerSlotList;
        [FieldOffset(0x1F20)] public uint NumStickersPlaced;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public unsafe struct StringThing
    {
        [FieldOffset(0x0)] public void* vtbl;

        [FieldOffset(0x08)]
        public byte*
            FullSealsText; // No more seals can be applied. Deliver the journal to Khloe Aliapoh to receive your reward.

        [FieldOffset(0x10)]
        public byte*
            OneOrMoreLinesText; // One or more lines of seals have been completed. Deliver the journal to Khloe Aliapoh to receive your reward or continue adventuring to add more seals.

        [FieldOffset(0x18)]
        public byte*
            SecondChancePointsText; // Second Chance points can be used to increase your chances of completing lines.

        [FieldOffset(0x20)] public byte* ReceiveSealCompleteText; // Select a completed duty to receive a seal.
        [FieldOffset(0x28)] public byte* ReceiveSealIncompleteText; // Complete a task to receive a seal.
        [FieldOffset(0x30)] public byte* SecondChanceRetryText; // Select a completed duty to be rendered incomplete.
        [FieldOffset(0x40)] public void* addon;
        [FieldOffset(0x48)] public AtkTextNode* TextNode;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x590)]
    public unsafe struct StickerSlotList
    {
        [FieldOffset(0x0)] public void** vtbl;
        [FieldOffset(0x8)] public void* addon; // AddonWeeklyBingo*
        [FieldOffset(0x10)] public StickerSlot StickerSlot1;
        [FieldOffset(0x68)] public StickerSlot StickerSlot2;
        [FieldOffset(0xC0)] public StickerSlot StickerSlot3;
        [FieldOffset(0x118)] public StickerSlot StickerSlot4;
        [FieldOffset(0x170)] public StickerSlot StickerSlot5;
        [FieldOffset(0x1C8)] public StickerSlot StickerSlot6;
        [FieldOffset(0x220)] public StickerSlot StickerSlot7;
        [FieldOffset(0x278)] public StickerSlot StickerSlot8;
        [FieldOffset(0x2D0)] public StickerSlot StickerSlot9;
        [FieldOffset(0x328)] public StickerSlot StickerSlot10;
        [FieldOffset(0x380)] public StickerSlot StickerSlot11;
        [FieldOffset(0x3D8)] public StickerSlot StickerSlot12;
        [FieldOffset(0x430)] public StickerSlot StickerSlot13;
        [FieldOffset(0x488)] public StickerSlot StickerSlot14;
        [FieldOffset(0x4E0)] public StickerSlot StickerSlot15;
        [FieldOffset(0x538)] public StickerSlot StickerSlot16;

        public StickerSlot this[int index] => index switch
        {
            0 => StickerSlot1,
            1 => StickerSlot2,
            2 => StickerSlot3,
            3 => StickerSlot4,
            4 => StickerSlot5,
            5 => StickerSlot6,
            6 => StickerSlot7,
            7 => StickerSlot8,
            8 => StickerSlot9,
            9 => StickerSlot10,
            10 => StickerSlot11,
            11 => StickerSlot12,
            12 => StickerSlot13,
            13 => StickerSlot14,
            14 => StickerSlot15,
            15 => StickerSlot16,
            _ => throw new ArgumentOutOfRangeException("Valid indexes are 0 through 15 inclusive.")
        };
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public unsafe struct StickerSlot
    {
        [FieldOffset(0x0)] public void** vtbl;
        [FieldOffset(0x8)] public void* addon; // AddonWeeklyBingo*
        [FieldOffset(0x10)] public int index; // 1-16

        [FieldOffset(0x20)] public AtkComponentButton* Button;

        // ComponentBase > ResNode > ImageNode (no ptr)
        [FieldOffset(0x28)] public AtkComponentBase* StickerComponentBase;
        [FieldOffset(0x30)] public AtkComponentBase* StickerShadowComponentBase;
        [FieldOffset(0x38)] public AtkResNode* StickerResNode;
        [FieldOffset(0x40)] public AtkResNode* StickerShadowResNode;
        [FieldOffset(0x48)] public AtkComponentBase* StickerSidebarBase;
        [FieldOffset(0x50)] public AtkResNode* StickerSidebarResNode;
    }
}
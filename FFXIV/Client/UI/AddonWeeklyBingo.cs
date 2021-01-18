using FFXIVClientStructs.FFXIV.Component.GUI;
using System;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Component::GUI::AddonWeeklyBingo
    //   Component::GUI::AtkUnitBase
    //     Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size = 0x23C8)]
    public unsafe struct AddonWeeklyBingo
    {
        [FieldOffset(0x0)] public AtkUnitBase AtkUnitBase;
        [FieldOffset(0x248)] public BingoSlot BingoSlot1;
        [FieldOffset(0x3B0)] public BingoSlot BingoSlot2;
        [FieldOffset(0x518)] public BingoSlot BingoSlot3;
        [FieldOffset(0x680)] public BingoSlot BingoSlot4;
        [FieldOffset(0x7E8)] public BingoSlot BingoSlot5;
        [FieldOffset(0x950)] public BingoSlot BingoSlot6;
        [FieldOffset(0xAB8)] public BingoSlot BingoSlot7;
        [FieldOffset(0xC20)] public BingoSlot BingoSlot8;
        [FieldOffset(0xD88)] public BingoSlot BingoSlot9;
        [FieldOffset(0xEF0)] public BingoSlot BingoSlot10;
        [FieldOffset(0x1058)] public BingoSlot BingoSlot11;
        [FieldOffset(0x11C0)] public BingoSlot BingoSlot12;
        [FieldOffset(0x1328)] public BingoSlot BingoSlot13;
        [FieldOffset(0x1490)] public BingoSlot BingoSlot14;
        [FieldOffset(0x15F8)] public BingoSlot BingoSlot15;
        [FieldOffset(0x1760)] public BingoSlot BingoSlot16;
        [FieldOffset(0x1948)] public BingoSlotSomething BingoSlotSomething1;
        [FieldOffset(0x19A0)] public BingoSlotSomething BingoSlotSomething2;
        [FieldOffset(0x19F8)] public BingoSlotSomething BingoSlotSomething3;
        [FieldOffset(0x1A50)] public BingoSlotSomething BingoSlotSomething4;
        [FieldOffset(0x1AA8)] public BingoSlotSomething BingoSlotSomething5;
        [FieldOffset(0x1B00)] public BingoSlotSomething BingoSlotSomething6;
        [FieldOffset(0x1B58)] public BingoSlotSomething BingoSlotSomething7;
        [FieldOffset(0x1BB0)] public BingoSlotSomething BingoSlotSomething8;
        [FieldOffset(0x1C08)] public BingoSlotSomething BingoSlotSomething9;
        [FieldOffset(0x1C60)] public BingoSlotSomething BingoSlotSomething10;
        [FieldOffset(0x1CB8)] public BingoSlotSomething BingoSlotSomething11;
        [FieldOffset(0x1D10)] public BingoSlotSomething BingoSlotSomething12;
        [FieldOffset(0x1D68)] public BingoSlotSomething BingoSlotSomething13;
        [FieldOffset(0x1DC0)] public BingoSlotSomething BingoSlotSomething14;
        [FieldOffset(0x1E18)] public BingoSlotSomething BingoSlotSomething15;
        [FieldOffset(0x1E70)] public BingoSlotSomething BingoSlotSomething16;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x168)]
    public unsafe struct BingoSlot
    {
        [FieldOffset(0x0)] public void* vtblUnkEventListener;
        [FieldOffset(0x8)] public void* thisWeeklyBingoAddon;
        [FieldOffset(0x32)] public char[] DutyString;  // size?
        [FieldOffset(0x138)] public AtkComponentButton* AtkComponentButton138;
        [FieldOffset(0x140)] public AtkImageNode* AtkImageNode140;
        [FieldOffset(0x148)] public AtkResNode* AtkResNode148;
        [FieldOffset(0x150)] public AtkResNode* AtkResNode150;
        [FieldOffset(0x158)] public AtkTextNode* AtkTextNode158;
        [FieldOffset(0x160)] public AtkResNode* AtkResNode160;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public unsafe struct BingoSlotSomething
    {
        [FieldOffset(0x0)] public void* vtblUnk;
        [FieldOffset(0x8)] public void* thisWeeklyBingoAddon;
        [FieldOffset(0x20)] public AtkComponentButton* AtkComponentButton20;
        [FieldOffset(0x28)] public AtkComponentBase* AtkComponentBase28;
        [FieldOffset(0x30)] public AtkComponentBase* AtkComponentBase30;
        [FieldOffset(0x38)] public AtkResNode* AtkResNode38;
        [FieldOffset(0x40)] public AtkResNode* AtkResNode40;
        [FieldOffset(0x50)] public AtkResNode* AtkResNode50;
    }
}

using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentPointMenu
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.PointMenu)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x48)]
public unsafe partial struct AgentPointMenu {
    [FieldOffset(0x28)] public PointMenuContext* Context;
    [FieldOffset(0x30)] public StdMap<int, int>* CompletionData;
    [FieldOffset(0x38)] public int Phase;
    [FieldOffset(0x3C)] public int SelectedIndex;
    [FieldOffset(0x40)] private uint unkInt40;
    [FieldOffset(0x44)] private byte unkByte44;

    // Allocates a PointMenuContext and loads Excel Sheet PointMenu (1181)
    [MemberFunction("40 55 41 56 41 57 48 83 EC ?? 48 8B 01 45 8B F8")]
    public partial PointMenuContext* CreateContext(uint eventType, int unk);
    
    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 55 57 41 54 41 56 41 57 48 8D 6C 24 ?? 48 81 EC ?? ?? ?? ?? 0F 29 B4 24")]
    public partial void SendEntryToAddon(uint index);

    [StructLayout(LayoutKind.Explicit, Size = 0x140)]
    public struct PointMenuContext {
        [FieldOffset(0x00)] public AgentPointMenu* Agent;
        [FieldOffset(0x08)] private void* unk08;
        [FieldOffset(0x10)] private void* unk10;
        [FieldOffset(0x18)] public ExcelSheetWaiter SheetWaiter;
        [FieldOffset(0xB8)] public Utf8String TitleText;
        [FieldOffset(0x120)] public StdVector<PointMenuEntry> Entries;
        [FieldOffset(0x138)] public uint EventType;
        [FieldOffset(0x13C)] public bool IsLoaded;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x88)]
    public struct PointMenuEntry {
        [FieldOffset(0x00)] public float X;
        [FieldOffset(0x04)] public float Y;
        [FieldOffset(0x08)] public float ClickAreaX;
        [FieldOffset(0x0C)] public float ClickAreaY;
        [FieldOffset(0x10)] public float ClickAreaWidth;
        [FieldOffset(0x14)] public float ClickAreaHeight;
        [FieldOffset(0x1A)] public byte State;
        [FieldOffset(0x1B)] public byte IsElliptical;
        [FieldOffset(0x1C)] public byte NavUp;
        [FieldOffset(0x1D)] public byte NavDown;
        [FieldOffset(0x1E)] public byte NavLeft;
        [FieldOffset(0x1F)] public byte NavRight;
        [FieldOffset(0x20)] public Utf8String Text;
    }
}

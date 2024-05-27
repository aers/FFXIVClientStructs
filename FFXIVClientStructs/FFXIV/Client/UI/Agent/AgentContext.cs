using System.Drawing;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Context)]
[StructLayout(LayoutKind.Explicit, Size = 0x1750)]
public unsafe partial struct AgentContext {
    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FixedSizeArray<ContextMenu>(2)]
    [FieldOffset(0x28)] public fixed byte ContextMenuArray[0x678 * 2];
    [FieldOffset(0x28), Obsolete("Use ContextMenuArraySpan[0]")] public ContextMenu MainContextMenu;
    [FieldOffset(0x6A0), Obsolete("Use ContextMenuArraySpan[0]")] public ContextMenu SubContextMenu;
    [FieldOffset(0xD18)] public ContextMenu* CurrentContextMenu;
    [FieldOffset(0xD20)] public Utf8String ContextMenuTitle;
    [FieldOffset(0xD88)] public Point Position;
    [FieldOffset(0xD90)] public uint OwnerAddon;

    [FieldOffset(0xDA0)] public InfoProxyCommonList.CharacterData ContextMenuTarget;
    [FieldOffset(0xE08)] public InfoProxyCommonList.CharacterData* CurrentContextMenuTarget;
    [FieldOffset(0xE10)] public Utf8String TargetName;
    [FieldOffset(0xE78)] public Utf8String YesNoTargetName;

    [FieldOffset(0xEE8)] public ulong TargetContentId;
    [FieldOffset(0xEF0)] public ulong YesNoTargetContentId;
    [FieldOffset(0xEF8)] public GameObjectID TargetObjectId;
    [FieldOffset(0xF00)] public GameObjectID YesNoTargetObjectId;
    [FieldOffset(0xF08)] public short TargetHomeWorldId;
    [FieldOffset(0xF0A)] public short YesNoTargetHomeWorldId;
    [FieldOffset(0xF0C)] public byte YesNoEventId;

    [FieldOffset(0xF10)] public int TargetSex;
    [Obsolete("Renamed to TargetSex")]
    [FieldOffset(0xF10)] public int TargetGender;
    [FieldOffset(0xF14)] public uint TargetMountSeats;

    [FieldOffset(0x1738)] public void* UpdateChecker; // AgentContextUpdateChecker*, if handler returns false the menu closes
    [FieldOffset(0x1740)] public long UpdateCheckerParam; //objectid of the target or list index of an addon or other things
    [FieldOffset(0x1748)] public byte ContextMenuIndex;
    [FieldOffset(0x1749)] public byte OpenAtPosition; // if true menu opens at Position else at cursor location

    [MemberFunction("E8 ?? ?? ?? ?? 45 88 7C 24")]
    public partial void OpenContextMenu(bool bindToOwner = true, bool closeExisting = true);

    [MemberFunction("41 0F B6 C0 89 91")]
    public partial void OpenContextMenuForAddon(uint ownerAddonId, bool bindToOwner = true);

    [MemberFunction("E8 ?? ?? ?? ?? 44 39 A3 ?? ?? ?? ?? 0F 86")]
    public partial bool OpenSubMenu();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4D E0 E9 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 0F B7 93")]
    [GenerateCStrOverloads]
    public partial void OpenYesNo(byte* text, uint yesId = 576, uint noId = 577, uint checkboxId = 0,
        bool setOwner = true);

    [MemberFunction("E8 ?? ?? ?? ?? 40 80 F6")]
    public partial void ClearMenu();

    [MemberFunction("E8 ?? ?? ?? ?? 41 BF ?? ?? ?? ?? 48 8D 44 24 ?? 41 8B D7")]
    [GenerateCStrOverloads]
    public partial void SetMenuTitle(byte* text);

    [MemberFunction("E8 ?? ?? ?? ?? FF CE 48 FF CF")]
    [GenerateCStrOverloads]
    public partial void AddMenuItem(byte* text, void* handler, long handlerParam, bool disabled = false,
        bool submenu = false);

    [MemberFunction("E8 ?? ?? ?? ?? 49 69 D6")]
    public partial void AddMenuItem2(uint addonTextId, void* handler, long handlerParam, bool disabled = false,
        bool submenu = false);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B 99 ?? ?? ?? ?? 4C 8B D1")]
    [GenerateCStrOverloads]
    public partial void AddContextMenuItem(int eventId, byte* text, bool disabled = false, bool submenu = false,
        bool copyText = true);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 85 F6 74 3F")]
    public partial void AddContextMenuItem2(int eventId, uint addonTextId, bool disabled = false, bool submenu = false,
        bool copyText = true);

    public void SetPosition(int x, int y) {
        Position.X = x;
        Position.Y = y;
        OpenAtPosition = 1;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x678)]
public unsafe partial struct ContextMenu {
    [FieldOffset(0x00)] public short CurrentEventIndex;
    [FieldOffset(0x02)] public short CurrentEventId;

    [FixedSizeArray<AtkValue>(33)]
    [FieldOffset(0x08)] public fixed byte EventParams[0x10 * 33]; // 32 * AtkValue + 1 * AtkValue for submenus with title

    [FieldOffset(0x428)] public fixed byte EventIdArray[32];
    [FieldOffset(0x450)] public fixed long EventHandlerArray[32];
    [FieldOffset(0x558)] public fixed long EventHandlerParamArray[32];

    [FieldOffset(0x660)] public uint ContextItemDisabledMask;
    [FieldOffset(0x664)] public uint ContextSubMenuMask;
    [FieldOffset(0x668)] public byte* ContextTitleString;
    [FieldOffset(0x670)] public byte SelectedContextItemIndex;
}

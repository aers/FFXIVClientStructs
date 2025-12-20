using System.Drawing;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using FFXIVClientStructs.FFXIV.Component.GUI;
using AtkEventInterface = FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface.AtkEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentContext
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.Context)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x1840)]
public unsafe partial struct AgentContext {

    [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray2<ContextMenu> _contextMenus;
    [FieldOffset(0x28), CExporterIgnore] public ContextMenu MainContextMenu;
    [FieldOffset(0x6D0), CExporterIgnore] public ContextMenu SubContextMenu;
    [FieldOffset(0xD78)] public ContextMenu* CurrentContextMenu;
    [FieldOffset(0xD80)] public Utf8String ContextMenuTitle;
    [FieldOffset(0xDE8)] public Point Position;
    [FieldOffset(0xDF0)] public uint OwnerAddon;

    [FieldOffset(0xE00)] public InfoProxyCommonList.CharacterData ContextMenuTarget;
    [FieldOffset(0xE70)] public InfoProxyCommonList.CharacterData* CurrentContextMenuTarget;

    [FieldOffset(0xEE0)] public Utf8String TargetName;
    [FieldOffset(0xF48)] public Utf8String YesNoTargetName;

    [FieldOffset(0xFB8)] public ulong TargetAccountId;
    [FieldOffset(0xFC0)] public ulong TargetContentId;
    [FieldOffset(0xFC8)] public ulong YesNoTargetAccountId;
    [FieldOffset(0xFD0)] public ulong YesNoTargetContentId;
    [FieldOffset(0xFD8)] public GameObjectId TargetObjectId;
    [FieldOffset(0xFE0)] public GameObjectId YesNoTargetObjectId;
    [FieldOffset(0xFE8)] public short TargetHomeWorldId;
    [FieldOffset(0xFEA)] public short YesNoTargetHomeWorldId;
    [FieldOffset(0xFEC)] public byte YesNoEventId;

    [FieldOffset(0xFF0)] public int TargetSex;
    [FieldOffset(0xFF4)] public uint TargetMountSeats;

    [FieldOffset(0x1828)] public void* UpdateChecker; // AgentContextUpdateChecker*, if handler returns false the menu closes
    [FieldOffset(0x1830)] public long UpdateCheckerParam; //objectid of the target or list index of an addon or other things
    [FieldOffset(0x1838)] public BlockFunctionsFlag ContextMenuBlockFunctionsFlags;
    [FieldOffset(0x1839)] public byte ContextMenuIndex;
    [FieldOffset(0x183A)] public byte OpenAtPosition; // if true menu opens at Position else at cursor location

    [MemberFunction("E8 ?? ?? ?? ?? 4C 89 6B ?? E9")]
    public partial void OpenContextMenu(bool bindToOwner = true, bool closeExisting = true);

    [MemberFunction("E8 ?? ?? ?? ?? 45 32 C0 E9")]
    public partial void OpenContextMenuForAddon(uint ownerAddonId, bool bindToOwner = true);

    [MemberFunction("E8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 4C 8B 86")]
    public partial bool OpenSubMenu();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4D ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B CB E8 ?? ?? ?? ?? 0F B7 B3")]
    [GenerateStringOverloads]
    public partial void OpenYesNo(CStringPointer text, uint yesId = 576, uint noId = 577, uint checkboxId = 0, bool setOwner = true);

    [MemberFunction("E8 ?? ?? ?? ?? 48 6B CE 3C")]
    public partial void ClearMenu();

    [MemberFunction("E8 ?? ?? ?? ?? 41 BF ?? ?? ?? ?? 48 8D 44 24 ?? 41 8B D7")]
    [GenerateStringOverloads]
    public partial void SetMenuTitle(CStringPointer text);

    [MemberFunction("E8 ?? ?? ?? ?? FF CE 48 FF CF")]
    [GenerateStringOverloads]
    public partial void AddMenuItem(CStringPointer text, AtkEventInterface* handler, long handlerParam, bool disabled = false, bool submenu = false);

    [MemberFunction("E8 ?? ?? ?? ?? 83 FD 0D")]
    public partial void AddMenuItem2(uint addonTextId, AtkEventInterface* handler, long handlerParam, bool disabled = false, bool submenu = false);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 4C 8B 99 ?? ?? ?? ?? 4C 8B D1 41 0F B6 F1 49 8B F8 8B DA 41 0F B7 0B 66 83 F9 22 0F 8D ?? ?? ?? ?? 8D 42 FF 83 F8 6F")]
    [GenerateStringOverloads]
    public partial void AddContextMenuItem(int eventId, CStringPointer text, bool disabled = false, bool submenu = false, bool copyText = true);

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 ED 79 0F")]
    public partial void AddContextMenuItem2(int eventId, uint addonTextId, bool disabled = false, bool submenu = false);

    public void SetPosition(int x, int y) {
        Position.X = x;
        Position.Y = y;
        OpenAtPosition = 1;
    }

    [Flags]
    public enum BlockFunctionsFlag : byte {
        None = 0,
        Blacklisted = 1 << 0,
        Muted = 1 << 1,
        TermFiltered = 1 << 2
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x6A8)]
public unsafe partial struct ContextMenu {
    [FieldOffset(0x00)] public short CurrentEventIndex;
    [FieldOffset(0x02)] public short CurrentEventId;

    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray34<AtkValue> _eventParams; // 32 * AtkValue + 1 * AtkValue for submenus with title + 1 * unk

    [FieldOffset(0x448), FixedSizeArray] internal FixedSizeArray34<byte> _eventIds;
    [FieldOffset(0x470), FixedSizeArray] internal FixedSizeArray34<Pointer<AtkEventInterface>> _eventHandlers;
    [FieldOffset(0x580), FixedSizeArray] internal FixedSizeArray34<long> _eventHandlerParams;

    [FieldOffset(0x690)] public uint ContextItemDisabledMask;
    [FieldOffset(0x694)] public uint ContextSubMenuMask;
    [FieldOffset(0x698)] public CStringPointer ContextTitleString;
    [FieldOffset(0x6A0)] public byte SelectedContextItemIndex;
}

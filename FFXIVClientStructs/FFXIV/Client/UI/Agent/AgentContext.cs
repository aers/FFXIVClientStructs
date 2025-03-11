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
[StructLayout(LayoutKind.Explicit, Size = 0x17E0)]
public unsafe partial struct AgentContext {

    [FieldOffset(0x28), FixedSizeArray] internal FixedSizeArray2<ContextMenu> _contextMenus;
    [FieldOffset(0x28), CExportIgnore] public ContextMenu MainContextMenu;
    [FieldOffset(0x6A0), CExportIgnore] public ContextMenu SubContextMenu;
    [FieldOffset(0xD18)] public ContextMenu* CurrentContextMenu;
    [FieldOffset(0xD20)] public Utf8String ContextMenuTitle;
    [FieldOffset(0xD88)] public Point Position;
    [FieldOffset(0xD90)] public uint OwnerAddon;

    [FieldOffset(0xDA0)] public InfoProxyCommonList.CharacterData ContextMenuTarget;
    [FieldOffset(0xE10)] public InfoProxyCommonList.CharacterData* CurrentContextMenuTarget;

    [FieldOffset(0xE80)] public Utf8String TargetName;
    [FieldOffset(0xEE8)] public Utf8String YesNoTargetName;

    [FieldOffset(0xF58)] public ulong TargetAccountId;
    [FieldOffset(0xF60)] public ulong TargetContentId;
    [FieldOffset(0xF68)] public ulong YesNoTargetAccountId;
    [FieldOffset(0xF70)] public ulong YesNoTargetContentId;
    [FieldOffset(0xF78)] public GameObjectId TargetObjectId;
    [FieldOffset(0xF80)] public GameObjectId YesNoTargetObjectId;
    [FieldOffset(0xF88)] public short TargetHomeWorldId;
    [FieldOffset(0xF8A)] public short YesNoTargetHomeWorldId;
    [FieldOffset(0xF8C)] public byte YesNoEventId;

    [FieldOffset(0xF90)] public int TargetSex;
    [FieldOffset(0xF94)] public uint TargetMountSeats;

    [FieldOffset(0x17C8)] public void* UpdateChecker; // AgentContextUpdateChecker*, if handler returns false the menu closes
    [FieldOffset(0x17D0)] public long UpdateCheckerParam; //objectid of the target or list index of an addon or other things
    [FieldOffset(0x17D8)] public BlockFunctionsFlag ContextMenuBlockFunctionsFlags;
    [FieldOffset(0x17D9)] public byte ContextMenuIndex;
    [FieldOffset(0x17DA)] public byte OpenAtPosition; // if true menu opens at Position else at cursor location

    [MemberFunction("E8 ?? ?? ?? ?? 45 88 74 24")]
    public partial void OpenContextMenu(bool bindToOwner = true, bool closeExisting = true);

    [MemberFunction("41 0F B6 C0 89 91")]
    public partial void OpenContextMenuForAddon(uint ownerAddonId, bool bindToOwner = true);

    [MemberFunction("E8 ?? ?? ?? ?? 44 39 BB ?? ?? ?? ?? 0F 86 ?? ?? ?? ??")]
    public partial bool OpenSubMenu();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4B 10 48 8B 01 FF 90 ?? ?? ?? ?? B2 01")]
    [GenerateStringOverloads]
    public partial void OpenYesNo(byte* text, uint yesId = 576, uint noId = 577, uint checkboxId = 0, bool setOwner = true);

    [MemberFunction("E8 ?? ?? ?? ?? 48 6B CE 3C")]
    public partial void ClearMenu();

    [MemberFunction("E8 ?? ?? ?? ?? 41 BF ?? ?? ?? ?? 48 8D 44 24 ?? 41 8B D7")]
    [GenerateStringOverloads]
    public partial void SetMenuTitle(byte* text);

    [MemberFunction("E8 ?? ?? ?? ?? FF CE 48 FF CF")]
    [GenerateStringOverloads]
    public partial void AddMenuItem(byte* text, AtkEventInterface* handler, long handlerParam, bool disabled = false, bool submenu = false);

    [MemberFunction("E8 ?? ?? ?? ?? 83 FD 0D")]
    public partial void AddMenuItem2(uint addonTextId, AtkEventInterface* handler, long handlerParam, bool disabled = false, bool submenu = false);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B 99 ?? ?? ?? ?? 4C 8B D1")]
    [GenerateStringOverloads]
    public partial void AddContextMenuItem(int eventId, byte* text, bool disabled = false, bool submenu = false, bool copyText = true);

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 ED 79 0F")]
    public partial void AddContextMenuItem2(int eventId, uint addonTextId, bool disabled = false, bool submenu = false, bool copyText = true);

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
[StructLayout(LayoutKind.Explicit, Size = 0x678)]
public unsafe partial struct ContextMenu {
    [FieldOffset(0x00)] public short CurrentEventIndex;
    [FieldOffset(0x02)] public short CurrentEventId;

    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray33<AtkValue> _eventParams; // 32 * AtkValue + 1 * AtkValue for submenus with title

    [FieldOffset(0x428), FixedSizeArray] internal FixedSizeArray32<byte> _eventIds;
    [FieldOffset(0x450), FixedSizeArray] internal FixedSizeArray32<Pointer<AtkEventInterface>> _eventHandlers;
    [FieldOffset(0x558), FixedSizeArray] internal FixedSizeArray32<long> _eventHandlerParams;

    [FieldOffset(0x660)] public uint ContextItemDisabledMask;
    [FieldOffset(0x664)] public uint ContextSubMenuMask;
    [FieldOffset(0x668)] public StringPointer ContextTitleString;
    [FieldOffset(0x670)] public byte SelectedContextItemIndex;
}

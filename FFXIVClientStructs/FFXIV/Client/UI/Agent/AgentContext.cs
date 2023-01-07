using System.Drawing;
using System.Text;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.Context)]
[StructLayout(LayoutKind.Explicit, Size = 0x1748)]
public unsafe partial struct AgentContext
{
    public static AgentContext* Instance()
    {
        return (AgentContext*) Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(
            AgentId.Context);
    }

    [FieldOffset(0x00)] public AgentInterface AgentInterface;

    [FieldOffset(0x28)] public fixed byte ContextMenuArray[0x678 * 2];
    [FieldOffset(0x28)] public ContextMenu MainContextMenu;
    [FieldOffset(0x6A0)] public ContextMenu SubContextMenu;

    [FieldOffset(0xD18)] public ContextMenu* CurrentContextMenu;
    [FieldOffset(0xD20)] public Utf8String ContextMenuTitle;
    [FieldOffset(0xD88)] public Point Position;
    [FieldOffset(0xD90)] public uint OwnerAddon;

    [FieldOffset(0xDA0)] public ContextMenuTarget ContextMenuTarget;
    [FieldOffset(0xE00)] public ContextMenuTarget* CurrentContextMenuTarget;
    [FieldOffset(0xE08)] public Utf8String TargetName;
    [FieldOffset(0xE70)] public Utf8String YesNoTargetName;

    [FieldOffset(0xEE0)] public ulong TargetContentId;
    [FieldOffset(0xEE8)] public ulong YesNoTargetContentId;
    [FieldOffset(0xEF0)] public GameObjectID TargetObjectId;
    [FieldOffset(0xEF8)] public GameObjectID YesNoTargetObjectId;
    [FieldOffset(0xF00)] public short TargetHomeWorldId;
    [FieldOffset(0xF02)] public short YesNoTargetHomeWorldId;
    [FieldOffset(0xF04)] public byte YesNoEventId;

    [FieldOffset(0xF08)] public int TargetGender;
    [FieldOffset(0xF0C)] public uint TargetMountSeats;

    [FieldOffset(0x1730)]
    public void* UpdateChecker; // AgentContextUpdateChecker*, if handler returns false the menu closes

    [FieldOffset(0x1738)]
    public long UpdateCheckerParam; //objectid of the target or list index of an addon or other things

    [FieldOffset(0x1740)] public byte ContextMenuIndex;
    [FieldOffset(0x1741)] public byte OpenAtPosition; // if true menu opens at Position else at cursor location

    [MemberFunction("E8 ?? ?? ?? ?? 45 88 7C 24")]
    public partial void OpenContextMenu(bool bindToOwner = true, bool closeExisting = true);

    [MemberFunction("41 0F B6 C0 89 91")]
    public partial void OpenContextMenuForAddon(uint ownerAddonId, bool bindToOwner = true);

    [MemberFunction("E8 ?? ?? ?? ?? 44 39 A3 ?? ?? ?? ?? 0F 86")]
    public partial bool OpenSubMenu();

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4B ?? 48 8B 01 FF 90 ?? ?? ?? ?? B2 ?? 48 8B 48")]
    public partial void OpenYesNo(byte* text, uint yesId = 576, uint noId = 577, uint checkboxId = 0,
        bool setOwner = true);

    [MemberFunction("E8 ?? ?? ?? ?? 40 80 F6")]
    public partial void ClearMenu();

    [MemberFunction("E8 ?? ?? ?? ?? 41 BF ?? ?? ?? ?? 48 8D 54 24")]
    public partial void SetMenuTitle(byte* text);

    [MemberFunction("E8 ?? ?? ?? ?? FF CE 48 FF CF")]
    public partial void AddMenuItem(byte* text, void* handler, long handlerParam, bool disabled = false,
        bool submenu = false);

    [MemberFunction("E8 ?? ?? ?? ?? 49 69 D6")]
    public partial void AddMenuItem2(uint addonTextId, void* handler, long handlerParam, bool disabled = false,
        bool submenu = false);

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B 99 ?? ?? ?? ?? 4C 8B D1")]
    public partial void AddContextMenuItem(int eventId, byte* text, bool disabled = false, bool submenu = false,
        bool copyText = true);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 85 F6 74 3F")]
    public partial void AddContextMenuItem2(int eventId, uint addonTextId, bool disabled = false, bool submenu = false,
        bool copyText = true);

    public void AddMenuItem(string text, void* handler, long handlerParam, bool disabled = false, bool submenu = false)
    {
        var str = Encoding.UTF8.GetBytes(text + '\0');
        fixed (byte* ptr = &str[0])
        {
            AddMenuItem(ptr, handler, handlerParam, disabled, submenu);
        }
    }

    public void AddContextMenuItem(int eventId, string text, bool disabled = false, bool submenu = false,
        bool copyText = true)
    {
        var str = Encoding.UTF8.GetBytes(text + '\0');
        fixed (byte* ptr = &str[0])
        {
            AddContextMenuItem(eventId, ptr, disabled, submenu, copyText);
        }
    }

    public void SetMenuTitle(string text)
    {
        var str = Encoding.UTF8.GetBytes(text + '\0');
        fixed (byte* ptr = &str[0])
        {
            SetMenuTitle(ptr);
        }
    }

    public void OpenYesNo(string text, uint yesId = 576, uint noId = 577, uint checkboxId = 0, bool bindToOwner = true)
    {
        var str = Encoding.UTF8.GetBytes(text + '\0');
        fixed (byte* ptr = &str[0])
        {
            OpenYesNo(ptr, yesId, noId, checkboxId, bindToOwner);
        }
    }

    public void SetPosition(int x, int y)
    {
        Position.X = x;
        Position.Y = y;
        OpenAtPosition = 1;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x678)]
public unsafe struct ContextMenu
{
    [FieldOffset(0x00)] public short CurrentEventIndex;
    [FieldOffset(0x02)] public short CurrentEventId;

    [FieldOffset(0x08)]
    public fixed byte EventParams[0x10 * 33]; // 32 * AtkValue + 1 * AtkValue for submenus with title

    public Span<AtkValue> EventParamSpan
    {
        get
        {
            fixed (byte* ptr = EventParams)
            {
                return new Span<AtkValue>(ptr, 33);
            }
        }
    }

    [FieldOffset(0x428)] public fixed byte EventIdArray[32];
    [FieldOffset(0x450)] public fixed long EventHandlerArray[32];
    [FieldOffset(0x558)] public fixed long EventHandlerParamArray[32];

    [FieldOffset(0x660)] public uint ContextItemDisabledMask;
    [FieldOffset(0x664)] public uint ContextSubMenuMask;
    [FieldOffset(0x668)] public byte* ContextTitleString;
    [FieldOffset(0x670)] public byte SelectedContextItemIndex;
}

[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe struct ContextMenuTarget
{
    [FieldOffset(0x00)] public ulong ContentId;
    [FieldOffset(0x14)] public byte AddonListIndex;
    [FieldOffset(0x16)] public ushort CurrentWorldId;
    [FieldOffset(0x18)] public ushort HomeWorldId;
    [FieldOffset(0x1A)] public ushort TerritoryTypeId;
    [FieldOffset(0x1C)] public byte GrandCompany;
    [FieldOffset(0x1D)] public byte ClientLanguage;
    [FieldOffset(0x1E)] public byte LanguageBitmask;
    [FieldOffset(0x20)] public byte Gender;
    [FieldOffset(0x21)] public byte ClassJobId;
    [FieldOffset(0x22)] public fixed byte Name[32];
    [FieldOffset(0x42)] public fixed byte FcName[14];
    [FieldOffset(0x50)] public void* Unk_Info_Ptr;
}
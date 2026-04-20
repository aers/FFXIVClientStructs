using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentTofuList
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.TofuList)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x38)]
public unsafe partial struct AgentTofuList {
    [FieldOffset(0x28)] public TofuListData* Data;

    /// <remarks> 
    /// Ensure TofuListData pointer is non-null before calling otherwise this will crash the game. <br/>
    /// The pointer is populated when the Agent is open. Use <see cref="TofuModule"/> to interact with Tofu <br/>
    /// while Agent is closed.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 88 46 ?? EB ?? C7 02")]
    public partial void ContextMenuOptions(AtkValue* values, uint valueCount, uint code);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3E98)]
public unsafe partial struct TofuListData {
    [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray70<TofuBoard> _boards; // Starts with Saved then Shared
    [FieldOffset(0x2530), FixedSizeArray] internal FixedSizeArray70<TofuBoardShort> _boardShorts;
    [FieldOffset(0x2BC0)] public uint TotalSavedList;
    [FieldOffset(0x2BC4)] public uint TotalSavedBoards;
    [FieldOffset(0x2BC8)] public uint TotalSaved;
    [FieldOffset(0x2BCC)] public int SavedSelectedIndex;
    [FieldOffset(0x2BD0)] public uint TotalSharedList;
    [FieldOffset(0x2BD4)] public uint TotalSharedBoards;
    [FieldOffset(0x2BD8)] public uint TotalShared;
    [FieldOffset(0x2BDC)] public int SharedSelectedIndex;
    [FieldOffset(0x2BE0)] public TofuMoveToFolder MoveToFolderDialog; 
    [FieldOffset(0x3D18)] public TofuSettings SettingsDialog;
    [FieldOffset(0x3DF8)] public Utf8String SelectYesNoText;
    [FieldOffset(0x3E60)] public AgentTofuList* Agent;
    [FieldOffset(0x3E68)] public UIModule* UIModule;
    [FieldOffset(0x3E70)] private nint Unk3E70; // struct of size 0x90

    [FieldOffset(0x3E7C)] private byte Unk3E7C; // 3 when creating item: `40 53 48 83 EC ?? 48 8B 01 48 8B D9 FF 50 ?? 84 C0 74 ?? 48 8B 5B ?? 8B 83`, 1 on Agent.Show, 0 by default

    [FieldOffset(0x3E84)] public uint IsSharedListOpen; // 4 byte bool, possible enum
    [FieldOffset(0x3E88)] private int Unk3E88; // Defaults to -1
    [FieldOffset(0x3E8C)] public uint ChildAddonId;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 48 8B 47 ?? 89 A8")]
    public partial void RenameItem(int index, Utf8String* newName); 

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 83 BB ?? ?? ?? ?? ?? 48 8D 8B")]
    public partial void ReviewSelectedBoard();

    [MemberFunction("E8 ?? ?? ?? ?? FF CB FF CF")]
    public partial void SwapBoards(uint boardIndex, uint targetIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B 36")]
    public partial void SwapFolders(uint folderIndex, uint targetIndex);
}

[StructLayout(LayoutKind.Explicit, Size = 0x88)]
public partial struct TofuBoard {
    [FieldOffset(0x0)] public StdVector<TofuFullObject> Objects;
    [FieldOffset(0x18)] public Utf8String Name;
    [FieldOffset(0x84)] public byte Background;
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe partial struct TofuBoardShort {
    [FieldOffset(0x0)] public TofuBoard* Board;
    [FieldOffset(0x8)] public CStringPointer Name;
}

[GenerateInterop]
// Includes 3 vfuncs, unk8, uimodule
[StructLayout(LayoutKind.Explicit, Size = 0x1138)]
public unsafe partial struct TofuMoveToFolder {
    [FieldOffset(0x18)] private byte Unk18; // 4 when dialog is open
    [FieldOffset(0x60), FixedSizeArray] internal FixedSizeArray75<TofuShortObject> _selectedBoardObjects; // Why is this 75 elements long, board can only have 50 objects
    [FieldOffset(0x10CC), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _boardName;
    [FieldOffset(0x1118)] private nint Unk1118; // Pointer to array of available folders, includes the names 
    [FieldOffset(0x1120)] public byte NumberOfFolders;
    [FieldOffset(0x1128)] public AgentTofuList* Agent;
}

//[GenerateInterop]
// Includes 3 vfuncs, unk8, uimodule, addonid
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public unsafe partial struct TofuSettings {
    [FieldOffset(0x48)] public bool IsSeparate; // either unified or separate
    [FieldOffset(0xC4)] public byte IconHighlight;
    [FieldOffset(0xD0)] public AgentTofuList* Agent;
}

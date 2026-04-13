using System.Runtime.CompilerServices;
using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::TofuModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct TofuModule {
    public static TofuModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetTofuModule();
    }

    [FieldOffset(0x48)] private TofuModuleData* Data;

    // TofuModule->SavedBoardData->Boards
    public TofuData* SavedBoardData => (TofuData*)Unsafe.AsPointer(ref this.Data->TofuData[0]);
    public TofuData* SavedFolderData => (TofuData*)Unsafe.AsPointer(ref this.Data->TofuData[1]);
    public TofuData* SharedBoardData => (TofuData*)Unsafe.AsPointer(ref this.Data->TofuData[2]);
    public TofuData* SharedFolderData => (TofuData*)Unsafe.AsPointer(ref this.Data->TofuData[3]);

    [VirtualFunction(10)]
    public partial void DeleteEverything();

    /// <summary>
    /// Gets the index of the folder of an array containing folders only with boards.
    /// </summary>
    /// <returns>
    /// The index of the folder of an array containing folders only with boards. If the board doesn't exist in a folder,
    /// returns just the index of the board within the board array. <c>-1</c> if the board is invalid.
    /// </returns>
    [MemberFunction("E8 ?? ?? ?? ?? 8B E8 8B 44 24")]
    public partial int GetBoardFolderIndexByBoardIndex(TofuType type, uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 83 C0 ?? 48 8D 9E")]
    public partial TofuFolderEntry* GetFolderAtUIIndex(TofuType type, uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 90")]
    public partial TofuBoardEntry* GetBoardAtUIIndex(TofuType type, uint index);

    /// <summary>
    /// Gets the folder index of the board.
    /// </summary>
    /// <returns>The index of the folder. If the board doesn't exist in a folder, the index of the board within entire item array.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 44 8B F0 EB ?? BB")]
    public partial int GetFolderIndexByBoardIndex(TofuType type, uint index);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 45 8B CF 44 89 64 24"), GenerateStringOverloads]
    public partial void RenameFolder(TofuType type, uint index, CStringPointer newName);

    [MemberFunction("E8 ?? ?? ?? ?? 83 BF ?? ?? ?? ?? ?? 75 ?? 44 8B A7"), GenerateStringOverloads]
    public partial void RenameBoard(TofuType type, uint index, CStringPointer newName);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 70 ?? 8B 44 24")]
    public partial uint GetNumberOfBoardsInFolder(TofuType type, uint index);

    /// <summary> Deletes the specified item. If a folder is deleted, it's boards will be deleted too.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 39 AC 24")]
    public partial bool DeleteItemAndContents(TofuType type, uint index);

    /// <summary> Creates a copy of the board to the folder.</summary>
    [MemberFunction("E8 ?? ?? ?? ?? FF C3 41 3B DC 7C ?? B0")]
    public partial TofuBoardEntry* CopyBoardToFolder(TofuType type, TofuBoardEntry* board, uint folderIndex);

    /// <remarks> This moves the UI order, but will not update the addon.</remarks>
    [MemberFunction("40 53 48 83 EC ?? 48 8B 41 ?? 48 8B D9 48 85 C0 74 ?? 83 FA")]
    public partial void MoveItem(TofuType type, TofuItem item, uint sourceIndex, uint targetIndex);

    [MemberFunction("48 83 EC ?? 48 8B 41 ?? 48 85 C0 74 ?? 83 FA")]
    public partial bool IsFull(TofuType type, TofuItem item);

    [MemberFunction("E8 ?? ?? ?? ?? 3B D8 7E ?? 49 8B 8F")]
    public partial uint MaxItemAllowed(TofuType type, TofuItem item);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B D6 41 89 45")]
    public partial uint TotalItemCount(TofuType type, TofuItem item);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 45 8B CC")]
    public partial bool IsItemValid(TofuType type, TofuItem item, uint index);

    /// <remarks> Can be used to create a copy if the folder to be copied is passed through.</remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B F8 83 FD ?? 75")]
    public partial TofuFolderEntry* CreateFolder(TofuType type, TofuFolderEntry* folder);
    /// <summary> Helper to create a new folder with a name. </summary>
    public TofuFolderEntry* CreateFolder(TofuType type, string name) {
        var folder = new TofuFolderEntry() { NameString = name };
        return CreateFolder(type, &folder);
    }

    /// <remarks> Can be used to create a copy if the board to be copied is passed through.</remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 48 8B 07")]
    public partial TofuBoardEntry* CreateBoard(TofuType type, TofuBoardEntry* board, bool notInFolder);
    /// <summary> Helper to create a new board with a name. </summary>
    public TofuBoardEntry* CreateBoard(TofuType type, string name) {
        var board = new TofuBoardEntry() { NameString = name };
        return CreateBoard(type, &board, true);
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public partial struct TofuModuleData {
        [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray4<TofuData> _tofuData;
        [FieldOffset(0xA0)] private ushort UnkA0; // used in `E8 ?? ?? ?? ?? 48 8D 54 24 ?? 66 41 89 87` + `4C 8B 41 ?? 4D 85 C0 74 ?? 41 0F BF 80`
        [FieldOffset(0xA2)] private int UnkA2; // used in `E8 ?? ?? ?? ?? 8D 48 ?? 83 F9 ?? 76 ?? 48 8D 4B` + `4C 8B 41 ?? 4D 85 C0 74 ?? 41 0F BE 80`
        [FieldOffset(0xA8)] public TofuModule* TofuModule;
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct TofuData {
    [FieldOffset(0x8)] private nint Unk8; // points to the tofutype start, which is always the boards. Differs between saved/shared
    [FieldOffset(0x10)] private byte* OrderArray;
    [FieldOffset(0x18)] public TofuDataType Id;
    [FieldOffset(0x1C)] public byte Total; // total number of existing items,
    [FieldOffset(0x20), CExporterUnion("Tofu")] private TofuBoardEntry* BoardArray;
    [FieldOffset(0x20), CExporterUnion("Tofu")] private TofuFolderEntry* FolderArray;

    public byte MaxCount { // max possible items, follows reused inlined code
        get
        => Id switch {
            TofuDataType.SavedBoards => 50,
            TofuDataType.SavedFolders => 55,
            TofuDataType.SharedBoards or TofuDataType.SharedFolders => 20,
            _ => 1
        };
    }

    public Span<byte> UIOrder => new(OrderArray, MaxCount);
    public Span<TofuBoardEntry> Boards => new(BoardArray, MaxCount);
    public Span<TofuFolderEntry> Folders => new(FolderArray, MaxCount);

    [VirtualFunction(1)]
    public partial bool DeleteAllItems();

    [VirtualFunction(2)]
    public partial bool SwapItems(int source, int target);

    [VirtualFunction(3)]
    public partial uint GetItemUIIndex(int index);

    [VirtualFunction(4)]
    public partial bool IsItemValid(int index);

    [VirtualFunction(5)]
    public partial uint GetItemOrderIndex(int index);

    [MemberFunction("4C 8B DC 49 89 5B ?? 55 57 41 57 48 81 EC")]
    public partial bool DeleteAllEmptyFolders();
}

public enum TofuDataType : uint {
    SavedFolders = 1,
    SavedBoards = 2,
    SharedFolders = 3,
    SharedBoards = 4,
}

public enum TofuType : uint {
    Saved = 1,
    Shared = 2,
}

public enum TofuItem : uint {
    Folder = 0,
    Board = 1,
}

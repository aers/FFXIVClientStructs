using FFXIVClientStructs.FFXIV.Client.System.String;
using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureUiDataModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x38D8)]
public unsafe partial struct RaptureUiDataModule {
    public static RaptureUiDataModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetRaptureUiDataModule();
    }

    [FieldOffset(0x38C0)] public MuteList Mutelist;

    [MemberFunction("4C 8B D1 41 83 F9 06")]
    public partial void MjiCreateWorkshopPreset(uint presetIndex, uint* mjiCraftWorksObjectList, uint listCount);

    public void MJI_SetWorkshopPreset(uint presetIndex, params uint[] mjiCraftWorksObjectList) {
        if (presetIndex is < 0 or > 9) return;
        if (mjiCraftWorksObjectList.Length is < 1 or > 6) return;
        var list = stackalloc uint[6];
        int i;
        for (i = 0; i < mjiCraftWorksObjectList.Length && i < 6; i++) list[i] = mjiCraftWorksObjectList[i];
        for (; i < 6; i++) list[i] = 0;
        MjiCreateWorkshopPreset(presetIndex, list, (uint)mjiCraftWorksObjectList.Length);
    }

    /// <remarks>See also: <seealso cref="Agent.AgentMutelist"/>.</remarks>
    // Should inherit StdVector<MuteListEntry>, but we can't do that due to technical limitations.
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public unsafe partial struct MuteList {
        [FieldOffset(0x00)] public StdVector<MuteListEntry> Entries;

        [MemberFunction("E8 ?? ?? ?? ?? 48 8D 75 1F")]
        public partial MuteListEntry* GetByAccountId(ulong accountId);

        /// <remarks>To save changes, call <see cref="RaptureUiDataModule.SaveFile(bool)"/>.</remarks>
        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F 10 48 8B 11 48 85 C0"), GenerateStringOverloads]
        public partial MuteListEntry* Add(ulong accountId, CStringPointer name, short worldId);

        /// <remarks>To save changes, call <see cref="RaptureUiDataModule.SaveFile(bool)"/>.</remarks>
        [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 1B 49 8B 4E 10")]
        public partial bool Remove(ulong accountId);

        /// <remarks>To save changes, call <see cref="RaptureUiDataModule.SaveFile(bool)"/>.</remarks>
        [MemberFunction("40 53 48 83 EC 20 48 8B 19 48 8B 41 08"), GenerateStringOverloads]
        public partial MuteListEntry* UpdateComment(ulong accountId, CStringPointer comment);

        [StructLayout(LayoutKind.Explicit, Size = 0xE0)]
        public struct MuteListEntry {
            [FieldOffset(0x00)] public ulong AccountId;
            [FieldOffset(0x08)] public short WorldId;

            [FieldOffset(0x10)] public Utf8String CharacterName;
            [FieldOffset(0x78)] public Utf8String Comment;
        }
    }
}

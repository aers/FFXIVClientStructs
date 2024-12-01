using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::RaptureUiDataModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x38D8)]
public unsafe partial struct RaptureUiDataModule {
    public static RaptureUiDataModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetRaptureUiDataModule();
    }

    [FieldOffset(0x4E0), FixedSizeArray, Obsolete("Moved to PartyRoleListModule", true)] internal FixedSizeArray16<ushort> _partyListTankOrder;
    [FieldOffset(0x500), FixedSizeArray, Obsolete("Moved to PartyRoleListModule", true)] internal FixedSizeArray16<ushort> _partyListHealerOrder;
    [FieldOffset(0x520), FixedSizeArray, Obsolete("Moved to PartyRoleListModule", true)] internal FixedSizeArray16<ushort> _partyListDpsOrder;

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
}

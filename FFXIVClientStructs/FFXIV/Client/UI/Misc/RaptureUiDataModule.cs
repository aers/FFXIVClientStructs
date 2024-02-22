using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::RaptureUiDataModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 4C 89 21 E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 4C 89 21 E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 4C 89 21"
[StructLayout(LayoutKind.Explicit, Size = 0x5AE8)]
public unsafe partial struct RaptureUiDataModule {
    public static RaptureUiDataModule* Instance() => Framework.Instance()->GetUiModule()->GetRaptureUiDataModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;

    [FieldOffset(0x4D8)] public fixed ushort PartyListTankOrder[16];
    [FieldOffset(0x4F8)] public fixed ushort PartyListHealerOrder[16];
    [FieldOffset(0x518)] public fixed ushort PartyListDpsOrder[16];

    [MemberFunction("4C 8B D1 41 83 F9 06")]
    public partial void MJI_SetWorkshopPreset(uint presetIndex, uint* mjiCraftWorksObjectList, uint listCount);

    public void MJI_SetWorkshopPreset(uint presetIndex, params uint[] mjiCraftWorksObjectList) {
        if (presetIndex is < 0 or > 9) return;
        if (mjiCraftWorksObjectList.Length is < 1 or > 6) return;
        var list = stackalloc uint[6];
        int i;
        for (i = 0; i < mjiCraftWorksObjectList.Length && i < 6; i++) list[i] = mjiCraftWorksObjectList[i];
        for (; i < 6; i++) list[i] = 0;
        MJI_SetWorkshopPreset(presetIndex, list, (uint)mjiCraftWorksObjectList.Length);
    }
}

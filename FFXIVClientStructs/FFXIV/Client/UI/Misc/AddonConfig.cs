using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct AddonConfig {
    public static AddonConfig* Instance() => Framework.Instance()->GetUiModule()->GetAddonConfig();

    [FieldOffset(0x00)] public UserFileEvent UserFileEvent;

    [FieldOffset(0x50)] public AddonConfigData* ModuleData;

    /// <summary>
    /// Changes the current HUD Layout to the specific value
    /// </summary>
    /// <param name="layoutIndex">HUD Layout Index, 0-based</param>
    /// <param name="unk1">Unknown, generally False</param>
    /// <param name="unk2">Unknown, generally True</param>
    /// <returns></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 EB 15")]
    public partial nint ChangeHudLayout(uint layoutIndex, bool unk1 = false, bool unk2 = true);
}

[StructLayout(LayoutKind.Explicit, Size = 0x9E90)]
public unsafe partial struct AddonConfigData {
    [FieldOffset(0x00)] public Utf8String DefaultString; // Literally says "Default"
                                                         // [FieldOffset(0x68)] public StdList<[SomeStruct Size 48]> SomeList; //Contains 300 elements
                                                         // [FieldOffset(0x78)] public StdList<[SomeStruct size 16]> SomeList; //Contains 400 elements
                                                         // [FixedSizeArray<[SomeStruct Size 36]>(400)] public byte SomeArray[400 * 36]; //Contains 400 elements
                                                         // There's a LOT more data here

    [FieldOffset(0x9E88)] public int CurrentHudLayout;
}

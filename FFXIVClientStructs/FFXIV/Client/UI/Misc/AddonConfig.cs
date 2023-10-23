using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc; 

[StructLayout(LayoutKind.Explicit, Size = 0x68)]
public unsafe partial struct AddonConfig {
    public static AddonConfig* Instance() => Framework.Instance()->GetUiModule()->GetAddonConfig();
    
    [FieldOffset(0x00)] public UserFileEvent UserFileEvent;

    [FieldOffset(0x50)] public AddonConfigData* ModuleData;
}

[StructLayout(LayoutKind.Explicit, Size = 0x9E90)]
public unsafe partial struct AddonConfigData {
    [FieldOffset(0x9E88)] public int CurrentHudLayout;
}

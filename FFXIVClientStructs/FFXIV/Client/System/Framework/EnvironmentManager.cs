using FFXIVClientStructs.FFXIV.Common.Configuration;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

[StructLayout(LayoutKind.Explicit, Size = 0x698)]
public partial struct EnvironmentManager {
    [FieldOffset(0x000)] public Task Task;
    [FieldOffset(0x038)] public ChangeEventInterface ChangeEventInterface;

    [FieldOffset(0x084)] public int CutsceneMovieVoice; //Cutscene Audio Language (-1 = ClientLanguage) 


    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 41 8B F8 41 0F B6 F1")]
    public partial void SetVolume(uint type, uint volume, bool saveToConfig);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 41 B1 ?? 41 83 C8")]
    public partial void SetMasterVolume(uint volume, bool saveToConfig);
}

using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::XBMNoteModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct XBMNoteModule {
    public static XBMNoteModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetXBMNoteModule();
    }

    [FieldOffset(0x48)] public StdVector<PetSetting> PetSettings;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 BA ?? ?? ?? ?? 48 8B CD 0F 94 C3")]
    public partial bool IsNewPetSeen(byte petId);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 83 ?? ?? ?? ?? 48 2B 43")]
    public partial bool SetPetMirage(byte petId, XBMPetMirage mirage);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 8D 4B ?? 8B C3")]
    public partial XBMPetMirage GetPetMirage(byte petId);

    [MemberFunction("E8 ?? ?? ?? ?? FF C7 83 FF ?? 7C ?? ?? ?? ?? 48 8B CB")]
    public partial bool SetPetSize(byte petId, XBMPetSize size);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8D 55 ?? 8B F8")]
    public partial XBMPetSize GetPetSize(byte petId);

    [StructLayout(LayoutKind.Explicit, Size = 0x04)]
    public struct PetSetting {
        /// <summary> XBMPet RowId </summary>
        [FieldOffset(0x00)] public byte Id;
        [FieldOffset(0x01)] public XBMPetSize Size;
        [FieldOffset(0x02)] public bool IsNewPetSeen;
        [FieldOffset(0x03)] public XBMPetMirage Mirage;
    }
}

public enum XBMPetSize : byte {
    Small = 0,
    Medium = 1,
    Large = 2,
}

public enum XBMPetMirage : byte {
    Normal = 0,
    Alternative = 1,
}

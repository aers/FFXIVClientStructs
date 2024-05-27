using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RetainerCommentModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8B D7"
[GenerateInterop, Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x5A0)]
public unsafe partial struct RetainerCommentModule {
    public static RetainerCommentModule* Instance() => UIModule.Instance()->GetRetainerCommentModule();
    
    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray10<RetainerComment> _retainers;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B BC 24 ?? ?? ?? ?? 48 8B B4 24 ?? ?? ?? ?? 49 8B 4E 10"), GenerateStringOverloads]
    public partial void SetComment(ulong retainerId, byte* comment);

    [MemberFunction("32 C0 0F 1F 40 00 66 66 0F 1F 84 ?? 00 00 00 00 44 0F B6 C0 4C 8D 51")]
    public partial byte* GetComment(ulong retainerId);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x88)]
    public partial struct RetainerComment {
        [FieldOffset(0)] public ulong Id;
        [FieldOffset(0x8), FixedSizeArray(isString: true)] internal FixedSizeArray91<byte> _comment;
    }
}

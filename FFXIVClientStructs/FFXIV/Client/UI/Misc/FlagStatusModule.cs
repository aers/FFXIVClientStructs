using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::FlagStatusModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
public unsafe partial struct FlagStatusModule {
    public static FlagStatusModule* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetFlagStatusModule();
    }

    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray32<ushort> _patchMarkVersions;
    [FieldOffset(0x88), FixedSizeArray] internal FixedSizeArray32<byte> _patchMarkStates;
    [FieldOffset(0xA8), FixedSizeArray] internal FixedSizeArray32<PatchMarkIdEntry> _patchMarkIds;
    /// <remarks>
    /// 1 = Summoned Companion Id<br/>
    /// 10 = Last seen MentorRenewDialogue MentorVersion<br/>
    /// 11 = Do not show MentorRenewDialogue again<br/>
    /// 13 = Default Currency Setting (Index of Rotation array in UIModule.UIModuleHelpers.CurrencySettings)<br/>
    /// 14 = Currency Setting Ids (bytes) for Rotation index 0 - 3<br/>
    /// 15 = Currency Setting Id (byte) for Rotation 5<br/>
    /// 16 = Actions &amp; Traits Display Mode (AgentActionMenu.CompactView)<br/>
    /// 21 = Hide Portrait Update Preview
    /// </remarks>
    [FieldOffset(0x1AC), FixedSizeArray] internal FixedSizeArray64<uint> _uIFlags;

    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public struct PatchMarkIdEntry {
        [FieldOffset(0)] public uint MarkId;
        [FieldOffset(4)] public uint RowId;
    }
}

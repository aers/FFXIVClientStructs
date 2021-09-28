using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc
{
    public unsafe partial struct ScreenLog
    {
        [MemberFunction("C7 02 ? ? ? ? 81 F9 ? ? ? ?", IsStatic = true)]
        public static partial int ConvertLogMessageIdToScreenLogKind(int logMessageId, int* unkOption);
    }
}
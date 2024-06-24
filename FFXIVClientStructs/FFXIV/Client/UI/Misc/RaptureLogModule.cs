using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Common.Log;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureLogModule
//   Component::Log::LogModule
// ctor "E8 ?? ?? ?? ?? 4C 8D A7 ?? ?? ?? ?? 49 8B CC E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ??"
[GenerateInterop]
[Inherits<LogModule>]
[StructLayout(LayoutKind.Explicit, Size = 0x3488)]
public unsafe partial struct RaptureLogModule {
    public static RaptureLogModule* Instance() => Framework.Instance()->GetUIModule()->GetRaptureLogModule();

    /// <remarks> Always <c>0x1F</c>, used as column terminator in <see cref="LogModule.LogMessageData"/>. </remarks>
    [FieldOffset(0x80)] internal Utf8String LogMessageDataTerminator;
    [FieldOffset(0xE8)] public UIModule* UIModule;
    [FieldOffset(0xF0)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0xF8)] public RaptureTextModule* RaptureTextModule;

    [FieldOffset(0x100)] public AtkFontCodeModule* AtkFontCodeModule;
    [FieldOffset(0x108), FixedSizeArray] internal FixedSizeArray10<Utf8String> _tempParseMessage;

    [FieldOffset(0x520)] public ExcelSheet* LogKindSheet;

    [FieldOffset(0x530), FixedSizeArray] internal FixedSizeArray5<RaptureLogModuleTab> _chatTabs;

    [FieldOffset(0x33D8)] public ExcelSheet* LogMessageSheet;
    /// <remarks> Set to <c>true</c> to reload the tab. </remarks>
    [FieldOffset(0x33E8), FixedSizeArray] internal FixedSizeArray4<bool> _chatTabIsPendingReload;
    /// <remarks> Controlled by config options <c>LogTimeDisp</c>, <c>LogTimeDispLog2</c>, <c>LogTimeDispLog3</c> and <c>LogTimeDispLog4</c>. </remarks>
    [FieldOffset(0x33ED), FixedSizeArray] internal FixedSizeArray4<bool> _chatTabShouldDisplayTime;
    /// <remarks> Controlled by config option <c>LogTimeSettingType</c>. </remarks>
    [FieldOffset(0x33F2)] public bool UseServerTime;
    /// <remarks> Controlled by config option <c>LogTimeDispType</c>. </remarks>
    [FieldOffset(0x33F3)] public bool Use12HourClock;

    [FieldOffset(0x3478)] public LogMessageSource* MsgSourceArray;
    [FieldOffset(0x3480)] public int MsgSourceArrayLength;

    [MemberFunction("E8 ?? ?? ?? ?? 8B D8 45 85 F6")]
    public partial uint PrintMessage(ushort logKindId, Utf8String* senderName, Utf8String* message, int timestamp, bool silent = false);

    [MemberFunction("E8 ?? ?? ?? ?? EB AA")]
    public partial void ShowLogMessage(uint logMessageId);

    [MemberFunction("E8 ?? ?? ?? ?? 41 8B 5E 28")]
    public partial void ShowLogMessageUInt(uint logMessageId, uint value);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BE 4B 44")]
    public partial void ShowLogMessageUInt2(uint logMessageId, uint value1, uint value2);

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 ED 74 0A 8B D7")]
    public partial void ShowLogMessageUInt3(uint logMessageId, uint value1, uint value2, uint value3);

    [MemberFunction("E8 ?? ?? ?? ?? EB 68 48 8B 07")]
    public partial void ShowLogMessageString(uint logMessageId, Utf8String* value);

    [MemberFunction("E8 ?? ?? ?? ?? FE 44 24 50"), GenerateStringOverloads]
    public partial void PrintString(byte* str);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 4D 50 44 0F B7 E0")]
    public partial ulong GetContentIdForLogMessage(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8D 96 ?? ?? ?? ?? 48 8D 4C 24")]
    public partial bool GetLogMessage(int index, Utf8String* str);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 51 44 0F B6 95 ?? ?? ?? ??")]
    public partial bool GetLogMessageDetail(int index, short* logKind, Utf8String* sender, Utf8String* message, int* timestamp);

    [MemberFunction("4C 8B D9 48 8B 89 ?? ?? ?? ??")]
    public partial void AddMsgSourceEntry(ulong contentId, int messageIndex, ushort worldId, ushort chatType);

    public bool GetLogMessage(int index, out byte[] message) {
        using var pMsg = new Utf8String();
        var result = GetLogMessage(index, &pMsg);
        message = pMsg.AsSpan().ToArray();
        return result;
    }

    public bool GetLogMessageDetail(int index, out byte[] sender, out byte[] message, out short logKind, out int time) {
        using var pMessage = new Utf8String();
        using var pSender = new Utf8String();
        short pKind = 0;
        int pTime = 0;

        var result = GetLogMessageDetail(index, &pKind, &pSender, &pMessage, &pTime);

        logKind = pKind;
        time = pTime;
        sender = pSender.AsSpan().ToArray();
        message = pMessage.AsSpan().ToArray();
        return result;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct LogMessageSource {
    [FieldOffset(0x00)] public ulong ContentId;
    [FieldOffset(0x08)] public int LogMessageIndex;
    [FieldOffset(0x0C)] public short World;
    [FieldOffset(0x0E)] public short ChatType;
}

[StructLayout(LayoutKind.Explicit, Size = 0x928)]
public struct RaptureLogModuleTab {
    [FieldOffset(0x00)] public Utf8String Name;
    [FieldOffset(0x68)] public Utf8String VisibleLogLines;
}

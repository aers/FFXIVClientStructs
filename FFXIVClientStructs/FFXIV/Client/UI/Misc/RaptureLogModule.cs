using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Log;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;
using FFXIVClientStructs.FFXIV.Component.Text;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureLogModule
//   Component::Log::LogModule
// ctor "E8 ?? ?? ?? ?? 4C 8D A7 ?? ?? ?? ?? 49 8B CC E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ??"
[StructLayout(LayoutKind.Explicit, Size = 0x3488)]
public unsafe partial struct RaptureLogModule {
    public static RaptureLogModule* Instance() => Framework.Instance()->GetUiModule()->GetRaptureLogModule();

    [FieldOffset(0x00)] public LogModule LogModule;
    /// <remarks> Always <c>0x1F</c>, used as column terminator in <see cref="LogModule.LogMessageData"/>. </remarks>
    [FieldOffset(0x80)] internal Utf8String LogMessageDataTerminator;
    [FieldOffset(0xE8)] public UIModule* UIModule;
    [FieldOffset(0xF0)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0xF8)] public RaptureTextModule* RaptureTextModule;

    [FieldOffset(0x100)] public AtkFontCodeModule* AtkFontCodeModule;
    [FieldOffset(0x100), Obsolete("Use AtkFontCodeModule instead")] public MacroDecoder* MacroDecoder;
    [FixedSizeArray<Utf8String>(10)]
    [FieldOffset(0x108)] public fixed byte TempParseMessage[0x68 * 10];

    [FieldOffset(0x520)] public ExcelSheet* LogKindSheet;

    [FixedSizeArray<RaptureLogModuleTab>(5)]
    [FieldOffset(0x530)] public fixed byte ChatTabs[0x928 * 5];

    [FieldOffset(0x33D8)] public ExcelSheet* LogMessageSheet;

    [Obsolete("Use ChatTabIsPendingReload")]
    [FieldOffset(0x33E8)] public fixed byte ChatTabsPendingReload[4];
    /// <remarks> Set to <c>true</c> to reload the tab. </remarks>
    [FieldOffset(0x33E8)] public fixed bool ChatTabIsPendingReload[4];
    /// <remarks> Controlled by config options <c>LogTimeDisp</c>, <c>LogTimeDispLog2</c>, <c>LogTimeDispLog3</c> and <c>LogTimeDispLog4</c>. </remarks>
    [FieldOffset(0x33ED)] public fixed bool ChatTabShouldDisplayTime[4];
    /// <remarks> Controlled by config option <c>LogTimeSettingType</c>. </remarks>
    [FieldOffset(0x33F2)] public bool UseServerTime;
    /// <remarks> Controlled by config option <c>LogTimeDispType</c>. </remarks>
    [FieldOffset(0x33F3)] public bool Use12HourClock;

    [FieldOffset(0x3478)] public LogMessageSource* MsgSourceArray;
    [FieldOffset(0x3480)] public int MsgSourceArrayLength;

    [MemberFunction("E8 ?? ?? ?? ?? 39 9E ?? ?? ?? ?? 7E 4B")]
    public partial uint PrintMessage(ushort logKindId, Utf8String* senderName, Utf8String* message, int timestamp, bool silent = false);

    [MemberFunction("E8 ?? ?? ?? ?? 44 03 FB")]
    public partial void ShowLogMessage(uint logMessageID);

    [MemberFunction("E8 ?? ?? ?? ?? 32 C0 EB 17")]
    public partial void ShowLogMessageUInt(uint logMessageId, uint value);

    [MemberFunction("E8 ?? ?? ?? ?? 0F B7 46 32")]
    public partial void ShowLogMessageUInt2(uint logMessageId, uint value1, uint value2);

    [MemberFunction("E8 ?? ?? ?? ?? 40 84 ED 74 0A 8B D7")]
    public partial void ShowLogMessageUInt3(uint logMessageId, uint value1, uint value2, uint value3);

    [MemberFunction("E8 ?? ?? ?? ?? EB 68 48 8B 07")]
    public partial void ShowLogMessageString(uint logMessageId, Utf8String* value);

    [MemberFunction("E8 ?? ?? ?? ?? FE 44 24 50")]
    [GenerateCStrOverloads]
    public partial void PrintString(byte* str);

    [MemberFunction("4C 8B 81 ?? ?? ?? ?? 4D 85 C0 74 17")]
    public partial ulong GetContentIdForLogMessage(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8D 96 ?? ?? ?? ?? 48 8D 4C 24")]
    public partial bool GetLogMessage(int index, Utf8String* str);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 0F B6 85 ?? ?? ?? ?? 48 8D 8D")]
    public partial bool GetLogMessageDetail(int index, short* logKind, Utf8String* sender, Utf8String* message, uint* timeStamp);

    public bool GetLogMessage(int index, out byte[] message) {
        var pMsg = stackalloc Utf8String[1];
        pMsg->Ctor();
        var result = GetLogMessage(index, pMsg);
        message = new Span<byte>(pMsg->StringPtr, (int)pMsg->BufUsed - 1).ToArray();
        pMsg->Dtor();
        return result;
    }

    public bool GetLogMessageDetail(int index, out byte[] sender, out byte[] message, out short logKind, out uint time) {
        var pMsg = stackalloc Utf8String[1];
        var pSender = stackalloc Utf8String[1];
        var pKind = stackalloc short[1];
        var pTime = stackalloc uint[1];

        pMsg->Ctor();
        pSender->Ctor();

        var result = GetLogMessageDetail(index, pKind, pSender, pMsg, pTime);

        logKind = *pKind;
        time = *pTime;

        sender = new Span<byte>(pSender->StringPtr, (int)pSender->BufUsed - 1).ToArray();
        message = new Span<byte>(pMsg->StringPtr, (int)pMsg->BufUsed - 1).ToArray();

        pMsg->Dtor();
        pSender->Dtor();
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

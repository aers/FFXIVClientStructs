using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Log;
using FFXIVClientStructs.FFXIV.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureLogModule
// ctor E8 ?? ?? ?? ?? 4C 8D AF ?? ?? ?? ?? 49 8B CD
[StructLayout(LayoutKind.Explicit, Size = 0x3480)]
public unsafe partial struct RaptureLogModule
{
    [FieldOffset(0x00)] public LogModule LogModule;

    [FieldOffset(0xE8)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0xF0)] public RaptureTextModule* RaptureTextModule;

    [FieldOffset(0x528)] public fixed byte ChatTabs[5 * 0x928]; // array of 5 RaptureLogModuleTab

    [FieldOffset(0x3470)] public LogMessageSource* MsgSourceArray;
    [FieldOffset(0x3478)] public int MsgSourceArrayLength;

    [MemberFunction("E8 ?? ?? ?? ?? 44 03 FB")]
    public partial void ShowLogMessage(uint logMessageID);

    [MemberFunction("4C 8B 81 ?? ?? ?? ?? 4D 85 C0 74 17")]
    public partial ulong GetContentIdForLogMessage(int index);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8D 96 ?? ?? ?? ?? 48 8D 4C 24")]
    public partial bool GetLogMessage(int index, Utf8String* str);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 0F B6 85 ?? ?? ?? ?? 48 8D 8D")]
    public partial bool GetLogMessageDetail(int index, short* logKind, Utf8String* sender, Utf8String* message, uint* timeStamp);

    public bool GetLogMessage(int index, out byte[] message)
    {
        var pMsg = stackalloc Utf8String[1];
        pMsg->Ctor();
        var result = GetLogMessage(index, pMsg);
        message = new Span<byte>(pMsg->StringPtr, (int)pMsg->BufUsed - 1).ToArray();
        pMsg->Dtor();
        return result;
    }

    public bool GetLogMessageDetail(int index, out byte[] sender, out byte[] message, out short logKind, out uint time)
    {
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
public struct LogMessageSource
{
    [FieldOffset(0x00)] public ulong ContentId;
    [FieldOffset(0x08)] public int LogMessageIndex;
    [FieldOffset(0x0C)] public short World;
    [FieldOffset(0x0E)] public short ChatType;
}

[StructLayout(LayoutKind.Explicit, Size = 0x928)]
public struct RaptureLogModuleTab
{
    [FieldOffset(0x00)] public Utf8String Name;
    [FieldOffset(0x68)] public Utf8String VisibleLogLines;
}
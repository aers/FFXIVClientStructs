using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Control;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.GUI;
using FFXIVClientStructs.FFXIV.Component.Log;
using FFXIVClientStructs.FFXIV.Component.Text;
using ExcelModuleInterface = FFXIVClientStructs.FFXIV.Component.Excel.ExcelModuleInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureLogModule
//   Component::Log::LogModule
[GenerateInterop]
[Inherits<LogModule>]
[StructLayout(LayoutKind.Explicit, Size = 0x46D0)]
public unsafe partial struct RaptureLogModule {
    public static RaptureLogModule* Instance() {
        var uiModule = UI.UIModule.Instance();
        return uiModule == null ? null : uiModule->GetRaptureLogModule();
    }

    /// <remarks> Always <c>0x1F</c>, used as column terminator in <see cref="LogModule.LogMessageData"/>. </remarks>
    [FieldOffset(0x80)] internal Utf8String LogMessageDataTerminator;
    [FieldOffset(0xE8)] public UIModule* UIModule;
    [FieldOffset(0xF0)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0xF8)] public RaptureTextModule* RaptureTextModule;

    [FieldOffset(0x100)] public AtkFontCodeModule* AtkFontCodeModule;
    [FieldOffset(0x108), FixedSizeArray] internal FixedSizeArray10<Utf8String> _tempParseMessage;

    [FieldOffset(0x520)] public ExcelSheet* LogKindSheet;

    [FieldOffset(0x530), FixedSizeArray] internal FixedSizeArray5<RaptureLogModuleTab> _chatTabs;

    /// <summary>
    /// Queue of messages (from the LogMessage sheet) to add to the log.
    /// Messages are added by ShowLogMessage calls and removed by a later Update.
    /// </summary>
    /// <remarks>
    /// Messages can stay in this queue for multiple frames if the relevant excel data is not loaded yet.
    /// </remarks>
    [FieldOffset(0x33B0)] public StdDeque<LogMessageQueueItem> LogMessageQueue;

    [FieldOffset(0x33D8)] public ExcelSheet* LogMessageSheet;
    /// <remarks> Set to <c>true</c> to reload the tab. </remarks>
    [FieldOffset(0x33E8), FixedSizeArray] internal FixedSizeArray4<bool> _chatTabIsPendingReload;
    /// <remarks> Controlled by config options <c>LogTimeDisp</c>, <c>LogTimeDispLog2</c>, <c>LogTimeDispLog3</c> and <c>LogTimeDispLog4</c>. </remarks>
    [FieldOffset(0x33ED), FixedSizeArray] internal FixedSizeArray4<bool> _chatTabShouldDisplayTime;
    /// <remarks> Controlled by config option <c>LogTimeSettingType</c>. </remarks>
    [FieldOffset(0x33F2)] public bool UseServerTime;
    /// <remarks> Controlled by config option <c>LogTimeDispType</c>. </remarks>
    [FieldOffset(0x33F3)] public bool Use12HourClock;
    [FieldOffset(0x33F4)] public byte LogNameType;

    [FieldOffset(0x3478)] public LogMessageSource* MsgSourceArray;
    [FieldOffset(0x3480)] public int MsgSourceArrayLength;

    [FieldOffset(0x3488)] public AddonMessageSub AddonMessageSub3488;

    [MemberFunction("E8 ?? ?? ?? ?? 41 83 EC ?? 89 43")]
    public partial uint FormatLogMessage(uint logKindId, Utf8String* sender, Utf8String* message, int* timestamp, void* a6, Utf8String* a7, int chatTabIndex);

    [MemberFunction("E8 ?? ?? ?? ?? 44 39 AE ?? ?? ?? ?? 7E")]
    public partial uint PrintMessage(ushort logKindId, Utf8String* senderName, Utf8String* message, int timestamp, bool silent = false);

    [MemberFunction("E8 ?? ?? ?? ?? 8D 47 FF 83 F8 06")]
    public partial void FormatPlayerLink(CStringPointer name, Utf8String* result, CStringPointer displayNamePrefix, uint unk5, bool isNotLocalPlayer, ushort homeWorld, bool unk8, CStringPointer displayNameOverride, bool unk10);

    [MemberFunction("E9 ?? ?? ?? ?? 40 88 AE")]
    public partial void ShowLogMessage(uint logMessageId);

    [MemberFunction("E9 ?? ?? ?? ?? 0C ?? 88 42")] // ShowLogMessage<uint>
    public partial void ShowLogMessageUInt(uint logMessageId, uint value);

    [MemberFunction("E8 ?? ?? ?? ?? 0F BE 4B 44")] // ShowLogMessage<uint,uint>
    public partial void ShowLogMessageUIntUInt(uint logMessageId, uint value1, uint value2);

    [MemberFunction("E8 ?? ?? ?? ?? 80 67 37 FE")] // ShowLogMessage<uint,uint,uint>
    public partial void ShowLogMessageUIntUIntUInt(uint logMessageId, uint value1, uint value2, uint value3);

    [MemberFunction("E8 ?? ?? ?? ?? EB ?? 41 8B 47 ?? 85 C0")] // ShowLogMessage<string>
    public partial void ShowLogMessageString(uint logMessageId, Utf8String* value);

    [MemberFunction("E8 ?? ?? ?? ?? C6 43 34 03")]
    public partial void ShowLogMessageTextParameters(uint logMessageId, StdDeque<TextParameter>* value);

    [MemberFunction("E8 ?? ?? ?? ?? 32 C0 EB 59")]
    public partial void ShowLogMessageSourceObjectTargetObject(uint logMessageId, GameObject* source, GameObject* target);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 45 DF")]
    public partial void ShowLogMessageSourceObjectTargetObjectTextParameters(uint logMessageId, GameObject* source, GameObject* target, StdDeque<TextParameter>* value);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 4D 18"), GenerateStringOverloads]
    public partial void ShowLogMessageSourceTarget(uint logMessageId, CStringPointer sourceName, byte sourceGender, CStringPointer targetName, byte targetSex, ushort sourceHomeWorld, ushort targetHomeWorld);

    [MemberFunction("E8 ?? ?? ?? ?? 4D 85 FF 74 3F"), GenerateStringOverloads]
    public partial void ShowLogMessageSourceTargetTextParameters(uint logMessageId, CStringPointer sourceName, byte sourceSex, CStringPointer targetName, byte targetSex, StdDeque<TextParameter>* value, ushort sourceHomeWorld, ushort targetHomeWorld);

    [MemberFunction("E8 ?? ?? ?? ?? 49 8D 8E ?? ?? ?? ?? E8 ?? ?? ?? ?? 49 8B 06 49 8B CE FF 50 40 4C 8B 7C 24")]
    public partial void Update();

    /// <summary>
    /// Shows a message in a chat bubble above a characters head.
    /// </summary>
    /// <param name="logKindId"> The LogKind RowId. </param>
    /// <param name="sender"> The senders name. </param>
    /// <param name="message"> The message. </param>
    /// <param name="worldId"> The World RowId of the sender. Used for <see cref="CharacterManager.LookupBattleCharaByName(CStringPointer, bool, short)"/>. </param>
    /// <param name="isLocalPlayer"> If <see langword="true"/>, uses <see cref="Control.LocalPlayer"/>, otherwise looks up the character via <see cref="CharacterManager.LookupBattleCharaByName(CStringPointer, bool, short)"/>. </param>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 41 8B C6 48 8B 8C 24")]
    public partial void ShowMiniTalkPlayer(ushort logKindId, Utf8String* sender, Utf8String* message, ushort worldId, bool isLocalPlayer);

    [MemberFunction("E8 ?? ?? ?? ?? 40 80 C6 41"), GenerateStringOverloads]
    public partial void PrintString(CStringPointer str);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 48 8D 4D ?? E8 ?? ?? ?? ?? 48 8B D0")]
    public partial bool GetLogMessage(int index, Utf8String* str);

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 51 44 0F B6 95")]
    public partial bool GetLogMessageDetail(int index, short* outLogInfo, Utf8String* outSender, Utf8String* outMessage, int* outTimestamp);

    [MemberFunction("4C 8B D9 48 8B 89")]
    public partial void AddMsgSourceEntry(ulong contentId, ulong accountId, int messageIndex, ushort worldId, ushort chatType);

    [MemberFunction("48 89 5C 24 ?? 55 48 8D 6C 24 ?? 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 ?? 48 63 C2")]
    public partial void SetTabName(int tabIndex, Utf8String* tabName);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 08 44 38 21")]
    public partial Utf8String* GetTabName(int tabIndex);

    public bool GetLogMessage(int index, out byte[] message) {
        using var pMsg = new Utf8String();
        var result = GetLogMessage(index, &pMsg);
        message = pMsg.AsSpan().ToArray();
        return result;
    }

    /// <remarks>
    /// For <paramref name="casterKind"/> and <paramref name="targetKind"/> the values are:<br/>
    /// 0 = You<br/>
    /// 1 = Party Member<br/>
    /// 2 = Alliance Member<br/>
    /// 3 = Other PC<br/>
    /// 4 = Engaged Enemy<br/>
    /// 5 = Unengaged Enemy<br/>
    /// 6 = Friendly NPCs<br/>
    /// 7 = Pets/Companions<br/>
    /// 8 = Pets/Companions (Party)<br/>
    /// 9 = Pets/Companions (Alliance)<br/>
    /// 10 = Pets/Companions (Other PC)
    /// </remarks>
    [OverloadResolutionPriority(1)]
    [Obsolete("Use the overload with the EntityRelationKind parameters instead. Note that the numeric value of these parameters is different by one compared to this overload.")]
    public bool GetLogMessageDetail(int index, out byte[] sender, out byte[] message, out short logKind, out sbyte casterKind, out sbyte targetKind, out int timestamp) {
        var result = GetLogMessageDetail(index, out sender, out message, out logKind, out EntityRelationKind casterKindRelation, out EntityRelationKind targetKindRelation, out timestamp);
        casterKind = (sbyte)(casterKindRelation - 1);
        targetKind = (sbyte)(targetKindRelation - 1);
        return result;
    }
    public bool GetLogMessageDetail(int index, out byte[] sender, out byte[] message, out short logKind, out EntityRelationKind casterKind, out EntityRelationKind targetKind, out int timestamp) {
        using var pSender = new Utf8String();
        using var pMessage = new Utf8String();
        short pLogInfo;
        int pTimestamp;

        var result = GetLogMessageDetail(index, &pLogInfo, &pSender, &pMessage, &pTimestamp);

        logKind = (short)(pLogInfo & 0x7F);
        casterKind = (EntityRelationKind)((pLogInfo >> 11) & 0xF);
        targetKind = (EntityRelationKind)((pLogInfo >> 7) & 0xF);
        timestamp = pTimestamp;
        sender = pSender.AsSpan().ToArray();
        message = pMessage.AsSpan().ToArray();

        return result;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x2A)]
    public unsafe partial struct AddonMessageSub {
        [FieldOffset(0x00)] public ulong AccountId;
        [FieldOffset(0x08)] public ulong ContentId;
        [FieldOffset(0x10)] public CStringPointer Name;
        [FieldOffset(0x18)] public Utf8String* MessageText;
        [FieldOffset(0x20)] public uint EntityId;
        [FieldOffset(0x24)] public ushort ChatType;
        [FieldOffset(0x26)] public ushort WorldId;
        [FieldOffset(0x28)] public sbyte PartyOrAllianceMemberIdent;
        [FieldOffset(0x29)] public byte Flags;
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public struct LogMessageSource {
    [FieldOffset(0x00)] public ulong ContentId;
    [FieldOffset(0x08)] public ulong AccountId;
    [FieldOffset(0x10)] public int LogMessageIndex;
    [FieldOffset(0x14)] public short World;
    [FieldOffset(0x16)] public short ChatType;
}

[StructLayout(LayoutKind.Explicit, Size = 0x928)]
public struct RaptureLogModuleTab {
    [FieldOffset(0x00)] public Utf8String Name;
    [FieldOffset(0x68)] public Utf8String VisibleLogLines;
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x248)]
public partial struct LogMessageQueueItem {
    [FieldOffset(0)] public StdDeque<TextParameter> Parameters;
    [FieldOffset(0x28), FixedSizeArray(isString: true)] internal FixedSizeArray256<byte> _sourceName;
    [FieldOffset(0x128), FixedSizeArray(isString: true)] internal FixedSizeArray256<byte> _targetName;
    [FieldOffset(0x228)] public uint LogMessageId;
    [FieldOffset(0x22C)] public EntityRelationKind SourceKind;
    [FieldOffset(0x22D)] public EntityRelationKind TargetKind;
    [FieldOffset(0x22E)] public byte SourceSex;
    [FieldOffset(0x22F)] public byte TargetSex;
    /// <summary> ObjStr id of the source object. </summary>
    /// <remarks> <seealso cref="RaptureTextModule.ResolveSheetRedirect"/> with the <c>ObjStr</c> sheet and column 0 </remarks>
    [FieldOffset(0x230)] public uint SourceObjStrId;
    /// <summary> ObjStr id of the target object. </summary>
    /// <remarks> <seealso cref="RaptureTextModule.ResolveSheetRedirect"/> with the <c>ObjStr</c> sheet and column 0 </remarks>
    [FieldOffset(0x234)] public uint TargetObjStrId;
    [FieldOffset(0x238)] public float SourceToLocalPlayerYDelta;
    [FieldOffset(0x23C)] public ushort SourceHomeWorld;
    [FieldOffset(0x23E)] public ushort TargetHomeWorld;
    [FieldOffset(0x240)] public bool SourceIsPlayer;
    [FieldOffset(0x241)] public bool TargetIsPlayer;
}

public enum EntityRelationKind : byte {
    None = 0,
    LocalPlayer = 1,
    PartyMember = 2,
    AllianceMember = 3,
    OtherPlayer = 4,
    EngagedEnemy = 5,
    UnengagedEnemy = 6,
    FriendlyNpc = 7,
    PetOrCompanion = 8,
    PetOrCompanionParty = 9,
    PetOrCompanionAlliance = 10,
    PetOrCompanionOther = 11,
}

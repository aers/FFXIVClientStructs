namespace FFXIVClientStructs.FFXIV.Component.Log;

//Component::Log::LogModule
//  Component::Log::LogModuleInterface
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct LogModule {
    [FieldOffset(0x08)] public ulong LocalPlayerContentId;

    [FieldOffset(0x14)] public int LogMessageCount;

    [FieldOffset(0x48)] public StdVector<int> LogMessageIndex;
    [FieldOffset(0x60)] public StdVector<byte> LogMessageData;
    
    [VirtualFunction(1)]
    public partial void ClearLog();
    
    [VirtualFunction(2)]
    public partial void SetContentId(ulong contentId);
    
    [VirtualFunction(3)]
    public partial uint GetCurrentLogIndex();
    
    [VirtualFunction(4)]
    public partial int GetLogMessageOverflow();
    
    [VirtualFunction(5)]
    public partial uint GetLogMessageCount();
    
    [VirtualFunction(6)]
    public partial uint AddLogMessageRawString(Utf8String* rawString);
    
    [VirtualFunction(7)]
    public partial uint AddLogMessageRaw(CStringPointer stringPointer, int size);
    
    [VirtualFunction(8)]
    public partial byte* GetLogMessageRawString(Utf8String* rawString, uint index);
    
    [VirtualFunction(9)]
    public partial byte* GetLogMessageRaw(int index, int* outLogMessageIndex);
}

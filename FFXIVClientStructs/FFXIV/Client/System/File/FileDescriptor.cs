namespace FFXIVClientStructs.FFXIV.Client.System.File;

// inlined ctor, see FileManager ctor
[StructLayout(LayoutKind.Explicit, Size = 0x278)]
public unsafe struct FileDescriptor
{
    [FieldOffset(0x0)] public FileMode FileMode;
    [FieldOffset(0x8)] public byte* FileBuffer;
    [FieldOffset(0x10)] public ulong FileLength;
    [FieldOffset(0x18)] public ulong CurrentFileOffset;
    [FieldOffset(0x30)] public void* FileInterface; // Client::System::File::FileInterface
    [FieldOffset(0x60)] public FileDescriptor* Previous; // believe its a queue
    [FieldOffset(0x68)] public FileDescriptor* Next;
    [FieldOffset(0x70)] public fixed byte Utf16FilePath[520];
}
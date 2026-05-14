using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.Interop;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xE0AC8)]
public unsafe partial struct ThreadLocals {

    [FieldOffset(0x238)] public Context* GraphicsKernelContext;


    // Not in data.yml as this is already named by IDA and isn't technically a class member
    [MemberFunction("65 48 8B 04 25 30 00 00 00 C3")]
    public static partial _TEB* NtCurrentTeb();

    [CExporterIgnore]
    [StructLayout(LayoutKind.Explicit, Size = 0x100)] // undefined size, see https://en.wikipedia.org/wiki/Win32_Thread_Information_Block
    public struct _TEB {
        [FieldOffset(0x58)] public ThreadLocals** ThreadLocalStoragePointer;
    }

    public static ThreadLocals* ThreadLocalInstance() {
        return *NtCurrentTeb()->ThreadLocalStoragePointer;
    }
}

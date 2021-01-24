using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework
{
    // Client::System::Framework::Framework

    // size=0x2B50
    // ctor E8 ? ? ? ? 48 8B C8 48 89 05 ? ? ? ? EB 0A 48 8B CE 
    [StructLayout(LayoutKind.Explicit, Size = 0x2B50)]
    public unsafe struct Framework
    {
        [FieldOffset(0x10)] public Client.System.Configuration.SystemConfig SystemConfig;
        [FieldOffset(0x29F8)] public void* UIModule;
    }
}

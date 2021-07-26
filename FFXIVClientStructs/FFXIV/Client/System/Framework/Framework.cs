using System.Runtime.InteropServices;
using FFXIVClientStructs.Common;
using FFXIVClientStructs.FFXIV.Client.System.Configuration;
using FFXIVClientStructs.FFXIV.Client.UI;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework
{
    // Client::System::Framework::Framework

    // size=0x2B50
    // ctor E8 ? ? ? ? 48 8B C8 48 89 05 ? ? ? ? EB 0A 48 8B CE 
    [StructLayout(LayoutKind.Explicit, Size = 0x2B50)]
    public unsafe partial struct Framework
    {
        [FieldOffset(0x10)] public SystemConfig SystemConfig;
        [FieldOffset(0x29F8)] public UIModule* UIModule;

        [MemberFunction("E8 ?? ?? ?? ?? 80 7B 1D 01")]
        public partial UIModule* GetUiModule();
    }
}
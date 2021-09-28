using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.System.Configuration;
using FFXIVClientStructs.FFXIV.Client.UI;
using FFXIVClientStructs.FFXIV.Common.Lua;
using FFXIVClientStructs.FFXIV.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Exd;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework
{
    // Client::System::Framework::Framework

    // size=0x2B50
    // ctor E8 ? ? ? ? 48 8B C8 48 89 05 ? ? ? ? EB 0A 48 8B CE 
    [StructLayout(LayoutKind.Explicit, Size = 0x2B50)]
    public unsafe partial struct Framework
    {
        [FieldOffset(0x10)] public SystemConfig SystemConfig;
        
        [FieldOffset(0x29C8)] public ExcelModuleInterface* ExcelModuleInterface;
        [FieldOffset(0x29D0)] public ExdModule* ExdModule;

        [FieldOffset(0x29F8)] public UIModule* UIModule;
        [FieldOffset(0x2A60)] public LuaState LuaState;

        [StaticAddress("44 0F B6 C0 48 8B 0D ? ? ? ?", isPointer: true)]
        public static partial Framework* Instance();

        [MemberFunction("E8 ?? ?? ?? ?? 80 7B 1D 01")]
        public partial UIModule* GetUiModule();
    }
}
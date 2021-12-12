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

    // size=0x35B8
    // ctor E8 ? ? ? ? 48 8B C8 48 89 05 ? ? ? ? EB 0A 48 8B CE 
    [StructLayout(LayoutKind.Explicit, Size = 0x35B8)]
    public unsafe partial struct Framework
    {
        [FieldOffset(0x10)] public SystemConfig SystemConfig;
        
        [FieldOffset(0x1680)] public long ServerTime;
        [FieldOffset(0x1770)] public long EorzeaTime;

        [FieldOffset(0x2B30)] public ExcelModuleInterface* ExcelModuleInterface;
        [FieldOffset(0x2B38)] public ExdModule* ExdModule;

        [FieldOffset(0x2B60)] public UIModule* UIModule;
        [FieldOffset(0x2BC8)] public LuaState LuaState;

        [StaticAddress("44 0F B6 C0 48 8B 0D ? ? ? ?", isPointer: true)]
        public static partial Framework* Instance();

        [MemberFunction("E8 ?? ?? ?? ?? 80 7B 1D 01")]
        public partial UIModule* GetUiModule();

        [MemberFunction("E8 ?? ?? ?? ?? 03 07", IsStatic = true)]
        public static partial long GetServerTime();
    }
}

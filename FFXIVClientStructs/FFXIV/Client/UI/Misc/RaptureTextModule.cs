using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc {
    // Client::UI::Misc::RaptureTextModule
    // ctor E8 ?? ?? ?? ?? 48 8D B7 ?? ?? ?? ?? 4D 8B C4
    [StructLayout(LayoutKind.Explicit, Size = 0xD58)]
    public unsafe partial struct RaptureTextModule {

        [MemberFunction("E9 ?? ?? ?? ?? 80 EA 20")]
        public partial byte* GetAddonText(uint addonId);

        [MemberFunction("E8 ?? ?? ?? ?? EB 2E 49 8B 4D 10")]
        public partial byte* FormatAddonText2(uint addonId, int intParam1, int intParam2);

        [MemberFunction("E8 ?? ?? ?? ?? EB 55 FF 50 30")]
        public partial byte* FormatAddonText3(uint addonId, int intParam1, int intParam2, int intParam3);
    }
}
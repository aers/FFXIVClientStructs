using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc {
    // Client::UI::Misc::RaptureLogModule
    // ctor E8 ?? ?? ?? ?? 4C 8D AF ?? ?? ?? ?? 49 8B CD
    [StructLayout(LayoutKind.Explicit, Size = 0x3480)]
    public unsafe partial struct RaptureLogModule {

        [MemberFunction("E8 ?? ?? ?? ?? 44 03 FB")]
        public partial void ShowLogMessage(uint logMessageID);
    }
}
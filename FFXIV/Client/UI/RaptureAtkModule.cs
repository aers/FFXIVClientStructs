using FFXIVClientStructs.FFXIV.Client.System.String;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::RaptureAtkModule
    //   Component::GUI::AtkModule
    //     Component::GUI::AtkModuleInterface
    [StructLayout(LayoutKind.Explicit, Size = 0x275E8)] // Size is estimated
    public unsafe struct RaptureAtkModule
    {
        [FieldOffset(0x0)] public void* vtbl;
        [FieldOffset(0x1A248)] public NamePlateInfo NamePlateInfoArray;  // 0-50, &NamePlateInfoArray[i]

        [StructLayout(LayoutKind.Explicit, Size = 0x248)]
        public unsafe struct NamePlateInfo
        {
            [FieldOffset(0x00)] public int ActorID;
            [FieldOffset(0x30)] public Utf8String Name;
            [FieldOffset(0x98)] public Utf8String FcName;
            [FieldOffset(0x100)] public Utf8String Title;
            [FieldOffset(0x168)] public Utf8String DisplayTitle;
            [FieldOffset(0x1D0)] public Utf8String Unk;
            [FieldOffset(0x240)] public int Flags;

            public bool IsPrefixTitle => ((Flags >> (8 * 3)) & 0xFF) == 1;
        }
    }
}

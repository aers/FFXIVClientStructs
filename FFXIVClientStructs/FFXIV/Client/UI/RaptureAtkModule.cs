using System.Runtime.InteropServices;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI
{
    // Client::UI::RaptureAtkModule
    //   Component::GUI::AtkModule
    //     Component::GUI::AtkModuleInterface
    [StructLayout(LayoutKind.Explicit, Size = 0x27718)]
    public struct RaptureAtkModule
    {
        [FieldOffset(0x0)] public AtkModule AtkModule;
        [FieldOffset(0x1A378)] public NamePlateInfo NamePlateInfoArray; // 0-50, &NamePlateInfoArray[i]

        [StructLayout(LayoutKind.Explicit, Size = 0x248)]
        public struct NamePlateInfo
        {
            [FieldOffset(0x00)] public GameObjectID ObjectID;
            [FieldOffset(0x30)] public Utf8String Name;
            [FieldOffset(0x98)] public Utf8String FcName;
            [FieldOffset(0x100)] public Utf8String Title;
            [FieldOffset(0x168)] public Utf8String DisplayTitle;
            [FieldOffset(0x1D0)] public Utf8String LevelText;
            [FieldOffset(0x240)] public int Flags;

            public bool IsPrefixTitle => ((Flags >> (8 * 3)) & 0xFF) == 1;
        }
    }
}
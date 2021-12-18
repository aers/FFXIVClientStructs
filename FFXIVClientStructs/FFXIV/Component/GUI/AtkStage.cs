using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.FFXIV.Client.UI;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // Component::GUI::AtkStage
    //   Component::GUI::AtkEventTarget

    // size = 0x75DF8
    // ctor E8 ? ? ? ? 48 8B F8 48 89 BE ? ? ? ? 48 8B 43 10 
    [StructLayout(LayoutKind.Explicit, Size = 0x75DF8)]
    public unsafe partial struct AtkStage
    {
        [FieldOffset(0x0)] public AtkEventTarget AtkEventTarget;
        [FieldOffset(0x20)] public RaptureAtkUnitManager* RaptureAtkUnitManager;
        [FieldOffset(0x168)] public AtkTooltipManager TooltipManager;
        [FieldOffset(0x338)] public AtkCursor AtkCursor;
        
        [MemberFunction("E8 ? ? ? ? 0F BF D5", IsStatic = true)]
        public static partial AtkStage* GetSingleton();
    }
}
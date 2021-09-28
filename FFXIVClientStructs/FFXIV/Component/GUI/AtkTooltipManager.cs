using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Component.GUI
{
    // Component::GUI::AtkToolTipManager
    //      Component::GUI::AtkEventListener
    [StructLayout(LayoutKind.Explicit, Size=0x150)]
    public unsafe partial struct AtkTooltipManager
    {
        /*
         * unknown1 seems to be specific to the addon
         * I didn't want to define tooltip args because I have no clue what the fields are, but it's like:
         *  byte* text
         *  int64 typeSpecificId (this is where you specify item/action ID for those types)
         *  int unknown1
         *  short unknown2
         *  byte type (1: text, 2: item tooltip, 3: text + item tooltip, 4: action tooltip)
         */
        [MemberFunction("E8 ?? ?? ?? ?? 41 3B ED")]
        public partial void AddTooltip(byte type, ushort unknown1, AtkResNode* targetNode, void* tooltipArgs);

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B CB 48 83 C4 38")]
        public partial void RemoveTooltip(AtkResNode* targetNode);
    }
}
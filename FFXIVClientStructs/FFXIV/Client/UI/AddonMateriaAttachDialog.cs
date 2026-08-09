using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonMateriaAttachDialog
//   Client::UI::AddonMateriaDialogBase
//     Component::GUI::AtkUnitBase
//       Component::GUI::AtkEventListener
[Addon("MateriaAttachDialog")]
[GenerateInterop]
[Inherits<AddonMateriaDialogBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x238)]
public unsafe partial struct AddonMateriaAttachDialog {
    public MateriaAttachDialogAtkValues* TypedAtkValues => (MateriaAttachDialogAtkValues*)AtkValues;

    [StructLayout(LayoutKind.Explicit, Size = AtkValue.StructSize * 58)]
    public struct MateriaAttachDialogAtkValues {
        /// <remarks><see cref="AtkValueType.Int"/>. Success rate percentage (0–100)</remarks>
        [FieldOffset(AtkValue.StructSize * 41)] public AtkValue SuccessRate;
    }
}

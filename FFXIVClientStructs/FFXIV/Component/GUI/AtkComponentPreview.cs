using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentPreview
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// type 23
[GenerateInterop]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe partial struct AtkComponentPreview {
    [FieldOffset(0xC0)] public AtkUldComponentDataPreview Data;

    [MemberFunction("E8 ?? ?? ?? ?? 48 89 43 ?? 48 85 C0 74 ?? 33 FF")]
    public partial AtkCollisionNode* GetCollisionNode();

    [MemberFunction("E9 ?? ?? ?? ?? 33 FF 48 89 79")]
    public partial bool SetTexture(Texture* texture);

    [MemberFunction("40 53 48 83 EC ?? F6 81 ?? ?? ?? ?? ?? 48 8B DA 74 ?? 44 8B 91"), GenerateStringOverloads]
    public partial void SetErrorText(CStringPointer text);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? 80 F3 ?? 48 85 C9")]
    public partial void SetErrorVisibility(bool visible);
}

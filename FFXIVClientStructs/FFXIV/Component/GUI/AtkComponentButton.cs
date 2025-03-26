using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkComponentButton
//   Component::GUI::AtkComponentBase
//     Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 1
[GenerateInterop(isInherited: true)]
[Inherits<AtkComponentBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe partial struct AtkComponentButton : ICreatable {
    // based on the text size
    [FieldOffset(0xC0)] public short Left;
    [FieldOffset(0xC2)] public short Top;
    [FieldOffset(0xC4)] public short Right;
    [FieldOffset(0xC6)] public short Bottom;
    [FieldOffset(0xC8)] public AtkTextNode* ButtonTextNode;
    [FieldOffset(0xD0)] public AtkResNode* ButtonBGNode;
    [FieldOffset(0xE8)] public uint Flags;

    public bool IsEnabled => AtkComponentBase.OwnerNode->AtkResNode.NodeFlags.HasFlag(NodeFlags.Enabled);

    /// <remarks> Used by AtkComponentCheckBox and AtkComponentRadioButton. </remarks>
    public bool IsChecked {
        get => (Flags & (1 << 18)) != 0;
        set => SetChecked(value);
    }

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 88 9F ?? ?? ?? ??")]
    public partial void Ctor();

    /// <summary>
    /// Set the text of the component button node.
    /// The game assumes the pointer passed to this function will stay alive. See <see href="https://github.com/aers/FFXIVClientStructs/issues/1040">here</see> for more information.
    /// </summary>
    /// <param name="text">Null-terminated UTF-8 string buffer to set the text to.</param>
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B D9 48 8B FA 48 8B 89 ?? ?? ?? ?? 48 85 C9 0F 84 ?? ?? ?? ?? 48 85 D2 74 ?? 0F B6 81")]
    public partial void SetText(CStringPointer text);

    public void SetText(string str) {
        int strUtf8Len = Encoding.UTF8.GetByteCount(str);
        Span<byte> strBytes = strUtf8Len <= 511 ? stackalloc byte[512] : new byte[strUtf8Len + 1];
        Encoding.UTF8.GetBytes(str, strBytes);
        strBytes[strUtf8Len] = 0;
        fixed (byte* strPtr = strBytes) {
            SetText(strPtr);
        }
        if (ButtonTextNode != null)
            ButtonTextNode->OriginalTextPointer = ButtonTextNode->NodeText.StringPtr;
    }

    public void SetText(ReadOnlySpan<byte> str) {
        fixed (byte* strPtr = str) {
            SetText(strPtr);
        }
        if (ButtonTextNode != null)
            ButtonTextNode->OriginalTextPointer = ButtonTextNode->NodeText.StringPtr;
    }

    /// <remarks> Used by AtkComponentCheckBox and AtkComponentRadioButton. </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? 8D 46 12")]
    public partial void SetChecked(bool isChecked);
}

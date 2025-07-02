using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;
// note: Name made up
// This is the "hold to proceed" button type

// Component::GUI::AtkComponentHoldButton
//   Component::GUI::AtkComponentButton
//     Component::GUI::AtkComponentBase
//       Component::GUI::AtkEventListener
// common CreateAtkComponent function "E8 ?? ?? ?? ?? 4C 8B F0 48 85 C0 0F 84 ?? ?? ?? ?? 49 8B 4D 08"
// type 24
[GenerateInterop]
[Inherits<AtkComponentButton>]
[StructLayout(LayoutKind.Explicit, Size = 0x120)]
public unsafe partial struct AtkComponentHoldButton : ICreatable {
    [FieldOffset(0xF0)] public AtkResNode* ProgressResNode;
    [FieldOffset(0xF8)] public AtkImageNode* ProgressImageNode;
    [FieldOffset(0x100)] public bool IsTargetReached;
    [FieldOffset(0x101)] public bool IsEventFired; // seems to be a safety mechanism to prevent multiple events from firing at the same time

    [FieldOffset(0x104)] public float Duration;
    [FieldOffset(0x108)] public float DecreaseRate;
    [FieldOffset(0x10C)] public ProgressState Progress;

    [MemberFunction("40 53 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? C7 83 ?? ?? ?? ?? ?? ?? ?? ?? 48 89 03 33 C0 48 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ?? 66 89 83 ?? ?? ?? ?? 48 89 83 ?? ?? ?? ??")]
    public partial void Ctor();

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct ProgressState {
        [FieldOffset(0x00)] public float StartValue;
        [FieldOffset(0x04)] public float TargetValue;
        [FieldOffset(0x08)] public float CurrentValue;
        [FieldOffset(0x0C)] public float EndValue;

        [MemberFunction("F3 0F 10 05 ?? ?? ?? ?? 0F 2F C1 F3 0F 11 51")]
        public partial void StartProgress(float currentValue, float targetValue, float endValue);
    }
}

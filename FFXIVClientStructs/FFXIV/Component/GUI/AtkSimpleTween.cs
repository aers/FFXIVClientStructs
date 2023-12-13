using FFXIVClientStructs.FFXIV.Client.System.Memory;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkSimpleTween
//   Component::GUI::AtkEventTarget

/// <summary>
/// Runs simple transitions on an AtkResNode.
/// </summary>
/// <remarks>
/// Transitions are calculated with a sinusoidal ease-out function and will run simultaneously.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct AtkSimpleTween : ICreatable {
    [FieldOffset(0x8)] public SimpleTweenState State;
    [FieldOffset(0x10)] public AtkResNode* Node;
    [FieldOffset(0x18)] public float CurrentTimestamp;
    [FieldOffset(0x1C)] public float Duration;
    [FieldOffset(0x20)] public StdVector<SimpleTweenAnimation> Animations;
    [FieldOffset(0x38)] public int Id;
    [FieldOffset(0x40)] public AtkEvent* Event;
    [FieldOffset(0x48)] public float EasingFactor;

    [MemberFunction("E8 ?? ?? ?? ?? 89 6B 58")]
    public partial void Ctor();

    [VirtualFunction(1)]
    public partial void Dtor();

    [MemberFunction("E9 ?? ?? ?? ?? 48 83 B9 ?? ?? ?? ?? ?? 74 8E")]
    public partial void Clear();

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 87 ?? ?? ?? ?? 4C 8B CF")]
    public partial void Prepare(int duration, AtkResNode* node, SimpleTweenValue* values, uint numValues, float easingFactor = 0.5f);

    [MemberFunction("E8 ?? ?? ?? ?? FF 4F 5C")]
    public partial void Execute();

    /// <remarks>
    /// Only <see cref="AtkEventType.TweenProgress"/> and <see cref="AtkEventType.TweenComplete"/> will be dispatched.
    /// </remarks>
    [MemberFunction("48 83 EC 48 0F B6 44 24 ?? 4C 8B D1")]
    public partial void RegisterEvent(AtkEventType eventType, uint eventParam, AtkEventListener* listener, AtkResNode* nodeParam, bool systemEvent);

    [MemberFunction("0F B6 44 24 ?? 48 83 C1 40")]
    public partial void UnregisterEvent(AtkEventType eventType, uint eventParam, AtkEventListener* listener, bool systemEvent);

    [MemberFunction("48 83 EC 28 0F 57 C0 83 FA 08")]
    public partial float GetNodeValue(SimpleTweenValueType type);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5B 08 48 85 DB 75 DF")]
    public partial void SetNodeValue(SimpleTweenValueType type, float value);

    [MemberFunction("E8 ?? ?? ?? ?? EB 31 48 63 50 38")]
    public partial void Update(float delta);
}

[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe struct SimpleTweenAnimation {
    [FieldOffset(0x0)] public SimpleTweenAnimation* Next;
    [FieldOffset(0x8)] public SimpleTweenAnimation* Previous;
    [FieldOffset(0x10)] public SimpleTweenValueType Type;
    [FieldOffset(0x14)] public float StartValue;
    [FieldOffset(0x18)] public float Delta; // SimpleTweenValue.Value - StartValue
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct SimpleTweenValue {
    [FieldOffset(0)] public SimpleTweenValueType Type;
    [FieldOffset(0x4)] public float Value;
}

public enum SimpleTweenState : uint {
    None = 0,
    Tweening = 1,
    Complete = 2
}

public enum SimpleTweenValueType : uint {
    X = 0,
    Y = 1,
    ScaleX = 2,
    ScaleY = 3,
    /// <remarks>
    /// Will be converted into two separate SimpleTweenAnimations, ScaleX and ScaleY, with the same value.<br/>
    /// Can not be used with GetNodeValue or SetNodeValue.
    /// </remarks>
    Scale = 4,
    /// <remarks>
    /// When the alpha value reaches 0, it will automatically make the node invisible (same as calling <see cref="AtkResNode.ToggleVisibility(bool)"/> with <c>false</c>).<br/>
    /// In order to make the transition from 0 work, it is necessary to call <see cref="AtkResNode.ToggleVisibility(bool)"/> with <c>true</c> first.
    /// </remarks>
    Alpha = 5,
    Width = 6,
    Height = 7,
    /// <remarks>
    /// When using this, the node must be a <see cref="AtkTextNode"/>, so it can read/write <see cref="AtkTextNode.NodeText"/>.<br/>
    /// Internally, the value is cast from float to int and then converted to an Utf8String.
    /// </remarks>
    NodeText = 8,
}

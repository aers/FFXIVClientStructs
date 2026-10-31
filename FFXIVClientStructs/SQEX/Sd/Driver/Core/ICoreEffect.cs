namespace FFXIVClientStructs.SQEX.Sd.Driver.Core;

// SQEX::Sd::Driver::Core::ICoreEffect
/// <summary>
/// The interface of an effect of the software mixer, the pointer source, submix and master voices hold in their effect lists.
/// Effects process the voice's buffer in place every period, after the voice volume and before the voice's sends.
/// </summary>
/// <remarks>
/// The effects of a submix or master voice only see the sum of everything routed to that voice. A source voice whose volume is (almost) 0
/// runs neither its effects nor its sends.
/// </remarks>
[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x08)]
public unsafe partial struct ICoreEffect {
    /// <summary> Clears the state of the effect, like the delay lines of the reverb. </summary>
    [VirtualFunction(1)]
    public partial void Reset();

    /// <summary> While this returns true the voice skips the effect. </summary>
    [VirtualFunction(2)]
    public partial bool IsBypassed();

    /// <summary> A submix that received nothing this period still processes the effects that return true here. Only the reverb does. </summary>
    [VirtualFunction(3)]
    public partial bool RunsWithoutInput();

    [VirtualFunction(5)]
    public partial void Process(EffectBuffer* buffer);

    [StructLayout(LayoutKind.Explicit, Size = 0x14)]
    public unsafe struct EffectBuffer {
        /// <summary> Interleaved samples, processed in place. </summary>
        [FieldOffset(0x00)] public float* Samples;
        [FieldOffset(0x0C)] public int FrameCount;
        [FieldOffset(0x10)] public int ChannelCount;
    }
}

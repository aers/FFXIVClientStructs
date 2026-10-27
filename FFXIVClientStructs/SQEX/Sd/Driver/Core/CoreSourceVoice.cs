namespace FFXIVClientStructs.SQEX.Sd.Driver.Core;

// SQEX::Sd::Driver::Core::CoreSourceVoice
//   SQEX::Sd::Driver::Core::ICoreSourceVoice
//   SQEX::Sd::Driver::Core::ICoreVoice
//   SQEX::Sd::SeadObject<1,16>
/// <summary>
/// A voice of the software mixer. The mixer renders all voices every period (256 frames at 48 kHz) and adds the result
/// to the submix and master voices the voice is routed to.
/// </summary>
/// <remarks>
/// Changes made through <see cref="SetVolume"/>, <see cref="SetPitch"/> and <see cref="SetOutputMatrix"/> go to
/// <see cref="PendingParams"/> and only reach the mixer when <see cref="CommitChanges"/> copies them to <see cref="CurrentParams"/>.
/// A voice with a volume of (almost) 0 sends nothing, but still consumes its buffers at the normal rate, so the owner keeps submitting
/// decoded samples to it. The input of <see cref="SubmitBuffer"/> is before any volume, panning, effect or master volume.
/// </remarks>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xA48)]
public unsafe partial struct CoreSourceVoice {
    /// <summary> The voice is rendered while this is 3. </summary>
    [FieldOffset(0xA8)] public int State;

    /// <summary> The callback object of the owner, the owner (<c>VoiceSead</c>) starts 8 bytes before it. </summary>
    [FieldOffset(0xB0)] public nint Callback;

    /// <summary> 1 for 16-bit samples, otherwise samples are 4 bytes. </summary>
    [FieldOffset(0xB8)] public int SampleType;
    [FieldOffset(0xBC)] public int SampleRate;

    /// <summary> The read position in samples, advanced by the resampling step every frame. Set to the start position of a buffer submitted to an empty queue. </summary>
    [FieldOffset(0xC0)] public double Position;
    [FieldOffset(0xD4)] public int InputChannels;
    [FieldOffset(0xD8)] public int QueuedBufferCount;
    [FieldOffset(0xDC)] public int CurrentBufferIndex;

    /// <summary> The read offset in the current buffer. </summary>
    [FieldOffset(0xE0)] public int BufferReadOffset;
    [FieldOffset(0xE8), FixedSizeArray] internal FixedSizeArray2<QueuedBuffer> _buffers;

    /// <summary> The parameters written by the setters, applied by <see cref="CommitChanges"/>. </summary>
    [FieldOffset(0x128)] public VoiceParams PendingParams;

    /// <summary> The parameters the mixer uses. </summary>
    [FieldOffset(0x530)] public VoiceParams CurrentParams;

    /// <summary> The volume of the previous period. The mixer ramps linearly from it to the current volume over one period. </summary>
    [FieldOffset(0x938)] public float PreviousVolume;

    /// <summary> The format of the voice the output goes to, it gives the number of output channels. </summary>
    [FieldOffset(0xA40)] public uint OutputFormat;

    /// <returns> 0, or -1 if the voice is not started. The same for the other setters. </returns>
    [VirtualFunction(8)]
    public partial int SetVolume(float volume);

    [VirtualFunction(9)]
    public partial int SetPitch(float pitch);

    /// <param name="matrix">The gains for the mix, one row per output channel and one column per input channel.</param>
    [VirtualFunction(10)]
    public partial int SetOutputMatrix(float* matrix);

    [VirtualFunction(11)]
    public partial int CommitChanges();

    /// <summary> Queues decoded samples for the voice. </summary>
    /// <param name="data">Interleaved samples of <see cref="InputChannels"/> channels in the format of <see cref="SampleType"/>.</param>
    /// <param name="size">The size in bytes, a multiple of the frame size.</param>
    /// <param name="context">Passed back to the callback when the buffer is started and when it is finished.</param>
    /// <param name="startPosition">Written to <see cref="Position"/> when the queue was empty.</param>
    /// <returns> 0, or -1 if the voice is not usable, two buffers are already queued or the size is not a multiple of the frame size. </returns>
    [VirtualFunction(12)]
    public partial int SubmitBuffer(void* data, ulong size, nint context, int startPosition);

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe struct QueuedBuffer {
        [FieldOffset(0x00)] public void* Data;
        [FieldOffset(0x08)] public ulong Size;
        [FieldOffset(0x10)] public int StartPosition;
        [FieldOffset(0x18)] public nint Context;
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x408)]
    public partial struct VoiceParams {
        [FieldOffset(0x00)] public float Volume; // 1.0f
        [FieldOffset(0x04)] public float Pitch; // 1.0f

        /// <summary> 16x16 gains, only the first <c>output channels x input channels</c> entries are used. </summary>
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray256<float> _outputMatrix;
    }
}

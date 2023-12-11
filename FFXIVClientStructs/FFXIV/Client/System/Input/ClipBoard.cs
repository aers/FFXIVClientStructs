using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.System.Input;

// Client::System::Input::ClipBoard
//   Client::System::Input::ClipBoardInterface
[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 8B D9 48 89 01 48 83 C1 08 E8 ?? ?? ?? ?? 48 8D 4B 70 E8 ?? ?? ?? ?? 48 8B C3", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0xD8)]
public unsafe partial struct ClipBoard {
    [FieldOffset(0x08)] public Utf8String SystemClipboardText;
    [FieldOffset(0x70)] public Utf8String CopyStagingText;

    /// <summary>
    /// Writes to the system clipboard.<br />
    /// Currently, <c>this</c> is unused; this might as well be a static function, but all uses of it are indirect.
    /// </summary>
    /// <param name="stringToCopy">[in] The string to copy with payloads.</param>
    /// <param name="copiedStringWithoutPayload">[inout] The copied string without payloads.</param>
    [VirtualFunction(1)]
    public partial void WriteToSystemClipboard(Utf8String* stringToCopy, Utf8String* copiedStringWithoutPayload);

    /// <summary>
    /// Retrieves the current system clipboard text.<br />
    /// Currently, <see cref="SystemClipboardText"/> is updated after this call.
    /// </summary>
    /// <returns>The text retrieved from the system clipboard.</returns>
    [VirtualFunction(2)]
    public partial Utf8String* GetSystemClipboardText();

    /// <summary>
    /// Sets the copy staging text.<br />
    /// Currently, this effectively copies <paramref name="utf8String"/> to <see cref="CopyStagingText"/>.
    /// </summary>
    /// <param name="utf8String">[in] The text.</param>
    [VirtualFunction(3)]
    public partial void SetCopyStagingText(Utf8String* utf8String);

    /// <summary>
    /// Sets the copy staging text to the system clipboard.<br />
    /// Currently, this effectively calls <see cref="WriteToSystemClipboard"/>, using <see cref="CopyStagingText"/> as both parameters.
    /// </summary>
    [VirtualFunction(4)]
    public partial void ApplyCopyStagingText();
}

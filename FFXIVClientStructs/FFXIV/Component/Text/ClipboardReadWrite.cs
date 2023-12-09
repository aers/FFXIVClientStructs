using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[StructLayout(LayoutKind.Sequential, Size = 0xD8)]
public unsafe struct ClipboardReadWrite {
    public ClipboardManagerVtbl* vtbl;
    public Utf8String SystemClipboardText;
    public Utf8String CopyStagingText;

    private ClipboardReadWrite* ThisPtr => (ClipboardReadWrite*)Unsafe.AsPointer(ref this);

    /// <summary>
    /// Writes to the system clipboard.
    /// </summary>
    /// <param name="stringToCopy">[in] The string to copy with payloads.</param>
    /// <param name="copiedStringWithoutPayload">[inout] The copied string without payloads.</param>
    public void WriteToSystemClipboard(Utf8String* stringToCopy, Utf8String* copiedStringWithoutPayload) =>
        ThisPtr->vtbl->WriteToSystemClipboard(ThisPtr, stringToCopy, copiedStringWithoutPayload);

    /// <summary>
    /// Retrieves the current system clipboard text.
    /// </summary>
    /// <returns></returns>
    public ref Utf8String GetSystemClipboardText() => ref *ThisPtr->vtbl->GetSystemClipboardText(ThisPtr);

    /// <summary>
    /// Sets the copy staging text.
    /// </summary>
    /// <param name="utf8String">The text.</param>
    public void SetCopyStagingText(Utf8String* utf8String) => ThisPtr->vtbl->SetCopyStagingText(ThisPtr, utf8String);

    /// <summary>
    /// Sets the copy staging text to the system clipboard.
    /// </summary>
    public void ApplyCopyStagingText() => ThisPtr->vtbl->ApplyCopyStagingText(ThisPtr);

    [StructLayout(LayoutKind.Sequential)]
    public struct ClipboardManagerVtbl {
        public delegate* unmanaged<ClipboardReadWrite*, uint, ClipboardReadWrite*> Dtor;
        public delegate* unmanaged<ClipboardReadWrite*, Utf8String*, Utf8String*, void> WriteToSystemClipboard;
        public delegate* unmanaged<ClipboardReadWrite*, Utf8String*> GetSystemClipboardText;
        public delegate* unmanaged<ClipboardReadWrite*, Utf8String*, void> SetCopyStagingText;
        public delegate* unmanaged<ClipboardReadWrite*, void> ApplyCopyStagingText;
    }
}

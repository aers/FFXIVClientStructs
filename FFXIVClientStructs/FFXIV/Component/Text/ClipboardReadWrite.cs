using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Component.Text;

[StructLayout(LayoutKind.Sequential, Size = 0xD8)]
public unsafe struct ClipboardReadWrite {
    public ClipboardManagerVtbl* vtbl;
    public Utf8String SystemClipboardText;
    public Utf8String CopyStagingText;

    private ClipboardReadWrite* ThisPtr => (ClipboardReadWrite*)Unsafe.AsPointer(ref this);

    public void WriteToSystemClipboard(Utf8String* withPayload, Utf8String* withoutPayload) =>
        ThisPtr->vtbl->WriteToSystemClipboard(ThisPtr, withPayload, withoutPayload);

    public ref Utf8String GetSystemClipboardText() => ref *ThisPtr->vtbl->GetSystemClipboardText(ThisPtr);

    public void SetCopyStagingText(Utf8String* utf8String) => ThisPtr->vtbl->SetCopyStagingText(ThisPtr, utf8String);

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


namespace FFXIVClientStructs.FFXIV.Common;

// Helper to use the native spinlocks like the game does
[StructLayout(LayoutKind.Explicit, Size = 0x04)]
public unsafe struct Spinlock {

    [FieldOffset(0x00)] private uint _sentinel;

    /// <summary>
    /// Waits until the spinlock is free and then locks it.
    /// </summary>
    /// <returns>A Disposable struct that will release the spinlock when disposed.</returns>
    public Scope Acquire() {
        // This is inlined in native code
        while (Interlocked.Exchange(ref _sentinel, 1) != 0) {
            Thread.Sleep(0);
        }
#pragma warning disable CS9084 // Struct member returns 'this' or other instance members by reference
        return new Scope(ref _sentinel);
#pragma warning restore CS9084 // Struct member returns 'this' or other instance members by reference
    }

    [CExporterIgnore]
    public ref struct Scope : IDisposable {
        private readonly ref uint _sentinel;

        internal Scope(ref uint sentinel) {
            _sentinel = ref sentinel;
        }

        // This is inlined in native code
        public void Dispose() {
            Interlocked.Exchange(ref _sentinel, 0);
        }
    }
}

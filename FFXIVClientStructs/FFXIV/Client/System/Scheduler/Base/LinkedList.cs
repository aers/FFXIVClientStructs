namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

// Client::System::Scheduler::Base::LinkedList
[StructLayout(LayoutKind.Sequential)]
public unsafe struct LinkedList<T> where T : unmanaged {
    public T* First;
    public T* Last;
}

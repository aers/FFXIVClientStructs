
using System.Runtime.InteropServices;


namespace FFXIVClientStructs.FFXIV.Client.Graphics.Kernel
{
    // Client::Graphics::Kernel::Device
    //   Client::Graphics::Singleton
    [StructLayout(LayoutKind.Explicit, Size = 0x210)]
    public unsafe struct Device
    {
        [FieldOffset(0x80)] public SwapChain* SwapChain;
    }
}

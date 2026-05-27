using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Environment;

// Client::LayoutEngine::Environment::LayoutEnvironment
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe struct LayoutEnvironment {
    [FieldOffset(0x08)] public LayoutManager* LayoutManager;
    [FieldOffset(0x10)] public EnvScene* GraphicsEnvironment; // Only set in the ActiveLayout, null in the GlobalLayout
    [FieldOffset(0x18)] private void* Unk18;
}

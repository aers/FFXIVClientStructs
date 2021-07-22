using System.Runtime.InteropServices;


namespace FFXIVClientStructs.FFXIV.Client.Game
{
    [StructLayout(LayoutKind.Explicit, Size = 0x188)]
    public unsafe struct StatusManager
    {
        // This field is often null and cannot be relied on to retrieve the owning Character object
        [FieldOffset(0x0)] public Character.Character* Owner;
        [FieldOffset(0x8)] public fixed byte Status[0xC * 30]; // Client::Game::Status array
        [FieldOffset(0x170)] public uint Unk_170;
        [FieldOffset(0x174)] public ushort Unk_174;
        [FieldOffset(0x178)] public long Unk_178;
        [FieldOffset(0x180)] public byte Unk_180;
    }
}

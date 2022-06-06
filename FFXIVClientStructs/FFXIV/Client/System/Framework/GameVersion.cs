using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework; 

// Allocates a lot of space for inlined array, even though it only uses 5 strings.
[StructLayout(LayoutKind.Explicit, Size = 0x900)]
public unsafe struct GameVersion {
    [FieldOffset(0x00)] private fixed byte baseVersion[32];
    // Big unused gap between base and expansions
    [FieldOffset(0xE0)] private fixed byte expansionVersion[32 * 10];

    public string Base => this[0];
    public string Heavensward => this[1];
    public string Stormblood => this[2];
    public string Shadowbringers => this[3];
    public string Endwalker => this[4];
        
    public string this[int i] {
        get {
            if (i == 0) {
                fixed (byte* p = baseVersion) {
                    return Encoding.UTF8.GetString(p, 32).TrimEnd('\0');
                }
            }
            fixed (byte* p = expansionVersion) {
                return Encoding.UTF8.GetString(p + i * 32, 32).TrimEnd('\0');
            }
        }
    }
}
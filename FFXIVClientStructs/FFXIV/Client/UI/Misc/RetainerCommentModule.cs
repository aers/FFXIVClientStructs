using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RetainerModule
// ctor 48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 33 ED 48 89 51 10 48 8D 05 ?? ?? ?? ?? 48 89 69 08 48 8B F1
[StructLayout(LayoutKind.Explicit, Size = 0x450)]
public unsafe partial struct RetainerCommentModule {
    public static RetainerCommentModule* Instance() => Framework.Instance()->GetUiModule()->GetRetainerCommentModule();
    
    [FieldOffset(0x40)] public RetainerCommentList Retainers;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B BC 24 ?? ?? ?? ?? 48 8B B4 24 ?? ?? ?? ?? 49 8B 4E 10")]
    [GenerateCStrOverloads]
    public partial void* SetComment(ulong retainerID, byte* comment);

    [MemberFunction("4C 8B D9 48 85 D2 74 27")]
    public partial byte* GetComment(ulong retainerId);
    
    [StructLayout(LayoutKind.Sequential, Size = 0x410)]
    public struct RetainerCommentList {
        private fixed byte data[0x68 * 10];
        
        public RetainerComment* this[int i]
        {
            get
            {
                if (i is < 0 or > 9) return null;
                fixed (byte* p = data)
                {
                    return (RetainerComment*) (p + sizeof(RetainerComment) * i);
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 0x68)]
    public struct RetainerComment {
        public ulong ID;
        public string Comment {
            get {
                var comment = Instance()->GetComment(ID);
                if (comment == null || comment[0] == 0) return string.Empty;
                int i;
                for (i = 0; i < 0x5B; i++) if (comment[i] == 0) break;
                return Encoding.UTF8.GetString(comment, i).TrimEnd('\0');
                
            }
            set => Instance()->SetComment(ID, value);
        }
        
    }
}

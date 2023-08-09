using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RetainerCommentModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 49 8B D4 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 8B D7"
[StructLayout(LayoutKind.Explicit, Size = 0x5A0)]
public unsafe partial struct RetainerCommentModule
{
    public static RetainerCommentModule* Instance() => Framework.Instance()->GetUiModule()->GetRetainerCommentModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
    [FieldOffset(0x40)] public RetainerCommentList Retainers;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B BC 24 ?? ?? ?? ?? 48 8B B4 24 ?? ?? ?? ?? 49 8B 4E 10")]
    [GenerateCStrOverloads]
    public partial void* SetComment(ulong retainerID, byte* comment);

    [MemberFunction("32 C0 0F 1F 40 00 66 66 0F 1F 84 ?? 00 00 00 00 44 0F B6 C0 4C 8D 51")]
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

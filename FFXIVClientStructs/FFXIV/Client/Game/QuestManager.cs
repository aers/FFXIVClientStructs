using System;

namespace FFXIVClientStructs.FFXIV.Client.Game;

// idk if this is a manager, but I don't know what else to call it
[StructLayout(LayoutKind.Explicit)]
public unsafe partial struct QuestManager
{
    [MemberFunction("E8 ?? ?? ?? ?? 66 BA 10 0C", IsStatic = true)]
    public static partial QuestManager* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 41 88 84 2C", IsStatic = true)]
    public static partial bool IsQuestComplete(ushort questId);

    public static bool IsQuestComplete(uint questId) => IsQuestComplete((ushort)(questId & 0xFFFF));

    [MemberFunction("E8 ?? ?? ?? ?? 3A 43 06", IsStatic = true)]
    public static partial bool IsQuestCurrent(ushort questId);

    public static bool IsQuestCurrent(uint questId) => IsQuestCurrent((ushort)(questId & 0xFFFF));

    [FieldOffset(0x10)] public QuestListArray Quest;

    [StructLayout(LayoutKind.Explicit)]
    public struct QuestListArray
    {
        [FieldOffset(0x00)] private fixed byte data[0x18 * 30];

        public Quest* this[int index]
        {
            get
            {
                if (index < 0 || index > 30) return null;

                fixed (byte* pointer = data)
                {
                    return (Quest*) (pointer + sizeof(Quest) * index);
                }
            }
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct Quest
        {
            [FieldOffset(0x08)] public ushort QuestID;
            [FieldOffset(0x0B)] public QuestFlags Flags; // 1 for Priority, 8 for Hidden

            public bool IsHidden => Flags.HasFlag(QuestFlags.Hidden);

            [Flags]
            public enum QuestFlags : byte
            {
                None,
                Priority,
                Hidden = 0x8
            }
        }
    }
}
namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentScenarioTree
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ScenarioTree)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct AgentScenarioTree {
    [FieldOffset(0x28)] public AgentScenarioTreeData* Data;

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public partial struct AgentScenarioTreeData {
        /// <summary>
        /// [0] Main Scenario Quest Path 1<br/>
        /// [1] Main Scenario Quest Path 2<br/>
        /// [2] Main Scenario Quest Path 3<br/>
        /// [3] Last completed Main Scenario Quest (Only populated if no MSQ is accepted and the MSQ wasn't finished yet)
        /// </summary>
        [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray4<ushort> _mainScenarioQuestIds;
        /// <summary>
        /// [0] Primary Job Quest<br/>
        /// [1] Secondary Job Quest
        /// </summary>
        [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray2<ushort> _jobQuestIds;
        [FieldOffset(0x0C)] private uint UnkC; // 0 or 1
        [FieldOffset(0x10)] public byte ScenarioTreeTipsId;
        [FieldOffset(0x11)] public sbyte GrandCompany;
        /// <remarks> Used as index for the <see cref="JobQuestIds"/> array. </remarks>
        [FieldOffset(0x12)] public byte JobQuestIndex;
        [FieldOffset(0x13)] private bool Unk13;
        [FieldOffset(0x14)] private bool Unk14;
        [FieldOffset(0x15)] private bool Unk15;

        [FieldOffset(0x18)] private CStringPointer Unk18;
        /// <remarks>
        /// 0 = Normal<br/>
        /// 1 = In Duty/Duty Recorder<br/>
        /// 2 = ScenarioTreeCompleteDisp != 0
        /// </remarks>
        [FieldOffset(0x20)] public uint DisplayMode;
        /// <summary>
        /// 0 = Nothing<br/>
        /// 1 = Update/Next Quest?!<br/>
        /// 2 = Open ScenarioTreeDetail (Main Scenario Quest Tree) for MainScenarioQuestIds 0-2<br/>
        /// 3 = Open MSQ on Map<br/>
        /// 4 = Open Job Quest on Map
        /// </summary>
        [FieldOffset(0x24)] public uint CommandType;
        [FieldOffset(0x28)] public uint ScenarioTreeDetailAddonId;
        /// <summary> The currently selected MSQ path. </summary>
        /// <remarks> Used as index for the <see cref="MainScenarioQuestIds"/> array. </remarks>
        [FieldOffset(0x2C)] public byte MSQPathIndex;
        [FieldOffset(0x2D)] private bool Unk2D;

        [FieldOffset(0x00), Obsolete("Use MainScenarioQuestIds[0]")] public ushort CurrentScenarioQuest; // CurrentScenarioQuest | 0x10000U = Quest row
        [FieldOffset(0x06), Obsolete("Use MainScenarioQuestIds[3]")] public ushort CompleteScenarioQuest; // Only populated if no MSQ is accepted
    }
}

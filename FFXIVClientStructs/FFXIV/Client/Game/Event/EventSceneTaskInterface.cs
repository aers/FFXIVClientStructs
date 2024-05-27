namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventSceneTaskInterface
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct EventSceneTaskInterface {
    [FieldOffset(0x08)] public EventSceneTaskType Type;
    [FieldOffset(0x0C)] public byte Flags;
}

public enum EventSceneTaskType : uint {
    None = 0,
    CreateAppearance = 1,
    BindCharacterByEntityId = 2,
    BindCharacterByLayoutId = 3,
    // 4 unused
    BindObjectByLayoutId = 5,
    LoadMovePosition = 6,
    PlayCutScene = 7,
    PrepareCutScene = 8,
    PostCutScene = 9,
    PlayStaffRoll = 10,
    PlayToBeContinued = 11,
    InitializeScene = 12,
    FinalizeScene = 13,
    SetPosition = 14,
    WaitForTime = 15,
    CancelEventScene = 16,
    WaitForTurn = 17,
    WaitForAction = 18,
    WaitForEmote = 19,
    WaitForLookAt = 20,
    WaitForMove = 21,
    WaitForTransparency = 22,
    // 23 unused
    WaitForFade = 24,
    WaitForCameraPan = 25,
    WaitForCameraDolly = 26,
    WaitForCameraZoom = 27,
    WaitForCameraGyro = 28,
    WaitForCameraOrbit = 29,
    // 30 not found
    EquipChange = 31,
    EquipQuestModel = 32,
    IsItemObtainable = 33,
    CheckItemsObtainable = 34,
    CheckItemsObtainableRareCheck = 35,
    HairMake = 36,
    WaitForBuildHouse = 37,
    WaitForFeedBuddy = 38,
    RequestRacingChocoboParam = 39,
    RacingChocoboName = 40,
    RequestAirshipsInfo = 41,
    RequestAirshipParam = 42,
    RequestAirshipExplorationResult = 43,
    SubmarineWaitCreateExplorationLog = 44,
    WaitForRetainerTaskLoaded = 45,
    WaitForCutSceneReplayDataLoaded = 46,
    WaitForIdleCamera = 47,
    GroupPose = 48,
    Snipe = 49,
    FashionCheck = 50,
    WaitForSharedGroupTimeline = 51,
    WaitForWhiteFade = 52,
    WaitForPathMove = 53,
    IsQuestSetCompleted = 54
}

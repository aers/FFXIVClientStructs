namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventGPoseController
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3590)]
public unsafe partial struct EventGPoseController {
    [MemberFunction("48 89 5C 24 ?? 57 41 54 41 56 48 83 EC 20 33 FF")]
    public partial void AddCharacterToGPose(Character.Character* character, ulong a1 = 0);

    [MemberFunction("45 33 D2 4C 8D 81 ?? ?? ?? ?? 41 8B C2 4C 8B C9 49 3B 10")]
    public partial void RemoveCharacterFromGPose(Character.Character* character);

    [MemberFunction("E8 ?? ?? ?? ?? 41 88 86 ?? ?? ?? ?? 49 8B CD")]
    public partial bool IsFaceCameraEnabled();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 33 D2 48 8B CB E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? B2 ?? E8")]
    public partial void ToggleFaceCamera();

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B6 9E ?? ?? ?? ?? 48 8D 4E")]
    public partial bool IsGazeCameraEnabled();

    [MemberFunction("40 53 48 83 EC 20 48 83 3D ?? ?? ?? ?? ?? 48 8B D9 74 39")]
    public partial void ToggleGazeCamera();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? F3 0F 10 9F")]
    public partial void ToggleMotionFreeze(bool allCharacters);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 39 27")]
    public partial void EnableCameraLight(uint index);

    [MemberFunction("48 83 EC 28 83 FA 03 73 43")]
    public partial void DisableCameraLight(uint index);
}

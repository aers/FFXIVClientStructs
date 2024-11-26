namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

// Client::Game::Event::EventGPoseController
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2F80)]
public unsafe partial struct EventGPoseController {
    [MemberFunction("48 89 5C 24 ?? 57 41 54 41 56 48 83 EC 20 33 FF")]
    public partial void AddCharacterToGPose(Character.Character* character, ulong a1 = 0);

    [MemberFunction("45 33 D2 4C 8D 81 ?? ?? ?? ?? 41 8B C2 4C 8B C9 49 3B 10")]
    public partial void RemoveCharacterFromGPose(Character.Character* character);

    [MemberFunction("E8 ?? ?? ?? ?? 41 88 85 ?? ?? ?? ?? 49 8B CC")]
    public partial bool IsFaceCameraEnabled();

    [MemberFunction("E9 ?? ?? ?? ?? 48 8B 4F 08 48 8B 01 FF 90 ?? ?? ?? ?? 48 8B C8 BA ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 85 C0 74 12")]
    public partial void ToggleFaceCamera();

    [MemberFunction("E8 ?? ?? ?? ?? 41 0F B6 BD ?? ?? ?? ?? 49 8D 4F 20")]
    public partial bool IsGazeCameraEnabled();

    [MemberFunction("40 53 48 83 EC 20 48 83 3D ?? ?? ?? ?? ?? 48 8B D9 74 39")]
    public partial void ToggleGazeCamera();

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? F3 41 0F 10 9E ?? ?? ?? ??")]
    public partial void ToggleMotionFreeze(bool allCharacters);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 39 27")]
    public partial void EnableCameraLight(uint index);

    [MemberFunction("48 83 EC 28 83 FA 03 73 43")]
    public partial void DisableCameraLight(uint index);
}

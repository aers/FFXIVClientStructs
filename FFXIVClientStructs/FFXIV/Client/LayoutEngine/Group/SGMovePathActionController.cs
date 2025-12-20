namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

// Client::LayoutEngine::Group::SGMovePathActionController
//   Client::LayoutEngine::Group::SGActionController
[GenerateInterop]
[Inherits<SGActionController>]
[StructLayout(LayoutKind.Explicit, Size = 0x100)]
public partial struct SGMovePathActionController {
    [FieldOffset(0x30)] public float Progress; // fractional representation
    [FieldOffset(0x34)] public float DurationSeconds;
    [FieldOffset(0x40)] public float ProgressSeconds;
    [FieldOffset(0x50)] public Transform TransformBase;
}

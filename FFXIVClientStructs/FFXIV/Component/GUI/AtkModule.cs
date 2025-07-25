using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.System.Input.SoftKeyboards;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using TextServiceEvent = FFXIVClientStructs.FFXIV.Client.System.Input.TextServiceInterface.TextServiceEvent;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkModule
//   Component::GUI::AtkModuleInterface
//   Component::GUI::AtkExternalInterface
//   Client::System::Input::TextServiceInterface::TextServiceEvent
[GenerateInterop(isInherited: true)]
[Inherits<AtkModuleInterface>, Inherits<AtkExternalInterface>, Inherits<TextServiceEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x82A0)]
public unsafe partial struct AtkModule {
    public delegate AtkValue* CallbackHandlerDelegate(AtkModule* thisPtr, AtkValue* returnValue, AtkValue* values, uint valueCount);

    [FieldOffset(0x20)] public ExcelSheet* AddonSheet;

    [FieldOffset(0x128)] public AtkStage* AtkStage;
    [FieldOffset(0x130)] internal nint Resources;
    [FieldOffset(0x1B8)] public AtkFontManager AtkFontManager;
    [FieldOffset(0x250)] public AtkTextureResourceManager AtkTextureResourceManager;
    [FieldOffset(0x2A8)] public AtkUnitManager* AtkUnitManager;
    [FieldOffset(0x2B0)] public AtkInputManager AtkInputManager;
    [FieldOffset(0x1B50)] public AtkCollisionManager AtkCollisionManager;
    [FieldOffset(0x1B90)] public AtkArrayDataHolder AtkArrayDataHolder;
    [FieldOffset(0x1BE0)] public AtkTimerHolder AtkTimerHolder;
    [FieldOffset(0x1C00)] public AtkSimpleTweenHolder AtkSimpleTweenHolder;
    [FieldOffset(0x5C08)] public AtkCrestManager AtkCrestManager;
    [FieldOffset(0x5C50)] public AtkUIColorHolder AtkUIColorHolder;

    [FieldOffset(0x5D00)] public AtkFontCodeModule AtkFontCodeModule;
    [FieldOffset(0x7280)] public StdVector<nint> CallbackHandlerFunctions; // see CallbackHandlerDelegate
    [FieldOffset(0x7298)] public AtkModuleEvent* UIModuleEvent;
    [FieldOffset(0x72A0)] public StdMap<uint, AddonCallbackEntry> AddonCallbackMapping; // Key is UnitBase->Id
    [FieldOffset(0x72B0)] public AtkMessageBoxManager* AtkMessageBoxManager;
    [FieldOffset(0x72B8)] public TextService TextService;
    [FieldOffset(0x72E8)] public AtkTextInput TextInput;
    [FieldOffset(0x7FA8)] internal Utf8String Unk7FA8;
    [FieldOffset(0x8010)] internal Utf8String Unk8010;
    [FieldOffset(0x8078)] internal Utf8String Unk8078;
    [FieldOffset(0x80E0)] internal Utf8String Unk80E0;

    // probably an #IFDEF WINDOWS here or something specifically creating a Steam keyboard.
    // hope they don't add more soft keyboards later!
    [FieldOffset(0x8150)] public SteamGamepadSoftKeyboard SoftKeyboardDevice;

    [FieldOffset(0x8268), FixedSizeArray(isString: true)] internal FixedSizeArray16<byte> _currentUIScene;
    [FieldOffset(0x8278), FixedSizeArray(isString: true)] internal FixedSizeArray16<byte> _loadingUIScene;

    [FieldOffset(0x8290)] internal ushort ScreenWidth; // maybe UI dimensions?
    [FieldOffset(0x8292)] internal ushort ScreenHeight;
    [FieldOffset(0x8294)] public bool EnableUiDraw;

    [FieldOffset(0x8298)] public bool EnableUiInput;

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 44 24 ?? 8B D3")]
    public partial bool IsTextInputActive();

    [MemberFunction("40 56 48 83 EC 50 C7 02"), Obsolete("Renamed to HandleAddonAgentCallback", true)]
    public partial AtkValue* UnitBaseCallbackHandler(AtkValue* returnValue, AtkValue* values, uint valueCount);

    // CallbackHandlerFunctions[2]
    [MemberFunction("40 56 48 83 EC 50 C7 02")]
    public partial AtkValue* HandleAddonAgentCallback(AtkValue* returnValue, AtkValue* values, uint valueCount);

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct AddonCallbackEntry {
        [FieldOffset(0x00), CExporterUnion("Interface")] public AtkModuleInterface.AtkEventInterface* EventInterface;
        [FieldOffset(0x00), CExporterUnion("Interface")] public AgentInterface* AgentInterface;
        [FieldOffset(0x08)] public ulong EventKind;
    }
}

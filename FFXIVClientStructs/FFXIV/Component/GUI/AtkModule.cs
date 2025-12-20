using FFXIVClientStructs.FFXIV.Client.System.Input;
using FFXIVClientStructs.FFXIV.Client.System.Input.SoftKeyboards;
using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using static FFXIVClientStructs.FFXIV.Component.GUI.AtkUnitManager;
using TextServiceEvent = FFXIVClientStructs.FFXIV.Client.System.Input.TextServiceInterface.TextServiceEvent;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

// Component::GUI::AtkModule
//   Component::GUI::AtkModuleInterface
//   Component::GUI::AtkExternalInterface
//   Client::System::Input::TextServiceInterface::TextServiceEvent
[GenerateInterop(isInherited: true)]
[Inherits<AtkModuleInterface>, Inherits<AtkExternalInterface>, Inherits<TextServiceEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x82C0)]
public unsafe partial struct AtkModule {
    public delegate AtkValue* CallbackHandlerDelegate(AtkModule* thisPtr, AtkValue* returnValue, AtkValue* values, uint valueCount);

    [FieldOffset(0x20)] public ExcelSheet* AddonSheet;

    [FieldOffset(0x128)] public AtkStage* AtkStage;
    [FieldOffset(0x130)] internal nint Resources;
    [FieldOffset(0x1D0)] public AtkFontManager AtkFontManager;
    [FieldOffset(0x268)] public AtkTextureResourceManager AtkTextureResourceManager;
    [FieldOffset(0x2C0)] public AtkUnitManager* AtkUnitManager;
    [FieldOffset(0x2C8)] public AtkInputManager AtkInputManager;
    [FieldOffset(0x1B68)] public AtkCollisionManager AtkCollisionManager;
    [FieldOffset(0x1BA8)] public AtkArrayDataHolder AtkArrayDataHolder;
    [FieldOffset(0x1BF8)] public AtkTimerHolder AtkTimerHolder;
    [FieldOffset(0x1C18)] public AtkSimpleTweenHolder AtkSimpleTweenHolder;
    [FieldOffset(0x5C20)] public AtkCrestManager AtkCrestManager;
    [FieldOffset(0x5C68)] public AtkUIColorHolder AtkUIColorHolder;

    [FieldOffset(0x5D18)] public AtkFontCodeModule AtkFontCodeModule;
    [FieldOffset(0x7298)] public StdVector<nint> CallbackHandlerFunctions; // see CallbackHandlerDelegate
    [FieldOffset(0x72B0)] public AtkModuleEvent* UIModuleEvent;
    [FieldOffset(0x72B8)] public StdMap<uint, AddonCallbackEntry> AddonCallbackMapping; // Key is UnitBase->Id
    [FieldOffset(0x72C8)] public AtkMessageBoxManager* AtkMessageBoxManager;
    [FieldOffset(0x72D0)] public TextService TextService;
    [FieldOffset(0x7300)] public AtkTextInput TextInput;
    [FieldOffset(0x7FC8)] internal Utf8String Unk7FA8;
    [FieldOffset(0x8030)] internal Utf8String Unk8010;
    [FieldOffset(0x8098)] internal Utf8String Unk8078;
    [FieldOffset(0x8100)] internal Utf8String Unk80E0;

    // probably an #IFDEF WINDOWS here or something specifically creating a Steam keyboard.
    // hope they don't add more soft keyboards later!
    [FieldOffset(0x8170)] public SteamGamepadSoftKeyboard SoftKeyboardDevice;

    [FieldOffset(0x8288), FixedSizeArray(isString: true)] internal FixedSizeArray16<byte> _currentUIScene;
    [FieldOffset(0x8298), FixedSizeArray(isString: true)] internal FixedSizeArray16<byte> _loadingUIScene;

    [FieldOffset(0x82B0)] internal ushort ScreenWidth; // maybe UI dimensions?
    [FieldOffset(0x82B2)] internal ushort ScreenHeight;
    [FieldOffset(0x82B4)] public bool EnableUiDraw;

    [FieldOffset(0x82B8)] public bool EnableUiInput;
    [FieldOffset(0x82B9)] public bool IsHudInitialized;

    [VirtualFunction(44)]
    public partial AddonStatus GetAddonStatus(uint addonId);

    [VirtualFunction(45)]
    public partial bool SetAddonDepthLayer(uint addonId, uint depthLayerIndex);

    [VirtualFunction(60)]
    public partial void Update(float delta);

    [VirtualFunction(65), GenerateStringOverloads]
    public partial bool OpenMapWithMapLink(CStringPointer mapLink);

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 44 24 ?? 8B D3")]
    public partial bool IsTextInputActive();

    // CallbackHandlerFunctions[2]
    [MemberFunction("40 56 48 83 EC ?? 48 8B F2 48 8B D1")]
    public partial AtkValue* HandleAddonAgentCallback(AtkValue* returnValue, AtkValue* values, uint valueCount);

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct AddonCallbackEntry {
        [FieldOffset(0x00), CExporterUnion("Interface")] public AtkModuleInterface.AtkEventInterface* EventInterface;
        [FieldOffset(0x00), CExporterUnion("Interface")] public AgentInterface* AgentInterface;
        [FieldOffset(0x08)] public ulong EventKind;
    }
}

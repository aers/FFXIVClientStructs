# current exe version: 2020.12.02.0000.0000

from __future__ import print_function

try:
    from typing import Dict, List, Optional, Any  # noqa
except ImportError:
    pass

try:
    import idaapi  # noqa
    import idc  # noqa

    # @formatter:off
    get_image_base = idaapi.get_imagebase  # func()->ea
    set_addr_name = idc.set_name           # func(ea, name)->1: ok, 0: fail
    get_addr_name = idc.get_name           # func(ea)->name: ok, "": fail
    get_qword = idc.get_qword              # func(ea)->long
    def is_offset(ea): return idc.is_off0(idc.get_full_flags(ea))  # func(ea)->bool
    # @formatter:on
except ImportError:  # Ghidra
    # @formatter:off
    def get_image_base():        raise NotImplementedError  # noqa
    def set_addr_name(ea, name): raise NotImplementedError  # noqa
    def get_addr_name(ea):       raise NotImplementedError  # noqa
    def get_qword(ea):           raise NotImplementedError  # noqa
    def is_offset(ea):           raise NotImplementedError  # noqa
    # @formatter:on

NameAddr = set_addr_name

print("Importing IDA data ...")


# TODO: Test the image offset stuff, should set the names regardless of your current image base
# TODO: Force the vtable into a struct, fancy decompiled output
# TODO: jump prefixed offsets "j_<stuff>"

# Client::Graphics::Kernel::Notifier May be 4, looks funky
# Clobber 0x141697D60! "Common::Lua::LuaState", "Common::Lua::LuaThread"

class VTableManager(object):
    # Class ea -> Class name
    _vtbls_ea = {}  # type: Dict[int, str]
    # Class name -> VTable obj
    _vtbls = {}  # type: Dict[str, VTable]
    # Class name -> [Parent class name, ...]
    _inheritance = {}  # type: Dict[str, List[str]]

    def register(self, vtbl_ea, class_name, vtbl_inheritance=None, funcs=None):
        """
        Register a vtable for later renaming
        :param vtbl_ea: Vtable effective address
        :type vtbl_ea: int
        :param class_name: Class name
        :type class_name: str
        :param vfunc_count: VFunc count
        :type vfunc_count: int
        :param vtbl_inheritance: List of classes inherited from, enforces naming order such that base classes are written first.
        :type vtbl_inheritance: List[str]
        :param funcs: Dictionary of vfunc indexes or effective addresses and their name. The class name will be prepended.
        :type funcs: Dict[int,str]
        :return: self
        """
        if vtbl_inheritance is None:
            vtbl_inheritance = []
        if funcs is None:
            funcs = {}

        if vtbl_ea in self._vtbls_ea and vtbl_ea != 0x0:
            other_name = self._vtbls_ea[vtbl_ea]
            print("Warning: Class \"{0}\" at 0x{1:x} is overwritten by {2}".format(other_name, vtbl_ea, class_name))
            return

        if class_name in self._vtbls:
            other = self._vtbls[class_name]
            other_ea = other.vtbl_ea if other else 0x0
            print("Warning: Class \"{0}\" at 0x{1:x} is already registered at 0x{2:X}".format(class_name, vtbl_ea, other_ea))
            return

        self._vtbls_ea[vtbl_ea] = class_name
        self._vtbls[class_name] = VTable(vtbl_ea, class_name, vfunc_count, vtbl_inheritance, funcs) if vtbl_ea > 0x0 else None
        self._inheritance[class_name] = list(vtbl_inheritance)  # Make a copy so the VTable has the data too

    def finalize(self):
        """
        Perform the vtable renaming
        :return: None
        """
        # If I was smarter, this would be a dependency graph.
        # Don't screw this up with circular inheritance
        while not len(self._vtbls) == 0:
            for class_name in list(self._vtbls):  # Make a copy to delete while iterating
                inherits_from = self._inheritance.get(class_name)
                if inherits_from:
                    for parent_class_name in inherits_from:
                        if parent_class_name in self._vtbls:
                            # print("Debug: Skipping \"{0}\", parent class \"{1}\" is not yet resolved".format(class_name, parent_class_name))
                            break
                        else:
                            print("Warning: Inherited class \"{0}\" is not documented, add a placeholder entry with an ea of 0x0 and find it later".format(parent_class_name))
                            self._resolve_inheritance(parent_class_name)
                    else:  # Did not break
                        self._write_vtbl(class_name)
                else:
                    self._write_vtbl(class_name)

    def _write_vtbl(self, class_name):
        """
        Write out the given vtbl
        :param class_name: Class name
        :type class_name: str
        :return: None
        """
        vtbl = self._vtbls.pop(class_name)
        if vtbl:
            # print("Info: Writing {0}".format(class_name))
            vtbl.write()
        self._resolve_inheritance(class_name)

    def _resolve_inheritance(self, parent_class_name):
        """
        Remove the given parent class from all hierarchies
        :param parent_class_name: Parent class name
        :type parent_class_name: str
        :return: None
        """
        for inherited_from in self._inheritance.values():
            if parent_class_name in inherited_from:
                inherited_from.remove(parent_class_name)


class VTable(object):
    STANDARD_IMAGE_BASE = 0x140000000
    REBASE_OFFSET = 0x0

    VTBL_FORMAT = "vtbl_{cls}"
    NAMED_FORMAT = "{cls}_{name}"
    SUB_FORMAT = "{cls}_vf{number}"
    NULLSUB_FORMAT = "{cls}_vf{number}_nullsub"
    LOC_FORMAT = "{cls}_vloc{number}"

    SUB_PREFIX = "sub_"
    NULLSUB_PREFIX = "nullsub_"
    LOC_PREFIX = "loc_"
    JUMP_PREFIX = "j_"
    PURECALL = "_purecall"

    def __init__(self, vtbl_ea, class_name, vfunc_count, inherits_from, funcs):
        """
        A vtable definition
        :param vtbl_ea: Vtable effective address
        :type vtbl_ea: int
        :param class_name: Class name
        :type class_name: str
        :param vfunc_count: VFunc count
        :type vfunc_count: int
        :param inherits_from: Class names this inherits from
        :type inherits_from: List[str]
        :param funcs: Dictionary of vfunc indexes or effective addresses and their name. The class name will be prepended.
        :type funcs: Dict[int,str]
        """
        current_image_base = get_image_base()
        if self.STANDARD_IMAGE_BASE != current_image_base:
            self.REBASE_OFFSET = current_image_base - self.STANDARD_IMAGE_BASE

        self.vtbl_ea = vtbl_ea
        self.class_name = class_name
        self.vfuncs = {}  # vtbl funcs
        self.rfuncs = {}  # related funcs
        self.vfunc_count = vfunc_count
        self.inherits_from = inherits_from
        for ea_or_index, func_name in funcs.items():
            if ea_or_index < 0x1000:
                vfunc_index = ea_or_index
                if vfunc_index >= self.vfunc_count:
                    print("Error: {0} vfunc \"{1}\" (Index {2}) is greater than vfunc count {3}".format(class_name, func_name, vfunc_index, vfunc_count))
                else:
                    self.vfuncs[vfunc_index] = func_name
            else:
                vfunc_ea = ea_or_index
                self.rfuncs[vfunc_ea] = func_name

    def write(self):
        vtbl_ea = self.vtbl_ea + self.REBASE_OFFSET

        # Name the vtbl start offset
        set_addr_name(vtbl_ea, self.VTBL_FORMAT.format(cls=self.class_name))

        # Name each vfunc
        for vfunc_index in range(self.vfunc_count):
            vfunc_offset = vtbl_ea + vfunc_index * 8
            vfunc_ea = get_qword(vfunc_offset)  # type: int
            if is_offset(vfunc_offset):
                self._set_index_name(vfunc_ea=vfunc_ea, vfunc_index=vfunc_index)
            else:
                vtbl_name = self.VTBL_FORMAT.format(cls=self.class_name)
                print("Warning: {0} ea 0x{1:X} is not an offset: {2:X}".format(vtbl_name, vfunc_offset, vfunc_ea))

        for rfunc_ea, rfunc_name in self.rfuncs.items():
            rfunc_full_name = self.NAMED_FORMAT.format(cls=self.class_name, name=rfunc_name)
            set_addr_name(rfunc_ea + self.REBASE_OFFSET, rfunc_full_name)

    def _set_index_name(self, vfunc_ea, vfunc_index):
        """
        Set the name of a vfunc target via ea, vfunc index from the vtable start
        :param vfunc_ea: VFunc ea, ensure the rebase offset is already applied
        :param vfunc_index: VFunc index from the VTable start ea
        :return: None
        """
        if vfunc_index in self.vfuncs:
            vfunc_name = self.vfuncs[vfunc_index]
            vfunc_full_name = self.NAMED_FORMAT.format(cls=self.class_name, name=vfunc_name)
            set_addr_name(vfunc_ea, vfunc_full_name)
        else:
            existing_vfunc_name = get_addr_name(vfunc_ea)  # type: str
            if existing_vfunc_name.startswith(self.JUMP_PREFIX):
                existing_vfunc_name = existing_vfunc_name.replace(self.JUMP_PREFIX, '', 1)

            if existing_vfunc_name.startswith(self.SUB_PREFIX):
                vfunc_full_name = self.SUB_FORMAT.format(cls=self.class_name, number=vfunc_index)
                set_addr_name(vfunc_ea, vfunc_full_name)
            elif existing_vfunc_name.startswith(self.NULLSUB_PREFIX):
                vfunc_full_name = self.NULLSUB_FORMAT.format(cls=self.class_name, number=vfunc_index)
                set_addr_name(vfunc_ea, vfunc_full_name)
            elif existing_vfunc_name.startswith(self.LOC_PREFIX):
                vfunc_full_name = self.LOC_FORMAT.format(cls=self.class_name, number=vfunc_index)
                set_addr_name(vfunc_ea, vfunc_full_name)
            elif existing_vfunc_name == self.PURECALL:
                return
            elif existing_vfunc_name.startswith(self.class_name):
                return
            elif any(existing_vfunc_name.startswith(parent_class_name) for parent_class_name in self.inherits_from):
                return
            elif existing_vfunc_name.startswith("?"):
                return  # Probably some library garbage
            else:
                vtbl_name = self.VTBL_FORMAT.format(cls=self.class_name)
                print("Warning: {0}[{1}] had a name of \"{2}\"".format(vtbl_name, vfunc_index, existing_vfunc_name))
                return


# region: functions
# ffxivstring is just their implementation of std::string presumably, there are more ctors etc
api.set_addr_name(0x140059670, "FFXIVString_ctor")  # empty string ctor
api.set_addr_name(0x1400596B0, "FFXIVString_ctor_copy")  # copy constructor
api.set_addr_name(0x140059730, "FFXIVString_ctor_FromCStr")  # from null-terminated string
api.set_addr_name(0x1400597C0, "FFXIVString_ctor_FromSequence")  # (FFXIVString, char * str, size_t size)
api.set_addr_name(0x14005A280, "FFXIVString_dtor")
api.set_addr_name(0x14005A300, "FFXIVString_SetString")
api.set_addr_name(0x1400604B0, "MemoryManager_Alloc")
api.set_addr_name(0x140064F10, "IsMacClient")
api.set_addr_name(0x14017FF50, "Client::Graphics::Environment::EnvManager_ctor")
api.set_addr_name(0x140194EE0, "j_SleepEx")
api.set_addr_name(0x1401B0460, "ResourceManager_GetResourceAsync")  # no vtbl on this class wouldn't be surprised if it was Client::System::Resource::ResourceManager or something though
api.set_addr_name(0x1401B0680, "ResourceManager_GetResourceSync")
api.set_addr_name(0x1401B8A40, "Client::System::Resource::Handle::ModelResourceHandle_GetMaterialFileNameBySlot")
api.set_addr_name(0x140210710, "Client::UI::Agent::AgentLobby_ctor")
api.set_addr_name(0x1402A5270, "CountdownPointer")
api.set_addr_name(0x1403636E0, "Client::Graphics::Render::RenderManager_ctor")
api.set_addr_name(0x1403648C0, "Client::Graphics::Render::RenderManager_CreateModel")
api.set_addr_name(0x140440E20, "PrepareColorSet")
api.set_addr_name(0x1404410F0, "ReadStainingTemplate")
api.set_addr_name(0x1404D66C0, "CreateAtkNode")
api.set_addr_name(0x1404D7AD0, "CreateAtkComponent")
api.set_addr_name(0x1404DB2C0, "GetScaleListEntryFromScale")
api.set_addr_name(0x1404E9A10, "GetScaleForListOption")
api.set_addr_name(0x140536380, "Component::GUI::TextModuleInterface::GetTextLabelByID")
api.set_addr_name(0x140708970, "Client::UI::Shell::RaptureShellModule_ctor")
api.set_addr_name(0x14070CC90, "Client::UI::Shell::RaptureShellModule_SetChatChannel")
api.set_addr_name(0x14073B630, "CreateBattleCharaStore")
api.set_addr_name(0x14073BC00, "BattleCharaStore_LookupBattleCharaByObjectID")
api.set_addr_name(0x140803D00, "ActionManager::StartCooldown")
api.set_addr_name(0x1408C17E0, "CreateSelectYesno")
api.set_addr_name(0x140A77F70, "EventFramework_GetSingleton")
api.set_addr_name(0x140A80680, "EventFramework_ProcessDirectorUpdate")
api.set_addr_name(0x141021BD0, "Client::UI::AddonHudLayoutScreen::MoveableAddonInfoStruct_UpdateAddonPosition")
api.set_addr_name(0x1412F78E0, "crc")
api.set_addr_name(0x1413716E4, "FreeMemory")
# endregion

# region: globals
api.set_addr_name(0x14169A2A0, "g_HUDScaleTable")
api.set_addr_name(0x141D3CE60, "g_ActionManager")
api.set_addr_name(0x141D66690, "g_Framework")
api.set_addr_name(0x141D66860, "g_KernelDevice")
api.set_addr_name(0x141D68228, "g_GraphicsConfig")
api.set_addr_name(0x141D68238, "g_Framework_2")  # these both point to framework
api.set_addr_name(0x141D68278, "g_AllocatorManager")
api.set_addr_name(0x141D68280, "g_PrimitiveManager")
api.set_addr_name(0x141D68288, "g_RenderManager")
api.set_addr_name(0x141D68290, "g_ShadowManager")
api.set_addr_name(0x141D68298, "g_LightingManager")
api.set_addr_name(0x141D682A0, "g_RenderTargetManager")
api.set_addr_name(0x141D682A8, "g_StreamingManager")
api.set_addr_name(0x141D682B0, "g_PostEffectManager")
api.set_addr_name(0x141D682B8, "g_EnvManager")
api.set_addr_name(0x141D682C0, "g_World")
api.set_addr_name(0x141D682C8, "g_CameraManager")
api.set_addr_name(0x141D682D0, "g_CharacterUtility")
api.set_addr_name(0x141D682D8, "g_ResidentResourceManager")
api.set_addr_name(0x141D6A7E0, "g_CullingManager")
api.set_addr_name(0x141D6A800, "g_TaskManager")
api.set_addr_name(0x141D6FA90, "g_ResourceManager")
api.set_addr_name(0x141D81AA0, "g_OcclusionCullingManager")
api.set_addr_name(0x141D81AE0, "g_RenderModelLinkedListStart")
api.set_addr_name(0x141D81AE8, "g_RenderModelLinkedListEnd")
api.set_addr_name(0x141D82930, "g_JobSystem_ApricotEngineCore")  # not a ptr
api.set_addr_name(0x141D8A070, "g_CameraHolder")
api.set_addr_name(0x141D8A1C0, "g_TargetSystem")
api.set_addr_name(0x141D8E500, "g_AtkStage")
api.set_addr_name(0x141DB1D00, "g_BattleCharaStore")  # this is a struct/object containing a list of all battlecharas (0x100) and the memory ptrs below
api.set_addr_name(0x141DB2020, "g_BattleCharaMemory")
api.set_addr_name(0x141DB2028, "g_CompanionMemory")
api.set_addr_name(0x141DB2050, "g_ActorList")
api.set_addr_name(0x141DB2D90, "g_ActorListEnd")
api.set_addr_name(0x141DD6F08, "g_EventFramework")
api.set_addr_name(0x141DE2D50, "g_ClientObjectManager")
# endregion

# region: vtbl
factory = VTableManager()
# Unknown classes old RTTI data says known classes inherit from
factory.register("Client::Game::Control::TargetSystem::ListFeeder")
factory.register("Client::Game::InstanceContent::ContentSheetWaiterInterface")
factory.register("Client::Game::Object::IGameObjectEventListener")
factory.register("Client::Graphics::Kernel::Buffer")
factory.register("Client::Graphics::Kernel::Resource")
factory.register("Client::Graphics::ReferencedClassBase")
factory.register("Client::Graphics::Render::BaseRenderer")
factory.register("Client::Graphics::Render::Camera")
factory.register("Client::Graphics::Render::RenderObject")
factory.register("Client::Graphics::RenderObjectList")
factory.register("Client::Graphics::Singleton")
factory.register("Client::Graphics::Vfx::VfxDataListenner")
factory.register("Client::System::Common::NonCopyable")
factory.register("Client::System::Crypt::CryptInterface")
factory.register("Client::System::Input::InputData::InputCodeModifiedInterface")
factory.register("Client::System::Input::SoftKeyboardDeviceInterface::SoftKeyboardInputInterface")
factory.register("Client::System::Input::TextServiceInterface::TextServiceEvent")
factory.register("Client::System::Resource::Handle::ResourceHandleFactory")
factory.register("Client::UI::AddonItemDetailBase")
factory.register("Client::UI::Agent::AgentItemDetailBase")
factory.register("Client::UI::Agent::AgentMap::MapMarkerStructSearch")
factory.register("Client::UI::Atk2DMap")
factory.register("Client::UI::UI3DModule::MapInfo")
factory.register("Client::UI::UIModuleInterface")
factory.register("Common::Configuration::ConfigBase::ChangeEventInterface")
factory.register("Component::Excel::ExcelLanguageEvent")
factory.register("Component::GUI::AtkComponentWindowGrab")
factory.register("Component::GUI::AtkDragDropInterface")
factory.register("Component::GUI::AtkEventListener")
factory.register("Component::GUI::AtkEventTarget")
factory.register("Component::GUI::AtkExternalInterface")
factory.register("Component::GUI::AtkManagedInterface")
factory.register("Component::GUI::AtkModuleEvent")
factory.register("Component::GUI::AtkModuleInterface")
factory.register("Component::GUI::AtkModuleInterface::AtkEventInterface")
factory.register("Component::GUI::AtkTextInput::AtkTextInputEventInterface")
factory.register("Component::Log::LogModuleInterface")
factory.register("Component::Text::TextChecker::ExecNonMacroFunc")
factory.register("Component::Text::TextModule")
factory.register("Component::Text::TextModuleInterface")
# Known classes
factory.register(0x14164E260, "Common::Configuration::ConfigBase", ["Client::System::Common::NonCopyable"], {
    0x140068C30: "ctor",
})
factory.register(0x14164E2C0, "Common::Configuration::SystemConfig", ["Common::Configuration::ConfigBase"], {
    0x140078DE0: "ctor",
})
factory.register(0x14164E280, "Common::Configuration::UIConfig", ["Common::Configuration::ConfigBase"], {})
factory.register(0x14164E2A0, "Common::Configuration::UIControlConfig", ["Common::Configuration::ConfigBase"], {})
factory.register(0x14164E2E0, "Common::Configuration::DevConfig", ["Common::Configuration::ConfigBase"], {
    0x14007EA30: "ctor",
})
factory.register(0x14164F4B8, "Client::System::Framework::Framework", [], {
    1: "Setup",
    4: "Tick",
    0x14008EA40: "ctor",
    0x140091EB0: "GetUIModule",
})
factory.register(0x14164F430, "Client::System::Framework::Task", [], {
    0x1400946B0: "TaskRunner",  # task starter which runs the task's function pointer
})
factory.register(0x14164F448, "Client::System::Framework::TaskManager::RootTask", ["Client::System::Framework::Task"], {})
factory.register(0x14164F460, "Client::System::Framework::TaskManager", [], {
    0x140093E60: "ctor",
    0x140171440: "SetTask",
})
factory.register(0x14164F478, "Client::System::Configuration::SystemConfig", ["Common::Configuration::SystemConfig"], {})
factory.register(0x14164F498, "Client::System::Configuration::DevConfig", ["Common::Configuration::DevConfig"], {})
factory.register(0x14164F4E0, "Component::Excel::ExcelModuleInterface", [], {})
factory.register(0x1416594C0, "Component::GUI::AtkUnitList", [], {})
factory.register(0x1416594C8, "Component::GUI::AtkUnitManager", ["Component::GUI::AtkEventListener"], {
    0x1404E5470: "ctor",
})
factory.register(0x141659620, "Client::UI::RaptureAtkUnitManager", ["Component::GUI::AtkUnitManager", "Component::GUI::AtkEventListener"], {
    0x1400AAE50: "ctor",
    0x1404E6F80: "GetAddonByName",  # dalamud GetUIObjByName
})
factory.register(0x141659878, "Client::UI::RaptureAtkModule", ["Component::GUI::AtkModule", "Component::GUI::AtkModuleInterface", "Component::GUI::AtkExternalInterface", "Client::System::Input::TextServiceInterface::TextServiceEvent", "Common::Configuration::ConfigBase::ChangeEventInterface"], {
    39: "SetUIVisibility",
    0x1400B06F0: "ctor",
    0x1400D37C0: "UpdateTask1",
    0x1400D6750: "IsUIVisible",
})
factory.register(0x141661D28, "Client::Graphics::Kernel::Notifier", [], {})
factory.register(0x1416657C0, "Client::System::Crypt::Crc32", [], {})
factory.register(0x14166BD58, "Client::Graphics::Environment::EnvSoundState", [], {})
factory.register(0x14166BD78, "Client::Graphics::Environment::EnvState", [], {})
factory.register(0x14166BDC8, "Client::Graphics::Environment::EnvSimulator", [], {})
factory.register(0x14166BDD8, "Client::Graphics::Environment::EnvManager", ["Client::Graphics::Singleton"], {})
factory.register(0x14166DA88, "Client::System::Resource::Handle::ResourceHandle", ["Client::System::Common::NonCopyable"], {
    0x1401A0080: "DecRef",
    0x1401A00B0: "IncRef",
    0x1401A0270: "ctor",
})
factory.register(0x14166DC08, "Client::System::Resource::Handle::DefaultResourceHandle", ["Client::System::Resource::Handle::ResourceHandle", "Client::System::Common::NonCopyable"], {
    23: "GetData",  # This was under Client::System::Resource::Handle::ResourceHandle
})
factory.register(0x14166E088, "Client::System::Resource::Handle::TextureResourceHandle", ["Client::System::Resource::Handle::ResourceHandle", "Client::System::Common::NonCopyable"], {
    0x1401A3730: "ctor",
})
factory.register(0x14166E8B8, "Client::System::Resource::Handle::CharaMakeParameterResourceHandle", ["Client::System::Resource::Handle::DefaultResourceHandle", "Client::System::Resource::Handle::ResourceHandle", "Client::System::Common::NonCopyable"], {})
factory.register(0x14166FB38, "Client::System::Resource::Handle::ApricotResourceHandle", ["Client::System::Resource::Handle::DefaultResourceHandle", "Client::System::Resource::Handle::ResourceHandle", "Client::System::Common::NonCopyable"], {
    33: "Load",
})
factory.register(0x1416729E8, "Client::System::Resource::Handle::UldResourceHandle", ["Client::System::Resource::Handle::DefaultResourceHandle", "Client::System::Resource::Handle::ResourceHandle", "Client::System::Common::NonCopyable"], {})
factory.register(0x141672B50, "Client::System::Resource::Handle::UldResourceHandleFactory", ["Client::System::Resource::Handle::ResourceHandleFactory"], {})
factory.register(0x141673178, "Client::Graphics::Primitive::Manager", ["Client::Graphics::Singleton"], {
    0x1401D1EB0: "ctor",
})
factory.register(0x141673338, "Client::Graphics::DelayedReleaseClassBase", ["Client::Graphics::ReferencedClassBase"], {
    0x1401D4810: "ctor",
})
factory.register(0x141673360, "Client::Graphics::IAllocator", [], {})
factory.register(0x1416734B0, "Client::Graphics::AllocatorLowLevel", ["Client::Graphics::IAllocator"], {})
factory.register(0x141673568, "Client::Graphics::AllocatorManager", ["Client::Graphics::Singleton"], {
    0x1401D6D90: "ctor",
})
factory.register(0x141674968, "Client::Network::NetworkModuleProxy", ["Client::System::Common::NonCopyable"], {
    0x1401EBFE0: "ctor",
})
factory.register(0x141675928, "Client::UI::Agent::AgentInterface", ["Component::GUI::AtkModuleInterface::AtkEventInterface"], {
    4: "IsAgentActive",
    0x1401EDBF0: "ctor",
})
factory.register(0x141675998, "Client::UI::Agent::AgentCharaMake", ["Client::UI::Agent::AgentInterface", "Component::GUI::AtkModuleInterface::AtkEventInterface"], {})
factory.register(0x141675D70, "Client::UI::Agent::AgentModule", [], {
    0x1401F5FF0: "ctor",
    0x1401FB250: "GetAgentByInternalID",
    0x1401FB260: "GetAgentByInternalID_2",  # dupe?
})
factory.register(0x141676AE0, "Client::UI::Agent::AgentCursor", ["Client::UI::Agent::AgentInterface", "Component::GUI::AtkModuleInterface::AtkEventInterface"], {})
factory.register(0x141676B50, "Client::UI::Agent::AgentCursorLocation", ["Client::UI::Agent::AgentInterface", "Component::GUI::AtkModuleInterface::AtkEventInterface"], {})
factory.register(0x14167E120, "Client::Graphics::Kernel::Texture", ["Client::Graphics::Kernel::Resource", "Client::Graphics::DelayedReleaseClassBase", "Client::Graphics::ReferencedClassBase", "Client::Graphics::Kernel::Notifier"], {
    0x1402F9930: "ctor",
})
factory.register(0x14167E3A8, "Client::Graphics::Kernel::ConstantBuffer", ["Client::Graphics::Kernel::Buffer", "Client::Graphics::Kernel::Resource", "Client::Graphics::DelayedReleaseClassBase", "Client::Graphics::ReferencedClassBase"], {})
factory.register(0x14167E430, "Client::Graphics::Kernel::Device", ["Client::Graphics::Singleton"], {
    0x140300FA0: "ctor",
})
factory.register(0x1416856A8, "Client::Graphics::Kernel::ShaderSceneKey", [], {})
factory.register(0x1416856B0, "Client::Graphics::Kernel::ShaderSubViewKey", [], {})
factory.register(0x1416856C8, "Client::Graphics::Render::GraphicsConfig", ["Client::Graphics::Singleton"], {
    0x14031FCE0: "ctor",
})
factory.register(0x141685708, "Client::Graphics::Render::ShadowCamera", ["Client::Graphics::Render::Camera", "Client::Graphics::ReferencedClassBase"], {})
factory.register(0x141685850, "Client::Graphics::Render::View", [], {})
factory.register(0x1416858D8, "Client::Graphics::Render::PostBoneDeformerBase", ["Client::Graphics::RenderObjectList", "Client::System::Framework::Task"], {})
factory.register(0x1416859C0, "Client::Graphics::Render::AmbientLight", [], {
    0x1403296C0: "ctor",
})
factory.register(0x1416859D0, "Client::Graphics::Render::Model", ["Client::Graphics::RenderObjectList", "Client::Graphics::Render::RenderObject", "Client::Graphics::ReferencedClassBase"], {
    0x14032B630: "ctor",
    0x14032B780: "SetupFromModelResourceHandle",
})
factory.register(0x141685A88, "Client::Graphics::Render::ModelRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::ModelRenderer::RenderJob", ["Client::Graphics::RenderObjectList", "Client::Graphics::Render::RenderObject", "Client::Graphics::ReferencedClassBase"], {})
factory.register(0x141685A90, "Client::Graphics::Render::ModelRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685AB8, "Client::Graphics::Render::GeometryInstancingRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685B60, "Client::Graphics::Render::BGInstancingRenderer_Client::Graphics::JobSystem_CClient::Graphics::Render::tagInstancingContainerRenderInfo", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685B68, "Client::Graphics::Render::BGInstancingRenderer", ["Client::Graphics::Render::GeometryInstancingRenderer", "Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685BD0, "Client::Graphics::Render::TerrainRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::TerrainRenderer::RenderJob", ["Client::Graphics::Render::GeometryInstancingRenderer", "Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685BD8, "Client::Graphics::Render::TerrainRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685C48, "Client::Graphics::Render::UnknownRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685CB0, "Client::Graphics::Render::WaterRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::WaterRenderer::RenderJob", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685CB8, "Client::Graphics::Render::WaterRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685DA0, "Client::Graphics::Render::VerticalFogRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::VerticalFogRenderer::RenderJob", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685DA8, "Client::Graphics::Render::VerticalFogRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685EC0, "Client::Graphics::Render::ShadowMaskUnit", [], {})
factory.register(0x141685ED8, "Client::Graphics::Render::ShaderManager", [], {})
factory.register(0x141685EE8, "Client::Graphics::Render::Manager_Client::Graphics::JobSystem_Client::Graphics::Render::Manager::BoneCollectorJob", [], {})
factory.register(0x141685EF0, "Client::Graphics::Render::Updater_Client::Graphics::Render::PostBoneDeformerBase", [], {})
factory.register(0x141685EF8, "Client::Graphics::Render::Manager", ["Client::Graphics::Singleton"], {})
factory.register(0x141685F10, "Client::Graphics::Render::ShadowManager", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {
    0x140365BA0: "ctor",
})
factory.register(0x141685F20, "Client::Graphics::Render::LightingManager::LightShape", [], {})
factory.register(0x141685F28, "Client::Graphics::Render::LightingManager::LightingRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::LightingManager::LightingRenderer::RenderJob", [], {})
factory.register(0x141685F30, "Client::Graphics::Render::LightingManager::LightingRenderer", [], {
    0x14036A1D0: "ctor",
})
factory.register(0x141685F38, "Client::Graphics::Render::LightingManager", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {
    0x140374A80: "ctor",
})
factory.register(0x141685F40, "Client::Graphics::Render::LightingManager_Client::Graphics::Kernel::Notifier", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {})
factory.register(0x141685F60, "Client::Graphics::Render::RenderTargetManager", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {
    0x140375260: "ctor",
})
factory.register(0x141685F68, "Client::Graphics::Render::RenderTargetManager_Client::Graphics::Kernel::Notifier", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {})
factory.register(0x1416885D8, "Client::Graphics::PostEffect::PostEffectChain", [], {})
factory.register(0x1416885E0, "Client::Graphics::PostEffect::PostEffectRainbow", [], {})
factory.register(0x1416885E8, "Client::Graphics::PostEffect::PostEffectLensFlare", [], {})
factory.register(0x1416885F0, "Client::Graphics::PostEffect::PostEffectRoofQuery", [], {})
factory.register(0x141688600, "Client::Graphics::PostEffect::PostEffectManager", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {
    0x140396010: "ctor",
})
factory.register(0x141688608, "Client::Graphics::PostEffect::PostEffectManager_Client::Graphics::Kernel::Notifier", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {})
factory.register(0x14168C238, "Client::Graphics::JobSystem(Apricot::Engine::Core_Apricot::Engine::Core::CoreJob_1)", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {
    0x1403DD170: "ctor",
    0x1403DD3A0: "GetSingleton",
})
factory.register(0x1416959D0, "Client::Graphics::Scene::Object", [], {})
factory.register(0x141695A00, "Client::Graphics::Scene::DrawObject", ["Client::Graphics::Scene::Object"], {
    0x14042BCE0: "ctor",
})
factory.register(0x141695B98, "Client::Graphics::Scene::World_Client::Graphics::JobSystem_Client::Graphics::Scene::World::SceneUpdateJob", ["Client::Graphics::Scene::Object"], {})
factory.register(0x141695BA0, "Client::Graphics::Scene::World", ["Client::Graphics::Scene::Object", "Client::Graphics::Singleton"], {
    0x14042C290: "ctor",
})
factory.register(0x141695BD0, "Client::Graphics::Scene::World_Client::Graphics::Singleton", ["Client::Graphics::Scene::Object", "Client::Graphics::Singleton"], {})
factory.register(0x141695BD8, "Client::Graphics::Scene::Camera", ["Client::Graphics::Scene::Object"], {
    0x14042C550: "ctor",
})
factory.register(0x141695C38, "Client::Graphics::Scene::CameraManager_Client::Graphics::Singleton", ["Client::Graphics::Scene::Object"], {})
factory.register(0x141695C40, "Client::Graphics::Scene::CameraManager", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {
    0x14042E020: "ctor",
})
factory.register(0x141695E08, "Client::Graphics::Scene::CharacterUtility", ["Client::Graphics::Singleton"], {
    0x140431750: "ctor",
    0x140431960: "CreateDXRenderObjects",
    0x140431DB0: "LoadDataFiles",
    0x140435B30: "GetSlotEqpFlags",
})
factory.register(0x141695E88, "Client::Graphics::Scene::CharacterBase", ["Client::Graphics::Scene::DrawObject", "Client::Graphics::Scene::Object"], {
    11: "UpdateMaterials",
    92: "CreateRenderModelForMDL",
    0x140438BD0: "ctor",
    0x14044AC50: "CreateSlotStorage",
    0x14043C9C0: "CreateBonePhysicsModule",
    0x14043E430: "LoadAnimation",
    0x14043EE00: "LoadMDLForSlot",
    0x14043EEF0: "LoadIMCForSlot",
    0x14043F0C0: "LoadAllMTRLsFromMDLInSlot",
    0x14043F260: "LoadAllDecalTexFromMDLInSlot",
    0x14043F3D0: "LoadPHYBForSlot",
    0x14043FB80: "CopyIMCForSlot",
    0x14043FEF0: "CreateStagingArea",
    0x140440010: "PopulateMaterialsFromStaging",
    0x140440160: "LoadMDLSubFilesIntoStaging",
    0x140440370: "LoadMDLSubFilesForSlot",
    0x14045FDD0: "dtor",
    0x1406E3470: "Create",
})
factory.register(0x141696198, "Client::Graphics::Scene::Human", ["Client::Graphics::Scene::CharacterBase", "Client::Graphics::Scene::DrawObject", "Client::Graphics::Scene::Object"], {
    1: "CleanupRender",
    4: "UpdateRender",
    67: "FlagSlotForUpdate",
    68: "GetDataForSlot",
    73: "ResolveMDLPath",
    82: "ResolveMTRLPath",
    86: "GetDyeForSlot",
    0x140443E40: "ctor",
    0x140444080: "SetupFromCharacterData",
    0x140460BB0: "dtor",
})
factory.register(0x141697860, "Client::Graphics::Scene::ResidentResourceManager::ResourceList", [], {})
factory.register(0x141697870, "Client::Graphics::Scene::ResidentResourceManager", ["Client::Graphics::Singleton"], {
    0x14045E220: "ctor",
    0x14045E250: "nullsub_1",
    0x14045E280: "LoadDataFiles",
})
factory.register(0x141697950, "Client::System::Task::SpursJobEntityWorkerThread", ["Client::Graphics::Singleton"], {})
factory.register(0x141697D60, "Common::Lua::LuaState", [], {})
factory.register(0x141697D60, "Common::Lua::LuaThread", ["Common::Lua::LuaState"], {})
factory.register(0x141698A90, "Client::Game::Control::TargetSystem::AggroListFeeder", ["Client::Game::Control::TargetSystem::ListFeeder"], {})
factory.register(0x141698AA0, "Client::Game::Control::TargetSystem::AllianceListFeeder", ["Client::Game::Control::TargetSystem::ListFeeder"], {})
factory.register(0x141698AB0, "Client::Game::Control::TargetSystem::PartyListFeeder", ["Client::Game::Control::TargetSystem::ListFeeder"], {})
factory.register(0x141698B00, "Client::Game::Control::TargetSystem", ["Client::Game::Object::IGameObjectEventListener"], {
    0x1404937B0: "ctor",
    0x14049E2D0: "IsActorInViewRange",
})
factory.register(0x14169A300, "Component::GUI::AtkArrayData", [], {})
factory.register(0x14169A310, "Component::GUI::NumberArrayData", ["Component::GUI::AtkArrayData"], {
    0x1404AABE0: "SetValue",
})
factory.register(0x14169A320, "Component::GUI::StringArrayData", ["Component::GUI::AtkArrayData"], {})
factory.register(0x14169A330, "Component::GUI::ExtendArrayData", ["Component::GUI::AtkArrayData"], {})
factory.register(0x14169A438, "Component::GUI::AtkSimpleTween", ["Component::GUI::AtkEventTarget"], {})
factory.register(0x14169A448, "Component::GUI::AtkTexture", [], {})
factory.register(0x14169A5A8, "Component::GUI::AtkStage", ["Component::GUI::AtkEventTarget"], {
    0x1404BC9C0: "ctor",
    0x1404DDEA0: "GetSingleton1",  # dalamud GetBaseUIObject
})
factory.register(0x14169AE50, "Component::GUI::AtkResNode", ["Component::GUI::AtkEventTarget"], {
    1: "Destroy",
    0x1404CC6B0: "ctor",
    0x1404CC810: "GetAsAtkImageNode",
    0x1404CC830: "GetAsAtkTextNode",
    0x1404CC850: "GetAsAtkNineGridNode",
    0x1404CC870: "GetAsAtkCounterNode",
    0x1404CC890: "GetAsAtkCollisionNode",
    0x1404CC8B0: "GetAsAtkComponentNode",
    0x1404CC8D0: "GetComponent",
    0x1404CD470: "GetPositionFloat",
    0x1404CD490: "SetPositionFloat",
    0x1404CD4E0: "GetPositionShort",
    0x1404CD510: "SetPositionShort",
    0x1404CD570: "GetScale",
    0x1404CD590: "GetScaleX",
    0x1404CD5B0: "GetScaleY",
    0x1404CD5D0: "SetScale",
    0x1404D8DF0: "SetSize",
    0x1404CE6E0: "Init",
    0x1404CE8B0: "SetScale0",  # SetScale jumps to this
})
factory.register(0x14169AE68, "Component::GUI::AtkImageNode", ["Component::GUI::AtkResNode"], {
    1: "Destroy",
    0x14053F960: "ctor",
})
factory.register(0x14169AE80, "Component::GUI::AtkTextNode", ["Component::GUI::AtkResNode"], {
    1: "Destroy",
    0x14053FB10: "ctor",
    0x1404CF1A0: "SetText",
    0x1404CFCD0: "SetForegroundColour",
    0x1404D0DF0: "SetGlowColour",
})
factory.register(0x14169AE98, "Component::GUI::AtkNineGridNode", ["Component::GUI::AtkResNode"], {
    1: "Destroy",
    0x14053F9C0: "ctor",
})
factory.register(0x14169AEB0, "Component::GUI::AtkCounterNode", ["Component::GUI::AtkResNode"], {
    1: "Destroy",
    0x14053F8E0: "ctor",
})
factory.register(0x14169AEC8, "Component::GUI::AtkCollisionNode", ["Component::GUI::AtkResNode"], {
    1: "Destroy",
    0x14053F820: "ctor",
})
factory.register(0x14169AEE0, "Component::GUI::AtkComponentNode", ["Component::GUI::AtkResNode"], {
    1: "Destroy",
    0x14053F880: "ctor",
})
factory.register(0x14169AEF8, "Component::GUI::AtkUnitBase", ["Component::GUI::AtkEventListener"], {
    8: "SetPosition",
    9: "SetX",
    10: "SetY",
    11: "GetX",
    12: "GetY",
    13: "GetPosition",
    14: "SetAlpha",
    15: "SetScale",
    39: "Draw",
    0x1404DA700: "ctor",
    0x1404DAE60: "SetPosition",
    0x1404DAFE0: "SetAlpha",
    0x1404DB3E0: "SetScale",
    0x1404DB750: "CalculateBounds",
    0x1404DDA00: "Draw",
    0x1404D3BB0: "ULDAddonData_SetupFromULDResourceHandle",
    0x1404D5FD0: "ULDAddonData_ReadTPHD",
    0x1404D61E0: "ULDAddonData_ReadAHSDAndLoadTextures",
})
factory.register(0x14169B188, "Component::GUI::AtkComponentBase", ["Component::GUI::AtkEventListener"], {
    0x1404F2670: "ctor",
    0x1404F2920: "GetOwnerNodePosition",
})
factory.register(0x14169B228, "Component::GUI::AtkComponentButton", ["Component::GUI::AtkComponentBase"], {
    10: "SetEnabledState",
    17: "InitializeFromComponentData",
    0x1404F3DA0: "ctor",
})
factory.register(0x14169B2F0, "Component::GUI::AtkComponentIcon", ["Component::GUI::AtkComponentBase"], {
    0x1404F62E0: "ctor",
})
factory.register(0x14169B410, "Component::GUI::AtkComponentListItemRenderer", ["Component::GUI::AtkComponentButton", "Component::GUI::AtkDragDropInterface"], {
    0x1404F6E20: "ctor",
})
factory.register(0x14169B580, "Component::GUI::AtkComponentList", ["Component::GUI::AtkComponentBase"], {
    0x140502070: "ctor",
})
factory.register(0x14169B6E8, "Component::GUI::AtkComponentTreeList", ["Component::GUI::AtkComponentList"], {
    0x140506A00: "ctor",
})
factory.register(0x14169B850, "Component::GUI::AtkModule", ["Component::GUI::AtkModuleInterface", "Component::GUI::AtkExternalInterface", "Client::System::Input::TextServiceInterface::TextServiceEvent"], {
    0x14050B670: "ctor",
})
factory.register(0x14169BAF8, "Component::GUI::AtkComponentCheckBox", ["Component::GUI::AtkComponentButton"], {
    0x14050F620: "ctor",
})
factory.register(0x14169BBC8, "Component::GUI::AtkComponentGaugeBar", ["Component::GUI::AtkComponentBase"], {
    0x140510540: "ctor",
})
factory.register(0x14169BC68, "Component::GUI::AtkComponentSlider", ["Component::GUI::AtkComponentBase"], {
    0x140512670: "ctor",
})
factory.register(0x14169BD08, "Component::GUI::AtkComponentInputBase", ["Component::GUI::AtkComponentBase"], {
    0x140513A80: "ctor",
})
factory.register(0x14169BDA8, "Component::GUI::AtkComponentTextInput", ["Component::GUI::AtkComponentInputBase", "Component::GUI::AtkTextInput::AtkTextInputEventInterface", "Client::System::Input::SoftKeyboardDeviceInterface::SoftKeyboardInputInterface"], {
    0x140515240: "ctor",
})
factory.register(0x14169BEA8, "Component::GUI::AtkComponentNumericInput", ["Component::GUI::AtkComponentInputBase", "Component::GUI::AtkTextInput::AtkTextInputEventInterface"], {
    0x140519950: "ctor",
})
factory.register(0x14169BF70, "Component::GUI::AtkComponentDropDownList", ["Component::GUI::AtkComponentBase"], {
    0x14051D5F0: "ctor",
})
factory.register(0x14169C010, "Component::GUI::AtkComponentRadioButton", ["Component::GUI::AtkComponentButton"], {
    0x14051EAE0: "ctor",
})
factory.register(0x14169C120, "Component::GUI::AtkComponentTab", ["Component::GUI::AtkComponentRadioButton"], {
    0x14051F3B0: "ctor",
})
factory.register(0x14169C230, "Component::GUI::AtkComponentGuildLeveCard", ["Component::GUI::AtkComponentBase"], {
    0x14051F990: "ctor",
})
factory.register(0x14169C2D0, "Component::GUI::AtkComponentTextNineGrid", ["Component::GUI::AtkComponentBase"], {
    0x14051FD20: "ctor",
})
factory.register(0x14169C370, "Component::GUI::AtkResourceRendererBase", [], {})
factory.register(0x14169C388, "Component::GUI::AtkImageNodeRenderer", ["Component::GUI::AtkResourceRendererBase"], {})
factory.register(0x14169C3A0, "Component::GUI::AtkTextNodeRenderer", ["Component::GUI::AtkResourceRendererBase"], {})
factory.register(0x14169C3C0, "Component::GUI::AtkNineGridNodeRenderer", ["Component::GUI::AtkResourceRendererBase"], {})
factory.register(0x14169C3D8, "Component::GUI::AtkCounterNodeRenderer", ["Component::GUI::AtkResourceRendererBase"], {})
factory.register(0x14169C3F0, "Component::GUI::AtkComponentNodeRenderer", ["Component::GUI::AtkResourceRendererBase"], {})
factory.register(0x14169C408, "Component::GUI::AtkResourceRendererManager", [], {
    0x140522930: "ctor",
    0x140522B30: "DrawUldFromData",
    0x140522C10: "DrawUldFromDataClipped",
})
factory.register(0x14169C428, "Component::GUI::AtkComponentMap", ["Component::GUI::AtkComponentBase"], {
    0x140525120: "ctor",
})
factory.register(0x14169C4C8, "Component::GUI::AtkComponentPreview", ["Component::GUI::AtkComponentBase"], {
    0x140527B50: "ctor",
})
factory.register(0x14169C568, "Component::GUI::AtkComponentScrollBar", ["Component::GUI::AtkComponentBase"], {
    0x140528BB0: "ctor",
})
factory.register(0x14169C608, "Component::GUI::AtkComponentIconText", ["Component::GUI::AtkComponentBase"], {
    0x14052A5C0: "ctor",
})
factory.register(0x14169C6A8, "Component::GUI::AtkComponentDragDrop", ["Component::GUI::AtkComponentBase", "Component::GUI::AtkDragDropInterface"], {
    0x14052B840: "ctor",
})
factory.register(0x14169C7C8, "Component::GUI::AtkComponentMultipurpose", ["Component::GUI::AtkComponentBase"], {
    0x14052D4A0: "ctor",
})
factory.register(0x14169C938, "Component::GUI::AtkComponentWindow", ["Component::GUI::AtkComponentWindowGrab", "Component::GUI::AtkComponentBase"], {
    0x14052DDD0: "ctor",
})
factory.register(0x14169CA08, "Component::GUI::AtkComponentJournalCanvas", ["Component::GUI::AtkComponentBase"], {
    0x140533360: "ctor",
})
factory.register(0x14169CAA8, "Component::GUI::AtkComponentUnknownButton", ["Component::GUI::AtkComponentButton"], {
    0x140536E90: "ctor",
})
factory.register(0x1416A9390, "Client::UI::Misc::UserFileManager::UserFileEvent", [], {})
factory.register(0x1416A9CF8, "Client::UI::UI3DModule::ObjectInfo", ["Client::UI::UI3DModule::MapInfo"], {})
factory.register(0x1416A9D28, "Client::UI::UI3DModule::MemberInfo", ["Client::UI::UI3DModule::MapInfo"], {})
factory.register(0x1416A9D88, "Client::UI::UI3DModule", [], {
    0x1405BB780: "ctor",
})
factory.register(0x1416A9DA0, "Client::UI::UIModule", ["Client::UI::UIModuleInterface", "Component::GUI::AtkModuleEvent", "Component::Excel::ExcelLanguageEvent", "Common::Configuration::ConfigBase::ChangeEventInterface"], {
    0x1405C47E0: "ctor",
})
factory.register(0x1416AA5A0, "Client::System::Crypt::SimpleString", ["Client::System::Crypt::CryptInterface"], {
    1: "Encrypt",
    2: "Decrypt",
})
factory.register(0x1416AB430, "Component::Text::MacroDecoder", [], {})
factory.register(0x1416AB5F0, "Component::Text::TextChecker", ["Component::Text::MacroDecoder", "Client::System::Common::NonCopyable"], {})
factory.register(0x1416AEAE8, "Client::UI::Misc::ConfigModule", ["Component::GUI::AtkModuleInterface::AtkEventInterface", "Common::Configuration::ConfigBase::ChangeEventInterface"], {
    0x1405FAEA0: "ctor",
})
factory.register(0x1416AEAF8, "Client::UI::Misc::ConfigModule_Common::Configuration::ConfigBase::ChangeEventInterface", ["Component::GUI::AtkModuleInterface::AtkEventInterface", "Common::Configuration::ConfigBase::ChangeEventInterface"], {})
factory.register(0x1416AEBD8, "Client::UI::Misc::RaptureMacroModule", ["Client::UI::Misc::UserFileManager::UserFileEvent"], {
    1: "ReadFile", 2: "WriteFile",
})
factory.register(0x1416AEC40, "Client::UI::Misc::RaptureTextModule", ["Component::Text::TextModule", "Component::Text::TextModuleInterface", "Component::Text::MacroDecoder", "Client::System::Common::NonCopyable", "Component::Text::TextChecker::ExecNonMacroFunc", "Component::Excel::ExcelLanguageEvent"], {})
factory.register(0x1416AEEB8, "Client::UI::Misc::RaptureLogModule", ["Component::Log::LogModule", "Component::Log::LogModuleInterface", "Client::System::Common::NonCopyable"], {
    0x140615880: "ctor",
    0x140617010: "PrintMessage",
})
factory.register(0x1416AEF08, "Client::UI::Misc::RaptureHotbarModule", ["Client::UI::Misc::UserFileManager::UserFileEvent", "Client::System::Input::InputData::InputCodeModifiedInterface"], {
    0x1406207D0: "ctor",
})
factory.register(0x1416AEF70, "Client::UI::Misc::RaptureHotbarModule_Client::System::Input::InputCodeModifiedInterface", ["Client::UI::Misc::UserFileManager::UserFileEvent", "Client::System::Input::InputData::InputCodeModifiedInterface"], {})
factory.register(0x1416AEFE8, "Client::UI::Misc::PronounModule", ["Component::Text::TextChecker::ExecNonMacroFunc"], {
    0x140629590: "ctor",
})
factory.register(0x1416AFAC0, "Client::UI::Misc::CharaView", [], {
    1: "Initialize",
    2: "Finalize",
    0x14064FB80: "ctor",
    0x14065F700: "dtor",
})
factory.register(0x1416B0EC0, "Client::Game::Object::GameObject", [], {
    0x1406C5270: "Initialize",
    0x1406C54D0: "ctor",
})
factory.register(0x1416B1B48, "Client::Game::Character::Character", ["Client::Game::Object::GameObject", "Client::Graphics::Vfx::VfxDataListenner"], {
    3: "GetObjectKind",
    16: "EnableDraw",
    17: "DisableDraw",
    21: "SetDrawObject",
    40: "Update",
    0x1406D5AC0: "dtor",
    0x1406EA340: "ctor",
})
factory.register(0x1416B1E10, "Client::Game::Character::Character_Client::Graphics::Vfx::VfxDataListener", ["Client::Game::Object::GameObject", "Client::Graphics::Vfx::VfxDataListenner"], {})
factory.register(0x1416C8150, "Client::Game::Character::BattleChara", ["Client::Game::Character::Character", "Client::Game::Object::GameObject", "Client::Graphics::Vfx::VfxDataListenner"], {
    0x14073C140: "ctor",
    0x14073C230: "dtor",
})
factory.register(0x1416C8418, "Client::Game::Character::BattleChara_Client::Graphics::Vfx::VfxDataListener", ["Client::Game::Character::Character", "Client::Game::Object::GameObject", "Client::Graphics::Vfx::VfxDataListenner"], {})
factory.register(0x1416CA7C0, "Client::Game::ActionManager", ["Client::Graphics::Vfx::VfxDataListenner"], {})
factory.register(0x1416CC740, "Client::UI::Agent::AgentHUD", ["Client::UI::Agent::AgentInterface", "Component::GUI::AtkModuleInterface::AtkEventInterface", "Common::Configuration::ConfigBase::ChangeEventInterface"], {
    5: "Update",
    0x14081F350: "ctor",
    0x140824ED0: "UpdateParty",
})
factory.register(0x1416CCAF0, "Client::UI::Agent::AgentItemDetail", ["Client::UI::Agent::AgentItemDetailBase", "Client::UI::Agent::AgentInterface", "Component::GUI::AtkModuleInterface::AtkEventInterface"], {
    0x1408D3F50: "ctor",
    0x1408D4F80: "OnItemHovered",
})
factory.register(0x1416CD4B8, "Client::UI::Agent::AgentMap::MapMarkerStructSearchName", ["Client::UI::Agent::AgentMap::MapMarkerStructSearch"], {
    1: "Evaluate",
})
factory.register(0x1416CD4C8, "Client::UI::Agent::AgentMap", ["Client::UI::Agent::AgentInterface"], {
    0x140887BE0: "ctor",
})
factory.register(0x1416CE090, "Client::UI::Agent::AgentHudLayout", ["Client::UI::Agent::AgentInterface"], {
    2: "Show",
    3: "Hide",
    0x1408C0B10: "ctor",
})
factory.register(0x1416CEED8, "Client::UI::Agent::AgentStatus", ["Client::UI::Agent::AgentInterface"], {
    0x140904190: "ctor",
})
factory.register(0x1416CEEA0, "Client::UI::Agent::AgentStatus::StatusCharaView", ["Client::UI::Misc::CharaView"], {})
factory.register(0x1416DEE58, "Client::Game::Event::EventHandler", [], {})
factory.register(0x1416DF680, "Client::Game::Event::ModuleBase", [], {})
factory.register(0x1416DF6E0, "Client::Game::Event::LuaEventHandler", ["Client::Game::Event::EventHandler"], {})
factory.register(0x1416DFEF0, "Client::Game::Event::EventSceneModuleImplBase", [], {})
factory.register(0x1416E05C8, "Client::Game::Event::EventSceneModuleUsualImpl", ["Client::Game::Event::EventSceneModuleImplBase"], {})
factory.register(0x1416E48A0, "Client::Game::Event::EventHandlerModule", ["Client::Game::Event::ModuleBase"], {})
factory.register(0x1416E4918, "Client::Game::Event::DirectorModule", ["Client::Game::Event::ModuleBase"], {})
factory.register(0x1416F4AA8, "Client::Game::Gimmick::GimmickBill", ["Client::Game::Gimmick::GimmickEventHandler", "Client::Game::Event::LuaEventHandler", "Client::Game::Event::EventHandler", "Client::Game::InstanceContent::ContentSheetWaiterInterface"], {})
factory.register(0x141798F70, "Client::UI::AddonNowLoading", ["Component::GUI::AtkUnitBase", "Component::GUI::AtkEventListener"], {
    41: "LoadUldResourceHandle",
    0x140CCD730: "ctor",
})
factory.register(0x1417C9DC8, "Client::UI::Atk2DAreaMap", ["Client::UI::Atk2DMap"], {})
factory.register(0x1417D4E18, "Client::UI::AddonTalk", ["Component::GUI::AtkUnitBase"], {
    0x140E7C1D0: "ctor",
})
factory.register(0x1417D6AA0, "Client::UI::AddonItemDetail", ["Client::UI::AddonItemDetailBase", "Component::GUI::AtkUnitBase", "Component::GUI::AtkManagedInterface"], {
    0x140E90440: "ctor",
    0x140E91960: "GenerateTooltip",
})
factory.register(0x1417DCDD0, "Client::UI::AddonAreaMap", ["Component::GUI::AtkUnitBase"], {
    0x140EBDC30: "ctor",
})
factory.register(0x1417DEC90, "Client::UI::AddonNamePlate", ["Component::GUI::AtkUnitBase"], {
    47: "UpdateNameplates",
    0x140ED87F0: "ctor",
})
factory.register(0x14179BAD0, "Client::UI::AddonHudSelectYesno", ["Component::GUI::AtkUnitBase", "Component::GUI::AtkEventListener"], {
    0x140CD9150: "ctor",
    0x140DD2610: "dtor",
})
factory.register(0x141810480, "Client::UI::AddonHudLayoutWindow", ["Component::GUI::AtkUnitBase"], {
    0x14101D810: "ctor",
})
factory.register(0x1418106A0, "Client::UI::AddonHudLayoutScreen", ["Component::GUI::AtkUnitBase"], {
    2: "HandleMouseEvent",
    0x14101EAA0: "ctor",
    0x141023730: "AddonOverlayMouseMovedEvent",
    0x141023960: "AddonOverlayMouseClickEvent",
    0x141023D60: "AddonOverlayMouseReleaseEvent",
    0x1410259A0: "_SetAddonScale",
})
factory.register(0x1417CDB58, "Client::UI::AddonMateriaAttach", ["Component::GUI::AtkUnitBase", "Component::GUI::AtkEventListener"], {})
factory.register(0x1417CDF98, "Client::UI::AddonMateriaAttachDialog", ["Component::GUI::AtkUnitBase", "Component::GUI::AtkEventListener"], {})
factory.register(0x141825368, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::CullingJobOpt", ["Component::GUI::AtkUnitBase", "Component::GUI::AtkEventListener"], {})
factory.register(0x141825370, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::CallbackJobOpt", ["Component::GUI::AtkUnitBase", "Component::GUI::AtkEventListener"], {})
factory.register(0x141825378, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::RenderCallbackJob", ["Component::GUI::AtkUnitBase", "Component::GUI::AtkEventListener"], {})
factory.register(0x141825380, "Client::Graphics::Culling::CullingManager", ["Client::Graphics::Singleton"], {})
factory.register(0x141828A68, "Client::Game::Character::Companion", ["Client::Game::Character::Character", "Client::Game::Object::GameObject", "Client::Graphics::Vfx::VfxDataListenner"], {
    16: "EnableDraw",
    0x141101890: "ctor",
})
factory.register(0x141829C80, "Client::Game::CameraBase", [], {})
factory.register(0x141829CE0, "Client::Game::Camera", ["Client::Game::CameraBase"], {
    0x14110A340: "ctor",
})
factory.register(0x14182B780, "Client::Graphics::Culling::OcclusionCullingManager", ["Client::Graphics::Singleton"], {})
factory.register(0x14182B790, "Client::Graphics::Streaming::StreamingManager_Client::Graphics::JobSystem_Client::Graphics::Streaming::StreamingManager::StreamingJob", ["Client::Graphics::Singleton"], {})
factory.register(0x14182B798, "Client::Graphics::Streaming::StreamingManager", ["Client::Graphics::Singleton"], {})
factory.register(0x1418334C8, "Component::Log::LogModule", ["Component::Log::LogModuleInterface", "Client::System::Common::NonCopyable"], {})
factory.register(0x1418791E0, "Client::Game::Gimmick::GimmickEventHandler", ["Client::Game::Event::LuaEventHandler", "Client::Game::Event::EventHandler"], {})
factory.register(0x14187A2A0, "Client::Game::Gimmick::GimmickRect", ["Client::Game::Gimmick::GimmickEventHandler", "Client::Game::Event::LuaEventHandler", "Client::Game::Event::EventHandler", "Client::Game::InstanceContent::ContentSheetWaiterInterface"], {})
factory.finalize()

# endregion

print("Done")

# current exe version: 2020.12.02.0000.0000

from __future__ import print_function

try:
    from typing import Any, Dict, List, Optional, Union  # noqa
except ImportError:
    pass

import sys
import itertools
from abc import abstractmethod
from collections import deque

if sys.version_info[0] >= 3:
    long = int


class BaseApi(object):
    @abstractmethod
    def get_image_base(self):
        """
        Get the image base ea
        :return: Image base ea
        :rtype: int
        """

    @abstractmethod
    def set_addr_name(self, ea, name):
        """
        Set the name of a given address (function)
        :param ea: Effective address
        :type ea: int
        :param name: Name to set
        :type name: str
        :return: Success/failure
        :rtype: bool
        """

    @abstractmethod
    def get_addr_name(self, ea):
        """
        Get the name of a given address
        :param ea: Effective address
        :type ea: int
        :return: Name or empty
        :rtype: str
        """

    @abstractmethod
    def get_qword(self, ea):
        """
        Read a qword of data from an address
        :param ea: Effective address
        :type ea: int
        :return: 64bits of data
        :rtype: int
        """

    @abstractmethod
    def is_offset(self, ea):
        """
        Is the given address an offset to something else
        :param ea: Effective address
        :type ea: int
        :return: Is offset or not
        :rtype: bool
        """

    @abstractmethod
    def xrefs_to(self, ea):
        """
        Retrieve all xrefs to the given address
        :param ea: Effective address
        :type ea: int
        :return: List of addresses
        :rtype: List[int]
        """

    @abstractmethod
    def get_struct_id(self, name):
        """
        Get the ID of a given struct by name
        :param name: Struct name
        :type name: str
        :return: Struct ID, -1 if does not exist
        :rtype: int
        """

    @abstractmethod
    def create_struct(self, name):
        """
        Create a new struct with the given Name
        :param name: Struct name
        :type name: str
        :return: Struct ID, -1 if failure
        :rtype: int
        """

    @abstractmethod
    def add_struct_member(self, sid, name):
        """
        Add a new struct member at the end of the structure
        :param sid: Struct ID
        :type sid: int
        :param name: Struct member name
        :type name: str
        :return: Success/failure
        :rtype: bool
        """

    @abstractmethod
    def clear_struct(self, sid):
        """
        Delete all struct members
        :param sid: Struct ID
        :type sid: int
        :return: Success/failure
        :rtype: bool
        """

    @abstractmethod
    def convert_to_struct(self, ea, sid):
        """
        Convert a location to a struct
        :param ea: Effective address
        :type ea: int
        :param sid: Struct ID
        :type sid: int
        :return: Success/failure
        :rtype: bool
        """


api = None
# region IDA Api
try:
    import idaapi  # noqa
    import idc  # noqa
    import idautils  # noqa


    class IdaApi(BaseApi):

        def get_image_base(self):
            return idaapi.get_imagebase()

        def set_addr_name(self, ea, name):
            result = idc.set_name(ea, name)
            return bool(result)

        def get_addr_name(self, ea):
            return idc.get_name(ea)

        def get_qword(self, ea):
            return idc.get_qword(ea)

        def is_offset(self, ea):
            return idc.is_off0(idc.get_full_flags(ea))

        def xrefs_to(self, ea):
            return [xref.to for xref in idautils.XrefsTo(ea)]

        def get_struct_id(self, name):
            sid = idc.get_struc_id(name)
            if sid == idc.BADADDR:
                return -1
            else:
                return sid

        def create_struct(self, name):
            sid = idc.add_struc(-1, name, is_union=0)
            return sid

        def add_struct_member(self, sid, name):
            idc.add_struc_member(sid, name, offset=-1, flag=idc.FF_DATA | idc.FF_QWORD, typeid=-1, nbytes=8, reftype=idc.REF_OFF64)
            member_offset = idc.get_last_member(sid)
            member_id = idc.get_member_id(sid, member_offset)
            idc.SetType(member_id, "void*")

        def clear_struct(self, sid):
            member_offset = idc.get_first_member(sid)
            if member_offset == -1:
                return False
            while member_offset != idc.BADADDR:
                idc.del_struc_member(sid, member_offset)
                member_offset = idc.get_first_member(sid)
            return True

        def convert_to_struct(self, ea, sid):
            struct_name = idc.get_struc_name(sid)
            result = idc.create_struct(ea, -1, struct_name)
            return bool(result)


    api = IdaApi()
except ImportError:
    print("Warning: Unable to load IDA")
# endregion
# region Ghidra Api
try:
    import ghidra


    class GhidraApi(BaseApi):
        def get_image_base(self):
            raise NotImplementedError

        def set_addr_name(self, ea, name):
            raise NotImplementedError

        def get_addr_name(self, ea):
            raise NotImplementedError

        def get_qword(self, ea):
            raise NotImplementedError

        def is_offset(self, ea):
            raise NotImplementedError

        def xrefs_to(self, ea):
            raise NotImplementedError

        def get_struct_id(self, name):
            raise NotImplementedError

        def create_struct(self, name):
            raise NotImplementedError

        def add_struct_member(self, sid, name):
            raise NotImplementedError

        def clear_struct(self, sid):
            raise NotImplementedError


    api = GhidraApi()
except ImportError:
    print("Warning: Unable to load Ghidra")
# endregion

if api is None:
    raise Exception("Unable to load IDA or Ghidra")

print("Importing IDA data ...")


# TODO: Clobber 0x141697D60! "Common::Lua::LuaState", "Common::Lua::LuaThread"

class FfxivClassFactory:
    # {name: ea}
    _vtbls_ea = []  # type: List[int]
    # name -> {class_name: FfxivClass}
    _classes = {}  # type: Dict[str, FfxivClass]

    def register(self, *args):
        """
        Register a class
        :param args: Optional[vtbl_ea], class_name, [hierarchy], {index/func_ea: func_name}
        :return: None
        """
        if len(args) == 1:
            vtbl_ea = 0x0
            class_name, = args
            hierarchy = []
            funcs = {}
        elif len(args) == 2:
            vtbl_ea, class_name = args
            hierarchy = []
            funcs = {}
        elif len(args) == 3:
            vtbl_ea = 0x0
            class_name, hierarchy, funcs = args
        elif len(args) == 4:
            vtbl_ea, class_name, hierarchy, funcs = args
        else:
            print("Error: Unsupported argument layout, args={0}".format(args))
            return

        arg_types = [type(arg) for arg in (vtbl_ea, class_name, hierarchy, funcs)]
        if (arg_types != [int, str, list, dict] and
                arg_types != [long, str, list, dict]):  # py2
            print("Error: Argument mismatch, types={0}".format(arg_types))
            return

        if vtbl_ea in self._vtbls_ea and vtbl_ea != 0x0:
            print("Error: Multiple vtables are defined at 0x{0:X}".format(vtbl_ea))
            return

        if class_name in self._classes:
            print("Error: Multiple classes are registered with the name \"{0}\"".format(class_name))
            return

        self._vtbls_ea.append(vtbl_ea)
        self._classes[class_name] = FfxivClass(vtbl_ea, class_name, hierarchy, funcs)

    def finalize(self):
        """
        Perform the class naming
        :return: None
        """
        self._resolve_hierarchies()
        for class_name, cls in self._classes.items():
            self._finalize_cls(cls)

    def _resolve_hierarchies(self):
        """
        Convert each class_name in each hierarchy to a class object reference
        :return: None
        """
        for class_name, cls in self._classes.items():
            for idx, parent_class_name in enumerate(cls.hierarchy):
                if isinstance(parent_class_name, str):
                    if parent_class_name not in self._classes:
                        print("Warning: Inherited class \"{0}\" is not documented, add a placeholder entry".format(parent_class_name))
                        self.register(parent_class_name)
                    cls.hierarchy[idx] = self._classes[parent_class_name]

        # Check for duplicate entries in hierarchy, likely a previous parent class inherits from the duplicate
        for class_name, cls in self._classes.items():
            hierarchy = cls.hierarchy_names
            if len(hierarchy) != len(set(hierarchy)):
                extras = set([x for x in hierarchy if hierarchy.count(x) > 1])
                for extra in extras:
                    print("Warning: \"{0}\" has a duplicate hierarchy entry \"{1}\"".format(cls.name, extra))

    _finalize_stack = deque()

    def _finalize_cls(self, cls):
        """
        Perform a single class naming
        :param cls: Class object
        :type cls: FfxivClass
        :return: None
        """
        if cls in self._finalize_stack:
            names = [c.name for c in self._finalize_stack] + [cls.name]
            names = "\n".join(["    - {0}".format(name) for name in names])
            raise ValueError("Hierarchy cycle detected: \n{0}".format(names))

        self._finalize_stack.append(cls)

        if not cls.finalized:
            for parent_cls in cls.hierarchy:
                if not parent_cls.finalized:
                    self._finalize_cls(parent_cls)
            cls.finalize()

        self._finalize_stack.pop()


class FfxivClass:
    STANDARD_IMAGE_BASE = 0x140000000

    VTBL_FORMAT = "vtbl_{cls}"
    NAMED_FUNC_FORMAT = "{cls}.{name}"
    GENERIC_SUB_FORMAT = "{cls}.vf{index}"
    GENERIC_NULLSUB_FORMAT = "{cls}.vf{index}_nullsub"
    GENERIC_LOC_FORMAT = "{cls}.vloc{index}"

    STRUCT_VTBL_FORMAT = "vtbl_{cls}_struct"
    STRUCT_NAMED_FORMAT = "{name}"
    STRUCT_GENERIC_SUB_FORMAT = "vf{index}"
    STRUCT_GENERIC_NULLSUB_FORMAT = "vf{index}_nullsub"
    STRUCT_GENERIC_LOC_FORMAT = "vloc{index}"
    STRUCT_PURECALL_FORMAT = "purecall{index}"
    STRUCT_MANGLE_FORMAT = "mangled{index}"

    SUB_PREFIX = "sub_"
    NULLSUB_PREFIX = "nullsub_"
    LOC_PREFIX = "loc_"
    JUMP_PREFIX = "j_"
    PURECALL = "_purecall"

    def __init__(self, vtbl_ea, class_name, hierarchy, funcs):
        """
        Object representing a class
        :param vtbl_ea: Vtable effective address
        :type vtbl_ea: int
        :param class_name: Class name
        :type class_name: str
        :param hierarchy: Inheritance hierarchy
        :type hierarchy: List[str|FfxivClass]
        :param funcs: Mapping of vtbl index or effective addresses to func names
        :type funcs: Dict[int, str]
        """
        self.vtbl_ea = vtbl_ea
        self.name = class_name
        self.hierarchy = hierarchy
        self.funcs = funcs

        # Offset the vtbl and funcs if the program has been rebased
        current_image_base = api.get_image_base()
        if self.STANDARD_IMAGE_BASE != current_image_base:
            rebase_offset = current_image_base - self.STANDARD_IMAGE_BASE
            self.vtbl_ea + rebase_offset
            for idx_or_ea in list(funcs.keys()):
                if idx_or_ea > 0x1000:
                    funcs[idx_or_ea + rebase_offset] = funcs.pop(idx_or_ea)

    # region hierarchy_names

    _hierarchy_names = None

    @property
    def hierarchy_names(self):
        """
        Get the class names of the entire hierarchy as a flat list
        :return: [class_name]
        """
        if self._hierarchy_names is None:
            self._hierarchy_names = list(itertools.chain(*[cls.hierarchy_names for cls in self.hierarchy])) + [self.name]
        return self._hierarchy_names

    # endregion

    # region vtbl_size
    _vtbl_size = 0

    @property
    def vtbl_size(self):
        """
        Iterate from the vtbl start until a non-offset or xref is encountered.
        This strategy implies that the only xref in a vtbl is the first vfunc.
        :return: VTable func count
        """
        if self.vtbl_ea == 0x0:
            return self._vtbl_size

        if self._vtbl_size == 0:
            self._vtbl_size = 1  # Set to 1, skip the first entry
            for ea in itertools.count(self.vtbl_ea + 8, 8):
                if api.is_offset(ea) and api.xrefs_to(ea) == []:
                    self._vtbl_size += 1
                else:
                    break

            parent_vtbl_size = sum(parent.vtbl_size for parent in self.hierarchy)
            if self.vtbl_size < parent_vtbl_size:
                print("Error: The sum of \"{0}\"'s parent vtbl sizes ({1}) is greater than the actual class itself ({2})".format(self.name, parent_vtbl_size, self._vtbl_size))

        return self._vtbl_size

    # endregion

    # region finalizing

    _finalized = False

    @property
    def finalized(self):
        """
        Has this class and its hierarchy been written out or not
        :return: bool yes/no
        :rtype: bool
        """
        return self._finalized and all(parent.finalized for parent in self.hierarchy)

    def finalize(self):
        """
        Write out this class
        :return: None
        """
        self._write_vtbl()
        self._write_funcs()
        self._finalized = True

    def _write_vtbl(self):
        # Name the vtbl start offset
        api.set_addr_name(self.vtbl_ea, self.VTBL_FORMAT.format(cls=self.name))

        struct_name = self.STRUCT_VTBL_FORMAT.format(cls=self.name)
        struct_id = api.get_struct_id(struct_name)
        if struct_id == -1:
            struct_id = api.create_struct(struct_name)
        else:
            api.clear_struct(struct_id)

        # Iterate through each offset
        for idx in range(0, self.vtbl_size):
            vfunc_offset = self.vtbl_ea + idx * 8
            vfunc_ea = api.get_qword(vfunc_offset)  # type: int

            if idx in self.funcs:
                func_name = self.funcs[idx]
                full_func_name = self.NAMED_FUNC_FORMAT.format(cls=self.name, name=func_name)
                api.set_addr_name(vfunc_ea, full_func_name)
                api.add_struct_member(struct_id, func_name)
            else:
                current_func_name = api.get_addr_name(vfunc_ea)  # type: str

                if current_func_name.startswith(self.JUMP_PREFIX):
                    current_func_name = current_func_name.lstrip(self.JUMP_PREFIX)

                parent_func_name = self._get_parent_func_name(idx)
                if parent_func_name:
                    parent_full_func_name = self.NAMED_FUNC_FORMAT.format(cls=self.name, name=parent_func_name)
                else:
                    parent_full_func_name = ""

                if current_func_name.startswith(self.SUB_PREFIX):
                    full_func_name = parent_full_func_name or self.GENERIC_SUB_FORMAT.format(cls=self.name, index=idx)
                    struct_member_name = parent_func_name or self.STRUCT_GENERIC_SUB_FORMAT.format(index=idx)
                elif current_func_name.startswith(self.NULLSUB_PREFIX):
                    full_func_name = parent_full_func_name or self.GENERIC_NULLSUB_FORMAT.format(cls=self.name, index=idx)
                    struct_member_name = parent_func_name or self.STRUCT_GENERIC_NULLSUB_FORMAT.format(index=idx)
                elif current_func_name.startswith(self.LOC_PREFIX):
                    full_func_name = parent_full_func_name or self.GENERIC_LOC_FORMAT.format(cls=self.name, index=idx)
                    struct_member_name = parent_func_name or self.STRUCT_GENERIC_LOC_FORMAT.format(index=idx)
                elif any(current_func_name.startswith(parent_class_name) for parent_class_name in self.hierarchy_names):
                    full_func_name = None  # Not an override
                    # Rework this at some point to get the actual parent name, minus the class?
                    struct_member_name = current_func_name.split(".", 1)[-1]
                elif current_func_name == self.PURECALL:
                    full_func_name = None  # Ignored
                    struct_member_name = self.STRUCT_PURECALL_FORMAT.format(index=idx)
                elif current_func_name.startswith("?"):
                    full_func_name = None  # Mangled? Probably a library
                    struct_member_name = self.STRUCT_MANGLE_FORMAT.format(index=idx)
                elif current_func_name.startswith("qword_"):
                    print("Warning: qword in vtbl at 0x{0:X}, it may be an offset to undefined code".format(vfunc_offset))
                    full_func_name = None
                    struct_member_name = "qword{0}".format(idx)
                    # TODO: How to handle this? Only observed instance so far is to unresolved code
                    # 0x141696198 Client::Graphics::Scene::Human
                    # 0x141696380 qword_140444F00, sub_140444F00, vf61
                else:
                    print("Error: Unexpected function name \"{0}\" at 0x{1:X}".format(current_func_name, self.vtbl_ea + idx * 8))
                    full_func_name = None
                    struct_member_name = "naming_error{0}".format(idx)

                if full_func_name:
                    api.set_addr_name(vfunc_ea, full_func_name)
                api.add_struct_member(struct_id, struct_member_name)

        # Running the script twice will undefine vast segments of the vtbl since theyre now structs
        # Need to work a method of not screwing that up.
        # api.convert_to_struct(self.vtbl_ea, struct_id)

    def _get_parent_func_name(self, index):
        """
        Override vfuncs need to inherit their parent vfunc name, iterate through each parent in the
        hierarchy until the base+index is within the base+parent_vtbl_range.
        :param index: VFunc index
        :type index: int
        :return: Parent vfunc name or empty
        :rtype: str
        """
        base = 0
        parent_iter = iter(self.hierarchy)
        parent = next(parent_iter, None)
        while parent:
            if base < index + base < parent.vtbl_size + base:
                parent_func_name = parent.funcs.get(index, "")
                if not parent_func_name:
                    return parent._get_parent_func_name(index - base)
                return parent_func_name
            else:
                base += parent.vtbl_size
                parent = next(parent_iter, None)
        return None

    def _write_funcs(self):
        """
        Write the names of all non-vtbl funcs
        :return: None
        """
        for ea, func_name in self.funcs.items():
            if ea > 0x1000:
                full_func_name = self.NAMED_FUNC_FORMAT.format(cls=self.name, name=func_name)
                current_name = api.get_addr_name(ea)  # type: str

                # strip jump prefixed
                if current_name.startswith(self.JUMP_PREFIX):
                    current_name = current_name.lstrip(self.JUMP_PREFIX)

                # same name? skip it
                if current_name == full_func_name:
                    continue
                # check that the name is unnamed
                elif any(current_name.startswith(prefix) for prefix in [self.SUB_PREFIX, self.NULLSUB_PREFIX, self.LOC_PREFIX]):
                    api.set_addr_name(ea, full_func_name)
                else:
                    print("Warning: 0x{0:X} \"{1}\" was already named \"{2}\"".format(ea, func_name, current_name))

    # endregion

    def __repr__(self):
        return "<{0}(\"{1}\")>".format(self.__class__.__name__, self.name)


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
factory = FfxivClassFactory()

# Unknown classes old RTTI data says known classes inherit from
factory.register("Client::Game::Control::TargetSystem::ListFeeder")
factory.register("Client::Game::InstanceContent::ContentSheetWaiterInterface")
factory.register("Client::Game::Object::IGameObjectEventListener")
factory.register("Client::Graphics::Kernel::Buffer")
factory.register("Client::Graphics::Kernel::Resource")
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
factory.register("Client::UI::UIModuleInterface")
factory.register("Common::Configuration::ConfigBase::ChangeEventInterface")
factory.register("Component::Excel::ExcelLanguageEvent")
factory.register("Component::GUI::AtkComponentWindowGrab")
factory.register("Component::GUI::AtkDragDropInterface")
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
factory.register(0x141659488, "Component::GUI::AtkEventListener", [], {
    2: "ReceiveEvent",
})  # TODO: Verify this
factory.register(0x1416594C0, "Component::GUI::AtkUnitList", [], {})
factory.register(0x1416594C8, "Component::GUI::AtkUnitManager", ["Component::GUI::AtkEventListener"], {
    0x1404E5470: "ctor",
})
factory.register(0x141659620, "Client::UI::RaptureAtkUnitManager", ["Component::GUI::AtkUnitManager"], {
    0x1400AAE50: "ctor",
    0x1404E6F80: "GetAddonByName",  # dalamud GetUIObjByName
})
factory.register(0x141659878, "Client::UI::RaptureAtkModule", ["Component::GUI::AtkModule", "Common::Configuration::ConfigBase::ChangeEventInterface"], {
    39: "SetUIVisibility",
    0x1400B06F0: "ctor",
    0x1400D37C0: "UpdateTask1",
    0x1400D6750: "IsUIVisible",
})
factory.register(0x141661D28, "Client::Graphics::Kernel::Notifier", [], {})
factory.register(0x1416657C0, "Client::System::Crypt::Crc32", [], {})
factory.register(0x14166BD10, "Client::Graphics::ReferencedClassBase", [], {})  # TODO: Verify this
factory.register(0x14166BD58, "Client::Graphics::Environment::EnvSoundState", [], {})
factory.register(0x14166BD78, "Client::Graphics::Environment::EnvState", [], {})
factory.register(0x14166BDC8, "Client::Graphics::Environment::EnvSimulator", [], {})
factory.register(0x14166BDD8, "Client::Graphics::Environment::EnvManager", ["Client::Graphics::Singleton"], {})
factory.register(0x14166DA88, "Client::System::Resource::Handle::ResourceHandle", ["Client::System::Common::NonCopyable"], {
    0x1401A0080: "DecRef",
    0x1401A00B0: "IncRef",
    0x1401A0270: "ctor",
})
factory.register(0x14166DC08, "Client::System::Resource::Handle::DefaultResourceHandle", ["Client::System::Resource::Handle::ResourceHandle"], {
    23: "GetData",  # This was under Client::System::Resource::Handle::ResourceHandle
})
factory.register(0x14166E088, "Client::System::Resource::Handle::TextureResourceHandle", ["Client::System::Resource::Handle::ResourceHandle"], {
    0x1401A3730: "ctor",
})
factory.register(0x14166E8B8, "Client::System::Resource::Handle::CharaMakeParameterResourceHandle", ["Client::System::Resource::Handle::DefaultResourceHandle"], {})
factory.register(0x14166FB38, "Client::System::Resource::Handle::ApricotResourceHandle", ["Client::System::Resource::Handle::DefaultResourceHandle"], {
    33: "Load",
})
factory.register(0x1416729E8, "Client::System::Resource::Handle::UldResourceHandle", ["Client::System::Resource::Handle::DefaultResourceHandle"], {})
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
factory.register(0x141675998, "Client::UI::Agent::AgentCharaMake", ["Client::UI::Agent::AgentInterface"], {})
factory.register(0x141675D70, "Client::UI::Agent::AgentModule", [], {
    0x1401F5FF0: "ctor",
    0x1401FB250: "GetAgentByInternalID",
    0x1401FB260: "GetAgentByInternalID_2",  # dupe?
})
factory.register(0x141676AE0, "Client::UI::Agent::AgentCursor", ["Client::UI::Agent::AgentInterface"], {})
factory.register(0x141676B50, "Client::UI::Agent::AgentCursorLocation", ["Client::UI::Agent::AgentInterface"], {})
factory.register(0x14167E120, "Client::Graphics::Kernel::Texture", ["Client::Graphics::Kernel::Resource", "Client::Graphics::DelayedReleaseClassBase"], {
    0x1402F9930: "ctor",
})
factory.register(0x14167E3A8, "Client::Graphics::Kernel::ConstantBuffer", ["Client::Graphics::Kernel::Buffer", "Client::Graphics::Kernel::Resource", "Client::Graphics::DelayedReleaseClassBase"], {})
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
factory.register(0x141685A50, "Client::Graphics::Render::BaseRenderer", [], {})  # TODO: Verify this
factory.register(0x141685A88, "Client::Graphics::Render::ModelRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::ModelRenderer::RenderJob", [], {})
factory.register(0x141685A90, "Client::Graphics::Render::ModelRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685AB8, "Client::Graphics::Render::GeometryInstancingRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685B60, "Client::Graphics::Render::BGInstancingRenderer_Client::Graphics::JobSystem_CClient::Graphics::Render::tagInstancingContainerRenderInfo", [], {})
factory.register(0x141685B68, "Client::Graphics::Render::BGInstancingRenderer", ["Client::Graphics::Render::GeometryInstancingRenderer"], {})
factory.register(0x141685BD0, "Client::Graphics::Render::TerrainRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::TerrainRenderer::RenderJob", [], {})
factory.register(0x141685BD8, "Client::Graphics::Render::TerrainRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685C48, "Client::Graphics::Render::UnknownRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685CB0, "Client::Graphics::Render::WaterRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::WaterRenderer::RenderJob", [], {})
factory.register(0x141685CB8, "Client::Graphics::Render::WaterRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685DA0, "Client::Graphics::Render::VerticalFogRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::VerticalFogRenderer::RenderJob", [], {})
factory.register(0x141685DA8, "Client::Graphics::Render::VerticalFogRenderer", ["Client::Graphics::Render::BaseRenderer"], {})
factory.register(0x141685EC0, "Client::Graphics::Render::ShadowMaskUnit", [], {})
factory.register(0x141685ED8, "Client::Graphics::Render::ShaderManager", [], {})
factory.register(0x141685EE8, "Client::Graphics::Render::Manager_Client::Graphics::JobSystem_Client::Graphics::Render::Manager::BoneCollectorJob", [], {})
factory.register(0x141685EF0, "Client::Graphics::Render::Updater_Client::Graphics::Render::PostBoneDeformerBase", [], {})
factory.register(0x141685EF8, "Client::Graphics::Render::Manager", ["Client::Graphics::Singleton"], {})
factory.register(0x141685F10, "Client::Graphics::Render::ShadowManager", [], {
    0x140365BA0: "ctor",
})
factory.register(0x141685F20, "Client::Graphics::Render::LightingManager::LightShape", [], {})
factory.register(0x141685F28, "Client::Graphics::Render::LightingManager::LightingRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::LightingManager::LightingRenderer::RenderJob", [], {})
factory.register(0x141685F30, "Client::Graphics::Render::LightingManager::LightingRenderer", [], {
    0x14036A1D0: "ctor",
})
factory.register(0x141685F38, "Client::Graphics::Render::LightingManager", [], {
    0x140374A80: "ctor",
})
factory.register(0x141685F40, "Client::Graphics::Render::LightingManager_Client::Graphics::Kernel::Notifier", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {})
factory.register(0x141685F60, "Client::Graphics::Render::RenderTargetManager", [], {
    0x140375260: "ctor",
})
factory.register(0x141685F68, "Client::Graphics::Render::RenderTargetManager_Client::Graphics::Kernel::Notifier", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {})
factory.register(0x1416885D8, "Client::Graphics::PostEffect::PostEffectChain", [], {})
factory.register(0x1416885E0, "Client::Graphics::PostEffect::PostEffectRainbow", [], {})
factory.register(0x1416885E8, "Client::Graphics::PostEffect::PostEffectLensFlare", [], {})
factory.register(0x1416885F0, "Client::Graphics::PostEffect::PostEffectRoofQuery", [], {})
factory.register(0x141688600, "Client::Graphics::PostEffect::PostEffectManager", [], {
    0x140396010: "ctor",
})
factory.register(0x141688608, "Client::Graphics::PostEffect::PostEffectManager_Client::Graphics::Kernel::Notifier", ["Client::Graphics::Singleton", "Client::Graphics::Kernel::Notifier"], {})
factory.register(0x14168C238, "Client::Graphics::JobSystem(Apricot::Engine::Core_Apricot::Engine::Core::CoreJob_1)", [], {
    0x1403DD170: "ctor",
    0x1403DD3A0: "GetSingleton",
})
factory.register(0x1416959D0, "Client::Graphics::Scene::Object", [], {})
factory.register(0x141695A00, "Client::Graphics::Scene::DrawObject", ["Client::Graphics::Scene::Object"], {
    0x14042BCE0: "ctor",
})
factory.register(0x141695B98, "Client::Graphics::Scene::World_Client::Graphics::JobSystem_Client::Graphics::Scene::World::SceneUpdateJob", [], {})
factory.register(0x141695BA0, "Client::Graphics::Scene::World", ["Client::Graphics::Scene::Object", "Client::Graphics::Singleton"], {
    0x14042C290: "ctor",
})
factory.register(0x141695BD0, "Client::Graphics::Scene::World_Client::Graphics::Singleton", ["Client::Graphics::Singleton"], {})
factory.register(0x141695BD8, "Client::Graphics::Scene::Camera", ["Client::Graphics::Scene::Object"], {
    0x14042C550: "ctor",
})
factory.register(0x141695C38, "Client::Graphics::Scene::CameraManager_Client::Graphics::Singleton", [], {})
factory.register(0x141695C40, "Client::Graphics::Scene::CameraManager", [], {
    0x14042E020: "ctor",
})
factory.register(0x141695E08, "Client::Graphics::Scene::CharacterUtility", ["Client::Graphics::Singleton"], {
    0x140431750: "ctor",
    0x140431960: "CreateDXRenderObjects",
    0x140431DB0: "LoadDataFiles",
    0x140435B30: "GetSlotEqpFlags",
})
factory.register(0x141695E88, "Client::Graphics::Scene::CharacterBase", ["Client::Graphics::Scene::DrawObject"], {
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
factory.register(0x141696198, "Client::Graphics::Scene::Human", ["Client::Graphics::Scene::CharacterBase"], {
    0: "dtor",
    1: "CleanupRender",
    4: "UpdateRender",
    67: "FlagSlotForUpdate",
    68: "GetDataForSlot",
    73: "ResolveMDLPath",
    82: "ResolveMTRLPath",
    86: "GetDyeForSlot",
    0x140443E40: "ctor",
    0x140444080: "SetupFromCharacterData",
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
factory.register(0x14169A3C8, "Component::GUI::AtkEventTarget", [], {})  # TODO: Verify this
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
factory.register(0x1416A9CD0, "Client::UI::UI3DModule::MapInfo", [], {})  # TODO: Verify this
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
factory.register(0x1416AEC40, "Client::UI::Misc::RaptureTextModule", [], {})
factory.register(0x1416AEEB8, "Client::UI::Misc::RaptureLogModule", ["Component::Log::LogModule"], {
    0x140615880: "ctor",
    0x140617010: "PrintMessage",
})
factory.register(0x1416AEF08, "Client::UI::Misc::RaptureHotbarModule", ["Client::UI::Misc::UserFileManager::UserFileEvent", "Client::System::Input::InputData::InputCodeModifiedInterface"], {
    0x1406207D0: "ctor",
})
factory.register(0x1416AEF70, "Client::UI::Misc::RaptureHotbarModule_Client::System::Input::InputCodeModifiedInterface", ["Client::System::Input::InputData::InputCodeModifiedInterface"], {})
factory.register(0x1416AEFE8, "Client::UI::Misc::PronounModule", ["Component::Text::TextChecker::ExecNonMacroFunc"], {
    0x140629590: "ctor",
})
factory.register(0x1416AFAC0, "Client::UI::Misc::CharaView", [], {
    0: "dtor",
    1: "Initialize",
    2: "Finalize",
    0x14064FB80: "ctor",
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
factory.register(0x1416B1E10, "Client::Game::Character::Character_Client::Graphics::Vfx::VfxDataListener", ["Client::Graphics::Vfx::VfxDataListenner"], {})
factory.register(0x1416C8150, "Client::Game::Character::BattleChara", ["Client::Game::Character::Character"], {
    0x14073C140: "ctor",
    0x14073C230: "dtor",
})
factory.register(0x1416C8418, "Client::Game::Character::BattleChara_Client::Graphics::Vfx::VfxDataListener", ["Client::Game::Character::Character_Client::Graphics::Vfx::VfxDataListener"], {})
factory.register(0x1416CA7C0, "Client::Game::ActionManager", ["Client::Graphics::Vfx::VfxDataListenner"], {})
factory.register(0x1416CC740, "Client::UI::Agent::AgentHUD", ["Client::UI::Agent::AgentInterface", "Common::Configuration::ConfigBase::ChangeEventInterface"], {
    5: "Update",
    0x14081F350: "ctor",
    0x140824ED0: "UpdateParty",
})
factory.register(0x1416CCAF0, "Client::UI::Agent::AgentItemDetail", ["Client::UI::Agent::AgentItemDetailBase", "Client::UI::Agent::AgentInterface"], {
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
factory.register(0x1416F4AA8, "Client::Game::Gimmick::GimmickBill", ["Client::Game::Gimmick::GimmickEventHandler", "Client::Game::InstanceContent::ContentSheetWaiterInterface"], {})
factory.register(0x141798F70, "Client::UI::AddonNowLoading", ["Component::GUI::AtkUnitBase"], {
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
factory.register(0x1417C9520, "Client::UI::AddonRecipeNote", ["Component::GUI::AtkUnitBase"], {})
factory.register(0x14179BAD0, "Client::UI::AddonHudSelectYesno", ["Component::GUI::AtkUnitBase"], {
    0: "dtor",
    0x140CD9150: "ctor",
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
factory.register(0x1417CDB58, "Client::UI::AddonMateriaAttach", ["Component::GUI::AtkUnitBase"], {})
factory.register(0x1417CDF98, "Client::UI::AddonMateriaAttachDialog", ["Component::GUI::AtkUnitBase"], {})
factory.register(0x141825368, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::CullingJobOpt", [], {})
factory.register(0x141825370, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::CallbackJobOpt", [], {})
factory.register(0x141825378, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::RenderCallbackJob", [], {})
factory.register(0x141825380, "Client::Graphics::Culling::CullingManager", ["Client::Graphics::Singleton"], {})
factory.register(0x141828A68, "Client::Game::Character::Companion", ["Client::Game::Character::Character"], {
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
factory.register(0x1418791E0, "Client::Game::Gimmick::GimmickEventHandler", ["Client::Game::Event::LuaEventHandler"], {})
factory.register(0x14187A2A0, "Client::Game::Gimmick::GimmickRect", ["Client::Game::Gimmick::GimmickEventHandler", "Client::Game::InstanceContent::ContentSheetWaiterInterface"], {})
factory.register(0x141879A40, "Client::Game::Gimmick::Gimmick_Unk1", ["Client::Game::Gimmick::GimmickEventHandler", "Client::Game::InstanceContent::ContentSheetWaiterInterface"], {})
factory.finalize()

# endregion

print("Done")

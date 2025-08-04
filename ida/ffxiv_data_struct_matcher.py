import idaapi
import idc
import ida_bytes
import ida_search
import ida_typeinf
import ida_funcs
import ida_name
import ida_kernwin
import os
import sys
from ida_wrapper import IdaInterface
from structs_schema import *
from data_schema import *
from yaml import load

if sys.version_info[0] >= 3:
    long = int

try:
    from yaml import CSafeLoader as Loader
except ImportError:
    from yaml import SafeLoader as Loader


def get_image_base():
    return idaapi.get_imagebase()


dataDir = os.path.dirname(os.path.realpath(__file__))
structFileName = os.path.join(dataDir, "ffxiv_structs.yml")
dataFileName = os.path.join(dataDir, "data.yml")

ida = IdaInterface()

def get_structs() -> DefinedStructExport:
    dic: dict[str, dict[str, list[dict[str, str | int | list[dict[str, str | int]]]]]] = load(open(structFileName), Loader=Loader)
    enums = []
    structs = []
    for enum in dic["enums"]:
        enums.append(
            DefinedStructEnum(
                enum["name"],
                enum["type"],
                enum["underlying"],
                enum["namespace"],
                enum["flags"],
                enum["values"],
            )
        )
    for struct in dic["structs"]:
        fields = []
        virtual_functions = None
        member_functions = []
        static_member_functions = None
        static_members = None
        for field in struct["fields"]:
            base = field["base"] if "base" in field else False
            if "size" in field:
                fields.append(
                    DefinedStructFixedField(
                        field["name"],
                        field["type"],
                        field["offset"],
                        base,
                        field["size"],
                    )
                )
            elif "return_type" in field:
                parameters = []
                for param in field["parameters"]:
                    parameters.append(
                        DefinedStructFuncParam(param["name"], param["type"])
                    )
                fields.append(
                    DefinedStructFuncField(
                        field["name"],
                        field["type"],
                        field["offset"],
                        base,
                        field["return_type"],
                        parameters,
                    )
                )
            else:
                fields.append(
                    DefinedStructField(
                        field["name"], field["type"], field["offset"], base
                    )
                )
        if "virtual_functions" in struct:
            virtual_functions = []
            for vfunc in struct["virtual_functions"]:
                parameters = (
                    [
                        DefinedStructFuncParam(param["name"], param["type"])
                        for param in vfunc["parameters"]
                    ]
                    if "parameters" in vfunc
                    else None
                )
                virtual_functions.append(
                    DefinedStructVFunc(
                        vfunc["name"],
                        vfunc["return_type"] if "return_type" in vfunc else None,
                        vfunc["offset"],
                        parameters,
                    )
                )
        for memfunc in struct["member_functions"]:
            parameters = []
            for param in memfunc["parameters"]:
                parameters.append(DefinedStructFuncParam(param["name"], param["type"]))
            member_functions.append(
                DefinedStructMemFunc(
                    memfunc["signature"],
                    memfunc["return_type"],
                    parameters,
                    memfunc["name"],
                )
            )
        if "static_member_functions" in struct:
            static_member_functions = []
            for smemfunc in struct["static_member_functions"]:
                parameters = []
                for param in smemfunc["parameters"]:
                    parameters.append(
                        DefinedStructFuncParam(param["name"], param["type"])
                    )
                static_member_functions.append(
                    DefinedStructMemFunc(
                        smemfunc["signature"],
                        smemfunc["return_type"],
                        parameters,
                        smemfunc["name"],
                    )
                )
        if "static_members" in struct:
            static_members = []
            for sm in struct["static_members"]:
                static_members.append(
                    DefinedStructStaticMember(
                        sm["signature"],
                        sm["relative_follow_offsets"],
                        sm["return_type"],
                        sm["is_pointer"] if "is_pointer" in sm else False,
                    )
                )
        size = None
        if "size" in struct:
            size = struct["size"]
        vtable_size = None
        if "vtable_size" in struct:
            vtable_size = struct["vtable_size"]
        structs.append(
            DefinedStruct(
                struct["name"],
                struct["type"],
                struct["namespace"],
                fields,
                size,
                vtable_size,
                virtual_functions,
                member_functions,
                struct["union"],
                static_member_functions,
                static_members,
            )
        )
    return DefinedStructExport(enums, structs)


def get_data():
    dic: dict[str, str | dict[int, str] | dict[str, dict[str, list[dict[str, int | bool | str]] | dict[int, str]]]] = load(open(dataFileName), Loader=Loader)
    classes = []
    for className, classInstance in dic["classes"].items():
        if classInstance == None:
            classes.append(DefinedDataClass(className))
            continue
        instances = []
        if "instances" in classInstance:
            for instance in classInstance["instances"]:
                instances.append(
                    DefinedDataClassInstance(
                        instance["ea"],
                        instance["pointer"] if "pointer" in instance else False,
                        instance["name"] if "name" in instance else None,
                    )
                )
        classes.append(DefinedDataClass(className, instances))
    return DefinedData(classes)


def load_data():
    structs = get_structs().structs
    for data in get_data().classes:
        struct = next((struc for struc in structs if struc.type == data.name), None)
        if struct is None or struct.static_members is None:
            continue
        for static_member in struct.static_members:
            ea = ida.search_binary(0, static_member.signature, ida_search.SEARCH_DOWN)
            for offset in static_member.relative_offsets:
                ea = ea + offset
                dword = ida.get_dword(ea)
                ea = ea + 4 + dword
            instance = next((inst for inst in data.instances if inst.ea == ea), None)
            if instance is None:
                continue
            if ea == instance.ea and static_member.is_pointer != instance.pointer:
                print(f"Found pointer discrepancy at {ea:X} on {data.name}")

load_data()

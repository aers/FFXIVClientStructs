// This script generates a ReClass.NET project with Enums and Classes provided by FFXIVClientStructs.
//
// Prerequisites:
// - Ensure Deno is installed on your system: https://deno.com
// - Ensure "ffxiv_structs.yml" and "data.yml" exist in the same directory as this file.
//
// Usage:
// - Navigate to the "ida" directory.
// - Execute the script with: "deno run convert-to-rcnet.ts"
//   (You can automatically grant all permissions by using the -A flag: "deno run -A convert-to-rcnet.ts")
//
// Output: ffxiv.rcnet

import { parse } from "jsr:@std/yaml";
import * as uuid from "jsr:@std/uuid";
import { escape } from "jsr:@std/html/entities";
import { Buffer } from "jsr:@std/io/buffer";
import { toReadableStream } from "jsr:@std/io/to-readable-stream";
import { ZipWriter } from "jsr:@zip-js/zip-js/";

// #region Input

const data = parse(Deno.readTextFileSync("data.yml")) as DataFile;
const ffxiv_structs = parse(
  Deno.readTextFileSync("ffxiv_structs.yml")
) as FfxivStructsFile;

// #region Interfaces

interface DataFile {
  classes: { [key: string]: Class };
}

interface Class {
  instances?: ClassInstance[];
}

interface ClassInstance {
  ea: number;
  pointer?: boolean;
}

interface FfxivStructsFile {
  enums: Enum[];
  structs: Struct[];
}

interface Enum {
  type: string;
  name: string;
  underlying: string;
  namespace: string;
  values: { [key: string]: number };
}

interface Struct {
  type: string;
  name: string;
  namespace: string;
  union: boolean;
  size: number;
  fields: Field[];
  virtual_functions?: VirtualFunction[];
  // member_functions: FfxivStructMemberFunction[];
}

interface VirtualFunction {
  name: string;
  offset: number;
  return_type: string;
  parameters: FunctionParameter[];
}

interface FunctionParameter {
  type: string;
  name: string;
}

interface Field {
  type: string;
  name: string;
  offset: number;
  size?: number;
}

interface TypeInfo {
  types: string[];
  reclassNode: string;
  enumSizeName?: string;
  enumFlags?: boolean;
  size: number;
}

// #region TypeInfo

const typeInfos: TypeInfo[] = [
  {
    types: ["__fastcall"],
    reclassNode: "FunctionPtrNode",
    size: 8,
  },
  {
    types: ["double"],
    reclassNode: "DoubleNode",
    size: 8,
  },
  {
    types: ["long", "__int64"],
    reclassNode: "Int64Node",
    enumSizeName: "EightBytes",
    enumFlags: false,
    size: 8,
  },
  {
    types: ["ulong", "unsigned long", "unsigned __int64"],
    reclassNode: "UInt64Node",
    enumSizeName: "EightBytes",
    enumFlags: true,
    size: 8,
  },
  {
    types: ["float"],
    reclassNode: "FloatNode",
    size: 4,
  },
  {
    types: ["int", "__int32"],
    reclassNode: "Int32Node",
    enumSizeName: "FourBytes",
    enumFlags: false,
    size: 4,
  },
  {
    types: ["uint", "unsigned int", "unsigned __int32"],
    reclassNode: "UInt32Node",
    enumSizeName: "FourBytes",
    enumFlags: true,
    size: 4,
  },
  {
    types: ["wchar_t"],
    reclassNode: "Utf16TextNode",
    size: 2,
  },
  {
    types: ["short", "__int16"],
    reclassNode: "Int16Node",
    enumSizeName: "TwoBytes",
    enumFlags: false,
    size: 2,
  },
  {
    types: ["ushort", "unsigned short", "unsigned __int16"],
    reclassNode: "UInt16Node",
    enumSizeName: "TwoBytes",
    enumFlags: true,
    size: 2,
  },
  {
    types: ["sbyte", "__int8"],
    reclassNode: "Int8Node",
    enumSizeName: "OneByte",
    enumFlags: false,
    size: 1,
  },
  {
    types: ["byte", "unsigned __int8"],
    reclassNode: "UInt8Node",
    enumSizeName: "OneByte",
    enumFlags: true,
    size: 1,
  },
  {
    types: ["bool"],
    reclassNode: "BoolNode",
    size: 1,
  },
];

function getTypeInfo(type: string): TypeInfo | undefined {
  for (const typeInfo of typeInfos) {
    if (typeInfo.types.includes(type)) return typeInfo;
  }
  return undefined;
}

function getEnumSizeType(type: string): string {
  const typeInfo = getTypeInfo(type);
  if (typeInfo === undefined) {
    throw new Error(`TypeInfo for type ${type} could not be found`);
  }
  if (typeInfo.enumSizeName === undefined) {
    throw new Error(`TypeInfo for type ${type} has no value for enumSizeName`);
  }
  return typeInfo.enumSizeName;
}

function getEnumFlags(type: string): string {
  const typeInfo = getTypeInfo(type);
  if (typeInfo === undefined) {
    throw new Error(`TypeInfo for type ${type} could not be found`);
  }
  if (typeInfo.enumFlags === undefined) {
    throw new Error(`TypeInfo for type ${type} has no value for enumFlags`);
  }
  return typeInfo.enumFlags ? "true" : "false";
}

function getPrimitiveSize(type: string, allowThrow: boolean = true): number {
  const typeInfo = getTypeInfo(type);
  if (typeInfo === undefined) {
    if (allowThrow)
      throw new Error(`TypeInfo for type ${type} could not be found`);
    else return -1;
  }
  return typeInfo.size;
}

function getReClassType(type: string): string {
  const typeInfo = getTypeInfo(type);
  if (typeInfo === undefined) {
    throw new Error(`TypeInfo for type ${type} could not be found`);
  }
  if (typeInfo.reclassNode === undefined) {
    throw new Error(`TypeInfo for type ${type} has no value for reclassNode`);
  }
  return typeInfo.reclassNode;
}

function getPointerDepth(type: string): number {
  let count = 0;
  for (let i = type.length - 1; i >= 0; i--) {
    if (type[i] === "*") {
      count++;
    } else {
      break;
    }
  }
  return count;
}

// #region Writer API

const textEncoder = new TextEncoder();
const buffer = new Buffer();

function write(str: string) {
  buffer.writeSync(textEncoder.encode(str));
}

function writeLine(str: string) {
  buffer.writeSync(textEncoder.encode(str + "\n"));
}

function writeNode(
  tag: string,
  args: { [key: string]: string | number },
  keepOpen: boolean = false
) {
  write(`<${tag} ${objectToAttributes(args)}${keepOpen ? "" : " /"}>\n`);
}

function objectToAttributes(args: { [key: string]: string | number }): string {
  return Object.entries(args)
    .map(([key, value]) => `${key}="${escape(value.toString())}"`)
    .join(" ");
}

function fillGaps(offset: number, maxOffset: number) {
  let gap = 0;

  while ((gap = maxOffset - offset) > 0) {
    if (offset % 8 == 0 && gap >= 8) {
      writeNode("node", {
        type: "Hex64Node",
        name: `_gap_0x${offset.toString(16).toUpperCase()}`,
        comment: "",
        hidden: "false",
      });
      offset += 8;
      continue;
    }
    if (offset % 4 == 0 && gap >= 4) {
      writeNode("node", {
        type: "Hex32Node",
        name: `_gap_0x${offset.toString(16).toUpperCase()}`,
        comment: "",
        hidden: "false",
      });
      offset += 4;
      continue;
    }
    if (offset % 2 == 0 && gap >= 2) {
      writeNode("node", {
        type: "Hex16Node",
        name: `_gap_0x${offset.toString(16).toUpperCase()}`,
        comment: "",
        hidden: "false",
      });
      offset += 2;
      continue;
    }
    writeNode("node", {
      type: "Hex8Node",
      name: `_gap_0x${offset.toString(16).toUpperCase()}`,
      comment: "",
      hidden: "false",
    });
    offset += 1;
  }

  return offset;
}

// #region Type Cache

const enumTypes: { [key: string]: { size: number } } = {};
const structTypes: { [key: string]: { uuid: string; size: number } } = {};

function getFieldSize(field: Field) {
  const count = field.size || 1;

  if (field.type.endsWith("*")) return 8 * count;

  const size = getPrimitiveSize(field.type, false);
  if (size != -1) return size * count;

  if (field.type in structTypes) return structTypes[field.type].size * count;
  if (field.type in enumTypes) return enumTypes[field.type].size * count;

  throw new Error(`Could not determine size of type ${field.type}`);
}

for (const entry of ffxiv_structs.enums) {
  enumTypes[entry.type] = { size: getPrimitiveSize(entry.underlying) };
}

for (const entry of ffxiv_structs.structs) {
  let size = entry.size;
  if (!size && entry.fields && entry.fields.length > 0) {
    const lastField = entry.fields[entry.fields.length - 1];
    size = lastField.offset + getFieldSize(lastField); // TODO: maybe suboptimal
  }

  structTypes[entry.type] = {
    uuid: await uuid.v5.generate(
      "6ba7b812-9dad-11d1-80b4-00c04fd430c8", // ISO OID
      textEncoder.encode(entry.type)
    ),
    size,
  };
}

// #region Address API

const agentNamespaceLength = "Client::UI::Agent::".length;
const addonNamespaceLength = "Client::UI::Addon".length;
function getAddress(struct: Struct): string {
  // some special cases supported by XivReClassPlugin

  if (struct.type == "Client::UI::UIModule") return "<UIModule>";

  if (struct.type == "Client::UI::Agent::AgentModule") return "<AgentModule>";

  // use Agent resolver, if possible
  if (
    struct.type.startsWith("Client::UI::Agent::Agent") &&
    !struct.type.substring(agentNamespaceLength).includes("::")
  )
    return `<Agent(${struct.type.substring(agentNamespaceLength)})>`;

  // use Addon resolver, if possible
  // TODO: get the addon name from the attribute
  if (
    struct.type.startsWith("Client::UI::Addon") &&
    !struct.type.substring(addonNamespaceLength).includes("::")
  )
    return `<Addon(${struct.type.substring(addonNamespaceLength)})>`;

  // use Instance resolver, if possible
  if (data.classes[struct.type]?.instances?.length) {
    const instance = data.classes[struct.type].instances![0];
    const isPointer = instance.pointer || true;
    return (
      (isPointer ? "[" : "") +
      "<" +
      struct.type +
      "_Instance>" +
      (isPointer ? "]" : "")
    );
  }

  return "140000000";
}

// #region Output Start

writeLine('<?xml version="1.0" encoding="utf-8"?>');
writeLine('<reclass version="65537" type="x64">');
writeLine(`<type_mapping>
<TypeBool>bool</TypeBool>
<TypeInt8>int8_t</TypeInt8>
<TypeInt16>int16_t</TypeInt16>
<TypeInt32>int32_t</TypeInt32>
<TypeInt64>int64_t</TypeInt64>
<TypeNInt>ptrdiff_t</TypeNInt>
<TypeUInt8>uint8_t</TypeUInt8>
<TypeUInt16>uint16_t</TypeUInt16>
<TypeUInt32>uint32_t</TypeUInt32>
<TypeUInt64>uint64_t</TypeUInt64>
<TypeNUInt>size_t</TypeNUInt>
<TypeFloat>float</TypeFloat>
<TypeDouble>double</TypeDouble>
<TypeVector2>Vector2</TypeVector2>
<TypeVector3>Vector3</TypeVector3>
<TypeVector4>Vector4</TypeVector4>
<TypeMatrix3x3>Matrix3x3</TypeMatrix3x3>
<TypeMatrix3x4>Matrix3x4</TypeMatrix3x4>
<TypeMatrix4x4>Matrix4x4</TypeMatrix4x4>
<TypeUtf8Text>char</TypeUtf8Text>
<TypeUtf16Text>wchar_t</TypeUtf16Text>
<TypeUtf32Text>char32_t</TypeUtf32Text>
<TypeFunctionPtr>void*</TypeFunctionPtr>
</type_mapping>`);

writeLine("<enums>");

for (const entry of ffxiv_structs.enums) {
  writeNode(
    "enum",
    {
      name: entry.type,
      size: getEnumSizeType(entry.underlying),
      flags: getEnumFlags(entry.underlying),
    },
    true
  );

  for (const name in entry.values) {
    writeNode("item", { name, value: entry.values[name] });
  }

  writeLine("</enum>");
}

writeLine("</enums>");

writeLine("<classes>");

for (const struct of ffxiv_structs.structs) {
  console.log(`Processing ${struct.type}`);

  const hasVTable =
    struct.virtual_functions !== undefined &&
    struct.virtual_functions.length > 0;

  writeNode(
    "class",
    {
      uuid: structTypes[struct.type].uuid,
      name: struct.type,
      comment: "",
      address: getAddress(struct),
    },
    true
  );

  if (struct.union) {
    writeNode(
      "node",
      {
        type: "UnionNode",
        name: struct.name,
        comment: "",
        address: "140000000",
      },
      true
    );
  }

  let offset = 0;
  for (const field of struct.fields) {
    // handle VTable first
    if (offset == 0 && hasVTable) {
      writeNode(
        "node",
        {
          type: "UnionNode",
          name: "VTable",
          comment: "",
          address: "140000000",
        },
        true
      );

      // add gap, so types and size are visible
      writeNode("node", {
        type: "Hex64Node",
        name: "_gap_0x00",
        comment: "",
        hidden: "false",
      });

      writeNode(
        "node",
        {
          type: "VirtualMethodTableNode",
          name: "VTable",
          comment: "",
          hidden: "false",
        },
        true
      );

      let offset = 0;
      for (const vf of struct.virtual_functions!) {
        for (; offset < vf.offset; offset += 8)
          writeLine('<method name="" comment="" hidden="false" />');

        writeNode("method", {
          name: vf.name,
          comment: "",
          hidden: "false",
        });

        offset = vf.offset + 8;
      }

      writeLine("</node>"); // end VirtualMethodTableNode

      if (field.offset != 0) {
        writeLine("</node>"); // if not in union with field, end UnionNode
      }
    }

    fillGaps(offset, field.offset);

    if (field.size) {
      writeNode(
        "node",
        {
          type: "ArrayNode",
          name: field.name,
          comment: "",
          hidden: "false",
          count: field.size,
        },
        true
      );
    }

    const pointerDepth = getPointerDepth(field.type);

    for (let i = pointerDepth; i > 0; i--) {
      writeNode(
        "node",
        {
          type: "PointerNode",
          name: field.name,
          comment: "",
          hidden: "false",
        },
        true
      );
    }

    const fieldType =
      pointerDepth > 0
        ? field.type.substring(0, field.type.length - pointerDepth)
        : field.type;

    if (fieldType in enumTypes) {
      writeNode("node", {
        type: "EnumNode",
        name: field.name,
        comment: "",
        hidden: "false",
        reference: fieldType,
      });
    } else if (fieldType in structTypes) {
      writeNode("node", {
        type: "ClassInstanceNode",
        name: field.name,
        comment: "",
        hidden: "false",
        reference: structTypes[fieldType].uuid,
      });
    } else {
      const type = getReClassType(fieldType);
      if (pointerDepth == 0 && type == "Utf16TextNode") {
        writeNode("node", {
          type: type,
          name: field.name,
          comment: "",
          hidden: "false",
          size: field.size ?? 1,
        });
      } else {
        writeNode("node", {
          type: type,
          name: field.name,
          comment: "",
          hidden: "false",
        });
      }
    }

    for (let i = pointerDepth; i > 0; i--) {
      writeLine("</node>"); // end PointerNode
    }

    if (field.size) {
      writeLine("</node>"); // end ArrayNode
    }

    if (offset == 0 && hasVTable && field.offset == 0) {
      writeLine("</node>"); // end union with VTable
    }

    offset = field.offset + getFieldSize(field);
  }

  fillGaps(offset, struct.size);

  if (struct.union) {
    writeLine("</node>");
  }

  writeLine("</class>");
}

writeLine("</classes>");

writeLine("</reclass>");

// #region Write Zip

const file = await Deno.create("ffxiv.rcnet");
const zipWriter = new ZipWriter(file.writable);
await zipWriter.add("Data.xml", toReadableStream(buffer));
await zipWriter.close();

console.log("Done!");

// don't know why it hangs here for a bit, just exit
Deno.exit();

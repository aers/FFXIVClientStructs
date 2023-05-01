using FFXIVClientStructs.Attributes;
using FFXIVClientStructs.Interop;
using FFXIVClientStructs.Interop.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace CExporter
{
    public class Program
    {
        public static void Main(string[] _)
        {
            var outputBase = "../../../../";
            File.WriteAllText($"{outputBase}ffxiv_client_structs.h",
                Exporter.Instance.Export(GapStrategy.FullSize, EnvFormat.IDA));
            File.WriteAllText($"{outputBase}ffxiv_client_structs_arrays.h",
                Exporter.Instance.Export(GapStrategy.ByteArray, EnvFormat.IDA));
            File.WriteAllText($"{outputBase}ffxiv_client_structs_ghidra.h",
                Exporter.Instance.Export(GapStrategy.FullSize, EnvFormat.Ghidra));
            File.WriteAllText($"{outputBase}ffxiv_client_structs_arrays_ghidra.h",
                Exporter.Instance.Export(GapStrategy.ByteArray, EnvFormat.Ghidra));
        }
    }

    public enum GapStrategy
    {
        FullSize,   // Fill gaps in structs with sequential longs, ints, shorts, or bytes
        ByteArray,  // Fill gaps in structs with byte arrays
    }

    public enum EnvFormat
    {
        IDA,     // IDA Format: Separator: "::", Enums: short names with underlying type info
        Ghidra,  // Ghidra Format: Separator: "_", Enums: long names w/o underlying type info
    }

    public class Exporter
    {
        #region singleton

        private static Exporter _exporter;
        public static Exporter Instance => _exporter ??= new Exporter();

        #endregion

        private GapStrategy GapStrategy;

        private EnvFormat EnvFormat;

        private readonly List<Type> TypesToExport = new List<Type>();
        private readonly HashSet<Type> KnownTypes = new HashSet<Type>();

        private readonly string FFXIVNamespacePrefix = string.Join(".", new string[] { nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.FFXIV), "" });
        private readonly string STDNamespacePrefix = string.Join(".", new string[] { nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.STD), "" });
        private readonly string InteropNamespacePrefix = string.Join(".", new string[] { nameof(FFXIVClientStructs), nameof(FFXIVClientStructs.Interop), "" });

        private bool IsGeneratedType(Type t) => t.DeclaringType != null && (t.Name == "Addresses" || t.Name == "MemberFunctionPointers" || t.Name == "StaticAddressPointers");

        private IEnumerable<Type> GetExportableTypes(string assemblyName)
        {
            var assembly = AppDomain.CurrentDomain.Load(assemblyName);

            Type[] definedTypes;
            try
            {
                definedTypes = assembly.DefinedTypes.Select(ti => ti.AsType()).ToArray();
            }
            catch (ReflectionTypeLoadException ex)
            {
                definedTypes = ex.Types.Where(t => t != null).ToArray();
            }

            return definedTypes.Where(t => t.FullName.StartsWith(FFXIVNamespacePrefix) && !IsGeneratedType(t));
        }

        public string Export(GapStrategy strategy, EnvFormat envFormat)
        {
            GapStrategy = strategy;
            EnvFormat = envFormat;
            KnownTypes.Clear();
            TypesToExport.Clear();
            TypesToExport.AddRange(GetExportableTypes(nameof(FFXIVClientStructs)));

            var definitions = new StringBuilder();
            for (int i = 0; i < TypesToExport.Count; ++i) // note: new types could be added while exporting
            {
                ProcessType(TypesToExport[i], definitions);
            }

            // Make forward references for everything, cycles are bad, detecting them is harder.
            var header = new StringBuilder();
            header.AppendLine("// Forward References");
            foreach (var type in KnownTypes)
                if (type.IsStruct() && !type.IsFixedBuffer())
                    header.AppendLine($"struct {FixFullName(type)};");

            header.AppendLine();
            header.AppendLine("// Definitions");
            header.Append(definitions);
            return header.ToString();
        }

        private void ProcessType(Type type, StringBuilder header)
        {
            if (type.IsPointer)
            {
                // make sure we export pointed-to type, but don't do it immediately - otherwise we might end up adding definition for a structure X containing member of type Y before Y, if Y has X* member
                var elemType = type.GetElementType();
                while (elemType.IsPointer)
                    elemType = elemType.GetElementType();
                TypesToExport.Add(elemType);
                return;
            }

            if (KnownTypes.Contains(type))
                return;

            if (type.IsFixedBuffer())
            {
                return;
            }
            else if (type.IsEnum)
            {
                ProcessEnum(type, header);
            }
            else if (type.IsStruct())
            {
                ProcessStruct(type, header);
            }
            else if (type.IsPrimitive)
            {
                ProcessPrimitive(type);
            }
            else
            {
                Debug.WriteLine($"Unhandled type: {type.FullName}");
            }
        }

        private void ProcessStruct(Type type, StringBuilder header)
        {
            if (KnownTypes.Contains(type))
                return;

            if (type == typeof(void))
                return;

            var name = type.FullName;
            // Debug.WriteLine($"Processing Struct:  {name}");

            KnownTypes.Add(type);

            int structSize;
            if (type.IsGenericType)
            {
                if (type.ContainsGenericParameters)
                {
                    structSize = 0; // Generic types are ignored if they cannot be instantiated.
                    header.AppendLine($"struct {FixFullName(type)}; /* Size=unknown due to generic type with parameters */");
                    return;
                }
                else
                {
                    structSize = Marshal.SizeOf(Activator.CreateInstance(type));
                }
            }
            else
            {
                structSize = SizeOf(type);
            }

            var pad = structSize.ToString("X").Length;
            var padFill = new string(' ', pad + 2);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"struct {FixFullName(type)} /* Size=0x{structSize:X} */");
            sb.AppendLine("{");

            var offset = 0;
            var fieldGroupings = type.GetFields()
                .Where(finfo => finfo.GetCustomAttribute<IDAIgnoreAttribute>() == null) // not ignored for exporter
                .Where(finfo => !Attribute.IsDefined(finfo, typeof(ObsoleteAttribute)))
                .Where(finfo => !finfo.IsLiteral) // not constants
                .Where(finfi => !finfi.IsStatic)  // not static
                .OrderBy(finfo => finfo.GetFieldOffset())
                .GroupBy(finfo => finfo.GetFieldOffset());
            foreach (var grouping in fieldGroupings)
            {
                var fieldOffset = grouping.Key;
                var finfos = grouping.ToList();

                int unionMaxSize = 0;
                var isUnion = finfos.Count > 1;
                if (isUnion)
                {
                    sb.AppendLine("    union {");
                }

                for (int i = 0; i < finfos.Count; i++)
                {
                    var finfo = finfos[i];
                    var fieldType = finfo.FieldType;
                    int fieldSize = 0;

                    if (!isUnion)
                        offset = FillGaps(offset, fieldOffset, padFill, sb);

                    if (offset > fieldOffset)
                    {
                        Debug.WriteLine($"Current offset exceeded the next field's offset (0x{offset:X} > 0x{fieldOffset:X}): {FixFullName(type)}.{finfo.Name}");
                        return;
                    }

                    if (finfo.IsFixed())
                    {
                        var fixedType = finfo.GetFixedType();
                        var fixedSize = finfo.GetFixedSize();
                        ProcessType(fixedType, header);
                        fieldSize = SizeOf(fixedType) * fixedSize;

                        var typeDataAttr = finfo.GetCustomAttribute(typeof(FixedSizeArrayAttribute<>));
                        if (typeDataAttr != null)
                        {
                            fixedSize = (int)typeDataAttr.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public).GetValue(typeDataAttr);
                            fixedType = typeDataAttr.GetType().GetGenericArguments()[0];
                            if (fixedType.IsGenericType && fixedType.GetGenericTypeDefinition() == typeof(Pointer<>))
                            {
                                fixedType = fixedType.GetGenericArguments()[0].MakePointerType();
                            }

                            ProcessType(fixedType, header);
                            var rawSize = fieldSize;
                            fieldSize = SizeOf(fixedType) * fixedSize;
                            if (rawSize != fieldSize)
                            {
                                Debug.WriteLine($"Array size mismatch for {FixFullName(type)}.{finfo.Name}: raw is {FixTypeName(finfo.GetFixedType())}[0x{finfo.GetFixedSize():X}] (0x{rawSize:X}), typed is {FixTypeName(fixedType)}[0x{fixedSize:X}] (0x{fieldSize:X})");
                            }
                        }

                        sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fixedType)} {finfo.Name}[0x{fixedSize:X}];", offset));
                    }
                    else if (fieldType.IsPointer)
                    {
                        ProcessType(fieldType, header);
                        sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fieldType)} {finfo.Name};", offset));
                        fieldSize = 8;
                    }
                    else if (fieldType.IsEnum)
                    {
                        ProcessType(fieldType, header);

                        sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fieldType)} {finfo.Name};", offset));

                        fieldSize = SizeOf(Enum.GetUnderlyingType(fieldType));
                    }
                    else
                    {
                        ProcessType(fieldType, header);

                        sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fieldType)} {finfo.Name};", offset));

                        if (fieldType == typeof(bool))
                            fieldSize = 1;
                        else if (fieldType.IsGenericType)
                            fieldSize = Marshal.SizeOf(Activator.CreateInstance(fieldType));
                        else
                            fieldSize = SizeOf(fieldType);
                    }

                    if (!isUnion)
                        offset += fieldSize;
                    else
                        unionMaxSize = Math.Max(unionMaxSize, fieldSize);
                }

                if (isUnion)
                {
                    offset += unionMaxSize;
                    sb.AppendLine($"    }} _union_0x{fieldOffset:X};");
                }
            }

            FillGaps(offset, structSize, padFill, sb);

            sb.AppendLine("};");

            if (offset > structSize)
            {
                Debug.WriteLine($"Structure size mismatch: 0x{offset:X} > 0x{structSize:X} for {FixFullName(type)}");
            }

            header.AppendLine(sb.ToString());
        }

        private int SizeOf(Type type)
        {
            if (type.IsPointer)
                return 8; // assume 64-bit
            // Marshal.SizeOf doesn't work correctly because the assembly is unmarshaled, and more specifically, it sets bools as 4 bytes long...
            return (int?)typeof(Unsafe).GetMethod("SizeOf")?.MakeGenericMethod(type).Invoke(null, null) ?? 0;
        }

        private void ProcessEnum(Type type, StringBuilder header)
        {
            if (KnownTypes.Contains(type))
                return;

            KnownTypes.Add(type);

            // Debug.WriteLine($"Processing Enum:  {type.FullName}");

            var sb = new StringBuilder();

            if (EnvFormat == EnvFormat.IDA)
            {
                var underlyingTypeName = FixTypeName(type.GetEnumUnderlyingType());
                sb.AppendLine($"enum {type.Name}: {underlyingTypeName}");
            }
            else
            {
                var underlyingType = type.GetEnumUnderlyingType();
                var fixedTypeName = FixTypeName(type);
                sb.AppendLine($"enum {fixedTypeName} /* Size=0x{SizeOf(underlyingType):X} */");
            }

            sb.AppendLine("{");

            var values = Enum.GetValues(type);
            for (int i = 0; i < values.Length; i++)
            {
                var value = values.GetValue(i);
                var name = Enum.GetName(type, value);
                sb.Append($"    {name} = {value:D}");
                if (i < values.Length - 1)
                    sb.AppendLine(",");
                else
                    sb.AppendLine();
            }

            sb.AppendLine("};");

            header.AppendLine(sb.ToString());
        }

        private void ProcessPrimitive(Type type)
        {
            if (KnownTypes.Contains(type))
                return;

            // Debug.WriteLine($"Processing Primitive: {type.FullName}");

            KnownTypes.Add(type);
        }

        private string FixFullName(Type type)
        {
            string separator;
            if (EnvFormat == EnvFormat.IDA)
                separator = "::";
            else if (EnvFormat == EnvFormat.Ghidra)
                separator = "_";
            else
                throw new Exception($"Unknown EnvFormat: {EnvFormat}");

            string fullName;
            if (type.IsGenericType || (type.IsPointer && type.GetElementType().IsGenericType))
            {
                bool isPointer = type.IsPointer;
                var dereferenced = isPointer ? type.GetElementType() : type;
                var generic = dereferenced.GetGenericTypeDefinition();
                fullName = generic.FullName.Split('`')[0];
                if (dereferenced.IsNested)
                {
                    fullName += '+' + generic.FullName.Split('+')[1].Split('[')[0];
                }
                foreach (var argType in dereferenced.GenericTypeArguments)
                {
                    var argTypeFullName = FixFullName(argType).Replace("::", "");
                    fullName += $"{separator}{argTypeFullName}";
                }
                if (isPointer)
                    fullName += '*';
            }
            else
            {
                fullName = type.FullName;
            }

            if (fullName.StartsWith(FFXIVNamespacePrefix))
                fullName = fullName.Remove(0, FFXIVNamespacePrefix.Length);
            if (fullName.StartsWith(STDNamespacePrefix))
                fullName = fullName.Remove(0, STDNamespacePrefix.Length);
            if (fullName.StartsWith(InteropNamespacePrefix))
                fullName = fullName.Remove(0, InteropNamespacePrefix.Length);

            if (fullName.Contains("FFXIVClientStructs, Version"))
            {
                if (fullName.EndsWith("*"))
                {
                    fullName = "void*";
                }
                else
                {
                    throw new Exception($"Failed to fix name: {fullName}");
                }
            }

            // This is a hack because Ghidra doesn't support specifying the enum size
            // By appending 0x<size> on the enum name, it makes it easier to manually go
            // in and fix the sizes up after the fact.
            if (EnvFormat == EnvFormat.Ghidra && type.IsEnum)
            {
                var underlyingType = type.GetEnumUnderlyingType();
                fullName += $"0x{SizeOf(underlyingType):X}";
            }

            return fullName.Replace(".", separator).Replace("+", separator);
        }

        private string FixTypeName(Type type)
        {
            if (type == typeof(void) || type == typeof(void*) || type == typeof(void**) ||
                type == typeof(char) || type == typeof(char*) || type == typeof(char**) ||
                type == typeof(byte) || type == typeof(byte*) || type == typeof(byte**))
                return type.Name.ToLower();
            else if (type == typeof(bool)) return "bool";
            else if (type == typeof(float)) return "float";
            else if (type == typeof(double)) return "double";
            else if (type == typeof(short)) return "__int16";
            else if (type == typeof(int)) return "__int32";
            else if (type == typeof(long)) return "__int64";
            else if (type == typeof(ushort)) return "unsigned __int16";
            else if (type == typeof(uint)) return "unsigned __int32";
            else if (type == typeof(ulong)) return "unsigned __int64";
            else if (type == typeof(sbyte)) return "signed __int8";
            else if (type == typeof(System.IntPtr)) return "__int64";
            else if (type == typeof(short*)) return "__int16*";
            else if (type == typeof(ushort*)) return "unsigned __int16*";
            else if (type == typeof(int*)) return "__int32*";
            else if (type == typeof(uint*)) return "unsigned __int32*";
            else if (type == typeof(System.Single*)) return "float*";
            else return FixFullName(type);
        }

        private int FillGaps(int offset, int maxOffset, string padFill, StringBuilder sb)
        {
            int gap;
            while ((gap = maxOffset - offset) > 0)
            {
                if (GapStrategy == GapStrategy.FullSize)
                {
                    if (offset % 8 == 0 && gap >= 8)
                    {
                        sb.AppendLine($"    /* {padFill} */ __int64 _gap_0x{offset:X};");
                        offset += 8;
                    }
                    else if (offset % 4 == 0 && gap >= 4)
                    {
                        sb.AppendLine($"    /* {padFill} */ __int32 _gap_0x{offset:X};");
                        offset += 4;
                    }
                    else if (offset % 2 == 0 && gap >= 2)
                    {
                        sb.AppendLine($"    /* {padFill} */ __int16 _gap_0x{offset:X};");
                        offset += 2;
                    }
                    else
                    {
                        sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X};");
                        offset += 1;
                    }
                }
                else if (GapStrategy == GapStrategy.ByteArray)
                {
                    if (offset % 8 == 0 && gap >= 8)
                    {
                        var gapDiv = gap - (gap % 8);
                        sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X}[0x{gapDiv:X}];");
                        offset += gapDiv;
                    }
                    else if (offset % 4 == 0 && gap >= 4)
                    {
                        sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X}[0x4];");
                        offset += 4;
                    }
                    else if (offset % 2 == 0 && gap >= 2)
                    {
                        sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X}[0x2];");
                        offset += 2;
                    }
                    else
                    {
                        sb.AppendLine($"    /* {padFill} */ byte _gap_0x{offset:X};");
                        offset += 1;
                    }
                }
                else
                {
                    throw new Exception($"Unknown GapStrategy {GapStrategy}");
                }
            }
            return offset;
        }
    }

    public static class TypeExtensions
    {
        public static bool IsFixedBuffer(this Type type)
        {
            return type.Name.EndsWith("e__FixedBuffer");
        }

        public static bool IsStruct(this Type type)
        {
            return type.IsValueType && !type.IsPrimitive && !type.IsEnum && type != typeof(decimal);
        }
    }

    public static class FieldInfoExtensions
    {
        public static bool IsFixed(this FieldInfo finfo)
        {
            var attr = finfo.GetCustomAttributes(typeof(FixedBufferAttribute), false).Cast<FixedBufferAttribute>().FirstOrDefault();
            return attr != null;
        }

        public static Type GetFixedType(this FieldInfo finfo)
        {
            return finfo.GetCustomAttributes(typeof(FixedBufferAttribute), false).Cast<FixedBufferAttribute>().Single().ElementType;
        }

        public static int GetFixedSize(this FieldInfo finfo)
        {
            return finfo.GetCustomAttributes(typeof(FixedBufferAttribute), false).Cast<FixedBufferAttribute>().Single().Length;
        }

        public static int GetFieldOffset(this FieldInfo finfo)
        {
            var attrs = finfo.GetCustomAttributes(typeof(FieldOffsetAttribute), false);
            if (attrs.Length != 0)
                return attrs.Cast<FieldOffsetAttribute>().Single().Value;

            // Lets assume this is because it's a LayoutKind.Sequential struct
            return Marshal.OffsetOf(finfo.DeclaringType, finfo.Name).ToInt32();
        }
    }
}
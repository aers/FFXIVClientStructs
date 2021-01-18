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
        public static void Main(string[] args)
        {
            var data = Exporter.Instance.Export();
            File.WriteAllText("../../../../ffxiv_client_structs.h", data);
        }
    }

    public class Exporter
    {
        #region singleton

        private static Exporter _exporter;
        public static Exporter Instance => _exporter ??= new Exporter();

        #endregion

        private HashSet<Type> KnownTypes = new HashSet<Type>();

        private HashSet<Type> DoNotProcessAsStruct = new HashSet<Type>() {
            typeof(void)
        };

        public string Export()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var assembly = Assembly.GetExecutingAssembly();

            var header = new StringBuilder();

            var clientStructs = AppDomain.CurrentDomain.Load(nameof(FFXIVClientStructs.FFXIV));
            // Make forward references for everything, cycles are bad, detecting them is harder.
            header.AppendLine("// Forward References");
            foreach (var type in clientStructs.DefinedTypes)
            {
                if (type.IsStruct() && !type.Name.EndsWith("e__FixedBuffer"))
                    header.AppendLine($"struct {FixFullName(type)};");
            }

            header.AppendLine();
            header.AppendLine("// Definitions");
            foreach (var type in clientStructs.DefinedTypes)
            {
                ProcessType(type, header);
            }

            return header.ToString();
        }

        private void ProcessType(Type type, StringBuilder header)
        {
            if (KnownTypes.Contains(type))
                return;

            if (type.Name.EndsWith("e__FixedBuffer"))
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
                ProcessPrimitive(type, header);
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

            if (DoNotProcessAsStruct.Contains(type))
                return;

            Debug.WriteLine($"Processing Struct:  {type.FullName}");

            KnownTypes.Add(type);

            var structSize = Marshal.SizeOf(type);
            var pad = structSize.ToString("X").Length;
            var padFill = new string(' ', pad + 2);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"struct {FixFullName(type)} /* Size=0x{structSize:X} */");
            sb.AppendLine("{");

            var offset = 0;
            foreach (var grouping in type.GetFields().OrderBy(finfo => finfo.GetFieldOffset()).GroupBy(finfo => finfo.GetFieldOffset()))
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
                        Debug.WriteLine($"Current offset exceeded the next field's offset (0x{offset:X} > 0x{fieldOffset:X}): {FixFullName(type)}.{FixTypeName(fieldType)}");
                        return;
                    }

                    if (finfo.IsFixed())
                    {
                        var fixedType = finfo.GetFixedType();
                        var fixedSize = finfo.GetFixedSize();
                        ProcessType(fixedType, header);

                        sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fixedType)} {finfo.Name}[0x{fixedSize:X}];", offset));

                        fieldSize = Marshal.SizeOf(fixedType) * fixedSize;
                    }
                    else if (fieldType.IsPointer)
                    {
                        var elemType = fieldType.GetElementType();
                        while (elemType.IsPointer)
                            elemType = elemType.GetElementType();
                        ProcessType(elemType, header);

                        sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fieldType)} {finfo.Name};", offset));

                        fieldSize = 8;

                    }
                    else if (fieldType.IsEnum)
                    {
                        ProcessType(fieldType, header);

                        sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fieldType)} {finfo.Name};", offset));

                        fieldSize = Marshal.SizeOf(Enum.GetUnderlyingType(fieldType));
                    }
                    else
                    {
                        ProcessType(fieldType, header);

                        sb.AppendLine(string.Format($"    /* 0x{{0:X{pad}}} */ {FixTypeName(fieldType)} {finfo.Name};", offset));

                        if (fieldType == typeof(bool))
                            fieldSize = 1;
                        else
                            fieldSize = Marshal.SizeOf(fieldType);
                    }

                    if (!isUnion)
                        offset += fieldSize;
                    else
                        unionMaxSize = Math.Max(unionMaxSize, 8);
                }

                if (isUnion)
                {
                    offset += unionMaxSize;
                    sb.AppendLine($"    }} _union_0x{fieldOffset:X};");
                }
            }

            FillGaps(offset, structSize, padFill, sb);

            sb.AppendLine("};");

            header.AppendLine(sb.ToString());
        }

        private void ProcessEnum(Type type, StringBuilder header)
        {
            if (KnownTypes.Contains(type))
                return;

            KnownTypes.Add(type);

            Debug.WriteLine($"Processing Enum:  {type.FullName}");

            var sb = new StringBuilder();

            var underlyingTypeName = FixTypeName(type.GetEnumUnderlyingType());

            sb.AppendLine($"enum {type.Name}: {underlyingTypeName}");
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

        private void ProcessPrimitive(Type type, StringBuilder header)
        {
            if (KnownTypes.Contains(type))
                return;

            Debug.WriteLine($"Processing Primitive: {type.FullName}");

            KnownTypes.Add(type);
        }

        private string FixFullName(Type type)
        {
            return type.FullName.Remove(0, nameof(FFXIVClientStructs.FFXIV).Length + 1).Replace(".", "::").Replace("+", "::");
        }

        private string FixTypeName(Type type)
        {
            if (type == typeof(void) || type == typeof(void*) || type == typeof(void**) ||
                type == typeof(char) || type == typeof(char*) || type == typeof(char**) ||
                type == typeof(byte) || type == typeof(byte*))
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
            else return FixFullName(type);
        }

        private int FillGaps(int offset, int maxOffset, string padFill, StringBuilder sb)
        {
            int gap;

            while ((gap = maxOffset - offset) > 0)
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
            return offset;
        }
    }

    public static class TypeExtensions
    {
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
            return finfo.GetCustomAttributes(typeof(FieldOffsetAttribute), false).Cast<FieldOffsetAttribute>().Single().Value;
        }
    }
}

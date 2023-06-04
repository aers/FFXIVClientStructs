using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using FFXIVClientStructs.Interop.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FFXIVClientStructs.MetadataGenerator;

public class ClientStructsSyntaxWalker : CSharpSyntaxWalker {
    public List<MetadataStruct> Structs = new();
    public List<MetadataEnum> Enums = new();
    public List<MetadataUnion> Unions = new();
    public List<MetadataFunction> Functions = new();
    public List<MetadataStaticAddressInfo> Globals = new();

    private SyntaxNode? root;
    protected SemanticModel model;
    protected Assembly cs;

    public ClientStructsSyntaxWalker(SemanticModel model, Assembly cs) {
        this.model = model;
        this.cs = cs;
    }

    public override void Visit(SyntaxNode? node) {
        this.root ??= node;
        base.Visit(node);
    }

    public override void VisitStructDeclaration(StructDeclarationSyntax node) {
        if (node == this.root) {
            base.VisitStructDeclaration(node);
            return;
        }

        var walker = new StructWalker(this.model, this.cs);
        var @struct = walker.Visit(node);
        this.Structs.Add(@struct);

        this.Structs.AddRange(walker.Structs);
        this.Enums.AddRange(walker.Enums);
        this.Unions.AddRange(walker.Unions);
        this.Functions.AddRange(walker.Functions);
        this.Globals.AddRange(walker.Globals);
    }

    public override void VisitEnumDeclaration(EnumDeclarationSyntax node) {
        if (node == this.root) {
            base.VisitEnumDeclaration(node);
            return;
        }

        var walker = new EnumWalker(this.model, this.cs);
        var @enum = walker.Visit(node);
        this.Enums.Add(@enum);

        this.Structs.AddRange(walker.Structs);
        this.Enums.AddRange(walker.Enums);
        this.Unions.AddRange(walker.Unions);
        this.Functions.AddRange(walker.Functions);
        this.Globals.AddRange(walker.Globals);
    }

    // Stolen from CExporter
    protected uint? GetSize(Type type) {
        if (type.IsPointer) return 8;
        if (type == typeof(void)) return 8; // it's probably a pointer. this is a bad assumption lmfao

        // Why the hell is it 2
        if (type == typeof(bool)
            || type == typeof(char)
            || type == typeof(byte)
            || type == typeof(sbyte)) return 1;

        var size = (int?)typeof(Unsafe).GetMethod("SizeOf")?.MakeGenericMethod(type).Invoke(null, null) ?? 0;

        return (uint)size;
    }

    protected uint? GetSizeFromField(MetadataField field) {
        if (field.PointerIndirection > 0) return 8;
        if (field.Type == null) return null;
        var size = this.GetSize(field.Type);
        return size * field.ArraySize;
    }

    protected Type GetTypeFromSymbol(ISymbol s) {
        var sb = new StringBuilder(s.MetadataName);
        var last = s;

        s = s.ContainingSymbol;

        while (!this.IsRootNamespace(s)) {
            if (s is ITypeSymbol && last is ITypeSymbol) {
                sb.Insert(0, '+');
            } else {
                sb.Insert(0, '.');
            }

            sb.Insert(0, s.MetadataName);
            s = s.ContainingSymbol;
        }

        var str = sb.ToString();
        var type = this.cs.GetType(str);
        if (type == null) throw new Exception($"Could not find type {str}");
        return type;
    }

    private bool IsRootNamespace(ISymbol symbol) => symbol as INamespaceSymbol is { IsGlobalNamespace: true };
}

public class StructWalker : ClientStructsSyntaxWalker {
    private List<MetadataField> fields = new();
    private Dictionary<uint, MetadataUnion> unions = new();
    private uint? size;
    private uint lastOffset;
    private string name;
    private Type structType;

    public StructWalker(SemanticModel model, Assembly cs) : base(model, cs) { }

    public new MetadataStruct Visit(SyntaxNode? node) {
        if (node is not StructDeclarationSyntax structNode) {
            throw new Exception("Expected a struct declaration");
        }

        var typeSymbol = this.model.GetDeclaredSymbol(structNode)!;
        var @struct = this.GetTypeFromSymbol(typeSymbol);
        this.structType = @struct;
        this.name = NameHelpers.FixTypeName(@struct);

        var structLayout = @struct.StructLayoutAttribute;
        if (structLayout != null) {
            this.size = (uint)structLayout.Size;
        }

        MetadataStaticAddressInfo? vtable = null;
        var vtableAttr = @struct.GetCustomAttribute<VTableAddressAttribute>();
        if (vtableAttr != null) {
            vtable = new MetadataStaticAddressInfo {
                Signature = vtableAttr.Signature,
                Offset = vtableAttr.Offset,
                IsPointer = vtableAttr.IsPointer
            };
        }

        base.Visit(node);
        this.Unions.AddRange(this.unions.Values);

        return new MetadataStruct {
            Name = this.name,
            Fields = this.fields,
            Size = this.size,
            VTableAddress = vtable
        };
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node) {
        var fieldName = node.Declaration.Variables[0].Identifier.Text;

        int offset;
        var ptrIndirection = 0;
        var arraySize = 1;

        var reflectedField = this.structType.GetField(fieldName,
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance);
        if (reflectedField == null) throw new Exception($"Could not find field {fieldName} in type {this.structType}");

        // Ignore:
        // - Static fields (Common::Math::Vector3)
        // - Const fields (Common::Math::Quaternion)
        // - Obsolete attributes (Client::UI::Info::InfoProxyCommonList)
        // - Delegates (Common::Lua::LuaState)
        // - Type parameters (StdVector)

        if (node.Modifiers.Any(SyntaxKind.StaticKeyword) || node.Modifiers.Any(SyntaxKind.ConstKeyword)) return;
        var obsoleteAttribute = reflectedField.GetCustomAttribute<ObsoleteAttribute>();
        if (obsoleteAttribute != null) return;

        var type = reflectedField.FieldType;
        if (reflectedField.FieldType.IsPointer) {
            ptrIndirection = 1;
            var ptrType = reflectedField.FieldType.GetElementType();
            while (true) {
                if (ptrType!.IsPointer) {
                    ptrIndirection++;
                    ptrType = ptrType.GetElementType();
                } else {
                    type = ptrType;
                    break;
                }
            }
        }

        if (type.ContainsGenericParameters || type.IsGenericParameter) return;
        if (type.BaseType == typeof(MulticastDelegate)) return;

        var fieldOffsetAttribute = reflectedField.GetCustomAttribute<FieldOffsetAttribute>();
        if (fieldOffsetAttribute != null) {
            offset = fieldOffsetAttribute.Value;
        } else {
            // Some types (like Client::UI::Misc::RaptureMacroModule::Macro) don't have field offsets
            // Fall back to the last offset we had
            offset = (int)this.lastOffset;
        }

        var fixedBufferAttribute = reflectedField.GetCustomAttribute<FixedBufferAttribute>();
        if (fixedBufferAttribute != null) {
            arraySize = fixedBufferAttribute.Length;
            type = fixedBufferAttribute.ElementType;
        }

        // Copy of GetSizeFromFieldWithUnion's logic because we don't have a constructed field yet
        if (fieldName == "userPath") {
            Console.WriteLine("a");
        }

        var fieldSize = this.GetSize(type);
        if (ptrIndirection > 0) fieldSize = 8;
        if (fieldSize == null) {
            var union = this.unions.GetValueOrDefault((uint)offset);
            if (union == null) throw new Exception($"Could not find union at offset {(uint)offset}");
            var unionFirstField = union.Fields[0];
            fieldSize = this.GetSize(unionFirstField.Type!)!.Value;
        }

        var field = new MetadataField {
            Name = fieldName,
            Type = type,
            Size = fieldSize.Value,
            Offset = (uint)offset,
            PointerIndirection = (uint)ptrIndirection,
            ArraySize = (uint)arraySize
        };

        var existingField = this.fields.FirstOrDefault(x => x.Offset == offset);
        var isUnion = existingField != null;

        this.lastOffset = (uint)(offset + fieldSize);
        var properSize = fieldSize * arraySize;

        foreach (var iterField in this.fields) {
            var pos = iterField.Offset;
            var size = this.GetSizeFromFieldWithUnion(iterField);
            var end = pos + size;

            if (pos <= offset && end > offset + properSize) {
                return;
            }
        }

        // Only union if they're the same size
        if (isUnion && this.GetSizeFromFieldWithUnion(existingField!) != properSize) {
            return;
        }

        if (isUnion) {
            var union = this.unions.GetValueOrDefault((uint)offset);
            if (union == null) {
                var unionName = "union_" + offset.ToString("X");
                var unionType = this.name + "_" + unionName;

                union = new MetadataUnion {
                    Name = unionType,
                    Fields = new List<MetadataField>()
                };

                // Recreate the field to set offset=0
                union.Fields.Add(new MetadataField {
                    Name = existingField!.Name,
                    Type = existingField.Type,
                    Size = existingField.Size,
                    Offset = 0,
                    PointerIndirection = existingField.PointerIndirection,
                    ArraySize = existingField.ArraySize
                });

                // Inject the union field in place
                this.fields.Remove(existingField);
                this.fields.Add(new MetadataField {
                    Name = unionName,
                    UnionType = unionType,
                    Size = existingField.Size,
                    Offset = existingField.Offset,
                    // Union isn't a pointer/array, but the contents of it may be
                    PointerIndirection = 0,
                    ArraySize = 1
                });
            }

            // Recreate, same as above
            union.Fields.Add(new MetadataField {
                Name = fieldName,
                Type = type,
                Size = fieldSize.Value,
                Offset = 0,
                PointerIndirection = (uint)ptrIndirection,
                ArraySize = (uint)arraySize
            });

            this.unions[(uint)offset] = union;
            return;
        }

        this.fields.Add(field);
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node) {
        var methodName = node.Identifier.Text;
        var reflectedMethods = this.structType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic |
                                                          BindingFlags.Static | BindingFlags.Instance);
        // [GenerateCStrOverloads] hack
        var reflectedMethod = reflectedMethods.FirstOrDefault(x =>
            x.Name == methodName
            && x.GetParameters().Length == node.ParameterList.Parameters.Count
            && x.GetParameters().All(y => y.ParameterType != typeof(string))
        );

        // Don't throw errors, because things like Client::System::String::Utf8String::FromString exist
        if (reflectedMethod == null) return;

        var staticAddrAttr = reflectedMethod.GetCustomAttribute<StaticAddressAttribute>();
        if (staticAddrAttr != null) {
            // Sike, we're actually an instance
            var staticAddr = new MetadataStaticAddressInfo {
                Signature = staticAddrAttr.Signature,
                Offset = staticAddrAttr.Offset,
                IsPointer = staticAddrAttr.IsPointer,
                Name = NameHelpers.FixTypeName(this.structType) + "_Instance",
                Type = staticAddrAttr.IsPointer
                    ? this.structType.MakePointerType()
                    : this.structType
            };
            this.Globals.Add(staticAddr);
            return;
        }

        var args = reflectedMethod
            .GetParameters()
            .Select(x => (x.ParameterType, x.Name!))
            .ToList();

        MetadataAddressInfo? addressInfo = null;
        var memberFunctionAttr = reflectedMethod.GetCustomAttribute<MemberFunctionAttribute>();
        if (memberFunctionAttr != null) {
            addressInfo = new MetadataMemberFunctionInfo {
                Signature = memberFunctionAttr.Signature
            };

            args.Insert(0, (this.structType.MakePointerType(), "this"));
        }

        var vfuncAttr = reflectedMethod.GetCustomAttribute<VirtualFunctionAttribute>();
        if (vfuncAttr != null) {
            addressInfo = new MetadataVirtualFunctionInfo {
                VTable = this.name,
                Index = vfuncAttr.Index
            };

            args.Insert(0, (this.structType.MakePointerType(), "this"));
        }

        if (addressInfo == null) return;

        var func = new MetadataFunction {
            Name = this.name + "::" + methodName,
            AddressInfo = addressInfo,
            Arguments = args,
            ReturnType = reflectedMethod.ReturnType
        };

        this.Functions.Add(func);
    }

    private uint GetSizeFromFieldWithUnion(MetadataField field) {
        var attempt = this.GetSizeFromField(field);
        if (attempt != null) return attempt.Value;

        var union = this.unions.GetValueOrDefault(field.Offset);
        if (union == null) throw new Exception($"Could not find union at offset {field.Offset}");
        var unionFirstField = union.Fields[0];
        return this.GetSize(unionFirstField.Type!)!.Value * unionFirstField.ArraySize;
    }
}

public class EnumWalker : ClientStructsSyntaxWalker {
    private string type;
    private Dictionary<string, long> values = new();
    private long nextValue = 0;
    private Type enumType;

    public EnumWalker(SemanticModel model, Assembly cs) : base(model, cs) { }

    public new MetadataEnum Visit(SyntaxNode? node) {
        if (node is not EnumDeclarationSyntax enumNode) {
            throw new Exception("Expected an enum declaration");
        }

        var typeSymbol = this.model.GetDeclaredSymbol(node)!;
        var @enum = this.GetTypeFromSymbol(typeSymbol);
        this.enumType = @enum;

        base.Visit(node);

        // Type of the enum is the underlying type of the first field
        var firstField = @enum.GetFields()[0];
        var underlyingType = firstField.FieldType;

        return new MetadataEnum {
            Name = NameHelpers.FixTypeName(@enum),
            Type = underlyingType,
            Values = this.values
        };
    }

    public override void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node) {
        var name = node.Identifier.Text;
        var reflectedField = this.enumType.GetField(name);
        if (reflectedField == null) throw new Exception($"Could not find field {name} in type {this.enumType}");
        var value = reflectedField.GetRawConstantValue();
        this.values.Add(name, Convert.ToInt64(value));
    }
}

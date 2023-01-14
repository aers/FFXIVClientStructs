FFXIVClientStructs
==================

This library encapsulates community efforts to reverse engineer the object layout of native classes in the game Final Fantasy XIV and provide tools to assist in interop with native objects and functions in the running game. The library is written in C# as the main third party plug-in loader, [Dalamud](https://github.com/goatcorp/Dalamud), is also written in C#.

Interacting with native game code is fundamentally unsafe and the library makes no attempt to prevent the user from shooting themselves in the foot. There is no type marshalling and all types are represented as explicit layout unmanaged structs that map 1:1 in memory with the game's objects. Since the game is written in C++, pointers are everywhere and you will likely need unsafe blocks when doing much of anything.

We make extensive use of [C# Source Generators](https://learn.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/source-generators-overview) to reduce the boilerplate necessary to call native functions. Rather than marshalled delegates, all functions are represented by [function pointers](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/function-pointers) resolved by the library from signatures and wrapped in a null safety check. From the user standpoint, calling these functions is as simple as calling a native C# method.

### Reverse Engineering Rename Database

A database and script(s) are maintained in the [ida](https://github.com/aers/FFXIVClientStructs/tree/main/ida) folder which can be used to import a large number of location names to IDA or Ghidra. This database is updated with every patch, although keep in mind this is volunteer work and some patches require more effort than others. There is more info in the readme in the folder itself.

### Credits

This project would not be possible without significant work from many members of the FFXIV RE/Dalamud communities.

#### Project Maintainers
* [aers](https://github.com/aers)
* [pohky](https://github.com/Pohky)
* [Caraxi](https://github.com/Caraxi)
* [daemitus](https://github.com/daemitus)

#### Contributors

[Too many](https://github.com/aers/FFXIVClientStructs/graphs/contributors) to list.

## For Library Users

### Signature Resolution

The library uses signatures to resolve locations at runtime. In order to populate locations from signatures to call functions, you need to initialize the library once at load. However, if you're writing a Dalamud plugin using the built-in copy of the library, you can just reference it in the project and Dalamud will have already initialized it for you. 

The following code is only necessary if you are not using Dalamud or using a local copy of the library in your plugin.

```csharp
FFXIVClientStructs.Interop.Resolver.GetInstance.SetupSearchSpace();
FFXIVClientStructs.Interop.Resolver.GetInstance.Resolve();
```

SetupSearchSpace has two optional arguments. The first allows you to pass a pointer to a copy of the FFXIV module somewhere in memory. The primary use of this is to allow the resolver to scan a fresh copy of the binary rather than one modified by active hooks from other sources. You can access Dalamud's module copy via the `SigScanner` service's `SearchBase` argument if you are trying to resolve your local copy within a Dalamud plugin. The second argument takes a path to a json file as a C# `FileInfo` object. This will cause the resolver to use that json file as a signature cache, speeding up resolving on future runs. The resolver is relatively fast, but using the cache is near-instant, so using it is your choice.

### Library Design

Native classes are represented as fixed-offset structs. If you have a pointer or reference to one of these structs, you can access native memory the same way you'd access a field on any C# class or struct. Native function calls are wrapped in methods on these structs and can be called the same way you would call a C# method. Source generation creates wrappers that automatically pass the struct's pointer to C++ member and virtual functions making them mostly-seamless.

Many native singletons can be accessed via static instance methods, which should get you started accessing native objects.

#### Caveats

C# is not C++. There are some constructs that aren't possible to represent properly as well and some rough edges around the interop process.

##### String types

The game has a string class, `Utf8String`, which is roughly analogous to `std::string` and is used in most places where strings are stored. However, it also uses C-style strings, aka pointers to null terminated character (UTF-8-encoded) arrays. C# strings are UTF-16 and pointers to them cannot be passed directly to functions requiring these C string pointers. Also, the C# `char` type is 16-bit and cannot be used to represent the arguments. All functions that take C string arguments therefore have `byte*` as the argument type. 

The library generates overloads for these methods that take `string` and perform the UTF-16 -> UTF-8 byte array conversion for you. Be aware this conversion is happening and consider storing your own copies of UTF-8 converted strings if you are noticing a performance hit from the string conversions. This is unlikely, but could happen.

There are also generated overloads that take `ReadOnlySpan<byte>` arguments. This is primarily to allow the use of [UTF-8 string literals](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-11.0/utf8-string-literals?source=recommendations) as function arguments.

No functions will ever return a C# `string` type in order to avoid making assumptions about the memory lifetime of pointers returned by the game.

##### Fixed-Size Arrays

C# does not support fixed-sized buffers of arbitrary types. While this feature is being worked on for a future version of the language (see the fixed buffer section of [this](https://github.com/dotnet/csharplang/blob/main/proposals/csharp-11.0/low-level-struct-improvements.md)), there is no ETA. All fixed-sized buffers of native types are represented as a buffer of `byte` instead. A future version of the library will support generation of convenience accessors for these, but that is currently not implemented. You will need to cast the type to access the array properly.

##### Generic Pointers

C# doesn't allow pointer types in generics. This makes it impossible to represent constructs like `std::vector<T*>`. The library uses a wrapper type `Pointer<T>` to get around this. `Pointer<T>` will implicitly convert to `T*` but you might need to do explicit conversions when working with collections of pointers.

##### STD collections

There are wrappers for accessing data from a handful of C++ std library collections used by the game such as vector and map. These do not support writing to those collections, and you will have to implement that yourself if you want to update them.

## For Library Developers

FFXIV is built with the MSVC 64-bit compiler and any mention of the way the compiler works applies to that compiler.

### Signatures

All signatures in the library must use `??` for wildcard bytes and include 2 characters per byte.

### Native Game Classes

```csharp
namespace FFXIVClientStructs.FFXIV.Component.GUI;
[StructLayout(LayoutKind.Explicit, Size = 0xA8)]
public unsafe partial struct AtkResNode : ICreatable { }
```

Native game classes are represented as explicit layout structs. If the official name of the class is available (via [old rtti](https://github.com/aers/FFXIVClientStructs/blob/main/ida/classinformer.csv)) use that for the name and namespace. For new classes or classes without virtual functions, make up a name that seems appropriate.

If the struct has unsafe members, mark the struct unsafe rather than the individual members. If you are using a generator, the struct must also be partial. If you are unable to get the exact size, use your best estimate.

##### ICreatable

If you give the struct a CTor function and the interface ICreatable it will be creatable using game allocators via convenience methods on IMemorySpace. This is only relevant for objects that you might want to create, which at this point in time is entirely UI objects.

#### Class Fields

```csharp
    [FieldOffset(0x20)] public AtkResNode* ParentNode;
    [FieldOffset(0x28)] public AtkResNode* PrevSiblingNode;
    [FieldOffset(0x30)] public AtkResNode* NextSiblingNode;
    [FieldOffset(0x38)] public AtkResNode* ChildNode;
 ```

Because struct layouts are explicit, all fields are required to have a FieldOffset defined.

Field types can (generally) only be types that the runtime considers [unmanaged](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/unmanaged-types). This boils down to most primitive integer/float types, enums, pointers, fixed-size primitive arrays, and structs that only contain fields meeting the definition. 

##### Arrays

Native fixed size arrays such as

```c++
AtkResNode resNodeArray[10];
```

cannot be represented in C# because the runtime does not currently allow fixed sized arrays of arbitrary types in structs, only integer primitives. Until this feature arrives, define all arrays that aren't integer primitives as byte arrays of `sizeof(T) * length`.

```cs
public fixed byte resNodeArray[4 * 0xA8]; // AtkResNode array
```

There are plans to implement a source generator to make interop with these arrays better, but that hasn't been developed yet.

### Native Game Functions

Native game functions are represented by methods with the correct signature and annotated with an attribute that causes generation of the appropriate wrapper to call the native function.

It is important to note that this assembly has the `DisableRuntimeMarshalling` [attribute](https://learn.microsoft.com/en-us/dotnet/standard/native-interop/disabled-marshalling) enabled, so only types that can be sent to native functions without marshalling are allowed (no `string` - use `byte*` and the CStr generator).

All native functions are called via C# function pointers and incur the minimum possible managed<->unmanaged penalty.

#### [MemberFunction]

```csharp
public MemberFunctionAttribute(string signature)
```
```csharp
[MemberFunction("E8 ?? ?? ?? ?? C1 E7 0C")]
public partial void AddEvent(ushort eventType, uint eventParam, AtkEventListener* listener,
        AtkResNode* nodeParam, bool isSystemEvent);
```

Used for functions that are non-virtual members of native classes. This includes static functions.

This will generate the following wrapper:

```csharp
public partial void AddEvent(ushort eventType, uint eventParam, global::FFXIVClientStructs.FFXIV.Component.GUI.AtkEventListener* listener, global::FFXIVClientStructs.FFXIV.Component.GUI.AtkResNode* nodeParam, bool isSystemEvent)
{
    if (MemberFunctionPointers.AddEvent is null)
        throw new InvalidOperationException("Function pointer for AtkResNode.AddEvent is null. The resolver was either uninitialized or failed to resolve address with signature E8 ?? ?? ?? ?? C1 E7 0C ?? ?? ?? ?? ?? ?? ?? ??.");

     fixed(AtkResNode* thisPtr = &this)
    {
        MemberFunctionPointers.AddEvent(thisPtr, eventType, eventParam, listener, nodeParam, isSystemEvent);
    }
}
```

Note that the wrapper takes care of passing the object instance pointer (known as the `this` pointer) to the function for you. This allows you to call native functions on library struct types as if they were regular C# methods. Static functions do not pass an object instance and the generator will not do this if the method is marked static.

#### [VirtualFunction]

```csharp
public VirtualFunctionAttribute(uint index)
```
```csharp
[VirtualFunction(78)]
public partial StatusManager* GetStatusManager();
```

Used for functions that are virtual members of native classes. 

This will generate the following wrapper:

```csharp
[StructLayout(LayoutKind.Explicit)]
public unsafe struct CharacterVTable
{
    [FieldOffset(624)] public delegate* unmanaged[Stdcall] <Character*, global::FFXIVClientStructs.FFXIV.Client.Game.StatusManager*> GetStatusManager;
}

[FieldOffset(0x0)] public CharacterVTable* VTable;
  
public partial global::FFXIVClientStructs.FFXIV.Client.Game.StatusManager* GetStatusManager()
{
    fixed(Character* thisPtr = &this)
    {
        return VTable->GetStatusManager(thisPtr);
    }
}
```

Virtual functions are referenced via the index in the class's virtual table. These cannot be static and always include the object instance pointer. Since these calls resolve the function pointer via the instance object's virtual table they will work the same way they do in native code and call the appropriate virtual overload for the class.

#### [StaticAddress]

```csharp
public StaticAddressAttribute(string signature, int offset, bool isPointer = false)
```

```csharp
[StaticAddress("44 0F B6 C0 48 8B 0D ?? ?? ?? ??", 7, isPointer: true)]
public static partial Framework* Instance();
```

Used for returning the location of static objects in the binary. This is mostly used for returning the location of singletons that are accessed directly rather than via a function call. All of these methods should return a pointer.

This will generate the following wrapper:

```csharp
public unsafe static class StaticAddressPointers
{
    public static global::FFXIVClientStructs.FFXIV.Client.System.Framework.Framework** ppInstance => (global::FFXIVClientStructs.FFXIV.Client.System.Framework.Framework**)Framework.Addresses.Instance.Value;
}

public static partial global::FFXIVClientStructs.FFXIV.Client.System.Framework.Framework* Instance()
{
    if (StaticAddressPointers.ppInstance is null)
        throw new InvalidOperationException("Pointer for Framework.Instance is null. The resolver was either uninitialized or failed to resolve address with signature 44 0F B6 C0 48 8B 0D ?? ?? ?? ?? ?? ?? ?? ?? ??.");
    return *StaticAddressPointers.ppInstance;
}
```

Note that in this case the static address is a pointer, so the attribute argument isPointer is true and our pointer turns into a pointer to a pointer which is handled by the wrapper. Some static locations in the client are static instances which are allocated within the binary (`static GameMain GameMainInstance`) and some are static pointers to instances which are allocated on the heap at runtime (`static Framework* FrameworkInstance`). 

##### Static Address Signatures

Since the instructions resolved from static address signatures are variable length, an offset argument is required to tell the resolver where to read the static address location from in the signature. This offset is usually to the first (0-indexed) ?? in your signature, but could be further away in some situations.

#### [GenerateCStrOverloads]

```csharp
public GenerateCStrOverloadsAttribute(string? ignoreArgument = null)
```

```csharp
[MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 41 B0 01")]
[GenerateCStrOverloads]
public partial AtkUnitBase* GetAddonByName(byte* name, int index = 1);
```

Used to generate some useful overload methods for native functions that take C string arguments. C strings are null-terminated char (8-bit) arrays. Since the assembly has marshalling disabled, you cannot use `string` as an argument to function pointers, so all C string arguments must be declared as `byte*`, as mentioned earlier. This has two problems - it makes working with the methods annoying, and hides the fact that the argument is a character array. C# `char` type is 16-bit to match C#'s native UTF16 strings, so it can't be used instead.

This generator will generate the following overloads:

```csharp
public global::FFXIVClientStructs.FFXIV.Component.GUI.AtkUnitBase* GetAddonByName(string name, int index = 1)
{
    int utf8StringLengthname = global::System.Text.Encoding.UTF8.GetByteCount(name);
    Span<byte> nameBytes = utf8StringLengthname <= 512 ? stackalloc byte[utf8StringLengthname + 1] : new byte[utf8StringLengthname + 1];
    global::System.Text.Encoding.UTF8.GetBytes(name, nameBytes);
    nameBytes[utf8StringLengthname] = 0;

    fixed (byte* namePtr = nameBytes)
    {
        return GetAddonByName(namePtr, index);
    }
}

public global::FFXIVClientStructs.FFXIV.Component.GUI.AtkUnitBase* GetAddonByName(ReadOnlySpan<byte> name, int index = 1)
{
    fixed (byte* namePtr = name)
    {
        return GetAddonByName(namePtr, index);
    }
}
```

The `string` argument wrapper will take care of converting the string to bytes for you. Obviously, this adds overhead, but the runtime's marshalling would be doing the same thing anyway. The `ReadOnlySpan<byte>` overload mainly exists to allow passing of [UTF-8 string literals](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-11.0/utf8-string-literals?source=recommendations).

This attribute is *not* meant to be used for C string returns; those will always return as `byte*` so as not to make assumptions about the memory lifetime of returned pointers.

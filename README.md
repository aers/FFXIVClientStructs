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

## For Users

### Signature Resolution

The library uses signatures to resovlve locations at runtime. In order to populate locations from signatures to call functions, you need to initialize the library once at load. However, if you're writing a Dalamud plugin using the built-in copy of the library, you can just reference it in the project and Dalamud will have already initialized it for you. 

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

## Developer Information

Coming soon.
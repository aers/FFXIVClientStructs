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

API Information
===============

Coming soon.

Developer Information
=====================

Coming soon.
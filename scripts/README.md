## ida/ and ghidra/
Both folders hold the same scripts for their disassembler, and share the files in `shared/`.

### rename.py
This script ingests the `data.yml` file in the scripts directory, and renames various offsets as globals, functions, vtables and such.

### struct_import.py
This script imports the Excel sheets and `structs.yml` as types, names the Excel getter functions and applies the function types.
Both generate the same C++ header and let clang work out the layout of every struct, template instances included. IDA uses its built in clang parser. Ghidra has no C++ parser, so `ghidra/clang_wrapper.py` reads the layouts back from libclang and `ghidra_wrapper.py` creates the data types from that.

### full_run.py
This script runs `rename.py` and `struct_import.py` in sequence

#### Shared prerequisites:
Both IDA and Ghidra need these for `struct_import.py`:
- Python, any version still listed on the [Python versions status page](https://devguide.python.org/versions/) is supported.
- The [.NET 10 runtime](https://dotnet.microsoft.com/download/dotnet/10.0), the same version FFXIVClientStructs uses. `pythonnet` loads [Lumina](https://github.com/NotAdam/Lumina) with it to read the Excel headers.
- The game installed. Its folder is read from the best query holding both `game` and `boot`.

#### IDA dependency installation:
`pip install pyyaml anytree pythonnet` or `python -m pip install pyyaml anytree pythonnet` in whichever version of python you are currently using with IDA Pro.
If you are familiar with Poetry, the `idarename` extras package will do the same. 

Additionally, you will need to place "idauser.cfg" from this repository in "%AppData%\Hex-Rays\IDA Pro\". IDA doesn't allow you to use certain characters in names and this config changes that.

#### Ghidra dependency installation:
See [Getting Started](../Ghidra/Getting%20Started.md) for information on how to set up PyGhidra. The same packages as IDA are needed in the PyGhidra environment, plus `libclang`.
Outside of Windows the MSVC and Windows SDK headers are needed as well, `struct_import.py` asks for the folder [mstorsjo/msvc-wine](https://github.com/mstorsjo/msvc-wine)'s `vsdownload.sh` was run in.
The `libclang` python package ships libclang 18, the MSVC headers want clang 20 or newer and report errors otherwise (the layouts still come out the same).
Set the `LIBCLANG_LIBRARY_FILE` environment variable to a libclang 20 or newer to avoid those, ex. `/usr/lib/llvm-20/lib/libclang-20.so.1`.

## ffxiv_sigmaker.py
> [!WARNING]
> Script file is no longer maintained by anyone. Most people use most people use this [sigmaker](https://github.com/caraxi/sigmaker-x64) instead

This script ingests the data.yml file in the same directory, and generates automatic signatures for consumption by the source-gen modules.

This support **Python3** and **IDA** only.

#### Dependency installation:
`pip install dacite pyyaml ruamel-yaml` or `python -m pip install dacite pyyaml ruamel-yaml` in whichever version of python you are currently using with IDA Pro.
If you are familiar with Poetry, the `sigmaker` extras package will do the same.

## classinformer.csv
Once upon a time, someone did a bad thing and released FFXIV with the RTTI data intact.
This is an export of that RTTI data using the ClassInformer IDA Pro plugin.
It is useful as a baseline for many hierarchies and class names, be aware however it is several years old at this point.

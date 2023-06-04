# FFXIVClientStructs helper scripts

Collection of helper scripts and files for reverse engineering, particularly static analysis.

To support multiple disassemblers (IDA and Ghidra), `loader.py` abstracts loading scripts. Scripts in the root directory should call `loader.load_script`, and then the actual source should be in the `python` folder. Please format scripts with `black`.

## Important notes

### Usage in IDA

You will need to place or adapt `idauser.cfg` into `%AppData%\Hex-Rays\IDA Pro`. Certain character names that are used by these scripts can't be used in IDA by default, which this config file changes.

### Removal of data.yml

If you used FFXIVClientStructs in the past, you may know of the `data.yml` file and the `ffxiv_idarename.py` script. This has been removed in favor of unifying the location of all information into the library. `FFXIVClientStructs.MetadataGenerator` now generates a `metadata.json` file containing information from the C# library (structure definitions, type signatures and names for various addresses), which is then imported by `metadata_importer.py`.

This change comes with a few pros and cons:

- Information is easier to add, because there's only one place for it to be located
- Everything visible in your disassembler is available in your code without hassle
- Structures are imported automatically, and function signatures are automatically applied

---

- This process is significantly slower than `ffxiv_idarename.py` - resolving addresses in the metadata generator and importing structures in the script takes a very long time
- Disassembler databases are much larger (observed size increase from a clean IDB: 563 MB -> 1.55 GB)
- The metadata generator uses Roslyn (instead of reflection, which the previous CExporter used), introducing some issues and restrictions as the structures must be able to be parsed with a syntax tree
  - As an example, `[StructLayout(Size = <some variable>)]` no longer works, as it must be constant

## Scripts

### metadata_importer.py

Imports the metadata generated from `FFXIVClientStructs.MetadataGenerator`:

- Imports structs and enums
- Imports documented globals and functions
- Imports documented class instances, functions, VTables & VFunctions
- Sets type signatures for some globals and functions

To use, build and run `FFXIVClientStructs.MetadataGenerator`, providing the path to your game executable:

```sh
dotnet run --project FFXIVClientStructs.MetadataGenerator -- "C:/Program Files (x86)/SquareEnix/FINAL FANTASY XIV - A Realm Reborn/game/ffxiv_dx11.exe"
```

After it finishes, run `metadata_importer.py` in your disassembler. This may take a long time.

## classinformer.csv

Once upon a time, someone did a bad thing and released FFXIV with the RTTI data intact. This is an export of that RTTI data using the ClassInformer IDA Pro plugin. It is useful as a baseline for many hierarchies and class names, be aware however it is several years old at this point.

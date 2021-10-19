## ffxiv_idarename.py

Despite the name being a misnomer at this point, this script supports both Ghidra and IDA.
This script ingests the `data.yml` file in the same directory, and renames various offsets as globals, functions, vtables and such.

Due to switching to a separate yaml format, it has a dependency on PyYaml.

#### IDA dependency installation:
`pip install pyyaml` or `python -m pip install pyyaml` in whichever version of python you are currently using with IDA Pro.
This could be either Python2 or Python3.

#### Ghidra dependency installation:
This is slightly more complicated as Ghidra uses an embedded version of Jython.
- Install a copy of Python2 from https://www.python.org/downloads/
- Execute the following `python.exe -m pip install -t \<YourGhidraFolder\>\Ghidra\Features\Python\data\jython-2.7.2\Lib\site-packages pyyaml`
- Add `FFXIVClientStructs\ida` as a script directory.

---

## Semi-automated update pipeline (mostly IDA only)
Named a bunch of things in your IDB and want to bring them across to `data.yml`, or want to automatically remap your definitions from one version to another? This hacky-ass script pipeline should help with that.

Assuming you have a database that's had `ffxiv_idarename.py` run on it, and items named by a user, you'll need to do the following:

1. Create a new database for the same version as the one you want to dump.
2. Run `ffxiv_idarename.py` on it.
3. You should now have two IDA databases; one with data.yml loaded in (base), and another with data.yml loaded in + your changes (yours).
4. Use `ffxiv_idadump.py` in IDA to dump the base database to `idadump.txt`. Rename this to `idadump_base.txt`.
5. Use `ffxiv_idadump.py` in IDA to dump your database to `idadump.txt`. Rename this to `idadump_yours.txt`.
6. Use `ffxiv_diff_dump.py` on the command line with `idadump_base.txt` and `idadump_yours.txt`, or your favourite diff tool, to produce a file that contains all the lines in your dump that weren't in the base dump
    ```
    python ffxiv_diff_dump.py "idadump_base.txt" "idadump_yours.txt" > "idadump_delta.txt"
    ```

    This will produce a file that looks something like this:

    ```
    Vector3::Normalize 0x140194940
    MemAlloc 0x1400604C0
    g_InvSqrt3 0x141DAEB94
    ```
7. Use `ffxiv_remap_dump.py` on your delta file and pass in an optional "offset definition file" (described below) if required to produce a `data.mapped.yml`. If you don't pass in a ODF, it'll do the same thing, it just won't do any remapping.
    ```
    python ffxiv_remap_dump.py "idadump_delta.txt" "current_offsets.txt"
    ```
8. Open up `data.mapped.yml` in your favourite text editor. You should see something like this in the file:
    ```yaml
    mapped:
    classes:
        Vector3:
        funcs:
            0x140194A90: Normalize
    functions:
        0x1400604C0: MemAlloc
    globals:
        0x141DA5B94: g_InvSqrt3
    unmapped:
    classes: {}
    functions: {}
    globals: {}
    ```
9. Start copying things across to `data.yml`. Be careful not to redefine anything that's already there.
10. Submit!

Potential areas of improvement:
- automatically merging into `data.yml`
- exporting structures
- improving our user-defined entity detection (if you understand the IDAPython API hmu) to make diffing against a base unnecessary
- if all of the above is possible, automating the entire pipeline so that you can run a script to automatically update `data.yml` with your latest findings

### ffxiv_idadump.py
This script, when run by IDA (no Ghidra support yet), produces a text file `idadump.txt` where the IDB is located.
`idadump.txt` is newline-separated and each line corresponds to a function that was named by a user or a script run by the user. (Ideally, we wouldn't include the latter, but IDA's API sucks)

### ffxiv_diff_dump.py
Helper script that takes two files `dump1` and `dump2` and prints all the lines that were in `dump2` but not in `dump1` to stdout. Trivially doable on a UNIX system, but most people are running Windows.

### ffxiv_remap_dump.py
Takes a dump file (as produced by `ffxiv_idadump.py` or `ffxiv_diff_dump.py`), and creates a new `data.mapped.yml` that contains two structures, `mapped` and `unmapped`, which resemble the format of `data.yml`.

You can pass in a second file (the "offset definition file") where each line is of the format `src dst`, where `src` and `dst` are hexadecimal numbers. This will be used to remap every offset in the dump file (such that any occurrences of `src` are replaced with `dst`), which is useful for updating to a new game version. The file should look something like this:
```
0x1419CCB20	0x1419C3D10
0x1419CCB48	0x1419C3D38
0x1419CCB08	0x1419C3CF8
0x1419CD3C0	0x1419C45B0
[...]
```
As for where you get this, ask aers. (I think it's BinDiff output)

This lets you take a dump and create definitions that you can manually paste into `data.yml`.

---

## ffxiv_client_structs.h
This file along with `ffxiv_client_structs_arrays.h` are rough exports of the C# struct implementations to a C header format.
The idea being, you can import these into your choice of tool that supports them. At time of writing, both Ghidra and IDA Pro support importing C headers.
The original file has "gaps" between struct members defined as sequential byte/short/int/long variables.
The `_arrays` variant uses byte arrays instead.

## classinformer.csv
Once upon a time, someone did a bad thing and released FFXIV with the RTTI data intact.
This is an export of that RTTI data using the ClassInformer IDA Pro plugin.
It is useful as a baseline for many hierarchies and class names, be aware however it is several years old at this point.
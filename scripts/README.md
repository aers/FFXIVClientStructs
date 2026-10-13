## ffxiv_idarename.py
Despite the name, this script is now only for Ghidra. The IDA version lives in `ida/rename.py`.
This script ingests the `data.yml` file in the same directory, and renames various offsets as globals, functions, vtables and such.
 
#### IDA dependency installation:
`pip install pyyaml anytree pythonnet` or `python -m pip install pyyaml anytree pythonnet` in whichever version of python you are currently using with IDA Pro.
If you are familiar with Poetry, the `idarename` extras package will do the same. 

Additionally, you will need to place "idauser.cfg" from this repository in "%AppData%\Hex-Rays\IDA Pro\". IDA doesn't allow you to use certain characters in names and this config changes that.

#### Ghidra dependency installation:
See [Getting Started](../Ghidra/Getting%20Started.md) for information on how to set up PyGhidra.

## ffxiv_sigmaker.py
> [!WARNING]
> Script file is no longer maintained by anyone. Most people use most people use this [sigmaker](https://github.com/caraxi/sigmaker-x64) instead

This script ingests the data.yml file in the same directory, and generates automatic signatures for consumption by the source-gen modules.

This support **Python3** and **IDA** only.

#### Dependency installation:
`pip install dacite pyyaml ruamel-yaml` or `python -m pip install dacite pyyaml ruamel-yaml` in whichever version of python you are currently using with IDA Pro.
If you are familiar with Poetry, the `sigmaker` extras package will do the same.

## ida/
### full_run.py
This script runs `rename.py` and `struct_import.py` in sequence

## classinformer.csv
Once upon a time, someone did a bad thing and released FFXIV with the RTTI data intact.
This is an export of that RTTI data using the ClassInformer IDA Pro plugin.
It is useful as a baseline for many hierarchies and class names, be aware however it is several years old at this point.

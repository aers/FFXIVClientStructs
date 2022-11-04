## ffxiv_idarename.py
Despite the name being a misnomer at this point, this script supports both Ghidra and IDA. 
This script ingests the `data.yml` file in the same directory, and renames various offsets as globals, functions, vtables and such.
 
#### IDA dependency installation:
`pip install pyyaml anytree` or `python -m pip install pyyaml anytree` in whichever version of python you are currently using with IDA Pro.
If you are familiar with Poetry, the `idarename` extras package will do the same.
This could be either Python2 or Python3. 

Additionally, you will need to place "idauser.cfg" from this repository in "%AppData%\Hex-Rays\IDA Pro\". IDA doesn't allow you to use certain characters in names and this config changes that.

#### Ghidra dependency installation:
This is slightly more complicated as Ghidra uses an embedded version of Jython. 
- Install a copy of Python2 from https://www.python.org/downloads/
- Execute the following `python.exe -m pip install -t \<YourGhidraFolder\>\Ghidra\Features\Python\data\jython-2.7.3\Lib\site-packages pyyaml==5.4.1 anytree`
- Add `FFXIVClientStructs\ida` as a script directory.

## ffxiv_sigmaker.py
This script ingests the data.yml file in the same directory, and generates automatic signatures for consumption by the source-gen modules.

This support **Python3** and **IDA** only.

#### Dependency installation:
`pip install dacite pyyaml` or `python -m pip install dacite pyyaml` in whichever version of python you are currently using with IDA Pro.
If you are familiar with Poetry, the `sigmaker` extras package will do the same.

## ffxiv_client_structs.h
This file along with `ffxiv_client_structs_arrays.h` are rough exports of the C# struct implementations to a C header format.
The idea being, you can import these into your choice of tool that supports them. At time of writing, both Ghidra and IDA Pro support importing C headers.
The original file has "gaps" between struct members defined as sequential byte/short/int/long variables.
The `_arrays` variant uses byte arrays instead.

## classinformer.csv
Once upon a time, someone did a bad thing and released FFXIV with the RTTI data intact.
This is an export of that RTTI data using the ClassInformer IDA Pro plugin.
It is useful as a baseline for many hierarchies and class names, be aware however it is several years old at this point.

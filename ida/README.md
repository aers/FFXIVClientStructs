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

## ffxiv_client_structs.h
This file along with `ffxiv_client_structs_arrays.h` are rough exports of the C# struct implementations to a C header format.
The idea being, you can import these into your choice of tool that supports them. At time of writing, both Ghidra and IDA Pro support importing C headers.
The original file has "gaps" between struct members defined as sequential byte/short/int/long variables.
The `_arrays` variant uses byte arrays instead.

## classinformer.csv
Once upon a time, someone did a bad thing and released FFXIV with the RTTI data intact.
This is an export of that RTTI data using the ClassInformer IDA Pro plugin.
It is useful as a baseline for many hierarchies and class names, be aware however it is several years old at this point.
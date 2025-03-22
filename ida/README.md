﻿## ffxiv_idarename.py
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
- Execute the following `python.exe -m pip install -t \<YourGhidraFolder\>\Ghidra\Features\Jython\lib\Lib\site-packages pyyaml==5.4.1 anytree==2.8.0`
- Add `FFXIVClientStructs\ida` as a script directory.

## ffxiv_sigmaker.py
> [!WARNING]
> Script file is no longer maintained by anyone. Most people use most people use this [sigmaker](https://github.com/caraxi/sigmaker-x64) instead

This script ingests the data.yml file in the same directory, and generates automatic signatures for consumption by the source-gen modules.

This support **Python3** and **IDA** only.

#### Dependency installation:
`pip install dacite pyyaml ruamel-yaml` or `python -m pip install dacite pyyaml ruamel-yaml` in whichever version of python you are currently using with IDA Pro.
If you are familiar with Poetry, the `sigmaker` extras package will do the same.

## ffxiv_exdgetters.py
> [!WARNING]
> Does not work with IDA 9 due to changes made on the application

This script ingests the `exh` files from the base game and renames various functions, including setting the return type of the functions to the propper sheet struct.

## ffxiv_structimporter.py
> [!WARNING]
> Does not work with IDA 9 due to changes made on the application

This script ingests the `ffxiv_structs.yml` file and forms the proper structs and assigns the member function return and param types correctly

## ffxiv_fullrun_ida.py
> [!WARNING]
> Does not work with IDA 9 due to changes made on the application

This script runs `ffxiv_idarename.py`,  `ffxiv_exdgetters.py`,  `ffxiv_structimporter.py` in sequence

## classinformer.csv
Once upon a time, someone did a bad thing and released FFXIV with the RTTI data intact.
This is an export of that RTTI data using the ClassInformer IDA Pro plugin.
It is useful as a baseline for many hierarchies and class names, be aware however it is several years old at this point.

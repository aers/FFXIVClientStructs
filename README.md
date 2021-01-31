## FFXIVClientStructs

This project encapsulates efforts to reverse-engineer the layout of the C++ classes that make up the FFXIV client. This library is intended to be used alongside [Dalamud](https://github.com/goatcorp/Dalamud), and is included with it.

### IDA/Ghidra

The ida directory has a python script that can be imported to either IDA or Ghidra to rename known binary locations. This is generally kept up to date with new game versions, but make sure you're on the appropriate version beforehand.

Special thanks to [daemitus](https://github.com/daemitus/) for extensive work on updating the import script to support vtable renaming.
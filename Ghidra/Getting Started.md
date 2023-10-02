# Pre-requisites
Download and install [Ghidra](https://ghidra-sre.org/)
They have an installation guide and some additional depdendencies themselves (Java runtime).

# Getting started with a new project
`File -> New Project` or press `Ctrl+N`<br>
`Non-Shared Project` is fine, then click `Next >>`<br>
Create a new directory somewhere, and select that as your `Project Directory`, then give it some name and click `Finish`.

With the project now open, `File -> Import File` or press `i`.  Navigate to the game directory (on Windows: `C:\Program Files (x86)\SquareEnix\FINAL FANTASY XIV - A Realm Reborn\game`) select `ffxiv_dx11.exe` and `Select File To Import`.

On the next window, the defaults should all be fine, just click `OK`.
<p align="center"><img src=".\images\Import.png"></p>

Upon completing the import, it'll provide a results summary.  Click `OK`.
<p align="center"><img src=".\images\Import Results Summary.png"></p>

Now that the assembly is imported into the project, double click it:
<p align="center"><img src=".\images\Project Window.png"></p>

The first time you open the file it'll tell you it hasn't been analyzed and ask you to do so:
<p align="center"><img src=".\images\Analyze.png"></p>

On the options window, the defaults should do:
<p align="center"><img src=".\images\Analyze Options.png"></p>

The initial analysis will take some time.  While it is still running, you should see status in the bottom right:
<p align="center"><img src=".\images\Analyze In Progress.png"></p>

While analysis is in progress it's a good time to get familiar with some of the tools we've compiled (and install their dependencies).

When analysis is complete, you shoould get a summary window that looks something like:
<p align="center"><img src=".\images\Analysis Summary.png"></p>
You can click `OK`.

## After Patches
Note that after each patch, you'll have to re-import, re-analyze, and re-run any scripts you may use.  It is possible to use the same Project and create folders for the various versions, and in doing so, you may be able to use some of Ghidra's tools, like `Version Tracking`.
<p align="center"><img src=".\images\Project Window Multi.png"></p>

# Script dependency installation:
We use [..\ida\ffxiv_idarename.py](../ida/ffxiv_idarename.py) to apply data.yml.  The same script works for both IDA and Ghidra, howver it's slightly more complicated in Ghidra as it uses an embedded version of jython.

- Install a copy of [Python 2](https://www.python.org/downloads/).<br>
Note: it has to be major version 2, so something like [Python 2.7.18](https://www.python.org/downloads/release/python-2718/) works.<br>

- Execute the following:<br>
`python.exe -m pip install -t <YourGhidraFolder\>\Ghidra\Features\Python\data\jython-2.7.3\Lib\site-packages pyyaml==5.4.1 anytree`<br>
Note: this must be run from Python 2.  If you have multiple versions installed, you may need to qualify the path like:<br>
`c:\Python27\python.exe -m pip install -t <YourGhidraFolder\>\Ghidra\Features\Python\data\jython-2.7.3\Lib\site-packages pyyaml==5.4.1 anytree`

- Open the Script Manager <p align="center"><img src=".\images\Open Script Manager.png"></p>

- Manage Script Directories <p align="center"><img src=".\images\Manage Script Directories.png"></p>

- Click the plus to add a directory <p align="center"><img src=".\images\Script Manager Add Directory.png"></p>

- Add both `FFXIVClientStructs/ida` (for ffxiv_idarename.py) and `FFXIVClientStructs/Ghidra/scripts` (for ffxiv_exdgetters and SigScanner)

After adding both, select `__UserScripts` and you should see all of the scripts.  SigScanner should already have a key binding assigned of `Ctrl-Alt-S`.  Assign any others you wish, and ensure the checkbox is ticked.
<p align="center"><img src=".\images\User Scripts.png"></p>

# The Scripts
## ffxiv_idarename.py
First a quick intro.  The analyzer reads through the code and attempts to determine things like what blocks of code are instructions vs pointers vs data, etc.  When it identifies things, it'll add labels to them:
- FUN_14#######: for what it believes to be functions
- PTR_FUN_14#######: for what it believes to be pointers to functions
- DAT_14#######
- and so on.

What you'll see in common here is, the numbers all start with 14.  This is the default base address for 64-bit images ([source](https://learn.microsoft.com/en-us/cpp/build/reference/base-base-address?view=msvc-170)).

The rest of the 7 #'s are the offset from the start of the program.

As an example, if you look in Dalamud's Data window
<p align="center"><img src=".\images\Address Dalamud Example.png"></p>

You'll see the vtbl has an address like`7FF6DDEAD480 ffxiv_dx11.exe+1A0D480`.  In Ghidra, if you were to `Navigation -> Go To...` (or simply press `g`) and typed 141A0D480, you'd arrive at the vtable.

What you'll find in [data.yml](../ida/data.yml) are definitions like:
```yaml
  Client::System::Framework::Framework:
    instances:
      - ea: 0x1420A83B8
      - ea: 0x1420A9F58
        name: InstancePointer2
    vtbls:
      - ea: 0x1418E0698
    vfuncs:
      0: dtor
      1: Setup
      2: Destroy
      3: Free
      4: Tick
    funcs:
      0x1400901D0: ctor
      ...
```

When you run the ffxiv_idarename.py script, it'll rename `FUN_1400901d0` to `Client::System::Framework::Framework.ctor` (per the first line under `funcs:`).  It'll turn:
<p align="center"><img src=".\images\Framework Before.png"></p>

Into:
<p align="center"><img src=".\images\Framework After.png"></p>

And much more.  So go ahead and run it.  Either by opening the script manager, right clicking the script, and `Run Script`, or by invoking anay keybind you made to it.

You can re-run this script as many times as you like, it'll just re-process data.yml, so it's much easier to update data.yml when you map out a new vtable and re-run than to try and set all the labels yourself.

## ffxiv_exdgetters.java
After having run ffxiv_idarename.py, we'll have a bunch of functions referencing Exd methods like:
```cpp
undefined8 FUN_1406cb6c0(undefined4 param_1)
{
  undefined8 *puVar1;
  puVar1 = (undefined8 *)
           Component::Exd::ExdModule.GetRowBySheetIndexAndRowIndex
                     (*(undefined8 *)
                       (g_Client::System::Framework::Framework_InstancePointer2 + 0x2b38),0x3b,
                      param_1);
  if (puVar1 == (undefined8 *)0x0) {
    return 0;
  }
  return *puVar1;
}
```

The label `Component::Exd::ExdModule.GetRowBySheetIndexAndRowIndex` came from data.yml, but unfortunately it's still not obvious exactly what that method is fetching.  The sheet indexes are fairly well-known, and this script parses these and relabels the function from `FUN_1406cb6c0` to `undefined8 Client::ExdData::GetClassJob(undefined4 param_1)`, which is much more useful.  Go ahead and run this too.

## SigScanner.java
In plugins (and FFXIVClientStructs) we use signatures rather than offsets.  This is because offsets change with every patch, while signatures are far more durable.

Signatures are essentially just a series of bytes that actually make up the instructions.  For example:
```
1400597e7 e8 e4 69        CALL       Client::System::Framework::Framework.ctor        undefined Client::System::Framew
          03 00
1400597ec 48 8b c8        MOV        RCX,RAX
1400597ef 48 89 05        MOV        qword ptr [g_Client::System::Framework::Framew   = ??
          c2 eb 04 02
1400597f6 eb 0a           JMP        LAB_140059802
                      LAB_1400597f8                                   XREF[1]:     1400597db(j)  
1400597f8 48 8b ce        MOV        RCX,RSI
```

This instruction set is physically just `e8 e4 69 03 00 48 8b c8 48 89 05 c2 eb 04 02 eb 0a 48 8b ce`.  But some of those instructions are themselves referring to offsets.  For example, `e8 e4 69 03 00`.  e8 indicates it's a CALL.  The next 4 bytes are little endian and added to the address of the next instruction: `000369e4 + 1400597ec = 1400901d0`.  Which is the address that `Client::System::Framework::Framework.ctor` starts on.  To make this signature durable across patches, we replace the offset with wildcards `??`.  For this example, we get `E8 ?? ?? ?? ?? 48 8B C8 48 89 05 ?? ?? ?? ?? EB ?? 48 8B CE`.

What this script does is, you place the cursor on the instruction you want the signature for, presss the keybind (`Ctrl+Alt+S` by default) and it will attempt to create the smallest signature that uniquely maps to just that one instruction.

Technically it'll do a few more things like, if the instruction you picked is the first in a function, it'll find the signature of a caller of that function (which works fine for Dalamud/FFXIVClientStructs signatures).

# Headers
In FFXIVClientStructs, we also have a helper program, [CExporter](../ida/CExporter/).  This program will load FFXIVClientStructs, reflect over all structs, and makes an approximate C++ Header with the corresponding struct definitions.  This header file can also be imported into Ghidra to give type definitions.

While we technically have pre-generated header files checked in, they are very rarely updated, so it is recommended you just run CExporter yourself before importing them.  Just set the project as startup in Visual Studio and run.  Assuming no errors, this should update 4 files under the ida folder, for which you really only care about [ffxiv_client_structs_arrays_ghidra.h](../ida/ffxiv_client_structs_arrays_ghidra.h).

After re-generating the header, in Ghidra, `File -> Parse C Source...`.  In the window that comes up, delete everything in the `Source files to parse` section, as well as the `Parse Options`, and add the path to ffxiv_client_structs_arrays_ghidra.h.  Then Save this profile for future use:
<p align="center"><img src=".\images\Parse C Source.png"></p>

Click `Parse to Program`, then `Continue`, and `Don't Use Open Archives` (the last one doesn't really matter).

This will allow you to retype variables, turning the decompiled code from:
```cpp
      uVar3 = *(uint *)((longlong)param_1 + 0x54);
      uVar5 = (**(code **)(*param_1 + 0x40))(param_1);
```

To:
```cpp
      uVar5 = *(uint *)&(param_1->NpcInfo).SelectedItemIndex;
      uVar7 = (*(code *)((param_1->AgentInterface)._union_0x0.VTable)->GetAddonID)(param_1);
```

There are some caveats to the imported headers.

## Namespaces
Ghidra's parser doesn't support namespaces.  To make the headers even import, the CExporter replaces :: with _, such as `Component_GUI_AgentInterface`.

## Enums
Ghidra doesn't honor any enum size/type.  All enums are imported as size 0x4.  To help with this, the CExporter appends the size to the end of all enum names.  For example: `Component_GUI_NodeType0x2`.  You can search in Data Type Manager for 0x1/0x2 and manually update the size of each.

<p align="center"><img src=".\images\Enum Size.png"></p>


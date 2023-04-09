# Common Issues


## Function appears read-only
In the Symbol Tree, you'll find that virtual functions will appear with 2 shades of blue.  the lighter shade will be under the top level `Functions` node, while a darker blue will appear under `Labels`.  When you navigate to that function, the Decompile window will be shaded gray, and you won't be able to retype/rename anything.  This is caused by the analyzer not knowing this was a function (no CALL instructions referencing it).

To remedy this, right click the first instruction for that function and select `Create Function` (or just press `f`).

## Error: Function ... had unexpected name "Client::UI::Agent::AgentInterface.vf1" during naming of ...
This is because `AtkEventInterface` has 2 virtual functions, but Ghidra didn't detect the second one.  So, the first derived class (AgentInterface) that didn't override that function updated it's label, claiming it for its own.  A subsequent class that derives AtkEventInterface but not AgentInterface then finds the wrong name.

To resolve this, navigate to `vtbl_Component::GUI::AtkModuleInterface::AtkEventInterface`.  You should see:
```
vtbl_Component::GUI::AtkModuleInterface::AtkEv  XREF[1588]:
1418ebca0 50 97 5b        addr       _purecall
          41 01 00 
          00 00
1418ebca8 10              ??         10h
1418ebca9 45              ??         45h
1418ebcaa 17              ??         17h
1418ebcab 40              ??         40h
1418ebcac 01              ??         01h
1418ebcad 00              ??         00h
1418ebcae 00              ??         00h
1418ebcaf 00              ??         00h

```

You see the first instruction was identified as an address.  Right click the next instruction and select `Data -> Pointer` (or put your cursor on that line and press `p`).  It should now look like:
```
vtbl_Component::GUI::AtkModuleInterface::AtkEv  XREF[1588]:
1418ebca0 50 97 5b        addr       _purecall
          41 01 00 
          00 00
1418ebca8 10 45 17        addr       Client::UI::Agent::AgentInterface.vf1
          40 01 00 
          00 00
```

Then right click `Client::UI::Agent::AgentInterface.vf1` and `Remove Label` (or press `Delete`).

Re-run the rename script.

## Error: Function at 0x1405129D0 had unexpected name "" during naming of ...
This occurs because Ghidra didn't identify that section of memory as anything useful.  Take the address in the error, select `Navigation -> Go To ...` (or press `g`), and put that address (1405129D0 in my example) in, and go.  You should see something like:
```
       1405129d0 48              ??         48h    H
       1405129d1 85              ??         85h
       1405129d2 c9              ??         C9h
       1405129d3 74              ??         74h    t
       1405129d4 04              ??         04h
```

Right click the address and select `Disassemble` (or press `d`) then `Create Function` (or `f`).

## Error: Function at 0x140AFA910 had unexpected name "Concurrency::details::FreeThreadProxy::`scalar_deleting_destructor'" during naming of Client::UI::Agent::AgentMiragePrismPrismBox.dtor (vtbl[2])
This is caused because the analyzer matched this to a visual studio function.  Right click the function name and remove the label (or press `Delete`) until it reverts to `FUN_140afa910`, re-run.

## Error: Function at 0x140573040 had unexpected name "Component::GUI::AtkComponentWindow.vf23" during naming of Component::GUI::AtkComponentMultipurpose.vf43 (vtbl[43])
This is actually caused because there are 2 vtables here, but Ghidra didn't find any pointers to the second one, and thus didn't label it.  When the rename script encountered the first, it just kept on attempting to incremet vf# until it reaches the end.

In this example, at vf20, you'll see references to the base vf's starting over again.  To resolve, you need to find the code that references that address.  In this case, vf8 is the first method this class overrides, navigate there and look around (up likely) for memory with bytes, but ?? as addresses.  Scroll to the first byte that isn't `cc` and press `d` then `f`.  In the resulting decompiled function, you'll see a line like
```cpp
*param_1 = &PTR_Component_GUI_AtkComponentMultipurpose.vf20_141935128;
```

Re-run.

## Error: The sum of "Client::UI::AddonActionDoubleCrossL"'s base vtbl sizes (96) is greater than the actual class itself (79)
Navigate to the vtable, scroll to vf79.  You'll see:
```
141a59ef8 10 8c 15        addr       Client::UI::AddonActionDoubleCrossBase.vf78
          41 01 00 
          00 00
141a59f00 a0              ??         A0h
              DAT_141a59f01
141a59f01 21              ??         21h    !
141a59f02 14              ??         14h
141a59f03 41              ??         41h    A
141a59f04 01              ??         01h
141a59f05 00              ??         00h
141a59f06 00              ??         00h
141a59f07 00              ??         00h
141a59f08 40 24 14        addr       Client::UI::AddonActionBarBase.vf80
          41 01 00 
          00 00
```

Select that first line (a0) and press `p` to turn this into a pointer.  Re-run.

## Known Errors
The following 2 errors are known and expected, as not everything is properly defined for these 2 classes yet:
```
Error: Function at 0x141264890 had unexpected name "Client::Network::PacketDispatcher.OnReceivePacket" during naming of Client::Network::NetworkModulePacketReceiverCallback.OnReceivePacket (vtbl[1])
Error: Function at 0x1412696E0 had unexpected name "Client::Network::PacketDispatcher___Client::Network::Protocol::Chat::PacketReceiverCallbackInterface.OnReceivePacket" during naming of Client::Network::NetworkModulePacketReceiverCallback.OnReceivePacket (vtbl[1])
```

## Misaligned Structs
The header files CExporter creates have all the fields from FFXIVClientStructs, but we don't have the luxury of omitting unknown fields.  To deal with sparse structs, the Arrays.h strategy is to create a "gap" field the size of the gap.  For example `byte _gap_0xB8[0x10];`.  Sometimes you'll see properties that look off, and if you edit the structure, you'll see something like:

<p align="center"><img src=".\images\Misaligned Struct.png"></p>

Ghidra believes this starts at 0x1de, but the header said the field was _gap_0x1D6.  This means that some property earlier in the structs definition was parsed into ghidra as larger than what we believe it to be in FFXIVClientStructs.  This most often happens because of the Enums (see above), but can happen for other reasons.  To resolve, scroll till you find the first gap that is misaligned, and start looking through properties prior to it.



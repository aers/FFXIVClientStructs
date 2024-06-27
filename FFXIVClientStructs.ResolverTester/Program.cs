using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Reflection.PortableExecutable;
using FFXIVClientStructs.Havok.Common.Base.System.IO.Reader;
using FFXIVClientStructs.ResolverTester;
using InteropGenerator.Runtime;
using YamlDotNet.Serialization.NamingConventions;

var gamePath = args.Length > 0 ? args[0] : @"D:\FFXIV\game\ffxiv_dx11.exe";

using PEReader reader = new PEReader(File.OpenRead(gamePath));
SectionHeader textHeader = reader.PEHeaders.SectionHeaders[0];

Span<byte> relocFile = new Span<byte>(new byte[reader.PEHeaders.PEHeader!.SizeOfImage]);

reader.GetSectionData(textHeader.Name).GetContent().CopyTo(relocFile.Slice(textHeader.VirtualAddress, textHeader.VirtualSize));
unsafe {
    fixed (byte* bytes = relocFile) {

        Resolver.GetInstance.Setup(new IntPtr(bytes),
            relocFile.Length,
            textHeader.VirtualAddress,
            textHeader.VirtualSize);

        var watch = new Stopwatch();
        watch.Start();
        FFXIVClientStructs.Interop.Generated.Addresses.Register();
        Resolver.GetInstance.Resolve();
        watch.Stop();

        foreach (Address addr in Resolver.GetInstance.Addresses)
            addr.Value = addr.Value - new IntPtr(bytes);
        //Console.WriteLine($"Resolved in {watch.ElapsedMilliseconds}ms");

        var totalSigCount = Resolver.GetInstance.Addresses.Count;
        var resolvedCount = Resolver.GetInstance.Addresses.Count(sig => sig.Value != 0);
        Console.WriteLine($"Resolved count: {resolvedCount} ({((float)resolvedCount / totalSigCount) * 100}%)");

        Console.WriteLine("\n=== Broken Signatures ===");
        var unresolvedSigs = Resolver.GetInstance.Addresses.Where(sig => sig.Value == 0);
        foreach (var sig in unresolvedSigs)
            Console.WriteLine($"[FAIL] {sig.Name}: {sig.String}");

        foreach (Address address in Resolver.GetInstance.Addresses)
            Console.WriteLine($"{address.Name} {address.Value:X}");
    }
}

/*
using StreamReader dataReader = new StreamReader(@"..\..\..\..\ida\data.yml");

var deserializer = new YamlDotNet.Serialization.DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();
var data = deserializer.Deserialize<Data>(dataReader);

int havokSigs = 0;
int notFoundSigs = 0;
int matchedSigs = 0;
int failedSigs = 0;

List<string> failedOutputs = new();
List<string> notfoundOutputs = new();

foreach (Address addr in Resolver.GetInstance.Addresses) {
    // havok names in data.yml mangled
    if (addr.Name.StartsWith("FFXIVClientStructs.Havok")) {
        havokSigs += 1;
        continue;
    }
    ReadOnlySpan<char> nameWithoutPrefix = addr.Name.Replace(".", "::").AsSpan(27);
    int index = nameWithoutPrefix.LastIndexOf(':');
    var className = nameWithoutPrefix[..(index - 1)].ToString();
    var functionName = nameWithoutPrefix[(index + 1)..].ToString();

    if (!data.Classes.TryGetValue(className, out Class? theClass) || theClass == null) {
        notfoundOutputs.Add($"Class {className} not found in data.yml for signature {functionName} @ {addr.String}");
        notFoundSigs += 1;
        continue;
    }

    if (functionName == "Instance") {
        if (theClass.Instances == null) {
            notfoundOutputs.Add($"No instance found in data.yml for class {className} / signature {functionName} @ {addr.String}");
            notFoundSigs += 1;
            continue;
        }
        if (!nint.TryParse(theClass.Instances[0].Ea.AsSpan(4), NumberStyles.HexNumber, null, out nint address)) {
            notfoundOutputs.Add($"Unable to parse data.yml offset {theClass.Instances[0].Ea} for class {className} Instance");
            notFoundSigs += 1;
            continue;
        }

        if (addr.Value == 0) {
            failedOutputs.Add($"{addr.Name} - {addr.String} failed to resolve, data.yml has {address:X}");
            failedSigs += 1;
            continue;
        }

        if (address != addr.Value) {
            failedOutputs.Add($"{addr.Name} - {addr.String} resolved to {addr.Value:X}, data.yml has {address:X}");
            failedSigs += 1;
            continue;
        }

        matchedSigs += 1;
        continue;
    }

    if (functionName == "StaticVirtualTable") {
        if (theClass.Vtbls == null) {
            notfoundOutputs.Add($"No vtbl found in data.yml for class {className} / signature {functionName} @ {addr.String}");
            notFoundSigs += 1;
            continue;
        }
        
        if (!nint.TryParse(theClass.Vtbls[0].Ea.AsSpan(4), NumberStyles.HexNumber, null, out nint address)) {
            notfoundOutputs.Add($"Unable to parse data.yml offset {theClass.Instances[0].Ea} for class {className} StaticVirtualTable");
            notFoundSigs += 1;
            continue;
        }
        
        if (addr.Value == 0) {
            failedOutputs.Add($"{addr.Name} - {addr.String} failed to resolve, data.yml has {address:X}");
            failedSigs += 1;
            continue;
        }

        if (address != addr.Value) {
            failedOutputs.Add($"{addr.Name} - {addr.String} resolved to {addr.Value:X}, data.yml has {address:X}");
            failedSigs += 1;
            continue;
        }

        matchedSigs += 1;
        continue;
    }
    
    if (functionName == "Ctor")
        functionName = "ctor";

    if (functionName == "Dtor")
        functionName = "dtor";
    
    if (theClass.Funcs == null || !theClass.Funcs.ContainsValue(functionName)) {
        notfoundOutputs.Add($"Function {functionName} of class {className} not found in data.yml for signature {addr.String}");
        notFoundSigs += 1;
        continue;
    }

    var key = theClass.Funcs.FirstOrDefault(x => x.Value == functionName).Key!;
    
    if (!nint.TryParse(key.AsSpan(4), NumberStyles.HexNumber, null, out nint dataAddress)) {
        notfoundOutputs.Add($"Unable to parse data.yml offset {key} for class {className} function {functionName}");
        notFoundSigs += 1;
        continue;
    }
    
    if (addr.Value == 0) {
        failedOutputs.Add($"{addr.Name} - {addr.String} failed to resolve, data.yml has {dataAddress:X}");
        failedSigs += 1;
        continue;
    }

    if (dataAddress != addr.Value) {
        failedOutputs.Add($"{addr.Name} - {addr.String} resolved to {addr.Value:X}, data.yml has {dataAddress:X}");
        failedSigs += 1;
        continue;
    }

    matchedSigs += 1;

}

Console.WriteLine($"Total Sigs {Resolver.GetInstance.Addresses.Count}");
Console.WriteLine($"Skipped Havok Sig Count {havokSigs}");
Console.WriteLine($"Sigs Not Found in data.yml Count {notFoundSigs}");
Console.WriteLine($"Sigs Matching data.yml Count {matchedSigs}");
Console.WriteLine($"Sigs Not Matching data.yml Count {failedSigs}");

Console.WriteLine();

Console.WriteLine("Failed Matches");
foreach (string line in failedOutputs)
    Console.WriteLine(line);

Console.WriteLine();

Console.WriteLine("Not Found in data.yml");
foreach (string line in notfoundOutputs)
    Console.WriteLine(line);*/

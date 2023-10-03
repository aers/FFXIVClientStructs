using System.Diagnostics;
using System.Reflection.PortableExecutable;
using FFXIVClientStructs.Interop;

var gamePath = args.Length > 0 ? args[0] : @"F:\xiv-dev\ew-exes\ffxiv_dx11_2023.01.11.0000.0000.exe";

using PEReader reader = new PEReader(File.OpenRead(gamePath));
SectionHeader textHeader = reader.PEHeaders.SectionHeaders[0];
SectionHeader rdataHeader = reader.PEHeaders.SectionHeaders[1];
SectionHeader dataHeader = reader.PEHeaders.SectionHeaders[2];

Span<byte> relocFile = new Span<byte>(new byte[reader.PEHeaders.PEHeader!.SizeOfImage]);

reader.GetSectionData(textHeader.Name).GetContent().CopyTo(relocFile.Slice(textHeader.VirtualAddress, textHeader.VirtualSize));
reader.GetSectionData(rdataHeader.Name).GetContent().CopyTo(relocFile.Slice(rdataHeader.VirtualAddress, rdataHeader.VirtualSize));
reader.GetSectionData(dataHeader.Name).GetContent().CopyTo(relocFile.Slice(dataHeader.VirtualAddress, dataHeader.VirtualSize));

unsafe {
    fixed (byte* bytes = relocFile) {
        var totalSigCount = Resolver.GetInstance.Addresses.Count;
        Console.WriteLine($"Unresolved count: {totalSigCount}");

        Resolver.GetInstance.SetupSearchSpace(new IntPtr(bytes),
            relocFile.Length,
            textHeader.VirtualAddress,
            textHeader.VirtualSize,
            dataHeader.VirtualAddress,
            dataHeader.VirtualSize,
            rdataHeader.VirtualAddress,
            rdataHeader.VirtualSize);

        var watch = new Stopwatch();
        watch.Start();
        Resolver.GetInstance.Resolve();
        watch.Stop();
        Console.WriteLine($"Resolved in {watch.ElapsedMilliseconds}ms");

        var resolvedCount = Resolver.GetInstance.Addresses.Count(sig => sig.Value != 0);
        Console.WriteLine($"Resolved count: {resolvedCount} ({((float)resolvedCount / totalSigCount) * 100}%)");

        Console.WriteLine("\n=== Broken Signatures ===");
        var unresolvedSigs = Resolver.GetInstance.Addresses.Where(sig => sig.Value == 0);
        foreach (var sig in unresolvedSigs)
            Console.WriteLine($"[FAIL] {sig.Name}: {sig.String}");

        Console.WriteLine("\n=== Static Addresses ===");
        foreach (var address in Resolver.GetInstance.Addresses.Where(address => address is StaticAddress))
            Console.WriteLine($"{address.Name} - {address.String} - {address.Value - new UIntPtr(bytes):X16}");
    }
}

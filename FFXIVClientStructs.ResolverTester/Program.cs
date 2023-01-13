using System.Diagnostics;
using FFXIVClientStructs.Interop;
using PeNet;
using PeNet.Header.Pe;

Memory<byte> file = new Memory<byte>(File.ReadAllBytes(@"F:\xiv-dev\ew-exes\ffxiv_dx11_2023.01.11.0000.0000.exe"));
PeFile peHeader = new PeFile(file.Span.ToArray());

ImageSectionHeader textHeader = peHeader.ImageSectionHeaders![0];
ImageSectionHeader rdataHeader = peHeader.ImageSectionHeaders![1];
ImageSectionHeader dataHeader = peHeader.ImageSectionHeaders![2];

Memory<byte> relocFile = new Memory<byte>(new byte[peHeader.FileSize]);

file.Slice((int)textHeader.PointerToRawData, (int)textHeader.VirtualSize).CopyTo(relocFile.Slice((int)textHeader.VirtualAddress, (int)textHeader.VirtualSize));
file.Slice((int)rdataHeader.PointerToRawData, (int)rdataHeader.VirtualSize).CopyTo(relocFile.Slice((int)rdataHeader.VirtualAddress, (int)rdataHeader.VirtualSize));
file.Slice((int)dataHeader.PointerToRawData, (int)dataHeader.VirtualSize).CopyTo(relocFile.Slice((int)dataHeader.VirtualAddress, (int)dataHeader.VirtualSize));

unsafe
{
    fixed (byte* bytes = relocFile.Span)
    {
        Console.WriteLine($"Unresolved count: {Resolver.GetInstance.Addresses.Count}");

        Resolver.GetInstance.SetupSearchSpace(new IntPtr(bytes), relocFile.Length, (int) textHeader.VirtualAddress,
            (int) textHeader.VirtualSize, (int) dataHeader.VirtualAddress, (int) dataHeader.VirtualSize,
            (int) rdataHeader.VirtualAddress, (int) rdataHeader.VirtualSize);
        
        var watch = new Stopwatch();
        watch.Start();
        Resolver.GetInstance.Resolve();
        watch.Stop();
        Console.WriteLine($"Resolved in {watch.ElapsedMilliseconds}ms");

        Console.WriteLine($"Resolved count: {Resolver.GetInstance.Addresses.Count(sig => sig.Value != 0)}");

        foreach(var address in Resolver.GetInstance.Addresses.Where(address => address is StaticAddress))
            Console.WriteLine($"{address.Name} - {address.String} - {address.Value - new UIntPtr(bytes):X16}");
    }
}
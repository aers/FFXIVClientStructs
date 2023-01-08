using System.Diagnostics;
using FFXIVClientStructs.Interop;
using PeNet;
using PeNet.Header.Pe;

Memory<byte> file = new Memory<byte>(File.ReadAllBytes(@"C:\Games\FFXIV\game\ffxiv_dx11.exe"));
PeFile peHeader = new PeFile(file.Span.ToArray());

ImageSectionHeader textHeader = peHeader.ImageSectionHeaders![0];
ImageSectionHeader rdataHeader = peHeader.ImageSectionHeaders![1];
ImageSectionHeader dataHeader = peHeader.ImageSectionHeaders![2];

unsafe
{
    fixed (byte* bytes = file.Span)
    {
        Console.WriteLine($"Unresolved count: {Resolver.GetInstance.Signatures.Count}");

        ResolverTarget target = new ResolverTarget(new IntPtr(bytes), file.Length, (int) textHeader.PointerToRawData,
            (int) textHeader.SizeOfRawData, (int) dataHeader.PointerToRawData, (int) dataHeader.SizeOfRawData,
            (int) rdataHeader.PointerToRawData, (int) rdataHeader.SizeOfRawData);

        var watch = new Stopwatch();
        watch.Start();
        Resolver.GetInstance.ResolveWithTarget(target);
        watch.Stop();
        Console.WriteLine($"Resolved in {watch.ElapsedMilliseconds}ms");

        Console.WriteLine($"Resolved count: {Resolver.GetInstance.Signatures.Count(sig => sig.Value != 0)}");

        //foreach(var sig in Resolver.GetInstance.Signatures)
        //    Console.WriteLine($"{sig.Name} {sig.String} {sig.Value:X16}");
        
    }
}
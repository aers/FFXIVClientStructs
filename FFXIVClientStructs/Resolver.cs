using System;
using System.Diagnostics;
using System.IO;

namespace FFXIVClientStructs;

public static partial class Resolver
{
    public static bool Initialized;

    public static void Initialize(FileInfo? cacheFile = null)
    {
        if (Initialized) return;

        var module = Process.GetCurrentProcess().MainModule;
        var scanner = new SigScanner(module, false, cacheFile);

        InitializeMemberFunctions(scanner);
        InitializeStaticAddresses(scanner);

        Initialized = true;
        scanner.Save();
    }

    public static void Initialize(IntPtr moduleCopy, FileInfo? cacheFile = null)
    {
        if (Initialized) return;

        var module = Process.GetCurrentProcess().MainModule;
        var scanner = new SigScanner(module, moduleCopy, cacheFile);

        InitializeMemberFunctions(scanner);
        InitializeStaticAddresses(scanner);

        Initialized = true;
        scanner.Save();
    }

    public static void InitializeParallel(FileInfo? cacheFile = null) {
        if (Initialized) return;

        var module = Process.GetCurrentProcess().MainModule;
        var scanner = new SigScanner(module, false, cacheFile);

        InitializeMemberFunctionsParallel(scanner);
        InitializeStaticAddressesParallel(scanner);

        Initialized = true;
        scanner.Save();
    }

    public static void InitializeParallel(IntPtr moduleCopy, FileInfo? cacheFile = null) {
        if (Initialized) return;

        var module = Process.GetCurrentProcess().MainModule;
        var scanner = new SigScanner(module, moduleCopy, cacheFile);

        InitializeMemberFunctionsParallel(scanner);
        InitializeStaticAddressesParallel(scanner);

        Initialized = true;
        scanner.Save();
    }
}
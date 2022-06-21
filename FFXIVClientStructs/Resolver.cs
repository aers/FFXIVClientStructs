using System;
using System.Diagnostics;
using System.IO;

namespace FFXIVClientStructs;

public static partial class Resolver
{
    public static bool Initialized;

    public static void Initialize()
    {
        Initialize(null);
    }

    public static void Initialize(IntPtr moduleCopy)
    {
        Initialize(moduleCopy, null);
    }

    public static void InitializeParallel()
    {
        InitializeParallel(null);
    }

    public static void InitializeParallel(IntPtr moduleCopy)
    {
        InitializeParallel(moduleCopy, null);
    }

    public static void Initialize(FileInfo cacheFile)
    {
        if (Initialized) return;

        var module = Process.GetCurrentProcess().MainModule;
        var scanner = new SigScanner(module, false, cacheFile);

        InitializeMemberFunctions(scanner);
        InitializeStaticAddresses(scanner);

        Initialized = true;
        scanner.Save();
    }

    public static void Initialize(IntPtr moduleCopy, FileInfo cacheFile)
    {
        if (Initialized) return;

        var module = Process.GetCurrentProcess().MainModule;
        var scanner = new SigScanner(module, moduleCopy, cacheFile);

        InitializeMemberFunctions(scanner);
        InitializeStaticAddresses(scanner);

        Initialized = true;
        scanner.Save();
    }

    public static void InitializeParallel(FileInfo cacheFile)
    {
        if (Initialized) return;

        var module = Process.GetCurrentProcess().MainModule;
        var scanner = new SigScanner(module, false, cacheFile);

        InitializeMemberFunctionsParallel(scanner);
        InitializeStaticAddressesParallel(scanner);

        Initialized = true;
        scanner.Save();
    }

    public static void InitializeParallel(IntPtr moduleCopy, FileInfo cacheFile)
    {
        if (Initialized) return;

        var module = Process.GetCurrentProcess().MainModule;
        var scanner = new SigScanner(module, moduleCopy, cacheFile);

        InitializeMemberFunctionsParallel(scanner);
        InitializeStaticAddressesParallel(scanner);

        Initialized = true;
        scanner.Save();
    }
}
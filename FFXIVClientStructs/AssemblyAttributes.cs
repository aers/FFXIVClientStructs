using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: DisableRuntimeMarshalling]

// Manually create these because <GenerateAssemblyInfo>false</GenerateAssemblyInfo>
[assembly: AssemblyCompany("FFXIVClientStructs")]
[assembly: AssemblyProduct("FFXIVClientStructs")]
[assembly: AssemblyTitle("FFXIVClientStructs")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly:AssemblyConfiguration("Release")]
#endif

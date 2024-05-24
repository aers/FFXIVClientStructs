namespace InteropGenerator.Runtime.Attributes;

/// <summary>
/// InteropGenerator attribute marking a method as a stub for calling a native class virtual function.
/// The stub method signature should match the native function, excluding the "this" (nearly always first) argument.
/// </summary>
/// <param name="index">Native function index in the class's virtual table</param>
[AttributeUsage(AttributeTargets.Method)]
public sealed class VirtualFunctionAttribute(uint index) : Attribute {

    public uint Index { get; } = index;
}

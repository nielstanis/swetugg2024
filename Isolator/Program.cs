// Set up an isolated runtime
using System.Runtime.InteropServices;
using DotNetIsolator;

using var host = new IsolatedRuntimeHost().WithBinDirectoryAssemblyLoader();
using var runtime = new IsolatedRuntime(host);

// Output: I'm running on Arm64
Console.WriteLine($"I'm running on {RuntimeInformation.OSArchitecture}");
int i = 0;

Console.WriteLine($"{i}");

runtime.Invoke(() =>
{
    // Output: I'm running on Wasm
    Console.WriteLine($"I'm running on {RuntimeInformation.OSArchitecture}");
    Console.WriteLine($"{i}");
    i++;
    Console.WriteLine($"{i}");
});

Console.WriteLine($"{i}");
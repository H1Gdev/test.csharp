using System;
using System.Runtime.InteropServices;

namespace Framework.Test
{
    class Runtime
    {
        public static void Test(string[] args)
        {
            Console.WriteLine("[S]Runtime Test");

            Console.WriteLine("[RuntimeInformation]");
            Console.WriteLine(".FrameworkDescription=" + RuntimeInformation.FrameworkDescription);
            Console.WriteLine(".OSArchitecture=" + RuntimeInformation.OSArchitecture);
            Console.WriteLine(".OSDescription=" + RuntimeInformation.OSDescription);
            Console.WriteLine(".ProcessArchitecture=" + RuntimeInformation.ProcessArchitecture);
            Console.WriteLine(".IsOSPlatform(Windows)=" + RuntimeInformation.IsOSPlatform(OSPlatform.Windows));
            Console.WriteLine(".IsOSPlatform(Linux)=" + RuntimeInformation.IsOSPlatform(OSPlatform.Linux));
            Console.WriteLine(".IsOSPlatform(OSX)=" + RuntimeInformation.IsOSPlatform(OSPlatform.OSX));
            Console.WriteLine(".IsOSPlatform(FreeBSD)=" + RuntimeInformation.IsOSPlatform(OSPlatform.FreeBSD));
            Console.WriteLine(".IsOSPlatform(ANDROID)=" + RuntimeInformation.IsOSPlatform(OSPlatform.Create("ANDROID")));   // valid ??

            Console.WriteLine("[E]Runtime Test");
        }
    }
}

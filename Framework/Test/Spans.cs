using System;

namespace Framework.Test
{
    class Spans
    {
        // System.Memory
        // https://www.nuget.org/packages/System.Memory
        // for before C# 7.2

        public static void Test(string[] args)
        {
            Console.WriteLine("[S]Spans Test");
            {
                var byteArray = new byte[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                // Span<T>
                {
                    var byteArraySpan = new Span<byte>(byteArray);
                    Console.WriteLine(".Length=" + byteArraySpan.Length);
                    Console.WriteLine("[3]=" + byteArraySpan[3]);
                    {
                        // Slice
                        var span = byteArraySpan.Slice(4, 2);
                        span.Fill(66);
                    }
                    Console.WriteLine("byteArray=[" + string.Join(", ", byteArray) + "]");
                }
                // ReadOnlySpan<T>
                {
                    var byteArraySpan = new ReadOnlySpan<byte>(byteArray);
                    Console.WriteLine(".Length=" + byteArraySpan.Length);
                    Console.WriteLine("[4]=" + byteArraySpan[4]);
                    {
                        // Slice
                        var span = byteArraySpan.Slice(6, 3);
                        Console.WriteLine("[0]=" + span[2]);
                    }
                    Console.WriteLine("byteArray=[" + string.Join(", ", byteArray) + "]");

                    // string -> ReadOnlySpan<char>
                    {
                        // https://docs.microsoft.com/dotnet/api/system.string.op_implicit
                        var testString = "This is test text.";
#if NETCOREAPP2_0
                        ReadOnlySpan<char> span = testString.AsSpan();
#else
                        ReadOnlySpan<char> span = testString;   // OK
#endif
                        Console.WriteLine("span=[" + string.Join(", ", span.ToArray()) + "]");

                        var sliced = span.Slice(8, 4);
                        // To String.(Copy)
                        var test = sliced.ToString();
                        Console.WriteLine("sliced=" + test);
                    }
                }
            }
            {
                // Memory<T>

                // ReadOnlyMemory<T>
            }
            {
                // MemoryExtensions
                var contentLengtHeader = "Content-Length: 132";
                var span = contentLengtHeader.AsSpan();
                Console.WriteLine("span=[" + string.Join(", ", span.ToArray()) + "]");

                if (span.StartsWith("Content-Length"))
                {
                    var index = span.IndexOf(":") + 1;
#if NETCOREAPP2_2
                    var sizeText = span.Slice(index).Trim();
#else
                    var sizeText = span[index..].Trim();
#endif
                    var size = int.Parse(sizeText);
                    Console.WriteLine("size=" + size);
                }

            }
            Console.WriteLine("[E]Spans Test");
        }
    }
}

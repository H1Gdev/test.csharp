using System;

namespace Spec.Test
{
    class Operator
    {
        public static void Test(string[] args)
        {
            Console.WriteLine("[S]Operator Test");

            // No explicit null check. (use ?. ?? default)
            void Func0(TestClass nullable)
            {
                Console.WriteLine($"nullable={nullable?.ToString() ?? "<null>"}");
                // check null
                if (nullable?.Prop != null)
                    Console.WriteLine($"\t{nullable.Prop}");

                // check int
#if false
                if (nullable?.Prop?.Length/* int? */ > 0)
#else
                // the same style as bool
                if ((nullable?.Prop?.Length ?? default)/* int */ > 0)
#endif
                    Console.WriteLine($"\t{nullable.Prop.Length}");

                // check bool
                if (nullable?.Prop?.Contains("a") ?? default)
                    Console.WriteLine($"\t{nullable.Prop}");
            }

            Func0(null);
            Func0(new TestClass(null));
            Func0(new TestClass("aa"));

            Console.WriteLine("[E]Operator Test");
        }

        class TestClass
        {
            public TestClass(string prop)
            {
                Prop = prop;
            }

            public string Prop { get; }

            public override string ToString()
            {
                return $"{{ Prop={Prop ?? "<null>"} }}";
            }
        }
    }
}

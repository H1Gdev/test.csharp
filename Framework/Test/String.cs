using System;

namespace Framework.Test
{
    class String
    {
        public static void Test(string[] args)
        {
            Console.WriteLine("[S]String Test");

            Console.WriteLine("[Check if string is empty or not]");
            static void CheckEmpty(string test)
            {
                Console.WriteLine($"\"{test}\"");

                // [Faster]
                if (test.Length == 0) // (Recommended)
                    Console.WriteLine(".Length == 0");

                if (test == string.Empty)
                    Console.WriteLine(" == string.Empty");
                if (test == "")
                    Console.WriteLine(" == \"\"");

                if (string.Empty.Equals(test))
                    Console.WriteLine("string.Empty.Equals()");
                if ("".Equals(test))
                    Console.WriteLine("\"\".Equals()");
                if (string.Equals(string.Empty, test))
                    Console.WriteLine("string.Equals(string.Empty,)");
                if (string.Equals("", test))
                    Console.WriteLine("string.Equals(\"\",)");
                // [Slower]

                if (string.IsNullOrEmpty(test)) // (Recommended)
                    Console.WriteLine("string.IsNullOrEmpty()");
            }
            static bool IsEmpty(string test)
            {
#if false
                return test != null && test.Length == 0;
#else
                return test?.Length == 0;
#endif
            }

            CheckEmpty("");
            CheckEmpty(string.Empty);
            CheckEmpty("a");

            IsEmpty(null);
            IsEmpty("");
            IsEmpty(string.Empty);
            IsEmpty("a");

            Console.WriteLine("[S]String Test");
        }
    }
}

using System;

namespace Spec.Test
{
    // static class.
    // existing type name + "Extension" is clear.
    static class StringExtension
    {
        // static method.
        public static int WordCount(this string str)
        {
            // may be null...
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // can be defined, but not called implicitly...
        public static string ToString(this string str)
        {
            return "Test of Extension Method.(" + str + ")";
        }

        // overload is fine.
        public static string ToString(this string str, int i)
        {
            return "Test of Extension Method.(" + str + "," + i + ")";
        }
    }

    class ExtensionMethod
    {
        public static void Test(string[] args)
        {
            Console.WriteLine("[S]ExtensionMethod Test");

            try
            {
                string a = null;
                a?.WordCount(); // not call extension.
                a.WordCount();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }

            {
                var a = "This is string.";
                // not call extension.
                Console.WriteLine(".ToString()=" + a.ToString());

                // call extension.
                Console.WriteLine("StringExtension.ToString()=" + StringExtension.ToString(a));
                Console.WriteLine(".ToString()=" + a.ToString(300));
            }

            Console.WriteLine("[E]ExtensionMethod Test");
        }
    }
}

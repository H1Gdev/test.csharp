using System;
using System.Globalization;
using System.Threading;

namespace Framework.Test
{
    class Culture
    {
        public static void Test(string[] args)
        {
            Console.WriteLine("[S]Culture Test");

            Console.WriteLine("InvariantCulture:");
            Output(CultureInfo.InvariantCulture);

            // get, set
            Console.WriteLine("CurrentCulture:");
            Output(CultureInfo.DefaultThreadCurrentCulture);
            Output(CultureInfo.CurrentCulture);
            Output(Thread.CurrentThread.CurrentCulture);

            Console.WriteLine("Create CurrentCulture:");
            Output(new CultureInfo("es-ES"));
            Output(CultureInfo.CreateSpecificCulture("es-ES"));

            Console.WriteLine("[E]Culture Test");
        }

        private static void Output(CultureInfo cultureInfo)
        {
            Console.WriteLine(".Name=" + cultureInfo.Name);
            Console.WriteLine(".NativeName=" + cultureInfo.NativeName);
            Console.WriteLine(".DisplayName=" + cultureInfo.DisplayName);
            Console.WriteLine(".EnglishName=" + cultureInfo.EnglishName);
        }
    }
}

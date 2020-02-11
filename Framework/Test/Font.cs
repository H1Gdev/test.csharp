using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;

namespace Framework.Test
{
    class Font
    {
        public static void Test(string[] args)
        {
            Console.WriteLine("[S]Font Test");

            // FontFamily
            Console.WriteLine("[FontFamily]");
            // Generic FontFamilies.
            Console.WriteLine("GenericSerif:" + FontFamily.GenericSerif.Name);
            Console.WriteLine("GenericSansSerif:" + FontFamily.GenericSansSerif.Name);
            Console.WriteLine("GenericMonospace:" + FontFamily.GenericMonospace.Name);
            using (var fontFamily = new FontFamily(GenericFontFamilies.Serif))
            {
                Console.WriteLine("GenericSerif:" + fontFamily.Name);
            }
            using (var fontFamily = new FontFamily(GenericFontFamilies.SansSerif))
            {
                Console.WriteLine("GenericSansSerif:" + fontFamily.Name);
            }
            using (var fontFamily = new FontFamily(GenericFontFamilies.Monospace))
            {
                Console.WriteLine("GenericMonospace:" + fontFamily.Name);
            }
            // Families
            Console.WriteLine("Families:");
            var families = FontFamily.Families;
            try
            {
                foreach (var fontFamily in families)
                {
                    Console.WriteLine("\t" + fontFamily.Name);
                }

                // Font
                Console.WriteLine("[Font]");
                using (var font = new System.Drawing.Font(families[0], 10f))
                {
                    Console.WriteLine("Name:" + font.Name);
                    Console.WriteLine("FontFamily.Name:" + font.FontFamily.Name);
                }
                // do not dispose FontFamily.
            }
            finally
            {
                families.ToList().ForEach(f => f.Dispose());
            }

            // InstalledFontCollection
            using (var collection = new InstalledFontCollection())
            {
                Console.WriteLine("[InstalledFontCollection]");
                Output(collection);
            }

            // PrivateFontCollection
            FontFamily[] privateFontFamilies = null;
            using (var collection = new PrivateFontCollection())
            {
                var fontFile = "BrushScriptMT2.ttf";
                var fontFilePath = Path.Combine(@"..\", fontFile);
                if (File.Exists(fontFilePath))
                {
                    // If add font files, cannot remove them until process is terminated.
                    // Even if dispose PrivateFontCollection...
                    collection.AddFontFile(fontFilePath);

                    // load only a FontCollection.
                    using (var fontFamily = new FontFamily("Brush Script MT2", collection))
                    {
                        Console.WriteLine("Brush Script MT2:" + fontFamily.Name);
                    }

                    privateFontFamilies = collection.Families;
                }

                Console.WriteLine("[PrivateFontCollection]");
                Output(collection);
            }
            // FontFamilies in PrivateFontCollection can be independent!
            if (privateFontFamilies != null)
            {
                Console.WriteLine("[FontFamilies in PrivateFontCollection]");
                foreach (var fontFamily in privateFontFamilies)
                {
                    using (var font = new System.Drawing.Font(fontFamily, 12f))
                    {
                        Console.WriteLine(font.Name);
                    }
                    fontFamily.Dispose();
                }
            }

            // SystemFonts
            Console.WriteLine("[SystemFonts]");
            Console.WriteLine(".DefaultFont:" + SystemFonts.DefaultFont.Name);
            Console.WriteLine(".MenuFont:" + SystemFonts.MenuFont.Name);
            Console.WriteLine(".StatusFont:" + SystemFonts.StatusFont.Name);
            // etc.

            Console.WriteLine("[E]Font Test");
        }

        private static void Output(FontCollection fontCollection)
        {
            foreach (var fontFamily in fontCollection.Families)
            {
                Console.Write("\t" + fontFamily.Name);
#if false
                // has no effect...
                Console.WriteLine("\t" + fontFamily.GetName(0));
#endif
                // Style
                Console.Write(" (");
                var styles = new StringBuilder();
                foreach (FontStyle style in Enum.GetValues(typeof(FontStyle)))
                    if (fontFamily.IsStyleAvailable(style))
                    {
                        if (styles.Length > 0)
                            styles.Append(" ");
                        styles.Append(style);
                    }
                Console.Write(styles);
                Console.WriteLine(")");
            }
        }
    }
}

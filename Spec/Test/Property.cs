using System;

namespace Spec.Test
{
    // Property and Indexer.

    class Property
    {
        public static void Test(string[] args)
        {
            Console.WriteLine("[S]Property Test");

            Console.WriteLine("[E]Property Test");
        }
    }

    class Test
    {
        private int _value0 = 100;
        public int Value0
        {
            get
            {
                return _value0;
            }
            set
            {
                _value0 = value;
            }
        }

        public int Value1
        {
            get;
            set;
        }

        private int _value2 = 10;
        public int Value2
        {
            get => _value2;
            set => _value2 = value;
        }
    }

    class Test2
    {
        private int _value0 = 100;
        public int Value0
        {
            get
            {
                return _value0;
            }
#if true
            set
            {
                _value0 = value;
            }
#endif
        }

        public int Value1
        {
            get;
            // if auto-implemented properties, can set properties in constructor without 'set'.
#if false
            set;
#elif false
            private set;
#endif
        }

        public Test2()
        {
            Value0 = 100;
            Value1 = 100;
        }
    }
}

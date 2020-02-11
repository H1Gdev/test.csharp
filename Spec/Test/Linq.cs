using System;
using System.Collections.Generic;
using System.Linq;

namespace Spec.Test
{
    class Linq
    {
        public static void Test(string[] args)
        {
            Console.WriteLine("[S]Linq Test");

            var numbers = Enumerable.Range(0, 10);
            var squares = numbers.Select(n => n * n);

            // LINQ query
            // https://docs.microsoft.com/dotnet/csharp/language-reference/keywords/query-keywords
            var numbers1 = from n in numbers select n * 2;
            {
                // where
                var even = from n in numbers where n % 2 == 0 select n;
                var odd = from n in numbers where n % 2 != 0 select n;

                // group
                var groups = from s in squares let str = s.ToString() group s by str[0];

                // orderby
#if false
                var ascending = from n in numbers orderby n ascending select n;
#else
                var ascending = from n in numbers orderby n select n;
#endif
                var descending = from n in numbers orderby n descending select n;
            }

            // LINQ methods
            var numbers2 = numbers.Select(n => n * 2);
            {
                // Where
                var even = numbers.Where(n => n % 2 == 0).Select(n => n);
                var odd = numbers.Where(n => n % 2 != 0).Select(n => n);

                // GroupBy
                var groups = squares.GroupBy(s => { var str = s.ToString(); return str[0]; });

                // OrderBy, OrderByDescending
                var ascending = numbers.OrderBy(n => n);
                var descending = numbers.OrderByDescending(n => n);
                // ThenBy, ThenByDescending
                var ascending2 = numbers.OrderBy(n => n).ThenBy(n => n);
                var descending2 = numbers.OrderBy(n => n).ThenByDescending(n => n);
            }

            // Result collections
            {
                // int[]
                var array = numbers.ToArray();
                // List<int>
                var list = numbers.ToList();
#if false
                // Dictionary<int, int>
                var dictionary = numbers.ToDictionary(n => n);
#else
                // Dictionary<int, string>
                var dictionary = numbers.ToDictionary(n => n, n => n.ToString());
#endif
                // HashSet<int>
                var hashSet = numbers.ToHashSet();
                // Lookup<int, int>
                var lookup = numbers.ToLookup(n => n);
            }

            // index
            {
#if false
                // not useful...
                var indices1 = from i in Enumerable.Range(0, square.Count()) select i;
#else
                var indices1 = from s in squares.Select((s, i) => new { s, i }) select s.i;
#endif
                var indices2 = squares.Select((s, i) => i);
            }

            // Empty
            {
                var empty = Enumerable.Empty<int>();

                // Is empty
                var isEmpty = !empty.Any();
            }
            // Repeat or One
            {
                var one = Enumerable.Repeat(100, 1);
                // not copy.
                var many = Enumerable.Repeat(100, 10);

                var empty = Enumerable.Repeat(100, 0);
            }

            // First, Last, Rest
            {
                // throw exception if return no elements.
                Console.WriteLine(".First()=" + numbers.First());
                Console.WriteLine(".First()=" + numbers.First(n => n - 2 > 0));
                Console.WriteLine(".Last()=" + numbers.Last());
                Console.WriteLine(".Last()=" + numbers.Last(n => n - 2 > 0));

                Console.WriteLine(".FirstOrDefault()=" + numbers.FirstOrDefault());
                Console.WriteLine(".FirstOrDefault()=" + numbers.FirstOrDefault(n => n - 200 > 0));
                Console.WriteLine(".LastOrDefault()=" + numbers.LastOrDefault());
                Console.WriteLine(".LastOrDefault()=" + numbers.LastOrDefault(n => n - 200 > 0));

                var rest = numbers.Skip(1);
                var restLast = numbers.SkipLast(1);
            }
            // Single
            {
                var one = Enumerable.Repeat(100, 1);

                // throw exception if return no elements or not only one.
                Console.WriteLine(".Single()=" + one.Single());
                Console.WriteLine(".Single()=" + one.Single(n => n == 100));

                // throw exception if not only one.
                Console.WriteLine(".Single()=" + one.SingleOrDefault());
                Console.WriteLine(".Single()=" + one.SingleOrDefault(n => n != 100));
            }

            // ForEach
            {
                // only List.
                numbers.ToList().ForEach(n => Console.WriteLine("ForEach:" + n));
            }

            // Contains
            {
                var fruits = new string[] { "Apple", "Banana", "Mango", "Orange", "Passionfruit", "Grape" };
                var fruit = "Mango";

                Console.WriteLine(".Contains(" + fruit + ")=" + fruits.Contains(fruit));
                Console.WriteLine(".Contains(" + fruit.ToLower() + ")=" + fruits.Contains(fruit.ToLower()));
                Console.WriteLine(".Contains(" + fruit.ToUpper() + ")=" + fruits.Contains(fruit.ToUpper()));

#if false
                var comparer = StringComparer.Create(System.Globalization.CultureInfo.InvariantCulture, true);
#elif false
                var comparer = StringComparer.Create(System.Globalization.CultureInfo.InvariantCulture, System.Globalization.CompareOptions.IgnoreCase);
#else
                var comparer = StringComparer.InvariantCultureIgnoreCase;
#endif
                Console.WriteLine(".Contains(" + fruit + ")=" + fruits.Contains(fruit, comparer));
                Console.WriteLine(".Contains(" + fruit.ToLower() + ")=" + fruits.Contains(fruit.ToLower(), comparer));
                Console.WriteLine(".Contains(" + fruit.ToUpper() + ")=" + fruits.Contains(fruit.ToUpper(), comparer));
            }

            // OfType
            {
                var objects = new object[] { 10, "Apple", 1, "Banana", 88, "Mango", 2f, "Orange", 99, "Passionfruit", 0, "Grape" };
                var strings = objects.OfType<string>();
                var floats = objects.OfType<float>();
                var ints = objects.OfType<int>();
            }

            // Lambda
            {
#if false
                // can not use var...
                var lambda = () => 2;
#else
#if false
                // use delegate.

                // System.Func<>   -> return values.
                // System.Action<> -> not return values.
                //
                // System.Predicate<T>
                // System.Comparison<T>
                // System.Converter<TInput,TOutput>
                Func<int> lambda = () => 2;

                // execute.
                var result = lambda();
                var result2 = lambda.Invoke();
#else
                // use local function.
                // https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/local-functions
#if true
                static int lambda() => 2;
#else
                static int lambda() { return 2; }
#endif
                // execute.
                var result = lambda();
#endif
#endif
            }

            // Anonymous type
            // https://docs.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/anonymous-types
            {
                var anonymous = new { };
                Console.WriteLine("anonymous=" + anonymous + "(" + anonymous.GetType().Name + ")");

                // int -> Anonymous type
                var temp1 = from n in numbers select new { Number = n, String = n.ToString(), n };
                var temp2 = numbers.Select(n => new { Number = n, String = n.ToString(), n });
            }

            Console.WriteLine("[E]Linq Test");
        }
    }
}

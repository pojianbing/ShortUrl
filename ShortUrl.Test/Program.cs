using System;
using System.Linq;
using System.Collections.Generic;

namespace ShortUrl.Test
{
    class Program
    {
        private static readonly List<char> DIGITS = new List<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        static void Main(string[] args)
        {
            var random = new Random();
            var initUrl = "";

            var total = 1000000;
            var codes = new List<string>();

            for (var i = 0; i < total; i++)
            {
                var index = random.Next(0, DIGITS.Count);
                initUrl += DIGITS[index];
                var hashCode = ShortUrl.Core.ShortUrlHelper.ToShrotId(initUrl);
                codes.Add(hashCode);
                Console.WriteLine(i);

                if (i % 100000 == 0)
                {
                    var same = codes.Distinct().Count() == i + 1;
                    Console.WriteLine(same);
                    Console.WriteLine(codes.Distinct().Count());
                    Console.ReadKey();
                }
            }

           



            Console.ReadKey();
        }
    }
}

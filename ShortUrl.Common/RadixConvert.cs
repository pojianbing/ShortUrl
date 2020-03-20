using System;
using System.Collections.Generic;
using System.Text;

namespace ShortUrl.Common
{
    /// <summary>
    /// 进制转换
    /// </summary>
    public class RadixConvert
    {
        #region 常量,变量区域

        private static readonly List<char> DIGITS = new List<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D',
            'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N',
            'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        #endregion

        #region 62进制

        /// <summary>
        /// 10进制转换为62进制
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string To62Radix(long num)
        {
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                int remainder = (int)(num % 62);
                sb.Insert(0, DIGITS[remainder]);
                num = num / 62;
                if (num == 0)
                {
                    break;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 从62进制转为10进制
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long From62Radix(string str)
        {
            long sum = 0L;
            int len = str.Length;
            for (int i = 0; i < len; i++)
            {
                var digitNum = DIGITS.IndexOf(str[len - i - 1]);
                var radix = (long)Math.Pow((double)62, (double)i);
                sum += digitNum * radix;
            }
            return sum;
        }

        #endregion
    }
}

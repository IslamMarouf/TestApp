using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1 {
    internal class Program {
        public static void Main(string[] args) {
            List<int> numbers = new List<int> {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 2, 5,
                2, 6, 7, 9, 10, 11, 2, 4, 6, 4,
                5, 12, 14, 13, 7, 8, 9, 10, 20,
                21, 22, 1, 4, 5, 7, 9, 8, 6, 7,
                8, 9, 10, 1, 2, 5, 6, 10, 22, 13
            };

            Console.WriteLine(GetRangeString(numbers));
            Console.WriteLine("===> " + numbers.First());
        }

        public static string GetRangeString(List<int> list) {
            // Return fast if list is null or contains less than 2 items
            if (list == null || !list.Any()) return string.Empty;
            if (list.Count == 1) return list[0].ToString();

            var rangeString = new StringBuilder();
            bool isRange = false;
            int count = 0;
            int difference = 0;
            string insert = string.Empty;

            for (int i = 0; i < list.Count; i++) {
                while (i < list.Count - 1 && list[i] + 1 == list[i + 1]) {
                    if (!isRange) {
                        rangeString.Append($"{list[i]}");
                    }

                    isRange = true;
                    ++count;
                    i++;
                }


                insert += " " + count + " ";

                if (isRange) {
                    rangeString.Append("-");
                    rangeString.Append($"{list[i]} ( " + count + " days),");
                    isRange = false;
                    count = 0;
                }

                rangeString.Append($"{list[i]},");
            }

            string str = rangeString.ToString().TrimEnd(',');

            int n = 0;


            char[] charArray = str.ToCharArray();

            for (int i = 0; i < str.Length; i++) {
                if (str[i].Equals('-')) {
                    n = i;

                    while (!str[n].Equals(',') && n > 0) {
                        n--;
                    }

                    if (str[n] == ',')
                        charArray[n] = '#';
                }
            }

            string str2 = string.Empty;

            foreach (var character in charArray) {
                str2 += character;
            }

            str2 = str2.Replace("#", " from ");
            str2 = str2.Replace("-", " to ");

            return str2;
        }

        static int Diff(int x, int y) => y - x;
    }
}

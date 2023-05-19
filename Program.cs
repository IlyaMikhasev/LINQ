using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public static class StringExtension
    {
        public static int CharCount(this string str, char _symbol)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == _symbol)
                    counter++;
            }
            return counter;
        }
        public static string Cezar(this string str, int C, out string input){//доделать для кирилицы
            input = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (((int)str[i] >= (int)'A' && (int)str[i] <= (int)'Z') || ((int)str[i] >= (int)'a' && (int)str[i] <= (int)'z'))
                {
                    if (((int)str[i] + C > (int)'Z' && (int)str[i] < (int)'a') || (int)str[i] + C > (int)'z')
                    {
                        input += (char)((int)str[i]+ C - 26); 
                    }
                    else
                    {
                        input += (char)(str[i] + C);
                    }
                }
                else
                    input += str[i];
            }
            return input;
        }
    }
    internal class Program
    {
        static public IEnumerable<char> myReverse(IEnumerable<char> _text, char math)
        {
            int number = (from c in _text where c == math select c).Count();
            return _text.Reverse<char>();
        }

        static void Main(string[] args)
        {

            string text = "ABCDEFGHIJKLMNOPQRDTUVWXYZ";
            char symb = 'o';
            Console.WriteLine($"В {text} символ {symb} встречается {text.ToLower().CharCount(symb)} раз");
            Console.WriteLine(text.Cezar(3, out string input));
        }
    }
}

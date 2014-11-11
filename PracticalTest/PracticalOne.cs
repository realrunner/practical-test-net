using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PracticalTest
{
    public class PracticalOne : IPracticalOne
    {
        public String ReverseWordsInString(String words)
        {
            if (string.IsNullOrEmpty(words))
                return words;

            var reversed = words.Split(' ').Aggregate("", (current, word) => word + " " + current);

            return reversed.Trim();
        }

        public int DoCalculation(String expression)
        {
            var tokens = Regex.Split(expression, @"([\\+\\-])");

            if (tokens.Length == 1)
                return parseNum(expression);

            var stack = new Stack<String>();
            foreach (var token in tokens)
            {
                stack.Push(token);
                if (stack.Count == 3)
                {
                    int and1 = parseNum(stack.ElementAt(2));
                    String op = stack.ElementAt(1);
                    int and2 = parseNum(stack.ElementAt(0));
                    int result = 0;
                    if (op == "+")
                    {
                        result = and1 + and2;
                    }
                    else if (op == "-")
                    {
                        result = and1 - and2;
                    }
                    stack.Clear();
                    stack.Push("" + result);
                }
            }

            return parseNum(stack.Peek());
        }

        public bool IsPalindrome(String palindrome)
        {
            char[] chars = palindrome.ToLower().ToCharArray();
            for (int i = 0, j = (chars.Length - 1); i < (chars.Length / 2); i++, j--)
            {
                if (chars[i] != chars[j])
                {
                    return false;
                }
            }
            return true;
        }

        private int parseNum(String number)
        {
            try
            {
                return int.Parse(number);
            }
            catch (FormatException)
            {
                Console.WriteLine("Oops, can't parse " + number + " as a number!");
                throw;
            }
        }
    }
}

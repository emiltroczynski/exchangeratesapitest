using System;
using System.Linq;

namespace TaskFromGain.ReverseTask
{
    class Utils
    {
        public static string Reverse(string text)
        {
            return string.Join(" ", text.Split(" ").Reverse());
        }
    }
}

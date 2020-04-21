using System;
using System.Linq;

namespace TaskFromGain.ReverseTask
{
    class Utils
    {
        public static string Reverse(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                return "";
            }
            return string.Join(" ", text.Split(" ").Reverse());
        }
    }
}

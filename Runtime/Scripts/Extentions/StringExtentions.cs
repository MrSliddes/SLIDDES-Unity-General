using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SLIDDES
{
    public static class StringExtentions
    {
        /// <summary>
        /// Get the n index of a char from a string
        /// </summary>
        /// <param name="s">String to check</param>
        /// <param name="c">The char character</param>
        /// <param name="index">Which occurrence index</param>
        /// <param name="caseSpecific">If to check if the string char matches the c char uppercase/lowercase</param>
        /// <returns>The position of the char in the string starting at 0. -1 if failed to find it.</returns>
        /// <seealso>s.Split(char)[index]</seealso>
        public static int GetNthCharIndex(this string s, char c, int index, bool caseSpecific = false)
        {
            // Loops trough string, checking for the char, if it found char increase count till it matches with index            
            int count = 0;
            for(int i = 0; i < s.Length; i++)
            {
                if(caseSpecific ? s[i] == c : s[i].ToString().ToLower()[0] == c.ToString().ToLower()[0])
                {
                    count++;
                    if(count == index)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Get every character from a string before specified char
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <param name="stopAt">The character to stop at</param>
        /// <returns>The string before specified character</returns>
        public static string GetUntilOrEmpty(this string s, string stopAt)
        {
            if(!string.IsNullOrWhiteSpace(s))
            {
                int charLocation = s.IndexOf(stopAt, StringComparison.Ordinal);

                if(charLocation > 0)
                {
                    return s.Substring(0, charLocation);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Get a string between 2 strings
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <param name="prefix">The part before the string to get</param>
        /// <param name="suffix">The part after the string to get</param>
        /// <returns>The string between prefix and suffix</returns>
        /// <example>value1value2valu3.SubstringBetween(value1, value3) -> value2</example>
        public static string SubstringBetween(this string s, string prefix, string suffix)
        {
            int p1 = s.IndexOf(prefix) + prefix.Length;
            int p2 = s.IndexOf(suffix, p1);

            if(suffix == "") return (s.Substring(p1));
            else return s.Substring(p1, p2 - p1);
        }
    }
}

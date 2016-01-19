using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    using System;
    using System.Globalization;
    using System.Text;
    using Random = UnityEngine.Random;

    public static class HelperClass
    {
        public static bool IsNullOrEmpty<T>(this IList<T> list )
        {
            return (list == null || list.Count == 0);
        }

       public static bool IsNullEmptyOrWhitespace(this string s)
       {
           return s == null || s.Trim().Equals(String.Empty);
       }

        public static void Shuffle<T>(this IList<T> list)
        {
            if (list == null) return;
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0,n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static string ArrayToString(this object[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object o in array)
                sb.Append(o + ";");
            return sb.ToString().Trim(';');
        }
        public static string ArrayToString(this int[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int o in array)
                sb.Append(o + ";");
            return sb.ToString().Trim(';');
        }

        // int i = 1000; i.ToStringWithSeperators();
        public static string ToStringWithSeperators(this int i)
        {
            CultureInfo dutchCulture = CultureInfo.CreateSpecificCulture("nl-NL");
            return String.Format(dutchCulture, "{0:n0}", i);
        }

        public static string ValueToStringWithSeperators(object value)
        {
            CultureInfo dutchCulture = CultureInfo.CreateSpecificCulture("nl-NL");
            return String.Format(dutchCulture, "{0:n0}", value);
        }

        public static bool PauseGame()
        {
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Time.timeScale = 0f;
            }

            return Time.timeScale == 1f;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Assets
{
    using System;
    using System.Globalization;
    using System.Text;
    using Random = UnityEngine.Random;

    public static class HelperClass
    {
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
#if (!UNITY_WP8_1 && !UNITY_WP_8_1 && !UNITY_WP8 && !UNITY_WSA_8_1)
            CultureInfo dutchCulture = CultureInfo.CreateSpecificCulture("nl-NL");
            return String.Format(dutchCulture, "{0:n0}", i);
#else
            return i.ToString();
#endif
        }

        public static string ValueToStringWithSeperators(object value)
        {
#if (!UNITY_WP8_1 && !UNITY_WP_8_1 && !UNITY_WP8 && !UNITY_WSA_8_1)
            CultureInfo dutchCulture = CultureInfo.CreateSpecificCulture("nl-NL");
            return String.Format(dutchCulture, "{0:n0}", value);
#else
            return value.ToString();
#endif
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

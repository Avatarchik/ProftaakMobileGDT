using System.Collections.Generic;

namespace Assets.Scripts.Helpers
{
    using System;
    using Random = UnityEngine.Random;

    public static class ExtensionMethods
    {
        public static bool IsNullOrEmpty<T>(this List<T> list )
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
    }
}

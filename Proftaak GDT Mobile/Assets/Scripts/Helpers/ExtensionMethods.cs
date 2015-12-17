using System.Collections.Generic;

namespace Assets.Scripts.Helpers
{
   public static class ExtensionMethods
    {
        public static bool IsNullOrEmpty<T>(this List<T> list )
        {
            return (list == null || list.Count == 0);
        }


    }
}

using System;
using System.Collections.Generic;

namespace Extensions
{
    public static class ArrayExtensions
    {
        public static T Random<T>(this T[] array)
        {
            int randomIndex = UnityEngine.Random.Range(0, array.Length);
            return array[randomIndex];
        }
    }
}
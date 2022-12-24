using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace GameJamKit.Scripts.Utils.Extensions
{
    public static class ListExtensions
    {
        public static T RandomItem<T>(this IList<T> list)
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("Cannot select a random item from an empty list");
            return list[Random.Range(0, list.Count)];
        }

        public static T RemoveRandom<T>(this IList<T> list)
        {
            if (list.Count == 0)
                throw new IndexOutOfRangeException("Cannot remove a random item from an empty list");
            var index = Random.Range(0, list.Count);
            var item = list[index];
            list.RemoveAt(index);
            return item;
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            var rng = new System.Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}
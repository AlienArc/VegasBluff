using System;
using System.Collections.Generic;
using Sony.Vegas;
using VegasTools.Models;

namespace VegasTools.Helpers
{
    public static class ListHelpers
    {
        public static void Shuffle<T>(IList<T> list, Random random, Action<SchuffleInfo<T>> onShuffleAction = null)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var j = random.Next(i, list.Count);
                var temp = list[j];
                list[j] = list[i];
                list[i] = temp;
                if (onShuffleAction != null)
                {
                    var si = new SchuffleInfo<T>();
                    si.OriginalItem = list[j];
                    si.NewItem = list[i];
                    si.Index = i;
                    onShuffleAction(si);
                }
            }
        }

        public struct SchuffleInfo<T>
        {
            public T OriginalItem;
            public T NewItem;
            public int Index;
        }
    }
}
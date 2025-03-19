using System;
using System.Collections.Generic;

namespace GardenOfDreamsTestProject.Scripts.Core.Extensions
{
    public static class CollectionsExtensions
    {
        public static T BinarySearch<T>(this IReadOnlyList<T> collection, Func<T, int> comparer, out int index)
        {
            if (collection == null || comparer == null)
            {
                index = -1;
                return default;
            }
            
            index = collection.Count / 2;
            int compareResult;
            while ((compareResult = comparer(collection[index])) != 0)
            {
                var indexOffset = (collection.Count - index) / 2;
                if(indexOffset == 0) break;
                
                if (compareResult > 0)
                {
                    index += indexOffset;
                }
                else
                {
                    index -= indexOffset;
                }
            }

            if (compareResult != 0)
                return default;

            return collection[index];
        } 
    }
}
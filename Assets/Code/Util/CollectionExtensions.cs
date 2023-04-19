using System.Collections.Generic;
using System.Linq;

namespace Miniclip.Util
{
    public static class CollectionExtensions
    {
        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            var array = enumerable.ToArray();

            return array.Length > 0 ? array[UnityEngine.Random.Range(0, array.Length)] : default;
        }
    }
}
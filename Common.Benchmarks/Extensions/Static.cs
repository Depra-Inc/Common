using System.Collections.Generic;
using System.Linq;

namespace Depra.Common.Benchmarks.Extensions;

internal static class Static
{
    public static List<Item> NewList(int count) => NewArray(count).ToList();

    public static IEnumerable<Item> NewEnumerable(int count) => NewArray(count);

    public static Item[] NewArray(int count)
    {
        var array = new Item[count];
        for (var index = 0; index < count; index++)
        {
            array[index] = new Item(index);
        }

        return array;
    }
}
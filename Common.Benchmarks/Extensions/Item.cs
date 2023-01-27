using System;

namespace Depra.Common.Benchmarks.Extensions;

public sealed class Item : IComparable<Item>
{
    public readonly int Number;

    public Item(int number) => Number = number;

    public int CompareTo(Item other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        return ReferenceEquals(null, other) ? 1 : Number.CompareTo(other.Number);
    }
}
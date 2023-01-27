using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Depra.Common.Extensions.Collections;
using static Depra.Common.Benchmarks.Extensions.Static;

namespace Depra.Common.Benchmarks.Extensions;

public class MinByBenchmarks
{
    private const int COLLECTION_SIZE = 10;

    private Item[] _itemsArray;
    private List<Item> _itemsList;
    private IEnumerable<Item> _items;

    [GlobalSetup]
    public void Setup()
    {
        _itemsList = NewList(COLLECTION_SIZE);
        _itemsArray = NewArray(COLLECTION_SIZE);
        _items = NewEnumerable(COLLECTION_SIZE);
    }

    [Benchmark(Baseline = true)]
    public Item MinBy_Linq() =>
        Enumerable.MinBy(_items, x => x.Number);

    [Benchmark]
    public Item MinBy_List() =>
        _itemsList.MinBy(x => x.Number);

    [Benchmark]
    public Item MinBy_Array() =>
        _itemsArray.MinBy(x => x.Number);

    [Benchmark]
    public Item MinBy_Enumerable() =>
        EnumerableExtensions.MinBy(_items, x => x.Number);
}
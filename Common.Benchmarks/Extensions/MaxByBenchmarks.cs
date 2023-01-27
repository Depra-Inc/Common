using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Depra.Common.Extensions.Collections;
using static Depra.Common.Benchmarks.Extensions.Static;

namespace Depra.Common.Benchmarks.Extensions;

public class MaxByBenchmarks
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
    public Item MaxBy_Linq() => 
        Enumerable.MaxBy(_items, x => x.Number);

    [Benchmark]
    public Item MaxBy_List() => 
        _itemsList.MaxBy(x => x.Number);

    [Benchmark]
    public Item MaxBy_Array() => 
        _itemsArray.MaxBy(x => x.Number);

    [Benchmark]
    public Item MaxBy_Enumerable() => 
        EnumerableExtensions.MaxBy(_items, x => x.Number);
}
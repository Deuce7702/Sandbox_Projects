using BenchmarkDotNet.Attributes;

namespace Make_a_Faster_Linq
{
    [MemoryDiagnoser(false)]
    public class Benchmarks
    {
        private static readonly int[] data = Enumerable.Range(0, 1000).ToArray();

        [Benchmark]
        public int ForLoop()
        {
            Span<int> _data = new Span<int>(data);
            var length = _data.Length;
            var sum = 0;
            for (int i = 0; i < length; i++)
            {
                sum += _data[i];
            }
            return sum;
        }
        [Benchmark]
        public int SumLinq()
        {
            return data.Sum();
        }
        [Benchmark]
        public int SimdLinq_()
        {
            return SimdLinq.SimdLinqExtensions.Sum(data);
        }
        [Benchmark]
        public double AverageLinq()
        {
            return data.Average();
        }
        [Benchmark]
        public double SimdLinqAverage_()
        {
            return SimdLinq.SimdLinqExtensions.Average(data);
        }
        [Benchmark]
        public int WhereSumLinq()
        {
            return data.Where<int>(x=>x % 2 == 0).Sum();
        }
        [Benchmark]
        public int SimdLinqWhere()
        {
            return SimdLinq.SimdLinqExtensions.Sum(data.Where<int>(x=>x % 2 == 0).ToArray<int>());
        }
    }
}

using BenchmarkDotNet.Running;
using SimdLinq;

namespace Make_a_Faster_Linq
{
    /**
     * We are using BenchmarkDotNet to run the benchmarks.
     * BenchmarkDotNet will run the benchmarks and provide the results.
     * We watch the difference of for,linq and SimdLinq nuget package.
     * The SimdLinq nuget package is faster than linq.
     * https://www.youtube.com/watch?v=5JKhNV9TY8k
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarks>();

            (int min, int max) GetMinMax(int[] data)
            {
                return data.MinMax();
            }
        }
    }
}

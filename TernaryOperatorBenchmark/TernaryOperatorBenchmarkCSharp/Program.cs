using System;
using System.Diagnostics;


namespace TernaryOperatorBenchmarkCSharp
{
    class Program
    {
        static Int64[] arrInt64 = new Int64[] { 3, 4 };
        static Double[] arrDouble = new Double[] { 3.0, 4.0 };

        static Int64 IntTernaryOp(Int64 value)
        {
            return (value==1) ? 3 : 4;
        }

        static Int64 IntArrayOp(Int64 value)
        {
            return arrInt64[value];
        }

        static double FloatTernaryOp(Int64 value)
        {
            return (value == 1) ? 3.0f : 4.0f;
        }

        static double FloatArrayOp(Int64 value)
        {
            return arrDouble[value];
        }

        static void DisplayElapseTime(string title, TimeSpan ts, double result)
        {
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0}{1:000}ms",
                ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine(title + ": " + elapsedTime + ", result:" + result);
        }
        static void DisplayElapseTime(string title, TimeSpan ts, Int64 result)
        {
            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0}{1:000}ms",
                ts.Seconds,
                ts.Milliseconds);
            Console.WriteLine(title + ": " + elapsedTime + ", result:" + result);
        }

        static void Main(string[] args)
        {
            const int MAX_LOOP = 1000000000;

            Int64 sum = 0;
            double sum_f = 0.0;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            sum = 0;
            for (Int64 k = 0; k < MAX_LOOP; ++k)
            {
                sum += IntTernaryOp(k % 2);
            }
            stopWatch.Stop();
            DisplayElapseTime("IntTernaryOp", stopWatch.Elapsed, sum);

            stopWatch = new Stopwatch();
            stopWatch.Start();
            sum = 0;
            for (Int64 k = 0; k < MAX_LOOP; ++k)
            {
                sum += IntArrayOp(k % 2);
            }
            stopWatch.Stop();
            DisplayElapseTime("IntArrayOp", stopWatch.Elapsed, sum);

            stopWatch = new Stopwatch();
            stopWatch.Start();
            sum_f = 0;
            for (Int64 k = 0; k < MAX_LOOP; ++k)
            {
                sum_f += FloatTernaryOp(k % 2);
            }
            stopWatch.Stop();
            DisplayElapseTime("FloatTernaryOp", stopWatch.Elapsed, sum_f);

            stopWatch = new Stopwatch();
            stopWatch.Start();
            sum_f = 0;
            for (Int64 k = 0; k < MAX_LOOP; ++k)
            {
                sum_f += FloatArrayOp(k % 2);
            }
            stopWatch.Stop();
            DisplayElapseTime("FloatArrayOp", stopWatch.Elapsed, sum_f);


        }
    }
}

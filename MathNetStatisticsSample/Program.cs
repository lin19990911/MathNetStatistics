using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MathNet.Numerics.Statistics;
using System.Diagnostics;

namespace MathNetStatisticsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            string I;
            var sw = new Stopwatch();
            var rnd = new System.Random();
            Console.WriteLine("人数をしてください: \r");
            Console.WriteLine("------------------------\n");
            int Data = int.Parse(Console.ReadLine());
            int i;
            double fa = 0;
            double[] data = new double[Data];
            Console.WriteLine("{0}名のテストの点数を入れてください: \r", Data);
            Console.WriteLine("------------------------\n");
            for (i = 0; i < Data; i++)
            {

                Console.WriteLine("数字を入力してください: ");
                I = Console.ReadLine();

                while (!double.TryParse(I, out fa))
                {
                    Console.WriteLine("適切ではない文字です。 数字を打ち込んでEnterを押してください: ");
                    I = Console.ReadLine();
                }
                data[i] = fa;
            }
            //for (i = 0; i < 10; i++)
            //{
            //    data[i] = rnd.NextDouble();
            //   Console.Write(data[i] + ",");
            //}
            //標本標準偏差
            sw.Start();
            var stddiv = Statistics.StandardDeviation(data);
            sw.Stop();
            Console.WriteLine("Standard Deviation = {0}", stddiv);
            Console.WriteLine("{1}件入力で標本標準偏差の計算時間: {0}", sw.Elapsed, i);
            //母標準偏差
            sw.Reset();
            sw.Start();
            var pstddiv = Statistics.PopulationStandardDeviation(data);
            sw.Stop();
            Console.WriteLine("Population Standard Deviation = {0}", pstddiv);
            Console.WriteLine("{1}件入力で母標準偏差の計算時間: {0}", sw.Elapsed, i);
            //標本分散
            var variance = Statistics.Variance(data);
            Console.WriteLine("Variance = {0}", variance);
            //母分散
            var pVariance = Statistics.PopulationVariance(data);
            Console.WriteLine("Population Variance = {0}", pVariance);
            //最大値・最小値
            var max = Statistics.Maximum(data);
            Console.WriteLine("Maximum = {0}", max);
            var min = Statistics.Minimum(data);
            Console.WriteLine("Minimum = {0}", min);
            //平均
            var mean = Statistics.Mean(data);
            Console.WriteLine("Mean = {0}", mean);
            //メジアン(中央値)
            var median = Statistics.Median(data);
            Console.WriteLine("Median = {0}", median);
            //順序統計量
            var orderStatistic = Statistics.OrderStatistic(data, 123);
            Console.WriteLine("Order Statisitc(i-Order = 123) = {0}", orderStatistic);

            Console.ReadLine();

        }
    }
}
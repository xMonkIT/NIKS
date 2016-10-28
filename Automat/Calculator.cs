using System;
using System.Collections.Generic;
using System.Linq;

namespace Automat
{
    class Calculator
    {
        public static IEnumerable<IEnumerable<double>> GetMatrix(double lambda, double mu, int count) =>
            Enumerable
                .Range(0, (int) Math.Pow(2, count))
                .Select(row => Enumerable
                        .Range(0, (int) Math.Pow(2, count))
                        .Select(cell => Enumerable
                                .Range(0, count)
                                .Select(bit => new Tuple<int, int>((row >> bit) & 1, (cell >> bit) & 1))
                                .Select(tuple => tuple.Item1 == tuple.Item2
                                        ? tuple.Item1 == 0
                                            ? Math.Exp(-lambda)
                                            : Math.Exp(-mu)
                                        : tuple.Item1 == 1
                                            ? 1 - Math.Exp(-mu)
                                            : 1 - Math.Exp(-lambda)
                                )
                                .Aggregate((acc, x) => acc*x)
                        )
                );

        public static double GetUptime(IEnumerable<IEnumerable<double>> data)
        {
            var matrix = data.Select(x => x.ToList()).ToList();
            var count = matrix.Count - 1;
            var prevUptime = new List<double> {1};
            prevUptime.AddRange(Enumerable.Range(0, matrix.Count - 1).Select(x => 0.0));
            while (true)
            {
                var uptime = Enumerable
                    .Range(0, matrix.Count)
                    .Select(i => prevUptime.Select((cell, j) => cell*matrix[j][i]).Sum())
                    .ToList();

                if (uptime.Select((x, i) => Math.Abs(prevUptime[i] - x) < Math.Pow(10, -6)).All(x => x)) break;

                prevUptime = uptime;
            }

            return prevUptime.Take(count).Sum();
        }

        public static IEnumerable<Tuple<int, double>> GetUptimes(double maxUptime, double lambda, double mu)
        {
            var count = 1;
            while (true)
            {
                var uptime = GetUptime(GetMatrix(lambda, mu, ++count));
                yield return new Tuple<int, double>(count, uptime);

                if (uptime >= maxUptime) break;
            }
        }
    }
}

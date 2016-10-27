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
                                        ? tuple.Item1 == 1
                                            ? Math.Exp(-lambda)
                                            : Math.Exp(-mu)
                                        : tuple.Item1 == 0
                                            ? 1 - Math.Exp(-mu)
                                            : 1 - Math.Exp(-lambda)
                                )
                                .Aggregate((acc, x) => acc*x)
                        )
                        .Reverse()
                )
                .Reverse();
    }
}

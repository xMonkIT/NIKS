using System;
using System.Collections.Generic;
using System.Linq;

namespace Automat
{
    class Calculator
    {
        public static IEnumerable<IEnumerable<double>> GetMatrix(double lambda, double mu, int count) =>
            Enumerable
                .Range(0, (int)Math.Pow(2, count))
                .Select(row => Enumerable
                        .Range(0, (int)Math.Pow(2, count))
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
                                .Aggregate((acc, x) => acc * x)
                        )
                );

        public static IEnumerable<IEnumerable<double>> GetMatrix(IList<double> lambdas, IList<double> mus)
        {
            if (lambdas.Count != mus.Count) throw new ArgumentException("count of lists must be equal");

            var count = mus.Count;

            return Enumerable
                .Range(0, (int) Math.Pow(2, count))
                .Select(row => Enumerable
                        .Range(0, (int) Math.Pow(2, count))
                        .Select(cell => Enumerable
                                .Range(0, count)
                                .Select(bit => new Tuple<int, int>((row >> bit) & 1, (cell >> bit) & 1))
                                .Select((tuple, i) => tuple.Item1 == tuple.Item2
                                        ? tuple.Item1 == 0
                                            ? Math.Exp(-lambdas[i])
                                            : Math.Exp(-mus[i])
                                        : tuple.Item1 == 1
                                            ? 1 - Math.Exp(-mus[i])
                                            : 1 - Math.Exp(-lambdas[i])
                                )
                                .Aggregate((acc, x) => acc*x)
                        )
                );
        }

        public static double GetUptime(IEnumerable<IEnumerable<double>> data)
        {
            var matrix = data.Select(x => x.ToList()).ToList();
            var prevUptime = new List<double> { 1 };
            prevUptime.AddRange(Enumerable.Repeat(0.0, matrix.Count - 1));
            while (true)
            {
                var uptime = Enumerable
                    .Range(0, matrix.Count)
                    .Select(i => prevUptime.Select((cell, j) => cell * matrix[j][i]).Sum())
                    .ToList();

                if (uptime.Select((x, i) => Math.Abs(prevUptime[i] - x) < Math.Pow(10, -6)).All(x => x)) break;

                prevUptime = uptime;
            }

            return prevUptime.Take(matrix.Count - 1).Sum();
        }

        public static IEnumerable<Tuple<int, double>> GetUptimes(double maxUptime, double lambda, double mu)
        {
            var count = 0;
            while (true)
            {
                var uptime = GetUptime(GetMatrix(lambda, mu, ++count));
                yield return new Tuple<int, double>(count, uptime);

                if (uptime >= maxUptime) break;
            }
        }

        public static IEnumerable<dynamic> GetUptimes(double maxUptime, IList<double> lambdas, IList<double> mus,
            IList<double> prices)
        {
            if (lambdas.Count != mus.Count && mus.Count != prices.Count)
                throw new ArgumentException("count of lists must be equal");

            var count = mus.Count;
            var maxCount = Enumerable
                .Range(0, count)
                .Select(i => GetUptimes(maxUptime, lambdas[i], mus[i]).Last().Item1)
                .Max();

            var servers = lambdas.Select((x, i) => new Server {Lambda = x, Mu = mus[i], Price = prices[i]});

            return Enumerable
                .Range(1, maxCount - 1)
                .SelectMany(i => GetCombinations(servers.ToList(), i).Select(x =>
                {
                    var list = x.ToList();
                    return new
                    {
                        Servers = list,
                        Uptime = GetUptime(GetMatrix(list.Select(y => y.Lambda).ToList(), list.Select(y => y.Mu).ToList()))
                    };
                }))
                .Where(x => x.Uptime > maxUptime)
                .Select(x => new
                {
                    Lambdas = x.Servers.Select(y => y.Lambda),
                    Mus = x.Servers.Select(y => y.Mu),
                    Price = x.Servers.Sum(y => y.Price)
                })
                .OrderBy(x => x.Price);
        }

        public class Server : IComparable
        {
            public double Lambda;
            public double Mu;
            public double Price;

            protected bool Equals(Server other) =>
                Lambda.Equals(other.Lambda) && Mu.Equals(other.Mu) && Price.Equals(other.Price);

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = Lambda.GetHashCode();
                    hashCode = (hashCode*397) ^ Mu.GetHashCode();
                    hashCode = (hashCode*397) ^ Price.GetHashCode();
                    return hashCode;
                }
            }

            public int CompareTo(object obj) => GetHashCode().CompareTo(obj.GetHashCode());
        }

        public static IEnumerable<IEnumerable<Server>> GetCombinations(IList<Server> servers, int count)
        {
            var combinations = new List<IEnumerable<Server>>();

            Enumerable
                .Range(0, (int) Math.Pow(servers.Count, count))
                .ToList()
                .ForEach(i =>
                {
                    var list = new List<Server>();
                    var num = i;
                    var del = (int)Math.Pow(servers.Count, count - 1);
                    while (del >= 1)
                    {
                        list.Add(servers[num/del]);
                        num %= del;
                        del /= servers.Count;
                    }
                    if (!combinations.Any(x => x.SequenceEqual(list.OrderBy(y => y))))
                        combinations.Add(list);
                });

            return combinations;
        }
    }
}

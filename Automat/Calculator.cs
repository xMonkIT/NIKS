using System;
using System.Collections.Generic;
using System.Linq;

namespace Automat
{
    static class Calculator
    {
        public static List<List<double>> GetMatrix(double lambda, double mu, int count) =>
            GetMatrix(Enumerable.Repeat(lambda, count).ToList(), Enumerable.Repeat(mu, count).ToList());

        public static List<List<double>> GetMatrix(List<Server> servers) =>
            GetMatrix(servers.Select(x => x.Lambda).ToList(), servers.Select(x => x.Mu).ToList());

        public static List<List<double>> GetMatrix(List<double> lambdas, List<double> mus)
        {
            if (lambdas.Count != mus.Count) throw new ArgumentException("count of lists must be equal");

            var count = mus.Count;

            return count == 0
                ? Enumerable.Empty<List<double>>().ToList()
                : Enumerable
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
                        .ToList()
                    )
                    .ToList();
        }

        public static double GetUptime(List<List<double>> matrix)
        {
            if (matrix.Count == 0) return 0;

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

        public static Tuple<int, double> GetServerCountForUptime(double maxUptime, double lambda, double mu)
        {
            var count = 0;
            while (true)
            {
                var uptime = GetUptime(GetMatrix(lambda, mu, ++count));
                if (uptime >= maxUptime) return new Tuple<int, double>(count, uptime);
            }
        }

        public static IEnumerable<dynamic> GetServerCombinationsWithPriceForUptime(double maxUptime, List<double> lambdas, List<double> mus,
            List<double> prices)
        {
            if (lambdas.Count != mus.Count && mus.Count != prices.Count)
                throw new ArgumentException("count of lists must be equal");

            var count = mus.Count;
            var maxCount = Enumerable
                .Range(0, count)
                .Select(i => GetServerCountForUptime(maxUptime, lambdas[i], mus[i]).Item1)
                .Max();

            var servers = lambdas
                .Select((x, i) => new Server {Lambda = x, Mu = mus[i], Price = prices[i]})
                .ToList();

            return GetCombinations(servers, 1, maxCount)
                .Where(x => GetUptime(GetMatrix(x)) >= maxUptime)
                .Select(x => new
                {
                    Lambdas = x.Select(y => y.Lambda).ToList(),
                    Mus = x.Select(y => y.Mu).ToList(),
                    Price = x.Sum(y => y.Price)
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

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, T, bool> comparator)
        {
            var list = new List<T>();

            source.ToList().ForEach(x => {if (!list.Any(y => comparator(x, y))) list.Add(x);});

            return list;
        }

        public static IEnumerable<int> ToBase(this int value, int scaleBase, int count) => Enumerable
            .Range(0, count)
            .Select(i => value/(int) Math.Pow(scaleBase, i)%scaleBase);

        public static List<List<Server>> GetCombinations(List<Server> servers, int count) => Enumerable
            .Range(0, (int) Math.Pow(servers.Count, count))
            .Select(i => i.ToBase(servers.Count, count).Select(j => servers[j]).OrderBy(x => x).ToList())
            .Distinct((x, y) => x.SequenceEqual(y))
            .ToList();

        public static List<List<Server>> GetCombinations(List<Server> servers, int min, int max) => Enumerable
            .Range(0, max + 1)
            .Skip(min)
            .SelectMany(i => GetCombinations(servers, i))
            .ToList();
    }
}

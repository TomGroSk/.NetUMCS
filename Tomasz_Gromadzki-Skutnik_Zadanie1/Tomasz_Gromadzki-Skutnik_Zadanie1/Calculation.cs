using System;
using System.Collections.Generic;
using System.Linq;

namespace Tomasz_Gromadzki_Skutnik_Zadanie1.Model
{
    public class Calculation
    {
        public static SingleCount SingleCalculation(SingleCount singleCount, Func<double, double> func)
        {
            double dx = (singleCount.X2 - singleCount.X1) / singleCount.N;

            singleCount.Area += func(singleCount.X1 + singleCount.CalculationNumber * dx);

            return singleCount;
        }


        public static Global calculateIntegral(SingleCount singleCount, Func<double, double> func)
        {
            List<SingleCount> singleCountsList = new List<SingleCount>();
            double dx = (singleCount.X2 - singleCount.X1) / singleCount.N;

            for (int i = 1; i < singleCount.N; i++)
            {
                singleCount.CalculationNumber = i;
                singleCount = SingleCalculation(singleCount, func);
                singleCountsList.Add(singleCount);
            }

            if (singleCount.AreaType == AreaType.Trapezoid)
            {
                singleCount.Area += (func(singleCount.X1) + func(singleCount.X2)) / 2;
            }

            singleCount.Area *= dx;

            singleCountsList.Add(singleCount);
            return new Global(singleCountsList);
        }

        public static string FindNDiffFromZ(double z, double exactValue, AreaType areaType)
        {
            int i = 0;
            Random random = new Random();
            while (true)
            {
                SingleCount singleCountRectangle = new SingleCount(0, 100, random.Next(10, 100000), areaType, 0, 1);
                double areaValue = Calculation.calculateIntegral(singleCountRectangle, x => x * x * x).SingleCountsList.Last().Area;
                double exactness = Math.Abs(exactValue - areaValue) / exactValue * 100;

                if (exactness > z)
                {
                    return i.ToString();
                }

                i++;
            }
        }

        public static List<string> GetAllValuesDiffFromZ (double z, double m, double exactValue, AreaType areaType)
        {
            List<string> globalData = new List<string>();
            Random random = new Random();
            for (int i = 0; i < m; i++)
            {
                SingleCount singleCount = new SingleCount(0, 100, random.Next(10, 100000), areaType, 0, 1);
                double areaValue = Calculation.calculateIntegral(singleCount, x => x * x).SingleCountsList.Last().Area;
                double exactness = Math.Abs(exactValue - areaValue) / exactValue * 100;

                if (exactness <= z)
                {
                    globalData.Add(areaValue.ToString());
                }
            }
            return globalData;
        }

        public static string FindMinDiff(int m, int n, AreaType areaType)
        {
            Random random = new Random();
            double minValue = double.MaxValue;

            for (int i = 0; i < m; i++)
            {
                var tuple = new Tuple<double, double>(random.Next(10, 1000000), random.Next(10, 1000000));
                SingleCount singleCount = new SingleCount(tuple.Item1, tuple.Item2, n, areaType, 0, 1);
                double areaValue = Calculation.calculateIntegral(singleCount, x => x * x * x).SingleCountsList.Last().Area;
                double areaValue2 = Calculation.calculateIntegral(singleCount, x => x * x).SingleCountsList.Last().Area;
                double diffValue = (areaValue2 - areaValue);

                if (diffValue < minValue) minValue = diffValue;

            }
            return minValue.ToString();
        }

        public static string FindX1X2DivByZ(double x1, double x2, int n, double z, AreaType areaType)
        {
            for (int i = 0; i < x1; i++)
            {
                for (int j = 0; j < x2; j++)
                {
                    SingleCount singleCount = new SingleCount(i, j, n, areaType, 0, 1);
                    double areaValue = Calculation.calculateIntegral(singleCount, x => x * x * x).SingleCountsList.Last().Area;

                    if (Math.Round(areaValue) % z == 0 && Math.Round(areaValue) != 0)
                    {
                        return "X1: " + i.ToString() + "   X2: " + j.ToString();

                    }
                }
            }
            return "X1: NaN   X2: NaN";
        }

        public static string FindFirstN(double x2, double z, double exactValue, AreaType areaType)
        {
            int i = 0;
            while (true)
            {
                SingleCount singleCount = new SingleCount(0, x2, i, areaType, 0, 1);
                double areaValue = calculateIntegral(singleCount, x => Math.Cos(x)).SingleCountsList.Last().Area;
                double exactness = Math.Abs(exactValue - areaValue) / exactValue * 100;

                if (exactness > z)
                {
                    return i.ToString();
                }
                i++;
            }
        }

        public static string FindFirstNDivideByZ(double x1, double x2, double z, AreaType areaType)
        {
            int i = 0;
            while (true)
            {
                SingleCount singleCount = new SingleCount(x1, x2, i, areaType, 0, 1);
                double areaValue = Calculation.calculateIntegral(singleCount, x => x * x).SingleCountsList.Last().Area;
                if (Math.Round(areaValue) % z == 0 && Math.Round(areaValue) != 0)
                {
                    return "N: " + i.ToString();
                }
                i++;
            }
        }

        public static string FindX1X2ForFunctionValuesEquality(int n, AreaType areaType)
        {
            int a = 0;
            while (true)
            {
                for (int b = 0; b < a; b++)
                {
                    for (int c = 0; c < a; c++)
                    {
                        for (int d = 0; d < a; d++)
                        {
                            double equation = (Math.Pow(a, 3) - Math.Pow(b, 3)) / 3; // x^2 = x^3/3     (a^3 - b^3)/3
                            double equation2 = (Math.Pow(c, 4) - Math.Pow(d, 4)) / 4; // x^3 = x^4/4    (c^4 - d^4)/4
                            if (equation == equation2)
                            {
                                SingleCount singleCount2 = new SingleCount(b, a, n, areaType, 0, 1);
                                SingleCount singleCount3 = new SingleCount(d, c, n, areaType, 0, 1);
                                double areaValue2 = Calculation.calculateIntegral(singleCount2, x => x * x).SingleCountsList.Last().Area;
                                double areaValue3 = Calculation.calculateIntegral(singleCount3, x => x * x * x).SingleCountsList.Last().Area;
                                if (Math.Round(areaValue2) == Math.Round(areaValue3) || areaValue2 <= areaValue3)
                                {
                                    return "f(X^2) - X1: " + b.ToString() + "  X2: " + a.ToString() + "     f(X^3) - X1: " + d.ToString() + "  X2: " + c.ToString();
                                }

                            }
                        }
                    }
                }
                a++;
            }
        }
    }
}

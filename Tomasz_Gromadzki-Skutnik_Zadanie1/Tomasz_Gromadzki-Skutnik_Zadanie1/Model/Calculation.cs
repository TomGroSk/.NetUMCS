using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomasz_Gromadzki_Skutnik_Zadanie1.Model
{
    public class Calculation
    {
        public SingleCount SingleCalculation(SingleCount singleCount, Func<double, double> func)
        {
            double dx = (singleCount.X2 - singleCount.X1) / singleCount.N;

            singleCount.Area += func(singleCount.X1 + singleCount.CalculationNumber * dx);

            return singleCount;
        }


        public Global CoronaDidIt(SingleCount singleCount, Func<double, double> func)
        {
            List<SingleCount> singleCountsList = new List<SingleCount>();
            double dx = (singleCount.X2 - singleCount.X1) / singleCount.N;
            if (singleCount.AreaType == AreaType.Rectangle)
            {
                for (int i = 1; i < singleCount.N; i++)
                {
                    singleCount.CalculationNumber = i;
                    singleCount = SingleCalculation(singleCount, func);
                    singleCountsList.Add(singleCount);
                }
                singleCount.Area += (func(singleCount.X1) + func(singleCount.X2)) / 2;
                singleCount.Area *= dx;
            }
            else
            {
                for (int i = 1; i <= singleCount.N; i++)
                {
                    singleCount.CalculationNumber = i;
                    singleCount = SingleCalculation(singleCount, func);
                    singleCountsList.Add(singleCount);
                }
                singleCount.Area *= dx;
            }
            singleCountsList.Add(singleCount);
            return new Global(singleCountsList);
        }
    }
}

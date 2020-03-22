using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomasz_Gromadzki_Skutnik_Zadanie1.Model
{
    public enum AreaType
    {
        Rectangle,
        Trapezoid
    }

    public class SingleCount
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public int N { get; set; }
        public AreaType AreaType { get; set; }
        public double Area { get; set; }
        public int CalculationNumber { get; set; }
        public int LowestN { get; set; }
        public double MinSquareError { get; set; }

        public SingleCount () { }

        public SingleCount(double x1, double x2, int n, AreaType areaType, double area, int calculationNumber)
        {
            X1 = x1;
            X2 = x2;
            N = n;
            this.AreaType = areaType;
            this.Area = area;
            this.CalculationNumber = calculationNumber;
        }

        public SingleCount(double x1, double x2, int n, AreaType areaType, double area, int calculationNumber, int lowestN)
        {
            X1 = x1;
            X2 = x2;
            N = n;
            this.AreaType = areaType;
            this.Area = area;
            this.CalculationNumber = calculationNumber;
            this.LowestN = lowestN;
        }
    }

    public class Global
    {
        public List<SingleCount> SingleCountsList { get; set; }

        public Global() { }

        public Global(List<SingleCount> singleCountsList)
        {
            this.SingleCountsList = singleCountsList;
        }

    }

}

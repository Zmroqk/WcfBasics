using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfLibrary
{
    public class Calculator : ICalculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Divide(double x, double y)
        {
            if (y < 0)
                return double.NaN;
            return x / y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Substract(double x, double y)
        {
            return x - y;
        }
    }
}

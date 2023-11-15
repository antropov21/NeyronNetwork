using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp64
{
    internal static class NForms
    {
       // public static double dO;
        public static double E=0.5;
        public static double a=0.3;
        public static double Ideal=1;
        public static double dO(double OUTa,double OUTi)
        {
            Console.WriteLine((OUTi - OUTa) * (1 - OUTa) * OUTa);
            return (OUTi - OUTa) * (1 - OUTa) * OUTa;
        }
        public static double dH(double OUTa,double dsum)
        {
            return (OUTa - OUTa * OUTa) * dsum;
        }
       private static double Grad(double OUTa, double d)
        {
            return OUTa*d ;
        }
        public static double dW(double OUTa, double GradD,double LastD)
        {
            return E*Grad(OUTa,GradD)+a*LastD;
        }
    }
}

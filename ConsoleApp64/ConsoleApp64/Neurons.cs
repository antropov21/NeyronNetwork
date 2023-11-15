using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp64
{
    class Neyron
    {
        public double Input;
       public double[] Weight;
         public List<double> Delts=new List<double>();
         public List<double> LastDelta=new List<double>();
        //public double LastDelta = 0;
        public double Output;
        private LayerType _NeyronType;
        private Random _r=new Random();
        public double Delta = 0;
        public Neyron(int countofnext,LayerType layerType)
        {
           
            Weight=new double[countofnext];
            for (int j = 0; j < Weight.Length; j++)
            {
                while (Math.Abs(0 - Weight[j])<0.001)
                {
                    var t = _r.Next(1, 3);
                   if(t==1) Weight[j] = _r.NextDouble();
                   else Weight[j] = -1*_r.NextDouble();
                }

                LastDelta.Add(0);
            }
            _NeyronType = layerType;
            if( countofnext == 0 )
            {
                LastDelta.Add(0);
            }
         //   Console.WriteLine(_NeyronType+" "+Weight.Length);
        }
        public void Learn(Neyron[] neyrons=null)
        {
      
            

           
            if (_NeyronType == LayerType.Out)
            {
                Delta = NForms.dO(Output,NForms.Ideal);
             //   Console.WriteLine(Delta+" do");
             //   Console.WriteLine(  "--------");

            }
            else
            {

                for (int j = 0; j < Weight.Length; j++)
                {
                    double sum = 0;
                    for (int i = 0; i < Weight.Length; i++)
                    {
              
                        sum += Weight[i] * neyrons[i].Delta;
                    }
                 
                    var dw= NForms.dW(Output, neyrons[j].Delta, LastDelta[j]);                
                    Delta = NForms.dH(Output, sum);                 
                    Weight[j] += dw;
                    LastDelta[j] =dw;
                 
                }
            }
       

        }
        public double Sigmoid()
        {
            Output= 1 / (1 + Math.Pow(Math.E, -Input));
            return Output;
        }
        public double OutHiden(int i)
        {
            Output = Sigmoid() * Weight[i];
            return Output;
        }
        public double OutForEnters(int i)
        {
            Output = Input * Weight[i];
            return Output;
        }

    }
}
        







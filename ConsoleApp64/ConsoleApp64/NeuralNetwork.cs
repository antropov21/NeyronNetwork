using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp64
{
   
    class NeyrolNetwork
    {
        public Layer[] layers;
        public NeyrolNetwork(int n,int countofenter,int countofend,int countofhiden)
        {
            layers = new Layer[n];
            
            layers[0] = new Layer(countofenter,LayerType.In);           
            for (int i = 1; i < n-1; i++)
            {
                layers[i] = new Layer(countofhiden, LayerType.Hidden);
            }
            layers[^1] = new Layer(countofend, LayerType.Out);
           
            for (int i = 0; i < n - 1; i++)
            {
                layers[i].InitNeyrons(layers[i+1].neyrons.Length);
            }
            layers[^1].InitNeyrons(0);
        }
        public void Initialization()
        {
            for (int i = 0; i < layers[0].neyrons.Length; i++)
            {
                Console.WriteLine($"Значение нейрона {i}= ") ;
                layers[0].neyrons[i].Input = int.Parse(Console.ReadLine());
            }
        }
        public void Zero()
        {
            for (int i = 1; i < layers.Length; i++)
            {
                layers[i].Zero();
            }
        }
         
        
        public /*void*/ double Work2()
        {
            for (int i = 0; i < layers.Length; i++)
            {
                if (i != layers.Length - 1) layers[i].Work(layers[i + 1]);
                else
                layers[i].Work();
                
            }
          
            return layers[^1].neyrons[0].Output;
        }
        public void Learn()
        {
         
            for (int i= layers.Length-1; i>=0; i--)
            {
                for (int j = 0; j < layers[i].neyrons.Length; j++)
                {
                   
                   if (i != layers.Length - 1) layers[i].neyrons[j].Learn(layers[i + 1].neyrons);
                    else layers[i].neyrons[j].Learn();



                }
            }
        }

    }

}

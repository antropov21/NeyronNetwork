using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp64
{
    public enum LayerType
    { 
       In,Hidden,Out
    }
    
    internal class Layer
    {
        
        public Neyron[] neyrons;
        private LayerType _layerType;
        public Layer(int n,LayerType layerType)
        {
            neyrons = new Neyron[n];
            _layerType = layerType;

        }
        public void InitNeyrons(int countofnext)
        {
            for (int i = 0; i < neyrons.Length; i++)
            {
                neyrons[i] = new Neyron(countofnext,_layerType);
            }
        }
        public void Zero()
        {
            foreach (var i in neyrons)
                i.Input = 0;
        }
        public void Work( Layer layer2=null)
        {
       

            for (int j = 0; j < neyrons.Length; j++)
            {
                if (_layerType == LayerType.In)
                {
                    for (int x = 0; x < layer2.neyrons.Length; x++)
                    {
                        layer2.neyrons[x].Input += neyrons[j].OutForEnters(x);
                    }

                }
                else
                {
                    if (_layerType != LayerType.Out)
                    {
                        for (int x = 0; x < layer2.neyrons.Length; x++)
                        {
                            layer2.neyrons[x].Input += neyrons[j].OutHiden(x);
                        }
                    }
                    else neyrons[j].Sigmoid();
                }
            }
        } 
            
       
    }
}

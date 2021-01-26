using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    class SamsungEdge:ITelefon
    {
        public void Model()
        {
            Console.WriteLine("Model : Samsung Edge");
        }

        public void bataryaOmru()
        {
            Console.WriteLine("5000Mah");
        }

        public void ekranBoyutu()
        {
            Console.WriteLine("6inç");
        }
    }

 
}

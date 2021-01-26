using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethod
{
    public class Apple:ITelefon
    {
        public void Model()
        {
            Console.WriteLine("Iphone 12");
        }

        public void bataryaOmru()
        {
            Console.WriteLine("4000Mah");
        }

        public void ekranBoyutu()
        {
            Console.WriteLine("5.1\" ");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero oHero = new Hero("spiderman", "telaraña");
            Console.WriteLine(oHero.nombre);
            Console.ReadLine();
        }

        class Hero
        {
            public string nombre;
            public string poder;
            public Hero(string pNombre, string pPoder)
            {
                this.nombre = pNombre;
                this.poder = pPoder;
            }
        }
    }
}

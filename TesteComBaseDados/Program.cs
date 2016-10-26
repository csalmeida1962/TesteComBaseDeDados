using Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            ContextoBD bd = new ContextoBD();
            Console.WriteLine("Quantidade de Categorias : " + bd.Categorias.Count().ToString());

            Console.ReadLine();
        }
    }
}

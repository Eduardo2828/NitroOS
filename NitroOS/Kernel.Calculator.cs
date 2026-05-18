using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using Cosmos.Core;
using Cosmos.HAL;

namespace NitroOS
{
    public partial class Kernel
    {
        // COMANDA SUMA
        void FerSuma()
        {
            int num1 = LlegirNumero("Introdueix el primer nombre: ");
            int num2 = LlegirNumero("Introdueix el segon nombre: ");
            Console.WriteLine("Resultat: " + (num1 + num2));
        }

        // COMANDA RESTA
        void FerResta()
        {
            int num1 = LlegirNumero("Introdueix el primer nombre: ");
            int num2 = LlegirNumero("Introdueix el segon nombre: ");
            Console.WriteLine("Resultat: " + (num1 - num2));
        }

        // COMANDA MULTIPLICACIÓ
        void FerMultiplicacio()
        {
            int num1 = LlegirNumero("Introdueix el primer nombre: ");
            int num2 = LlegirNumero("Introdueix el segon nombre: ");
            Console.WriteLine("Resultat: " + (num1 * num2));
        }

        // COMANDA DIVISIÓ
        void FerDivisio()
        {
            int num1 = LlegirNumero("Introdueix el dividend: ");
            int num2 = LlegirNumero("Introdueix el divisor: ");

            if (num2 == 0)
            {
                Console.WriteLine("Error: no es pot dividir per zero");
                return;
            }

            Console.WriteLine("Resultat: " + (num1 / num2));
        }

        // COMANDA MÒDUL
        void FerModul()
        {
            int num1 = LlegirNumero("Introdueix el primer nombre: ");
            int num2 = LlegirNumero("Introdueix el segon nombre: ");

            if (num2 == 0)
            {
                Console.WriteLine("Error: no es pot fer modul amb zero");
                return;
            }

            Console.WriteLine("Resultat: " + (num1 % num2));
        }

        // COMANDA ARREL QUADRADA
        void FerArrelQuadrada()
        {
            int num = LlegirNumero("Introdueix el nombre: ");

            if (num < 0)
            {
                Console.WriteLine("Error: no es pot fer l'arrel quadrada d'un nombre negatiu");
                return;
            }

            Console.WriteLine("Resultat: " + Math.Sqrt(num));
        }

    }
}

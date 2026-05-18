using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroOS
{
    public partial class Kernel
    {
        // Llista que guarda les ultimes 5 comandes executades
        List<string> commandHistory = new List<string>();

        // Afegeix una comanda a l'historial
        void AfegirHistorial(string comanda)
        {
            if (string.IsNullOrWhiteSpace(comanda))
                return;

            // No guardem la comanda hist per evitar omplir l'historial només consultant-lo
            if (comanda.ToLower() == "hist")
                return;

            commandHistory.Add(comanda);

            // Si hi ha mes de 5 comandes, eliminem la mes antiga
            if (commandHistory.Count > 5)
            {
                commandHistory.RemoveAt(0);
            }
        }

        // Mostra les ultimes 5 comandes executades
        void MostrarHistorial()
        {
            if (commandHistory.Count == 0)
            {
                Console.WriteLine("No hi ha comandes a l'historial.");
                return;
            }

            Console.WriteLine("Ultimes comandes executades:");

            for (int i = 0; i < commandHistory.Count; i++)
            {
                Console.WriteLine((i + 1) + " - " + commandHistory[i]);
            }

            Console.WriteLine("Per repetir una comanda escriu: repetir numero");
            Console.WriteLine("Exemple: repetir 2");
        }

        // Recupera una comanda de l'historial segons el numero indicat
        string RecuperarComandaHistorial(int numero)
        {
            int index = numero - 1;

            if (index < 0 || index >= commandHistory.Count)
            {
                Console.WriteLine("Numero d'historial no valid.");
                return "";
            }

            return commandHistory[index];
        }
    }
}
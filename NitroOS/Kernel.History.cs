using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroOS
{
    public partial class Kernel
    {
        List<string> commandHistory = new List<string>();

        void AfegirHistorial(string comanda)
        {
            if (string.IsNullOrWhiteSpace(comanda))
                return;

            if (comanda.ToLower() == "hist")
                return;

            commandHistory.Add(comanda);

            if (commandHistory.Count > 5)
            {
                commandHistory.RemoveAt(0);
            }
        }

        void MostrarHistorial()
        {
            if (commandHistory.Count == 0)
            {
                EscriureSortida("No hi ha comandes a l'historial.");
                return;
            }

            EscriureSortida("Ultimes comandes executades:");

            for (int i = 0; i < commandHistory.Count; i++)
            {
                EscriureSortida((i + 1) + " - " + commandHistory[i]);
            }

            EscriureSortida("Per repetir una comanda escriu: repetir numero");
        }

        string RecuperarComandaHistorial(int numero)
        {
            int index = numero - 1;

            if (index < 0 || index >= commandHistory.Count)
            {
                EscriureSortida("Numero d'historial no valid.");
                return "";
            }

            return commandHistory[index];
        }
    }
}
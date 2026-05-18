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
        // COMANDA ADEU
        void ShutdownOS()
        {
            EscriureSortida("Apagant el sistema...");
            Sys.Power.Shutdown();

        }

        // COMANDA FORA
        void RebootOS()
        {
            EscriureSortida("Reiniciant el sistema...");
            Sys.Power.Reboot();
        }

        // COMANDA SCRIB
        void EscriureText()
        {
            try
            {
                Console.Write("On vols escriure? (pantalla/fitxer): ");
                string desti = Console.ReadLine().ToLower();

                if (desti == "pantalla")
                {
                    Console.Write("Introdueix el text: ");
                    string text = Console.ReadLine();
                    EscriureSortida("Text:");
                    EscriureSortida(text);
                }
                else if (desti == "fitxer")
                {
                    Console.Write("Nom del fitxer: ");
                    string nomFitxer = Console.ReadLine();

                    Console.Write("Introdueix el text: ");
                    string text = Console.ReadLine();

                    string ruta = currentPath + nomFitxer;

                    if (File.Exists(ruta))
                    {
                        string contingutActual = File.ReadAllText(ruta);
                        File.WriteAllText(ruta, contingutActual + "\n" + text);
                    }
                    else
                    {
                        File.WriteAllText(ruta, text);
                    }

                    EscriureSortida("Text guardat a: " + nomFitxer);
                }
                else
                {
                    EscriureSortida("Opcio no valida. Escriu 'pantalla' o 'fitxer'");
                }
            }
            catch (Exception e)
            {
                EscriureSortida("Error a scrib: " + e.Message);
            }
        }

        // FUNCIO ESPERAR PAGINA
        void EsperarPagina()
        {
            EscriureSortida("\n--- Prem Enter per continuar ---");
            Console.ReadLine();
        }

        // FUNCIO PER LLEGIR NUMEROS DES DE TECLAT
        int LlegirNumero(string missatge)
        {
            while (true)
            {
                Console.Write(missatge);
                string entrada = Console.ReadLine();

                try
                {
                    return int.Parse(entrada);
                }
                catch
                {
                    EscriureSortida("Error: introdueix un nombre valid");
                }
            }
        }
    }
}

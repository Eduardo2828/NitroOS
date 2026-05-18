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
        // COMANDA SOS
        void ShowSOS()
        {
            // ---------- PAGINA 1 ----------
            Console.Clear();
            Console.WriteLine("===== INFORMACIO DEL SISTEMA I COMANDES =====");

            Console.WriteLine("\n--- Gestio de fitxers i directoris ---");
            Console.WriteLine("lc       - Mostra tots els fitxers i carpetes dins del directori actual");
            Console.WriteLine("cdir     - Canvia el directori actual a un altre especificat");
            Console.WriteLine("hcdir    - Crea un nou directori amb el nom indicat");
            Console.WriteLine("eldir    - Elimina un directori especificat");
            Console.WriteLine("mc       - Mostra el contingut d'un fitxer sense obrir editor");

            EsperarPagina();


            // ---------- PAGINA 2 ----------
            Console.Clear();
            Console.WriteLine("===== INFORMACIO DEL SISTEMA I COMANDES =====");

            Console.WriteLine("\n--- Informacio del sistema ---");
            Console.WriteLine("sos      - Mostra aquesta ajuda");
            Console.WriteLine("edicio   - Mostra la versio del sistema operatiu");
            Console.WriteLine("seemem   - Mostra la memoria disponible");
            Console.WriteLine("tf       - Mostra el temps funcionant");

            EsperarPagina();


            // ---------- PAGINA 3 ----------
            Console.Clear();
            Console.WriteLine("===== INFORMACIO DEL SISTEMA I COMANDES =====");

            Console.WriteLine("\n--- Calculadora ---");
            Console.WriteLine("suma     - Fa una suma de dos nombres");
            Console.WriteLine("resta    - Fa una resta de dos nombres");
            Console.WriteLine("multi    - Fa una multiplicacio de dos nombres");
            Console.WriteLine("div      - Fa una divisio de dos nombres");
            Console.WriteLine("mod      - Fa el modul de dos nombres");
            Console.WriteLine("arrel    - Fa l'arrel quadrada");

            EsperarPagina();


            // ---------- PAGINA 4 ----------
            Console.Clear();
            Console.WriteLine("===== INFORMACIO DEL SISTEMA I COMANDES =====");

            Console.WriteLine("\n--- Utils ---");
            Console.WriteLine("hist     - Mostra les ultimes 5 comandes executades");
            Console.WriteLine("repetir  - Torna a executar una comanda de l'historial");
            Console.WriteLine("lp       - Neteja la pantalla");
            Console.WriteLine("scrib    - Escriu text a pantalla o fitxer");
            Console.WriteLine("adeu     - Apaga el sistema");
            Console.WriteLine("fora     - Reinicia el sistema");

            Console.WriteLine("\n--- Fi de l'ajuda ---");
        }

        // COMANDA EDICIO
        void MostrarEdicio()
        {
            Console.WriteLine("Versio del sistema: " + osVersion);
        }

        // COMANDA SEEMEM
        void MostrarMemoria()
        {
            try
            {
                uint totalRamMB = CPU.GetAmountOfRAM();
                Console.WriteLine("Memoria total detectada: " + totalRamMB + " MB");
                Console.WriteLine("Memoria usada: no disponible en aquesta versio");
                Console.WriteLine("Memoria lliure: no disponible en aquesta versio");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error a seemem: " + e.Message);
            }
        }

        // COMANDA TF
        void MostrarTempsFuncionant()
        {
            try
            {
                int actualSeconds = (RTC.Hour * 3600) + (RTC.Minute * 60) + RTC.Second;
                int elapsed = actualSeconds - bootSeconds;

                // Si ha passat la mitjanit
                if (elapsed < 0)
                {
                    elapsed += 24 * 3600;
                }

                int hores = elapsed / 3600;
                int minuts = (elapsed % 3600) / 60;
                int segons = elapsed % 60;

                Console.WriteLine("Temps ences: " + hores + "h " + minuts + "m " + segons + "s");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error a tf: " + e.Message);
            }
        }
    }
}

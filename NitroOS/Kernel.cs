using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace NitroOS
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back.");
        }

        protected override void Run()
        {
            Console.Clear();  // Limpia pantalla VGA text mode [web:47]

            // Versión del SO
            Console.WriteLine("cosmoOS v1.0 - Boot Sequence");
            Console.WriteLine("Desenvolupament per Eduardo, Noha i Marc - Granollers, 2026");
            Console.Beep(1000, 200);  // Sonido boot [web:40]

            // Logo ASCII (centrado aprox., ajusta líneas)
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
    _   _ _ _             
   | \ | (_) |            
   |  \| |_| |_ _ __ ___  
   | . ` | | __| '__/ _ \ 
   | |\  | | |_| | | (_) |
   |_| \_|_|\__|_|  \___/ 
");
            Console.WriteLine("Benvingut a NitroOS");
            Console.ResetColor();

            // Pausa para ver boot (luego inicia shell)
            Console.WriteLine("\nPresiona Enter per a la shell...");
            Console.ReadLine();

            // SHELL
            while (true)
            {
                Console.Write("NitroOS> ");
                string cmd = Console.ReadLine();

                switch (cmd)
                {
                    case "sos":
                        ShowSOS();
                        break;

                    case "lp":
                        Console.Clear();
                        break;

                    case "adeu":
                        ShutdownOS();
                        break;

                    case "fora":
                        RebootOS();
                        break;

                    default:
                        Console.WriteLine("Comanda no reconeguda. Escriu 'sos'");
                        break;
                }
            }

            // COMANDA SOS
            void ShowSOS()
            {
                Console.WriteLine("===== INFORMACIO DEL SISTEMA I COMANDES =====");

                Console.WriteLine("\n--- Gestio de fitxers i directoris ---");
                Console.WriteLine("lc       - Mostra tots els fitxers i carpetes dins del directori actual");
                Console.WriteLine("cdir     - Canvia el directori actual a un altre especificat");
                Console.WriteLine("hcdir    - Crea un nou directori amb el nom indicat");
                Console.WriteLine("eldir    - Elimina un directori especificat (nomes si esta buit o amb advertiment)");
                Console.WriteLine("mc       - Mostra el contingut d'un fitxer sense obrir editor");

                Console.WriteLine("\n--- Informacio del sistema ---");
                Console.WriteLine("sos      - Mostra aquesta ajuda o llistat de totes les comandes disponibles");
                Console.WriteLine("edicio   - Mostra la versio del sistema operatiu");
                Console.WriteLine("seemem   - Mostra la memoria disponible i l'ús actual");
                Console.WriteLine("tf       - Mostra el temps que el sistema ha estat funcionant des de l'ultim reinici");

                Console.WriteLine("\n--- Utils ---");
                Console.WriteLine("lp          - Neteja la pantalla");
                Console.WriteLine("scrib       - Permet escriure text en pantalla o en un fitxer");
                Console.WriteLine("adeu/fora   - Apaga o reinicia el sistema segons l'opcio triada");

                Console.WriteLine("=============================================");
            }

            // COMANDA ADEU
            void ShutdownOS()
            {
                Console.WriteLine("Apagant el sistema...");
                Sys.Power.Shutdown();

            }

            // COMANDA FORA
            void RebootOS()
            {
                Console.WriteLine("Reiniciant el sistema...");
                Sys.Power.Reboot();
            }
        }
    }
}

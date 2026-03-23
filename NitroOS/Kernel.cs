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
    _____         _     _     
   / ____|       | |   | |    
  | |  __  __ _  | | __| | __ 
  | | |_ |/ _` | | |/ _` |/ _`|
  | |__| | (_| | | | (_| | (_|
   \_____|\__,_| |_|\__,_|\__,|
");
            Console.WriteLine("Benvingut al Sistema Operatiu Basic");
            Console.ResetColor();

            // Pausa para ver boot (luego inicia shell)
            Console.WriteLine("\nPresiona Enter per a la shell...");
            Console.ReadLine();

            // SHELL
            while (true)
            {
                Console.Write("NitroOS> ");
                string cmd = Console.ReadLine();

                if (cmd == "sos")
                {
                    ShowSOS();
                }
                if (cmd == "lp")
                {
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Comanda no reconeguda. Escriu 'sos'");
                }
            }

            // COMANDA SOS
            void ShowSOS()
            {
                Console.WriteLine("===== INFORMACIÓ DEL SISTEMA I COMANDES =====");

                Console.WriteLine("\n--- Gestió de fitxers i directoris ---");
                Console.WriteLine("lc       - Mostra tots els fitxers i carpetes dins del directori actual");
                Console.WriteLine("cdir     - Canvia el directori actual a un altre especificat");
                Console.WriteLine("hcdir    - Crea un nou directori amb el nom indicat");
                Console.WriteLine("eldir    - Elimina un directori especificat (només si està buit o amb advertiment)");
                Console.WriteLine("mc       - Mostra el contingut d’un fitxer sense obrir editor");

                Console.WriteLine("\n--- Informació del sistema ---");
                Console.WriteLine("sos      - Mostra aquesta ajuda o llistat de totes les comandes disponibles");
                Console.WriteLine("edicio   - Mostra la versió del sistema operatiu");
                Console.WriteLine("seemem   - Mostra la memòria disponible i l’ús actual");
                Console.WriteLine("tf       - Mostra el temps que el sistema ha estat funcionant des de l’últim reinici");

                Console.WriteLine("\n--- Útils ---");
                Console.WriteLine("lp          - Neteja la pantalla");
                Console.WriteLine("scrib       - Permet escriure text en pantalla o en un fitxer");
                Console.WriteLine("adeu/fora   - Apaga o reinicia el sistema segons l’opció triada");

                Console.WriteLine("=============================================");
            }
        }
    }
}

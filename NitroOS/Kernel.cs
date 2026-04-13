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

                Console.WriteLine("\n--- Calculadora ---");
                Console.WriteLine("suma     - Fa una suma de dos nombres");
                Console.WriteLine("resta    - Fa una resta de dos nombres");
                Console.WriteLine("multi    - Fa una multiplicacio de dos nombres");
                Console.WriteLine("div      - Fa una divisio de dos nombres");
                Console.WriteLine("mod      - Fa el modul de dos nombres");
                Console.WriteLine("arrel    - Fa l'arrel quadrada d'un nombre");

                Console.WriteLine("\n--- Utils ---");
                Console.WriteLine("lp       - Neteja la pantalla");
                Console.WriteLine("scrib    - Permet escriure text en pantalla o en un fitxer");
                Console.WriteLine("adeu     - Apaga el sistema");
                Console.WriteLine("fora     - Reinicia el sistema");

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

            // COMANDA SUMA
            void FerSuma()
            {
                double num1 = LlegirNumero("Introdueix el primer nombre: ");
                double num2 = LlegirNumero("Introdueix el segon nombre: ");
                Console.WriteLine("Resultat: " + (num1 + num2));
            }

            // COMANDA RESTA
            void FerResta()
            {
                double num1 = LlegirNumero("Introdueix el primer nombre: ");
                double num2 = LlegirNumero("Introdueix el segon nombre: ");
                Console.WriteLine("Resultat: " + (num1 - num2));
            }

            // COMANDA MULTIPLICACIÓ
            void FerMultiplicacio()
            {
                double num1 = LlegirNumero("Introdueix el primer nombre: ");
                double num2 = LlegirNumero("Introdueix el segon nombre: ");
                Console.WriteLine("Resultat: " + (num1 * num2));
            }

            // COMANDA DIVISIÓ
            void FerDivisio()
            {
                double num1 = LlegirNumero("Introdueix el dividend: ");
                double num2 = LlegirNumero("Introdueix el divisor: ");

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
                double num1 = LlegirNumero("Introdueix el primer nombre: ");
                double num2 = LlegirNumero("Introdueix el segon nombre: ");

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
                double num = LlegirNumero("Introdueix el nombre: ");

                if (num < 0)
                {
                    Console.WriteLine("Error: no es pot fer l'arrel quadrada d'un nombre negatiu");
                    return;
                }

                Console.WriteLine("Resultat: " + Math.Sqrt(num));
            }

            double LlegirNumero(string missatge)
            {
                while (true)
                {
                    Console.Write(missatge);
                    string entrada = Console.ReadLine();

                    try
                    {
                        return double.Parse(entrada);
                    }
                    catch
                    {
                        Console.WriteLine("Error: introdueix un nombre valid");
                    }
                }
            }
        }
    }
}

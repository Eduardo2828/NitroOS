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
    public partial class Kernel : Sys.Kernel
    {
        // Crear la variable global del VFS
        CosmosVFS fs = new CosmosVFS();

        // Variable Directori Arrel de l'OS
        string currentPath = @"0:\";

        // Guardar segons d'inici del sistema per calcular el temps ences
        int bootSeconds;

        // Versio del sistema operatiu
        string osVersion = "NitroOS v1.0";

        protected override void BeforeRun()
        {
            // Canviar teclat US al ES abans d'engagar
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.ESStandardLayout());

            // Registrar el VFS
            VFSManager.RegisterVFS(fs);

            // Guardar l'hora d'inici del sistema
            bootSeconds = (RTC.Hour * 3600) + (RTC.Minute * 60) + RTC.Second;

            Console.WriteLine("Cosmos booted successfully.");
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
                Console.Write($"NitroOS {currentPath}> ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                ExecutarComanda(input, true);
            }
        }


        void ExecutarComanda(string input, bool guardarHistorial)
        {
            string[] parts = input.Split(' ');
            string cmd = parts[0].ToLower();

            if (guardarHistorial)
            {
                AfegirHistorial(input);
            }

            switch (cmd)
            {
                case "sos":
                    ShowSOS();
                    break;

                case "lp":
                    Console.Clear();
                    break;

                case "hist":
                    MostrarHistorial();
                    break;

                case "repetir":
                    if (parts.Length < 2)
                    {
                        Console.WriteLine("Us: repetir numero");
                    }
                    else
                    {
                        try
                        {
                            int numero = int.Parse(parts[1]);
                            string comandaRecuperada = RecuperarComandaHistorial(numero);

                            if (!string.IsNullOrWhiteSpace(comandaRecuperada))
                            {
                                Console.WriteLine("Executant: " + comandaRecuperada);
                                ExecutarComanda(comandaRecuperada, true);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Error: has d'indicar un numero valid.");
                        }
                    }
                    break;

                case "adeu":
                    ShutdownOS();
                    break;

                case "fora":
                    RebootOS();
                    break;

                case "lc":
                    LlistarContingut();
                    break;

                case "hcdir":
                    if (parts.Length < 2)
                        Console.WriteLine("Us: hcdir nomDirectori");
                    else
                        CrearDirectori(parts[1]);
                    break;

                case "eldir":
                    if (parts.Length < 2)
                        Console.WriteLine("Us: eldir nomDirectori");
                    else
                        EliminarDirectori(parts[1]);
                    break;

                case "mc":
                    if (parts.Length < 2)
                        Console.WriteLine("Us: mc nomFitxer");
                    else
                        MostrarContingutFitxer(parts[1]);
                    break;

                case "cdir":
                    if (parts.Length < 2)
                        Console.WriteLine("Us: cdir nomDirectori");
                    else
                        CanviarDirectori(parts[1]);
                    break;

                case "edicio":
                    MostrarEdicio();
                    break;

                case "seemem":
                    MostrarMemoria();
                    break;

                case "tf":
                    MostrarTempsFuncionant();
                    break;

                case "scrib":
                    EscriureText();
                    break;

                case "suma":
                    FerSuma();
                    break;

                case "resta":
                    FerResta();
                    break;

                case "multi":
                    FerMultiplicacio();
                    break;

                case "div":
                    FerDivisio();
                    break;

                case "mod":
                    FerModul();
                    break;

                case "arrel":
                    FerArrelQuadrada();
                    break;

                default:
                    Console.WriteLine("Comanda no reconeguda. Escriu 'sos'");
                    break;
            }
        }
    }
}

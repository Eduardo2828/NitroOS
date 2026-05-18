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

            // Preparem i inicialitzem l'audio despres de registrar el sistema de fitxers
            InicialitzarAudio();

            Console.WriteLine("Cosmos booted successfully.");
        }

        protected override void Run()
        {
            Console.Clear();  // Limpia pantalla VGA text mode [web:47]

            // Versión del SO
            Console.WriteLine("cosmoOS v1.6 - Boot Sequence");
            Console.WriteLine("Desenvolupament per Eduardo, Noha i Marc - Granollers, 2026");

            // AUDIO D'INICI
            SoInici();

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
            AturarAudio();

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
                    SoComandaCorrecta();
                    ShowSOS();
                    break;

                case "lp":
                    SoComandaCorrecta();
                    Console.Clear();
                    break;

                case "hist":
                    SoComandaCorrecta();
                    MostrarHistorial();
                    break;

                case "repetir":
                    if (parts.Length < 2)
                    {
                        SoError();
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
                            else
                            {
                                SoError();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Error: has d'indicar un numero valid.");
                            SoError();
                        }
                    }
                    break;

                case "adeu":
                    SoComandaCorrecta();
                    ShutdownOS();
                    break;

                case "fora":
                    SoComandaCorrecta();
                    RebootOS();
                    break;

                case "lc":
                    SoComandaCorrecta();
                    LlistarContingut();
                    break;

                case "hcdir":

                    if (parts.Length < 2)
                    {
                        SoError();
                        Console.WriteLine("Us: hcdir nomDirectori");
                    }
                    else
                    {
                        SoComandaCorrecta();
                        CrearDirectori(parts[1]);
                    }
                    break;

                case "eldir":
                    if (parts.Length < 2)
                    {
                        SoError();
                        Console.WriteLine("Us: eldir nomDirectori");
                    }
                    else
                    {
                        SoComandaCorrecta();
                        EliminarDirectori(parts[1]);
                    }
                    break;

                case "mc":

                    if (parts.Length < 2)
                    {
                        SoError();
                        Console.WriteLine("Us: mc nomFitxer");
                    }
                    else
                    {
                        SoComandaCorrecta();
                        MostrarContingutFitxer(parts[1]);
                    }
                    break;

                case "cdir":
                    if (parts.Length < 2)
                    {
                        SoError();
                        Console.WriteLine("Us: cdir nomDirectori");
                    }
                    else
                    {
                        SoComandaCorrecta();
                        CanviarDirectori(parts[1]);
                    }
                    break;

                case "edicio":
                    SoComandaCorrecta();
                    MostrarEdicio();
                    break;

                case "seemem":
                    SoComandaCorrecta();
                    MostrarMemoria();
                    break;

                case "tf":
                    SoComandaCorrecta();
                    MostrarTempsFuncionant();
                    break;

                case "scrib":
                    SoComandaCorrecta();
                    EscriureText();
                    break;

                case "suma":
                    SoComandaCorrecta();
                    FerSuma();
                    break;

                case "resta":
                    SoComandaCorrecta();
                    FerResta();
                    break;

                case "multi":
                    SoComandaCorrecta();
                    FerMultiplicacio();
                    break;

                case "div":
                    SoComandaCorrecta();
                    FerDivisio();
                    break;

                case "mod":
                    SoComandaCorrecta();
                    FerModul();
                    break;

                case "arrel":
                    SoComandaCorrecta();
                    FerArrelQuadrada();
                    break;

                default:
                    SoError();
                    Console.WriteLine("Comanda no reconeguda. Escriu 'sos'");
                    break;
            }
        }
    }
}

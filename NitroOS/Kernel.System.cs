using Cosmos.Core;
using Cosmos.HAL;
using System;
namespace NitroOS
{
    public partial class Kernel
    {
        // COMANDA SOS
        void ShowSOS()
        {
            EscriureSortida("===== INFORMACIO DEL SISTEMA I COMANDES =====\n");

            EscriureSortida("--- Gestio de fitxers i directoris ---");
            EscriureSortida("lc       - Mostra tots els fitxers i carpetes dins del directori actual");
            EscriureSortida("cdir     - Canvia el directori actual a un altre especificat");
            EscriureSortida("hcdir    - Crea un nou directori amb el nom indicat");
            EscriureSortida("eldir    - Elimina un directori especificat");
            EscriureSortida("mc       - Mostra el contingut d'un fitxer sense obrir editor\n");

            EscriureSortida("--- Informacio del sistema ---");
            EscriureSortida("sos      - Mostra aquesta ajuda");
            EscriureSortida("edicio   - Mostra la versio del sistema operatiu");
            EscriureSortida("seemem   - Mostra la memoria disponible");
            EscriureSortida("tf       - Mostra el temps funcionant\n");

            EscriureSortida("--- Calculadora ---");
            EscriureSortida("suma     - Fa una suma de dos nombres");
            EscriureSortida("resta    - Fa una resta de dos nombres");
            EscriureSortida("multi    - Fa una multiplicacio de dos nombres");
            EscriureSortida("div      - Fa una divisio de dos nombres");
            EscriureSortida("mod      - Fa el modul de dos nombres");
            EscriureSortida("arrel    - Fa l'arrel quadrada\n");

            EscriureSortida("--- Utils ---");
            EscriureSortida("lp       - Neteja la pantalla");
            EscriureSortida("scrib    - Escriu text a pantalla o fitxer");
            EscriureSortida("adeu     - Apaga el sistema");
            EscriureSortida("fora     - Reinicia el sistema");
        }

        // COMANDA EDICIO
        void MostrarEdicio()
        {
            EscriureSortida("Versio del sistema: " + osVersion);
        }

        // COMANDA SEEMEM
        void MostrarMemoria()
        {
            try
            {
                uint totalRamMB = CPU.GetAmountOfRAM();
                EscriureSortida("Memoria total detectada: " + totalRamMB + " MB");
                EscriureSortida("Memoria usada: no disponible en aquesta versio");
                EscriureSortida("Memoria lliure: no disponible en aquesta versio");
            }
            catch (Exception e)
            {
                EscriureSortida("Error a seemem: " + e.Message);
            }
        }

        // COMANDA TF
        void MostrarTempsFuncionant()
        {
            try
            {
                int actualSeconds = (RTC.Hour * 3600) + (RTC.Minute * 60) + RTC.Second;
                int elapsed = actualSeconds - bootSeconds;

                if (elapsed < 0)
                {
                    elapsed += 24 * 3600;
                }

                int hores = elapsed / 3600;
                int minuts = (elapsed % 3600) / 60;
                int segons = elapsed % 60;

                EscriureSortida("Temps ences: " + hores + "h " + minuts + "m " + segons + "s");
            }
            catch (Exception e)
            {
                EscriureSortida("Error a tf: " + e.Message);
            }
        }
    }
}
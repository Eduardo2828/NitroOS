using System;
using System.Collections.Generic;
using System.IO;
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
        // COMANDA LC
        void LlistarContingut()
        {
            try
            {
                var directoris = Directory.GetDirectories(currentPath);
                var fitxers = Directory.GetFiles(currentPath);

                EscriureSortida("Directoris:");
                foreach (var directori in directoris)
                {
                    EscriureSortida(" [DIR]  " + NomFinalRuta(directori));
                }

                EscriureSortida("Fitxers:");
                foreach (var fitxer in fitxers)
                {
                    EscriureSortida(" [FILE] " + NomFinalRuta(fitxer));
                }
            }
            catch (Exception e)
            {
                EscriureSortida("Error a lc: " + e.Message);
            }
        }

        // Llegir ruta dels fitxers o directoris
        string NomFinalRuta(string ruta)
        {
            string temp = ruta.TrimEnd('\\');
            int pos = temp.LastIndexOf('\\');

            if (pos >= 0 && pos < temp.Length - 1)
            {
                return temp.Substring(pos + 1);
            }

            return temp;
        }

        // COMANDA HCDIR
        void CrearDirectori(string nomDirectori)
        {
            try
            {
                string novaRuta = currentPath + nomDirectori + @"\";
                Directory.CreateDirectory(novaRuta);
                EscriureSortida("Directori creat: " + nomDirectori);
            }
            catch (Exception e)
            {
                EscriureSortida("Error a hcdir: " + e.Message);
            }
        }

        // COMANDA ELDIR
        void EliminarDirectori(string nomDirectori)
        {
            try
            {
                string ruta = currentPath + nomDirectori + @"\";
                Directory.Delete(ruta);
                EscriureSortida("Directori eliminat: " + nomDirectori);
            }
            catch (Exception e)
            {
                EscriureSortida("Error a eldir: " + e.Message);
            }
        }

        // COMANDA MC
        void MostrarContingutFitxer(string nomFitxer)
        {
            try
            {
                string ruta = currentPath + nomFitxer;
                string contingut = File.ReadAllText(ruta);
                EscriureSortida("Contingut de " + nomFitxer + ":");
                EscriureSortida(contingut);
            }
            catch (Exception e)
            {
                EscriureSortida("Error a mc: " + e.Message);
            }
        }

        // COMANDA CDIR
        void CanviarDirectori(string nomDirectori)
        {
            try
            {
                // Tornar enrere amb ..
                if (nomDirectori == "..")
                {
                    if (currentPath != @"0:\")
                    {
                        string temp = currentPath.TrimEnd('\\');
                        int ultimaBarra = temp.LastIndexOf('\\');

                        if (ultimaBarra >= 2)
                        {
                            currentPath = temp.Substring(0, ultimaBarra + 1);
                        }
                        else
                        {
                            currentPath = @"0:\";
                        }
                    }

                    return;
                }

                // Construir nova ruta
                string novaRuta = currentPath + nomDirectori + @"\";

                // Comprovar si existeix el directori
                if (Directory.Exists(novaRuta))
                {
                    currentPath = novaRuta;
                }
                else
                {
                    EscriureSortida("El directori no existeix");
                }
            }
            catch (Exception e)
            {
                EscriureSortida("Error a cdir: " + e.Message);
            }
        }
    }
}

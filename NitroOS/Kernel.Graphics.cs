using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System;
using System.Drawing;
using Sys = Cosmos.System;

namespace NitroOS
{
    public partial class Kernel
    {
        Canvas canvas;

        bool modeGrafic = false;
        string sortidaGrafica = "Benvingut a la shell grafica de NitroOS.";

        void InicialitzarGrafics()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(640, 480, ColorDepth.ColorDepth32));
            canvas.Clear(Color.FromArgb(13, 27, 42));
            canvas.Display();
        }

        void EscriureSortida(string text)
        {
            if (modeGrafic)
            {
                sortidaGrafica += text + "\n";
            }
            else
            {
                Console.WriteLine(text);
            }
        }

        void NetejarSortidaGrafica()
        {
            sortidaGrafica = "";
        }

        void DibuixarLogoNitroOS(int x, int y)
        {
            Color c = Color.FromArgb(0, 196, 204);
            int g = 10;
            int alt = 70;

            // N
            canvas.DrawFilledRectangle(c, x, y, g, alt);
            canvas.DrawFilledRectangle(c, x + 40, y, g, alt);
            canvas.DrawLine(c, x + 10, y + 5, x + 40, y + 65);

            // I
            canvas.DrawFilledRectangle(c, x + 70, y, 55, g);
            canvas.DrawFilledRectangle(c, x + 92, y, g, alt);
            canvas.DrawFilledRectangle(c, x + 70, y + 60, 55, g);

            // T
            canvas.DrawFilledRectangle(c, x + 145, y, 65, g);
            canvas.DrawFilledRectangle(c, x + 172, y, g, alt);

            // R millorada
            canvas.DrawFilledRectangle(c, x + 230, y, g, alt);
            canvas.DrawFilledRectangle(c, x + 240, y, 55, g);
            canvas.DrawFilledRectangle(c, x + 240, y + 30, 55, g);
            canvas.DrawFilledRectangle(c, x + 295, y + 10, g, 25);
            canvas.DrawFilledRectangle(c, x + 285, y + 35, g, 8);
            canvas.DrawLine(c, x + 245, y + 40, x + 305, y + 70);

            // O
            canvas.DrawFilledRectangle(c, x + 330, y, 65, g);
            canvas.DrawFilledRectangle(c, x + 330, y + 60, 65, g);
            canvas.DrawFilledRectangle(c, x + 330, y, g, alt);
            canvas.DrawFilledRectangle(c, x + 385, y, g, alt);
        }

        void MostrarBenvingudaGrafica()
        {
            canvas.Clear(Color.FromArgb(13, 27, 42));

            canvas.DrawFilledRectangle(Color.FromArgb(20, 30, 45), 40, 40, 560, 380);
            canvas.DrawRectangle(Color.FromArgb(26, 115, 232), 40, 40, 560, 380);
            canvas.DrawRectangle(Color.FromArgb(0, 196, 204), 50, 50, 540, 360);

            DibuixarLogoNitroOS(120, 115);

            canvas.DrawString(osVersion + " - Graphic Mode", PCScreenFont.Default, Color.FromArgb(0, 196, 204), 220, 215);
            canvas.DrawString("Desenvolupament per Eduardo, Noha i Marc", PCScreenFont.Default, Color.LightGray, 155, 250);
            canvas.DrawString("Granollers, 2026", PCScreenFont.Default, Color.LightGray, 260, 275);
            canvas.DrawString("Prem Enter per entrar a la shell", PCScreenFont.Default, Color.FromArgb(20, 212, 107), 190, 355);

            canvas.Display();
        }

        void EsperarEnterGrafic()
        {
            while (true)
            {
                var tecla = Sys.KeyboardManager.ReadKey();

                if (tecla.Key == Sys.ConsoleKeyEx.Enter)
                    return;
            }
        }

        void ShellGrafica()
        {
            modeGrafic = true;
            string input = "";

            while (true)
            {
                DibuixarShellGrafica(input);

                var tecla = Sys.KeyboardManager.ReadKey();

                if (tecla.Key == Sys.ConsoleKeyEx.Enter)
                {
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        NetejarSortidaGrafica();
                        ExecutarComanda(input, true);
                    }

                    input = "";
                }
                else if (tecla.Key == Sys.ConsoleKeyEx.Backspace)
                {
                    if (input.Length > 0)
                        input = input.Substring(0, input.Length - 1);
                }
                else
                {
                    char c = tecla.KeyChar;

                    if (c >= 32 && c <= 126)
                        input += c;
                }
            }
        }

        void DibuixarShellGrafica(string input)
        {
            canvas.Clear(Color.FromArgb(13, 27, 42));

            canvas.DrawFilledRectangle(Color.FromArgb(20, 30, 45), 20, 20, 600, 440);
            canvas.DrawRectangle(Color.FromArgb(26, 115, 232), 20, 20, 600, 440);
            canvas.DrawRectangle(Color.FromArgb(0, 196, 204), 30, 30, 580, 420);

            canvas.DrawString("NitroOS Shell Grafica", PCScreenFont.Default, Color.FromArgb(0, 196, 204), 40, 45);
            canvas.DrawString(osVersion, PCScreenFont.Default, Color.LightGray, 470, 45);
            canvas.DrawLine(Color.FromArgb(0, 196, 204), 40, 70, 590, 70);

            canvas.DrawString("Directori actual:", PCScreenFont.Default, Color.LightGray, 40, 90);
            canvas.DrawString(currentPath, PCScreenFont.Default, Color.White, 180, 90);

            canvas.DrawFilledRectangle(Color.FromArgb(8, 15, 25), 40, 125, 550, 185);
            canvas.DrawRectangle(Color.FromArgb(0, 196, 204), 40, 125, 550, 185);
            canvas.DrawString("Sortida:", PCScreenFont.Default, Color.FromArgb(0, 196, 204), 50, 135);
            DibuixarTextMultilinia(sortidaGrafica, 50, 160, Color.White, 8);

            canvas.DrawFilledRectangle(Color.FromArgb(8, 15, 25), 40, 330, 550, 45);
            canvas.DrawRectangle(Color.FromArgb(0, 196, 204), 40, 330, 550, 45);
            canvas.DrawString("NitroOS " + currentPath + "> " + input, PCScreenFont.Default, Color.FromArgb(20, 212, 107), 50, 345);

            canvas.DrawString("Enter: executar | Backspace: esborrar", PCScreenFont.Default, Color.LightGray, 40, 405);
            canvas.DrawString("Escriu 'sos' per veure les comandes", PCScreenFont.Default, Color.LightGray, 40, 425);

            canvas.Display();
        }

        void DibuixarTextMultilinia(string text, int x, int y, Color color, int maxLinies)
        {
            string[] linies = text.Split('\n');

            for (int i = 0; i < linies.Length && i < maxLinies; i++)
            {
                canvas.DrawString(linies[i], PCScreenFont.Default, color, x, y + (i * 18));
            }
        }
    }
}
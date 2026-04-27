using Cosmos.HAL.Audio;
using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.Audio;
using Cosmos.System.Audio.DSP;
using Cosmos.System.Audio.IO;
using System;
using System.IO;

namespace NitroOS
{
    public partial class Kernel
    {
        // Mixer principal del sistema d'audio
        AudioMixer mixer;

        // Gestor que envia el so del mixer cap al driver AC97
        AudioManager audioManager;

        // Indica si l'audio s'ha pogut inicialitzar correctament
        bool audioDisponible = false;

        // Inicialitza el sistema d'audio amb el driver AC97
        void InicialitzarAudio()
        {
            try
            {
                mixer = new AudioMixer();

                var driver = AC97.Initialize(4096);

                audioManager = new AudioManager()
                {
                    Stream = mixer,
                    Output = driver
                };

                audioManager.Enable();

                audioDisponible = true;
                Console.WriteLine("Audio inicialitzat correctament");
            }
            catch
            {
                audioDisponible = false;
                Console.WriteLine("Audio no disponible en aquesta maquina");
            }
        }

        // Reprodueix un fitxer WAV guardat al disc del sistema
        void ReproduirWav(string ruta)
        {
            try
            {
                if (!audioDisponible)
                    return;

                if (!File.Exists(ruta))
                {
                    Console.WriteLine("No s'ha trobat l'audio: " + ruta);
                    return;
                }

                // Llegim el fitxer WAV com a array de bytes
                byte[] audioBytes = File.ReadAllBytes(ruta);

                // Convertim el WAV en un stream d'audio
                var audioStream = MemoryAudioStream.FromWave(audioBytes);

                // Afegim el stream al mixer perquè es reprodueixi
                mixer.Streams.Add(audioStream);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reproduint audio: " + e.Message);
            }
        }
        
        // So d'inici del sistema
        void SoInici()
        {
            ReproduirWav(@"0:\sons\inici.wav");
        }

        // So quan una comanda és correcta
        void SoComandaCorrecta()
        {
            ReproduirWav(@"0:\sons\correcte.wav");
        }

        // So quan hi ha un error
        void SoError()
        {
            ReproduirWav(@"0:\sons\error.wav");
        }
    }
}
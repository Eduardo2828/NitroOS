using Cosmos.HAL.Audio;
using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.Audio;
using Cosmos.System.Audio.DSP;
using Cosmos.System.Audio.IO;
using System;
using IL2CPU.API.Attribs;

namespace NitroOS
{
    public partial class Kernel
    {
        [ManifestResourceStream(ResourceName = "NitroOS.Resources.sons.inici.wav")]
        static byte[] audioInici;

        [ManifestResourceStream(ResourceName = "NitroOS.Resources.sons.correcte.wav")]
        static byte[] audioCorrecte;

        [ManifestResourceStream(ResourceName = "NitroOS.Resources.sons.error.wav")]
        static byte[] audioError;

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
        void ReproduirWav(byte[] audioBytes)
        {
            try
            {
                if (!audioDisponible)
                    return;

                if (audioBytes == null || audioBytes.Length == 0)
                {
                    Console.WriteLine("Audio buit o no carregat.");
                    return;
                }

                mixer.Streams.Clear();

                var audioStream = MemoryAudioStream.FromWave(audioBytes);
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
            ReproduirWav(audioInici);
        }

        // So quan una comanda és correcta
        void SoComandaCorrecta()
        {
            ReproduirWav(audioCorrecte);
        }

        // So quan hi ha un error
        void SoError()
        {
            ReproduirWav(audioError);
        }

        void AturarAudio()
        {
            try
            {
                if (mixer != null)
                {
                    mixer.Streams.Clear();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error aturant audio: " + e.Message);
            }
        }
    }
}
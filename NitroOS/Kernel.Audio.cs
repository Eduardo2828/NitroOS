using Cosmos.HAL.Audio;
using Cosmos.HAL.Drivers.Audio;
using Cosmos.System.Audio;
using Cosmos.System.Audio.DSP;
using Cosmos.System.Audio.IO;
using System;
using System.IO;
using System.Reflection;

namespace NitroOS
{
    public partial class Kernel
    {
        // Mixer d'audio que permet afegir diferents sons per reproduir-los
        AudioMixer mixer;

        // AudioManager que connecta el mixer amb el driver de sortida d'audio
        AudioManager audioManager;

        // Inicialitza el sistema d'audio utilitzant el driver AC97
        void InicialitzarAudio()
        {
            try
            {
                // Creem el mixer principal
                mixer = new AudioMixer();

                // Inicialitzem el driver AC97 amb una mida de buffer de 4096
                var driver = AC97.Initialize(4096);

                // Connectem el mixer amb el driver de sortida
                audioManager = new AudioManager()
                {
                    Stream = mixer,
                    Output = driver
                };

                // Activem el sistema d'audio
                audioManager.Enable();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error inicialitzant audio: " + e.Message);
            }
        }

        // Llegeix un fitxer WAV incrustat com a recurs dins del projecte
        byte[] LlegirAudioResource(string nomRecurs)
        {
            try
            {
                // Obtenim l'assembly actual, que conte els recursos incrustats
                var assembly = Assembly.GetExecutingAssembly();

                // Obrim el recurs WAV indicat
                Stream stream = assembly.GetManifestResourceStream(nomRecurs);

                if (stream == null)
                {
                    Console.WriteLine("No s'ha trobat el recurs: " + nomRecurs);
                    return null;
                }

                // Convertim el recurs a array de bytes
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);

                return bytes;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error llegint recurs d'audio: " + e.Message);
                return null;
            }
        }

        // Reprodueix un fitxer WAV carregat des dels recursos del projecte
        void ReproduirAudioResource(string nomRecurs)
        {
            try
            {
                // Llegim el fitxer WAV com a bytes
                byte[] audioBytes = LlegirAudioResource(nomRecurs);

                if (audioBytes == null)
                    return;

                // Convertim el WAV en un MemoryAudioStream
                var audioStream = MemoryAudioStream.FromWave(audioBytes);

                // Afegim el so al mixer perquè es reprodueixi
                mixer.Streams.Add(audioStream);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reproduint audio: " + e.Message);
            }
        }

        // So que es reprodueix quan arrenca el sistema
        void SoInici()
        {
            ReproduirAudioResource("NitroOS.Resources.inici.wav");
        }

        // So que es reprodueix quan una comanda és correcta
        void SoComandaCorrecta()
        {
            ReproduirAudioResource("NitroOS.Resources.correcte.wav");
        }

        // So que es reprodueix quan hi ha un error
        void SoError()
        {
            ReproduirAudioResource("NitroOS.Resources.error.wav");
        }
    }
}
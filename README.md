**NitroOS**🚀
### *El nostre sistema operatiu desenvolupat amb CosmosOS*

---

## 🌌 Descripció del projecte

**NitroOS** és un sistema operatiu desenvolupat en **C#** utilitzant el framework **CosmosOS**. El principal objectiu del projecte és construir un entorn de consola funcional capaç de gestionar:

* 📂 Fitxers
* 📁 Directoris
* ⚙️ Informació bàsica del sistema
* 💻 Execució de comandes pròpies

Aquest projecte ens ha permès entendre millor el funcionament intern d’un sistema operatiu i experimentar amb la gestió de maquinari i recursos des d’un nivell més baix.

---

# 👨‍💻 Membres del grup

| Nom       | Funció                 |
| --------- | ---------------------- |
| 👩 Noha   | Revisió i documentació |
| 👨 Javier | Documentació           |
| 👨 Marc   | Programació            |

---

## 🖼️ Logo del projecte

<p align="center">
  <img src="src/logo.png" alt="Logo NitroOS" width="300">
</p>

---

# 🖥️ Funcionament del sistema

<p align="center">
  <img width="700" alt="Pantalla d'inici NitroOS" src="https://github.com/user-attachments/assets/d0a3d2a0-f237-4cc4-a5a6-f92fd8262736" />
</p>

### 🔹 Pantalla d’inici

Aquesta és la pantalla inicial de **NitroOS** executant-se dins d’una màquina virtual amb **CosmosOS**.

Durant l’arrencada del sistema podem observar:

* ⚡ La seqüència de *boot* del sistema
* 👨‍💻 Informació dels desenvolupadors
* 🎨 El logotip de NitroOS en format ASCII Art
* 💬 Un missatge de benvinguda
* ⌨️ Instruccions per entrar a la shell del sistema

---

# 🛠️ Tecnologies utilitzades

Aquest projecte ha estat desenvolupat utilitzant les següents tecnologies:

| Tecnologia                 | Ús                                      |
| -------------------------- | --------------------------------------- |
| 💜 C#                      | Llenguatge de programació principal     |
| 🌌 CosmosOS                | Framework per crear el sistema operatiu |
| 🧠 .NET                    | Plataforma de desenvolupament           |
| 💻 Visual Studio Code 2022 | Entorn de desenvolupament (IDE)         |
| 🖥️ VirtualBox / VMware    | Execució en màquines virtuals           |

---

# 📦 Instal·lació i ús

```bash
[Més endavant]
```

---

# 🧱 Estructura del projecte

📌 *Properament s’afegiran captures i explicacions detallades de l’estructura interna del sistema.*

---

# 🚧 Roadmap i millores futures

## 📂 Sistema de fitxers

* ✅ Llistar contingut
* ✅ Canviar directori
* ✅ Crear directori
* ✅ Eliminar directori
* ✅ Mostrar contingut de fitxers

## ⚙️ Sistema

* ✅ Informació del sistema
* ✅ Mostrar ajuda
* ✅ Mostrar versió del SO
* ✅ Mostrar memòria disponible
* ✅ Temps de funcionament

## 🖥️ Consola

* ✅ Netejar pantalla
* ✅ Escriure text
* ✅ Apagar / Reiniciar sistema
* ✅ Sistema de comandes matemàtiques bàsiques

---

# 🔌 Control de l’estat del sistema

S’han implementat funcions per controlar l’estat del sistema operatiu:

## 🔴 Apagar sistema

```csharp
Cosmos.Sys.Deboot.ShutDown();
```

## 🔄 Reiniciar sistema

```csharp
Cosmos.Sys.Deboot.Reboot();
```

---

# ⌨️ Configuració del teclat

Per defecte, **CosmosOS** utilitza una distribució de teclat americana 🇺🇸.

Per adaptar el sistema a la configuració local 🇪🇸, s’ha implementat la possibilitat de configurar el layout del teclat.

## 📌 Configuració dins de `BeforeRun()`

```csharp
Sys.KeyboardManager.SetKeyLayout(
    new Sys.ScanMaps.ESStandardLayout()
);
```

---

# 💡 Exemple d’una funció implementada

## 🔄 Reiniciar el sistema

```csharp
using System.Diagnostics;

void HastaLuego()
{
    Console.WriteLine("Reiniciant el sistema...");

    Process.Start(new ProcessStartInfo("shutdown", "/r /t 0")
    {
        CreateNoWindow = true,
        UseShellExecute = false
    });
}
```

---

# 📁 Sistema de fitxers

Per administrar fitxers i directoris s’utilitza el sistema **CosmosVFS**.

## 📌 Declaració del VFS

```csharp
Sys.FileSystem.CosmosVFS fs =
    new Cosmos.System.FileSystem.CosmosVFS();
```

## 📌 Registrar el VFS

```csharp
Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
```

## 📌 Afegir referència necessària

```csharp
using System.IO;
```

---

## 💾 Formatació del disc

Primer es busca el disc disponible i després es formata en **FAT32**.

```csharp
Disk.FormatDisk(int index, string format, bool quick = true)
```

---

# 📂 Comandes bàsiques implementades

## 📄 Obtenir fitxers d’un directori

```csharp
var files_list = Directory.GetFiles(@"0:\\");
```

## 📁 Obtenir directoris

```csharp
var directory_list = Directory.GetDirectories(@"0:\\");
```

## 🔍 Mostrar fitxers amb foreach

```csharp
foreach (var file in files_list)
{
    Console.WriteLine(file);
}
```

## 📖 Llegir contingut d’un fitxer

```csharp
var content = File.ReadAllText(file);
```

## 🆕 Crear fitxer

```csharp
File.Create(@"0:\\testing.txt");
```

## 📁 Crear directori

```csharp
Directory.Create(@"0:\\testdirectory\\");
```

## ❌ Eliminar fitxer i directori

```csharp
File.Delete(@"0:\\testing.txt");
Directory.Delete(@"0:\\testdirectory\\");
```

---

# 🔊 Sistema d’àudio

Per afegir sons de:

* 🔔 Arrencada
* ✅ Comanda correcta
* ❌ Error de comanda

s’utilitzen arxius `.wav`.

## 📌 Càrrega dels àudios

```csharp
byte[] bootBytes = GetResourceBytes("boot.wav");
byte[] okBytes = GetResourceBytes("ok.wav");
byte[] errorBytes = GetResourceBytes("error.wav");
```

## 📌 Llibreries necessàries

```csharp
using Cosmos.System.Audio;
using Cosmos.System.Audio.IO;
```

## 📌 Components utilitzats

```csharp
AudioMixer mixer;
AudioManager audioManager;
MemoryAudioStream bootStream, okStream, errorStream;
```

---

## 🎧 Compatibilitat d’àudio

L’àudio està implementat amb:

* `AudioMixer`
* `MemoryAudioStream`
* `AC97`

⚠️ En **VMware** pot no funcionar correctament perquè necessita compatibilitat amb el controlador **AC97**.

✅ Es recomana executar NitroOS amb **VirtualBox** configurant:

```text
Audio Controller → ICH AC97
```

Després de compilar el projecte, es genera una ISO que es pot carregar directament a la màquina virtual.

També s’ha modificat l’arxiu `.csproj` per adaptar la compilació del sistema.

---

🖥️ Interfície gràfica (CGS - Cosmos Graphics System)

En aquesta fase s’ha implementat el pas del mode text al mode gràfic utilitzant el subsistema CGS de Cosmos.

S’ha creat un canvas a pantalla completa amb resolució 640x480 i color de 32 bits, mitjançant:

FullScreenCanvas.GetFullScreenCanvas

Aquest sistema permet dibuixar directament sobre la pantalla utilitzant primitives gràfiques com:

▭ Rectangles
─ Línies
📝 Text
🎨 Elements visuals personalitzats
🎯 Pantalla de benvinguda gràfica

A partir del canvas s’ha dissenyat una pantalla inicial per a NitroOS, que inclou:

Element	Descripció
🎨 Fons personalitzat	Disseny visual propi del sistema
🧱 Marc decoratiu	Estructura visual de la pantalla
🚀 Logotip	Representació simple de NitroOS
ℹ️ Missatges informatius	Informació del sistema i instruccions
⌨️ Indicació d’entrada	“Prem Enter per entrar a la shell”
🧠 Arquitectura del sistema

Aquesta implementació introdueix una separació clara:

🖥️ Capa gràfica inicial (GUI) → Presentació del sistema
💻 Shell (CLI) → Execució de comandes

👉 La shell deixa de ser l’única interfície del sistema i passa a estar darrere d’una capa gràfica inicial, mantenint la mateixa lògica de comandaments però millorant l’experiència d’usuari.

🧩 Adaptació de les comandes al mode gràfic

El pas a mode gràfic també afecta directament el sistema de comandes, ja que aquestes deixen d’estar pensades exclusivament per a la shell en mode text.

Anteriorment, les ordres retornaven la informació directament per consola. En canvi, ara en entorn gràfic, la sortida s’ha de representar dins d’un Canvas, dibuixant manualment:

📝 Texts
🎨 Elements visuals
🪟 Components d’interfície
🔄 Canvis principals
Abans (mode text)	Ara (mode gràfic)
Sortida per consola	Sortida sobre Canvas
Console.WriteLine()	Dibuix manual de text
Flux lineal	Interfície visual estructurada
⚙️ Impacte en les comandes

Les comandes existents s’han d’adaptar perquè:

🖥️ Ja no n’hi ha prou amb imprimir text
🎯 Cal definir com es mostra la informació dins la UI
🧭 La sortida pot anar a pantalles, menús o elements visuals
⌨️ L’entrada de l’usuari s’ha de gestionar dins d’un entorn gràfic
🧠 Disseny del sistema

Aquest canvi implica una evolució important en l’arquitectura:

🧩 La lògica de les comandes es manté independent
🎨 La visualització es separa completament
🔌 Es crea una connexió entre comandes i interfície gràfica
🚀 Resultat

Aquest enfocament no elimina les comandes, sinó que:

✔ Les manté funcionals
✔ Les adapta al nou entorn gràfic
✔ Millora la modularitat del sistema
✔ Prepara NitroOS per futures interfícies més avançades

# 📚 Enllaç explicatiu de les comandes

> urlNitroOS Commands Documentation[https://github.com/Eduardo2828/NitroOS/blob/main/ideas/comandos.txt](https://github.com/Eduardo2828/NitroOS/blob/main/ideas/comandos.txt)

---

# 📜 Llicència

Aquest projecte disposa d’una llicència de **codi obert**.

---

<p align="center">
  <b>🚀 NitroOS — Aprenent sistemes operatius des de zero 🚀</b>
</p>
 https://github.com/Eduardo2828/NitroOS/blob/main/ideas/comandos.txt

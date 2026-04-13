**NitroOS**🚀

*Descripció*: NitroOS és el nostra propi sistema operatiu que hem desenvolupat amb CosmOS. Uilitza el llenguatge de C#. Tenint com a objectiu del projecte construir un entorn de consola que ens pugui permetre gestionar fitxers, directoris i informació del sistema de manera bàsica.


*Noms dels membres del grup*:

Noha, Javier i Marc.

![Logo del projecte](src/logo.png)




*Com funciona el nostra sistema*:


<img width="532" height="263" alt="image" src="https://github.com/user-attachments/assets/d0a3d2a0-f237-4cc4-a5a6-f92fd8262736" />




Aquí podem veure la pantalla d’inici de NitroOS executant-se dins d’una màquina virtual amb CosmOS.

A la part superior es veu la seqüència d’arrencada del sistema (Boot Sequence). Es mostra informació dels desenvolupadors del projecte i apareix el logotip de NitroOS en format ASCII art.

Finalment, es mostra un missatge de benvinguda i una breu instrucció perquè l’usuari entri a la shell. 

*Tecnologies utilitzades*:

Per a aquest servidor hem utilitzat llenguatge de programació en C#, com bé hem dit abans, el framework és de CosmOS, com a IDE tenim el Visual Studio Code 2022 i la plataforma que utilitcem és la .NET.


*Instal·lació i ús*:

[Més endavant]


*Estructura del projecte*:

[Captures + explicacions]


*Autors i contribucions*:

👩 Noha -> Revisió/Documentació.
👨 Javier -> Documentació 
👨 Marc -> Programació


*Llicència*:

Nosaltres disposem d'una llicència de codi obert per a aquest projecte.


*Roadmap o millores futures*:

·Llistar contingut
·Canviar directori
·Crear directori
·Eliminar directori
·Mostrar contingut fitxer
·Informació del sistema

·Mostrar ajuda
·Versió del SO
·Memòria disponible
·Temps de funcionament

·Netejar pantalla
·Escriure text
·Apagar/reiniciar

*Exemples d'una de les funcions creades*

#*Reiniciar el sistema*:

-----------------------------------------------------------------------------------------------------------------------------
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
-----------------------------------------------------------------------------------------------------------------------------


*Enllaç explicatiu de les comandes implementades:*

> https://github.com/Eduardo2828/NitroOS/blob/main/ideas/comandos.txt

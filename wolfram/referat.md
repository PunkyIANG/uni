Paradigme de Programare

Turcanu Cristian

Universitatea de Stat din Moldova

# 1. Principalele paradigme de programare

Paradigmele de programare de fapt sunt stiluri sau moduri de programare ce facilitează rezolvarea anumitor tipuri de sarcini în cadrul limbajelor de programare. Modelele date inerent nu exclud implementarea altor stiluri și pot evolua dintr-o paradigmă în alta, astfel rareori se găsesc limbaje de programare ce implementează doar o anumită paradigmă la suta de procente (asemenea limbaje fiind numite pure). Cel mai des se implementează elemente din mai multe modele pentru a facilita dezvoltarea programelor și rezolvarea diverselor sarcini în cadrul unui sistem.

## 1.1 Programarea imperativă

În programarea imperativă se descrie explicit fiecare pas din program, astfel fiind stilul cel mai apropiat de limbajul mașină. Stilul dat este implementat în limbajul Assembly, iar controlul explicit este în același timp avantajul și dezavantajul principal a acestui stil, oferind control total asupra stărilor programului, însă fiind extrem de dificil de programat și mai ales depanat.

```
.MODEL SMALL
.STACK 200H
.DATA <--------- This is a new part! Make sure to include this
Textstring db "I'm a string$"
.CODE
START:

Mov ax, SEG Textstring
Mov ds, ax
Mov dx, OFFSET Textstring
Mov ah, 09
Int 21h

mov ah, 4ch
mov al,00h
int 21h

END START
```

## 1.2 Programarea structurată 

Stilul de programare structurată este o evoluție directă a celui imperativ, în care controlul programului se face prin expresii imbricate, condiții și proceduri în loc de goto, iar variabilele sunt în general locale contextului. Cel mai popular reprezentant este limbajul C, care până în ziua de azi se folosește în programarea microcontrolerelor. 

```c
#include <stdio.h>
int main()
{
    for (int i = 0; i < 5; i++)
        printf("%d", i);

    return 0;
}
```
## 1.3 Programarea orientată pe obiect

Paradigma de programare orientată pe obiect se bazează pe transmiterea mesajelor obiectelor. Obiectele răspund la mesaje efectuând operații numite metode. De asemenea pot fi implementate principii precum moștenirea, polimorfismul și încapsularea. Un exemplu de limbaj orientat pe obiect este C#, care comparativ cu C++ nu permite prezența codului în afara obiectelor. 

```cs
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

## 1.4 Programarea declarativă

În programarea declarativă programatorul doar descrie rezultatul, iar sistemul singur alege metoda prin care va obține rezultatul dat.

```sql
select upper(name)
from people
where length(name) > 5
order by name
```

## 1.5 Programarea funcțională

Paradigma de programare funcțională structurează programul prin combinarea apelurilor de funcții în loc de folosirea variabilelor pentru controlarea stărilor programului. Această paradigmă de asemenea oferă posibilitatea de a transmite funcții ca parametri și valori returnate din alte funcții. O asemenea structurare a programului oferă posibilitatea de multithreading automat, astfel programatorul nu trebuie să se ocupe cu optimizările ce sunt efectuate de compilator.

```cs
var studentNames = studentList.Where(s => s.Age > 18)
                              .Select(s => s)
                              .Where(st => st.StandardID > 0)
                              .Select(s => s.StudentName);
```

# 2. Descrierea sistemului Wolfram Mathematica

## 2.1 Componentele sistemului Wolfram Mathematica

Sistemul Wolfram Mathematica este constituit din două părți de bază: frontend-ul și kernel-ul. Frontend-ul este de facto interfața grafică a sistemului și efectuează rendering-ul a notebook-ului și oricăror grafice create. Kernel-ul de facto este backend-ul sistemului, astfel efectuând calculele necesare. E de menționat faptul că componentele date pot lucra separat cu o funcționalitate limitată, astfel frontend-ul poate arăta fișierele de tip nb, iar kernel-ul poate fi rulat din consolă și astfel efectua toate calculele necesare, însă frontend-ul are nevoie de kernel pentru calcule, iar kernel-ul are nevoie de frontend pentru renderul graficelor.

## 2.2 Descrierea frontend-ului sistemului

În cadrul frontend-ului fragmentele de cod se separă în celule, fiecare având câte o porțiune pentru input și output, astfel codul este introdus în input, iar rezultatul este prezentat în output după rulare. Separarea pe celule permite setarea mai multor programe mici în cadrul unui fișier, ceea ce permite scrierea și testarea rapidă a mai multor programe, pe când scrierea programelor mari decurge ca de obicei în cadrul altor medii de dezvoltare. Celulele date pot fi folosite nu numai pentru cod, ci și pentru scrierea textelor, pentru care se folosește Writing Assistant-ul din tab-ul paletelor. 

## 2.3 Descrierea kernel-ului

În cadrul versiunii pentru Windows kernelul sistemului Wolfram se află în fișierul wolframscript.exe. Acest script poate fi pornit pur și simplu prin dublu clic, ceea ce va porni consola de comenzi asemănătoare cu interfața frontend-ului, însă fără avantajele acestuia precum introducerea ușoară a simbolurilor speciale. Cum a fost menționat mai sus, kernelul poate lucra și separat, însă în cazul când se cere vreun render grafic într-o interfață mai detaliată (precum frontend-ul), acesta pur și simplu va scrie textul -Graphics- la ecran, ceea ce semnalizează că este nevoie de frontend pentru rendering. De asemenea kernelul poate fi chemat doar pentru calculul unei comenzi din consolă sau chiar alte programe, pur și simplu chemând kernelul și adăugând parametrul -code înainte de codul ce trebuie calculat. De asemenea există și fișierele executabile MathKernel și WolframKernel ce oferă aceeași funcționalitate ca și kernelul, însă într-o interfață asemănătoare cu notepad-ul standard din Windows.

# 3. Descrierea limbajului Wolfram

## 3.1 Rebrandingul sistemului din Mathematica

Inițial produsul dat a fost lansat în 1988 sub denumirea Mathematica, care ulterior a fost implementat în cadrul limbajului Wolfram, împreună cu Wolfram Alpha, Wolfram Cloud și alte componente. Reorganizarea dată a permis și rebrandingul produsului, ceea ce a permis adoptarea mai largă a sistemului, mai ales în cazul persoanelor ce nu se ocupă în adânc cu matematica. Asocierea denumirii vechi cu orice fel de calcule manuale nu a dat impresia că produsul dat poate fi folosit pentru rezolvarea unor sarcini reale, astfel decizia dată a permis lărgirea porțiunii de piață care potențial ar dori să folosească acest produs.

## 3.2 Regulile limbajului Wolfram

În cadrul limbajului Wolfram sunt trei reguli de bază ce definesc modul de interacțiune cu sistemul. În primul rând, orice este o expresie simbolică de tip f[a, b ... n]. Un simbol este o oarecare unitate de date, fie ea o structură complexă sau o denumire de date nedefinite, astfel nivelul dat de abstracție permite obținerea unui răspuns în cazul când o cerere nu este definită în întregime (spre exemplu - rezolvarea unei ecuații). În continuare, orice este o listă, astfel implementarea colecțiilor dinamice la nivel fundamental permite folosirea ușoară și optimizarea maximă a acestora. În final, orice este o funcție. Funcțille sunt definite ca expresii de tipul f[a, b ... n], ceea ce permite citirea ușoară a codului de către kernel. Această structură însă nu este cea mai ușoară de citit pentru utilizatori, astfel în sistem sunt incluse variante de utilizare a unor funcții prin expresii mai comode, precum 2 + 2 în loc de Plus[2, 2]. 

## 3.3 Wolfram as a functional language

Regulile descrise mai sus permit implementarea paradigmei de programare funcțională. În primul rând, faptul că orice este o funcție de facto impune necesitatea de formare a lanțurilor de funcții pentru a efectua anumite calcule. De asemenea, în Wolfram fiecare funcție este extension function automat, ceea ce permite utilizarea expresiei // postfix care ia rezultatul funcției din stânga ca primul parametru pentru cea din dreapta, ceea ce permite citirea intuitivă a codului de la stânga la dreapta asemenea unui text. 

În continuare, faptul că orice este o listă permite formarea unui sistem uniform de output a rezultatelor funcțiilor în cazul când se obține o mulțime de răspunsuri. Uniformitatea dată permite utilizarea ulterioară a listelor date ca date de intrare pentru alte funcții, ulterior facilitând formarea lanțurilor de funcții. 

În final, folosirea simbolurilor ca unități de bază pentru variabile permite executarea funcțiilor chiar în cazul când acestea nu sunt cunoscute, continuând executarea în cadrul lanțului de funcții.

Stabilirea acestor reguli permite implementarea avantajelor paradigmei de programare funcțională, cel mai important fapt fiind că fiecare funcție este pură în sens programatic, adică nu folosește date globale și interacționează doar cu datele transmise prin parametri. Acest fapt asigură faptul că doar funcția dată poate interacționa cu informațiile, automat excluzând posibilitatea de formare a race condition-urilor, ceea ce în final permite implementarea automată a multithreading-ului. Analog funcției foreach ce permite interacțiunea secvențială cu fiecare component a unei liste, Wolfram efectuează aceasta prin funcția Map, însă face aceasta în mod automat paralel.


<!-- https://cs.lmu.edu/~ray/notes/paradigms/
https://mathematica.stackexchange.com/questions/37557/is-mathematica-an-implementation-of-the-wolfram-language
https://youtu.be/_P9HqHVPeik -->
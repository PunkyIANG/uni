Paradigme de Programare

Turcanu Cristian

Universitatea de Stat din Moldova

# 1. Principalele paradigme de programare

Paradigmele de programare de fapt sunt stiluri sau moduri de programare ce facilitează rezolvarea anumitor tipuri de sarcini în cadrul limbajelor de programare. Modelele date inerent nu exclud implementarea altor stiluri și pot evolua dintr-o paradigmă în alta, astfel rareori se găsesc limbaje de programare ce implementează doar o anumită paradigmă la suta de procente (asemenea limbaje fiind numite pure). Cel mai des se implementează elemente din mai multe modele pentru a facilita dezvoltarea programelor și rezolvarea diverselor sarcini în cadrul unui sistem.

## 1.1 Programarea imperativă

În programarea imperativă se descrie explicit fiecare pas din program, astfel fiind stilul cel mai apropiat de limbajul mașină. Stilul dat este implementat în limbajul Assembly, iar controlul explicit este în același timp avantajul și dezavantajul principal a acestui stil, oferind control total asupra stărilor programului, însă fiind extrem de dificil de programat și mai ales depanat.

***insert assembly example from iCloud***

## 1.2 Programarea structurată 

Stilul de programare structurată este o evoluție directă a celui imperativ, în care controlul programului se face prin expresii imbricate, condiții și proceduri în loc de goto, iar variabilele sunt în general locale contextului. Cel mai popular reprezentant este limbajul C, care până în ziua de azi se folosește în programarea microcontrolerelor. 

***example***

## 1.3 Programarea orientată pe obiect

Paradigma de programare orientată pe obiect se bazează pe transmiterea mesajelor obiectelor. Obiectele răspund la mesaje efectuând operații numite metode. De asemenea pot fi implementate principii precum moștenirea, poliformismul și incapsularea. Un exemplu de limbaj orientat pe obiect este C#, care comparativ cu C++ nu permite prezența codului în afara obiectelor. 

***example***

## 1.4 Programarea declarativă

În programarea declarativă programatorul doar descrie rezultatul, iar sistemul singur alege metoda prin care va obține rezultatul dat.

***example***

## 1.5 Programarea funcțională

Paradigma de programare funcțională structurează programul prin combinarea apelurilor de funcții în loc de folosirea variabilelor pentru controlarea stărilor programului. Această paradigmă de asemenea oferă posibilitatea de a transmite funcții ca parametri și valori returnate din alte funcții. O asemenea structurare a programului oferă posibilitatea de multithreading automat, astfel programatorul nu trebuie să se ocupe cu optimizările ce sunt efectuate de compilator.

***example***

# 2. Descrierea sistemului Wolfram Mathematica

## 2.1 Componentele sistemului Wolfram Mathematica

Sistemul Wolfram Mathematica este constituit din două părți de bază: frontend-ul și kernel-ul. Frontend-ul este de facto interfața grafică a sistemului și efectuează rendering-ul a notebook-ului și oricăror grafice create. Kernel-ul de facto este backend-ul sistemului, astfel efectuând calculele necesare. E de menționat faptul că componentele date pot lucra separat cu o funcționalitate limitată, astfel frontend-ul poate arăta fișierele de tip nb, iar kernel-ul poate fi rulat din consolă și astfel efectua toate calculele necesare, însă frontend-ul are nevoie de kernel pentru calcule, iar kernel-ul are nevoie de frontend pentru renderul graficelor.

## 2.2 Descrierea frontend-ului sistemului

Frontend-ul 
//structurarea pe noduri

## 2.3 Descrierea kernel-ului

// cli stuff

# 3. Descrierea limbajului Wolfram

## 3.1 Scurt istoric

Inițial Stephen Wolfram a lansat sistemul Mathematica în anul 1988, însă din cauza asocierii acestei denumiri cu orice fel de matematică superioară acesta a fost redenumit în Wolfram Language, astfel fiind adoptat în mai multe sfere de inginerie și cercetare.
// doubt (https://www.wolfram.com/language/faq/) 

## 3.2 Regulile limbajului Wolfram

everything is a function

## 3.3 Wolfram as a functional language

Limbajul Wolfram este bazat pe paradigma de programare funcțională, astfel fiecare 

//multithreading automat
//your own pc memory is the limit
symbolic



sauce: 

https://cs.lmu.edu/~ray/notes/paradigms/
https://mathematica.stackexchange.com/questions/37557/is-mathematica-an-implementation-of-the-wolfram-language
https://youtu.be/_P9HqHVPeik
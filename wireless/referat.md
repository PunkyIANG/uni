## Cuprins

- Introducere
- wifisec & exploits
- bluetooth shenanigans

## Introducere

Rețelele fără fir au o diferență cardinală în structura sa comparativ cu cele cu fir: semnalele se transmit printr-un mediu comun, deci orice utilizator ce are echipamentul necesar poate de facto primi orice semnal din rețeaua dată, chiar dacă acestea nu sunt destinate lui. Această diferență oferă oportunitatea de a asculta orice informații transmise și impune necesitatea de a securiza datele la nivel de rețea. 

## Bluetooth

În primul rând, standartul Bluetooth oferă patru moduri de securitate ce specifică timpul în care se efectuează procedurile de securitate. Primul mod niciodată nu folosește proceduri de securitate, al doilea folosește autorizarea la nivel logic, însă deja după crearea legăturii fizice, al treilea efectuează procedurile la crearea legăturii fizice, iar al patrulea folosește autorizarea după crearea legăturii fizice și logice. Primul mod nu oferă niciun grad de securitate și este folosit doar pentru compatibilitate, iar modul al patrulea este folosit numaidecât la conecțiunea dintre dispozitive de versiune Bluetooth 2.1 și mai sus. Modul 4 de asemenea folosește 5 niveluri de securitate ce specifică necesitatea de criptare, interacțiunile utilizatorului la crearea legăturii, protecția MITM și folosirea algoritmilor criptografici aprobați de FIPS. Sistemul dat este astfel de complicat din cauza necesității de compatibilitate totală, diferenței de specificații și lipsei de standartizare a securității dispozitivelor Bluetooth lansate inițial.

La crearea legăturii dintre dispozitive se stabilește cheia simetrică care se va folosi pentru criptarea mesajelor transmise, care se numește Link Key. În modurile de securitate 2 și 3 se folosește generarea cheii prin tastarea unui cod PIN în ambele device-uri. Dispozitivele se vor autentifica prin verificarea PIN-ului comun și vor crea legătura.

În modul de securitate 4 se folosește metoda SSP (Secure Simple Pairing) ce oferă mai multe opțiuni de asociere a dispozitivelor în dependență de opțiunile de input și output prezente. 

Prima opțiune numită Numeric Comparison se folosește pe dispozitivele ce pot arăta un cod de șase cifre pe ecranele sale și permit utilizatorului să introducă răspunsul "Da" sau "Nu". La crearea legăturii, fiecare dispozitiv va arăta un cod de șase cifre pe ecran, și în caz că acestea coincid utilizatorul apasă "Da", în caz contrar introduce "Nu". Comparativ cu autentificarea prin PIN, codul dat nu se folosește la crearea Link Key-ului, astfel chiar dacă o persoană terță are acces la acest cod, acesta nu va putea folosi codul pentru obținerea cheii. 

Passkey Entry se folosește în cazul când un dispozitiv poate arăta output, pe când celălalt poate doar transmite input (ex. tastatură). În cazul dat, dispozitivul cu ecran afișează un cod de șase cifre pe care utilizatorul îl va introduce pe dispozitivul de input. Analog opțiunii de mai sus, codul dat nu se folosește la crearea cheii.

Just Works se folosește în cazul când cel puțin un dispozitiv nu are nici opțiuni de input, nici de output. Opțiunea dată efectuează autentificarea conform metodei Numeric Comparison, însă utilizatorul este cerut să accepte conexiunea fără să verifice codul generat, astfel Just Works nu oferă protecție împotriva atacurilor MITM.

Out of Band (OOB) este creat pentru dispozitivele ce suportă o tehnologie cu sau fără fir (ex. Near Field Communication, NFC) comună pentru descoperirea dispozitivelor și schimb de date criptografice. În cazul tehnologiei NFC, metoda OOB permite asocierea dispozitivelor prin simpla atingere a lor și confirmarea conexiunii de către utilizator. Este important de reținut că pentru a face procesul de împerechere cât mai sigur, tehnologia OOB folosită trebuie să fie proiectată și configurată pentru a mitiga ascultarea pasivă și atacurile MITM.

De asemenea, SSP folosește algoritmul ECDH (Elliptic Curve Diffie-Hellman) pentru stabilirea Link Key-ului, implementând metode de criptografie cu cheie publică, astfel cheia dată este protejată împotriva atacurilor pasive și MITM.

Analog modurilor de securitate de mai sus, există moduri de securitate și servicii ce oferă niveluri diferite de protecție, de la criptare totală până la transmiterea datelor fără nicio protecție. Deși specificațiile Bluetooth cer ca să fie folosit cel mai sigur mod suportat de ambele dispozitive, în cazul utilizării unor aparate vechi pot să fie ignorate toate măsurile de securitate pentru a păstra compatibilitatea, astfel dispozitivele vechi sunt prime ținte pentru atac.

Atacurile Bluetooth în mare parte folosesc vulnerabilitățile versiunilor vechi pentru a exploata problemele hardware-ului sau ingineria socială pentru a manipula utilizatorul. Spre exemplu, Bluesnarfing și Bluebugging lucrează doar pe dispozitivele create până în anul 2003, iar Bluejacking și BlueStumbling se previn prin folosirea modului de descoperire doar în caz strict necesar, fără a lăsa acesta întotdeauna pornit.

## WLAN/Wi-Fi


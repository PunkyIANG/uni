# Introducere
## Obiectivele lucrării

- Setarea topologiei rețelei,
- Configurarea serviciului DHCP pe routerul fără fir,
- Conectarea dispozitivelor la rețea și testarea conexiunii.

# Rezolvare
## Setarea topologiei

Pentru rețeaua dată avem nevoie de un router wireless de tip Home Router, un desktop ce va fi conectat prin fir și câteva laptop-uri ca clienți wireless. Conectăm desktopul la routerul wireless.

![](1.png)

## Configurarea serviciului DHCP pe routerul fără fir

Deschidem interfața routerului, fereastra GUI. În secțiunea Network Setup setăm ip adresa dorită pentru router în rețeaua dată și masca de subrețea. Pornim serverul DHCP și setăm adresa de start pentru DHCP și numărul maxim de utilizatori. În cazul nostru setăm adresa routerului 192.168.0.1/24, adresa de start 192.168.0.2, iar numărul de utilizatori 50. 

![](2.png)

În continuare vom rezerva o anumită adresă desktopului cu fir. Tastăm DHCP Reservation și adăugăm manual desktopul. Setăm o denumire oarecare, alegem adresa ip dorita din diapazonul DHCP pentru rezervare, iar adresa MAC o luăm din setările cartelei de rețea a desktopului. În cazul nostru avem adresa 192.168.0.2.

![](3.png)

## Conectarea dispozitivelor la rețea și testarea conexiunii

Conectăm desktopul la router prin cablul Copper Straight-Through și setăm cartela de rețea ca să obțină adresa de ip prin DHCP. Laptop-urile le oprim, schimbăm cartela de rețea la una wireless, intrăm în interfața PC Wireless și conectăm laptopul la rețea fără fir. 

![](4.png)

Verificăm dacă adresele IP au fost setate corect. Desktop-ul trebuie să aibă adresa 192.168.0.2, iar laptop-urile trebuie să fie în diapazonul 192.168.0.3-51.

![](5.png)

Adresele au fost setate cu succes, deci verificăm conexiunea prin ping:

![](6.png)

![](7.png)

Vedem că conexiunea lucrează, deci rețeaua a fost setată cu succes.

# Concluzii

În această lucrare am demonstrat cum se setează serviciul DHCP a unei rețele fără fir. Am observat faptul că serviciului dat se setează în același timp pentru dispozitivele cu fir și fără fir, astfel în cazul adăugării funcționalității wireless la o rețea existentă nu e necesară setarea adițională a DHCP. De asemenea acest serviciu este necesar de folosit în cazul proiectării unei rețele publice, astfel utilizatorii ce nu cunosc arhitectura rețelei se vor putea conecta într-un clic.
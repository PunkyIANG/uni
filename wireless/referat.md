## Cuprins

- Introducere
- wifisec & exploits
- bluetooth shenanigans

## Introducere

Rețelele fără fir au o diferență cardinală în structura sa comparativ cu cele cu fir: semnalele se transmit printr-un mediu comun, deci orice utilizator ce are echipamentul necesar poate de facto primi orice semnal din rețeaua dată, chiar dacă acestea nu sunt destinate lui. Această diferență oferă oportunitatea de a asculta orice informații transmise și impune necesitatea de a securiza datele la nivel de rețea. 

## Bluetooth

Ca și o măsură de securitate de bază, tehnologia Bluetooth folosește algoritmi ce permit transmiterea securizată de chei, precum introducerea unui pin de către utilizator fără a transmite acesta în rețea (Out Of Band), transmiterea prin NFC sau **folosirea algoritmului Diffie-Hellman pentru partajarea cheii în mod securizat** counterpoint - Just Works . Ulterior această cheie se folosește pentru criptarea simetrică AES-CCM. 

## WLAN/Wi-Fi


Fie gramatica independentă de context

$ G=(V_N, V_T, P, S), \\\\
V_N=\\{S, A, B\\}, \\\\
V_T=\\{a, b\\}, \\\\ 
P=\\{ \\\\
1\. S → bA | aB \\\\
2\. A → bAA | aS | a \\\\
3\. B → aBB | ab | b \\\\
\\}
$

Generați un cuvânt alcătuit din 5-7 simboluri.

Efectuați analiza sintactică utilizând algoritmul Cocke-Younger-Kasami.

Desenaţi arborele de derivare. 

In gramatica nu avem epsilon productii, redenumiri si reguli inaccesibile si inutile, deci reducem la FNC:

$ G=(VN, VT, P, S), \\\\
VN=\\{S, A, B, X, Y\\}, \\\\
VT=\\{a, b\\}, \\\\ 
P=\\{ \\\\
1\. S → YA | XB \\\\
2\. A → YAA | XS | a \\\\
3\. B → XBB | XY | b \\\\
4\. X → a \\\\
5\. Y → b \\\\
\\}
$

$ G=(VN, VT, P, S), \\\\
VN=\\{S, A, B, X, Y, Z_1, Z_2\\}, \\\\
VT=\\{a, b\\}, \\\\ 
P=\\{ \\\\
1\. S → YA | XB \\\\
2\. A → YZ_1 | XS | a \\\\
3\. Z_1 → AA \\\\
4\. B → XZ_2 | XY | b \\\\
5\. Z_2 → BB \\\\
6\. X → a \\\\
7\. Y → b \\\\
\\}
$

Generam un cuvant din gramatica:

$ S → YA → YXS → YXXB → YXXXZ_2 → YXXXBB → baaabb$

<br>
<br>

| b | a | a | a | b | b |
| --- | --- | --- | --- | --- | --- |
| B, Y | A, X | A, X | A, X | B, Y | B, Y |
| S | Z<sub>1</sub> | Z<sub>1</sub> | S, B | Z<sub>2</sub> |
| A | - | A, B | B, Z<sub>2</sub> |
| Z<sub>1</sub> | Z<sub>1</sub>, S | S, B, Z<sub>2</sub> | 
| A | A, B |
| S, Z<sub>2</sub>|

S este la sfarsit, deci confirmam ca cuvantul este in gramatica
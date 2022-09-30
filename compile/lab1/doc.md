Turcanu Cristian, IA1901

Lucrare de laborator nr.1

Varianta 1

Construiti forma normala Greybach pentru g.i.c:

$ G = (\\{F, R, T, M, E\\}, \\{a, b, k, \\{, [, \\}, ]\\}, P, S), \\\\
1\. F \rightarrow \\{R | [Rk \\\\
2\. R \rightarrow Ra\\} | Rab] | a | T | M | \varepsilon \\\\
3\. M \rightarrow \\{E\\} | bb \\\\
4\. T \rightarrow [M] \\\\
5\. E \rightarrow \varepsilon \\\\
$

Rezolvare:

Initial eliminam epsilon productiile:

$ \varepsilon _1 = \\{R, E\\}; 
\varepsilon _2 = \\{R, E\\}; 
$

$ G = (\\{F, R, T, M, E\\}, \\{a, b, k, \\{, [, \\}, ]\\}, P, S), \\\\
1\. F \rightarrow \\{R | \\{ | [Rk | [k \\\\
2\. R \rightarrow Ra\\} | a\\} | Rab] | ab] | a | T | M \\\\
3\. M \rightarrow \\{E\\} | \\{\\} | bb \\\\
4\. T \rightarrow [M] \\\\
$

Eliminam simbolurile inutile si neproductive

E e neproductiv, deci il eliminam:

$ G = (\\{F, R, T, M\\}, \\{a, b, k, \\{, [, \\}, ]\\}, P, S), \\\\
1\. F \rightarrow \\{R | \\{ | [Rk | [k \\\\
2\. R \rightarrow Ra\\} | a\\} | Rab] | ab] | a | T | M \\\\
3\. M \rightarrow \\{\\} | bb \\\\
4\. T \rightarrow [M] \\\\
$

Construim forma normala Greybach, deci redenumim neterminalii:

$F = A_0; R = A_1; M = A_2; T = A_3 \\\\
G = (\\{A_0, A_1, A_2, A_3\\}, \\{a, b, k, \\{, [, \\}, ]\\}, P, S), \\\\

1\. A_0 \rightarrow \\{A_1 | \\{ | [A_1k | [k \\\\
2\. A_1 \rightarrow A_1a\\} | a\\} | A_1ab] | ab] | a | A_3 | A_2 \\\\
3\. A_2 \rightarrow \\{\\} | bb \\\\
4\. A_3 \rightarrow [A_2] \\\\
$

Eliminam recursia stanga din A<sub>1</sub>:


$ 1\. A_0 \rightarrow \\{A_1 | \\{ | [A_1k | [k \\\\
2\. A_1 \rightarrow a\\} | ab] | a | A_3 | A_2 
| a\\}A_4 | ab]A_4 | aA_4 | A_3A_4 | A_2A_4 \\\\
3\. A_2 \rightarrow \\{\\} | bb \\\\
4\. A_3 \rightarrow [A_2] \\\\
5\. A_4 \rightarrow aA_4 | a | abA_4 | ab
$

Observam ca toate partile stangi a regulilor se incep cu simboluri terminale, deci am obtinut gramatica in forma Greybach.
CYK01. Fie gramatica independenta de context 

$ G = (V_N, V_T, P, D),  \\\\
V_N=\\{ D, L, S, Z \\},\\\\
V_T = \\{ :, (, ), v, ,, i \\},  \\\\
P = \\\\
\\{ \\\\
1\. D \rightarrow L, \\\\
2\. L \rightarrow Z:S, \\\\
3\. S \rightarrow i, \\\\
4\. S \rightarrow (Z), \\\\
5\. Z \rightarrow v, \\\\
6\. Z \rightarrow Z,v  \\\\
\\}
$

Generati un cuvant alcatuit din 5-7 simboluri. Efectuati analiza sintactica utilizand algoritmul Cocke-Yanger-Kasami.

Rezolvare:

Initial transformam gramatica pentru a elimina epsilon productiile, redenumirile si simboluri inaccesibile si inutile. Gramatica nu are epsilon productii, iar singura redenumire este in regula 1:


$ G = (V_N, V_T, P, D),  \\\\
V_N=\\{ D, S, Z \\},\\\\
V_T = \\{ :, (, ), v, ,, i \\},  \\\\
P = \\\\
\\{ \\\\
1\. D \rightarrow Z:S, \\\\
2\. S \rightarrow i, \\\\
3\. S \rightarrow (Z), \\\\
4\. Z \rightarrow v, \\\\
5\. Z \rightarrow Z,v  \\\\
\\}
$

Reguli inaccesibile si inutile nu avem, deci reducem la FNC:

$ G = (V_N, V_T, P, D),  \\\\
V_N=\\{ D, S, Z, X_1, X_2, X_3, X_4, X_5 \\},\\\\
V_T = \\{ :, (, ), v, ,, i \\},  \\\\
P = \\\\
\\{ \\\\
1\. D \rightarrow ZX_1S, \\\\
2\. X_1 \rightarrow : \\\\
3\. S \rightarrow i, \\\\
4\. S \rightarrow X_2ZX_3, \\\\
5\. X_2 \rightarrow (  \\\\
6\. X_3 \rightarrow ) \\\\
7\. Z \rightarrow v, \\\\
8\. Z \rightarrow ZX_4X_5  \\\\
9\. X_4 \rightarrow , \\\\
10\. X_5 \rightarrow v \\\\
\\}
$

$ G = (V_N, V_T, P, D),  \\\\
V_N=\\{ D, S, Z, X_1, X_2, X_3, X_4, X_5, Y_1, Y_2 \\},\\\\
V_T = \\{ :, (, ), v, ,, i \\},  \\\\
P = \\\\
\\{ \\\\
1\. D \rightarrow ZY_1, \\\\
2\. Y_1 \rightarrow X_1S \\\\
2\. X_1 \rightarrow : \\\\
3\. S \rightarrow i, \\\\
4\. S \rightarrow X_2Y_2, \\\\
5\. Y_2 \rightarrow ZX_3 \\\\
6\. X_2 \rightarrow (  \\\\
7\. X_3 \rightarrow ) \\\\
8\. Z \rightarrow v, \\\\
9\. Z \rightarrow ZY_3  \\\\
10\. Y_3 \rightarrow X_4X_5 \\\\
11\. X_4 \rightarrow , \\\\
12\. X_5 \rightarrow v \\\\
\\}
$

Generam un cuvant din gramatica:

$ D \rightarrow ZY_1 \rightarrow vX_1S \rightarrow v:X_2Y_2 \rightarrow v:(ZX_3 \rightarrow v:(v) $
<!-- 
<br>
<br>
<br>
<br>
<br>
<br>
<br> -->

$ T_{11} = Z | X_5 $

$ T_{21} = X_1 $

$ T_{31} = X_2 $

$ T_{41} = Z | X_5 $

$ T_{51} = X_3 $

<br>

$ T_{12} = Z | X_5 $

$ T_{22} = X_1 $

$ T_{32} = X_2 $

$ T_{42} = Z | X_5 $

$ T_{52} = X_3 $





| v | : | ( | v | ) |
| --- | --- | --- | --- | --- |
| Z, X<sub>5</sub> | X<sub>1</sub> | X<sub>2</sub> | Z, X<sub>5</sub> | X<sub>3</sub> |
| - | - | - | Y<sub>2</sub> |
| - | - | S |
| - | Y<sub>1</sub> |
| D |

Confirmam ca cuvantul face parte din gramatica.
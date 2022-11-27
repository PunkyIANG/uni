Fie gramatica independentă de context  

$ G=(V_N, V_T, P, S), \\\\
V_N = \\{S, A, B, C\\}, \\\\
V_T = \\{a, b, c, d\\},\\\\
P = \\{\\\\
1\. S → aSA | ab     \\\\
2\. A → Bab | Ab | b       \\\\
3\. B → BaC | da      \\\\
4\. C → cb \\\\
\\}. $

Construiți Forma Normală Greibach.

Nu avem epsilon productii, simboluri inutile si neproductive, deci redenumim neterminalii: 

$ G=(V_N, V_T, P, A_0), \\\\
V_N = \\{A_0, A_1, A_2, A_3\\}, \\\\
V_T = \\{a, b, c, d\\},\\\\
P = \\{\\\\
1\. A_0 → aA_0A_1| ab     \\\\
2\. A_1 → A_2ab | A_1b | b       \\\\
3\. A_2 → A_2aA_3 | da      \\\\
4\. A_3 → cb \\\\
\\}. $

Eliminam recursia stanga din A_1 si A_2:

$ G=(V_N, V_T, P, A_0), \\\\
V_N = \\{A_0, A_1, A_2, A_3, A_4, A_5\\}, \\\\
V_T = \\{a, b, c, d\\},\\\\
P = \\{\\\\
1\. A_0 → aA_0A_1| ab     \\\\
2\. A_1 → A_2ab | b | A_2abA_4 | bA_4      \\\\
3\. A_2 → da | daA_5     \\\\
4\. A_3 → cb \\\\
5\. A_4 → bA_4 | b\\\\
6\. A_5 → aA_3A_5 | aA_3\\\\
\\}. $

Inlocuim A_2 din regula 2 cu partea sa stanga:

$ G=(V_N, V_T, P, A_0), \\\\
V_N = \\{A_0, A_1, A_2, A_3, A_4, A_5\\}, \\\\
V_T = \\{a, b, c, d\\},\\\\
P = \\{\\\\
1\. A_0 → aA_0A_1| ab     \\\\
2\. A_1 → daab | daA_5ab | b | daabA_4 | daA_5abA_4 | bA_4      \\\\
3\. A_2 → da | daA_5     \\\\
4\. A_3 → cb \\\\
5\. A_4 → bA_4 | b\\\\
6\. A_5 → aA_3A_5 | aA_3\\\\
\\}. $

Toate regulile se incep cu un simbol terminal, deci am obtinut gramatica in forma Greybach.
Este dată gramatica independentă de context

G=(VN, VT, P, E), 
VN = {E, T, F},    
VT = {a ,b, c, +, -, *,/, (, )},    

P={ 
    1. E → T   
    2. E → E + T     
    3. E → E - T    
    4. T → F    
    5. T → T * F     
    6. T → T / F    
    7. F → ( E )    
    8. F → a   
    9. F → b    
    10. F → c   
    11. F → d  
}.

Aplicând schema de traducere dirijată prin sintaxă cu atributul sintetizat postfix construiţi notaţia postfix pentru expresia b-(a/b-d)/c-a.

![](1.png)
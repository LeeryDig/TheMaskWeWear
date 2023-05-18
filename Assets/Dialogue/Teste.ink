INCLUDE globals.ink 

{mano == "": -> main | -> already_chosen }

=== main ===

O que o que é? Clara e salgada?
    + [Cabe em um olho pesa uma tonelada]
        -> chosen("Tem sabor de mar, pode ser discreta inquilina da dor morada predileta, na calada ela vem refem da vingança, irmã do desespero rival da esperaça.")
    + [Mar?]
        -> chosen("Voce não é cria")
    + [HK?]
        -> chosen("Voce não é cria")
    + [Sai tiu! Ta locão?]
        -> END
        
=== chosen(response) ===
~mano = response
{response}!
->END

=== already_chosen ===
{mano}
->END 
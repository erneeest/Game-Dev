INCLUDE global.ink

{pokemon_name == "": ->main | ->alreadyChose}

=== main ===
Which pokemon do you choose?
    *[Charmander2222222222222222222222222222]
        -> chosen("Charmander")  
    *[Squirtle]
        -> chosen("Squirtle")
    *[Bulbasaur]
        -> chosen("Bulbasaur")
    - HELL YEAH!
-> END

=== chosen(pokemon) ===
~ pokemon_name = pokemon
you chose {pokemon}
-> END

=== alreadyChose ===
you already chose {pokemon_name}
->END
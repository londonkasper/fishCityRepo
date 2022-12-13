INCLUDE globals.ink
{color_choice == "": -> main | -> already_chosen}
-> main
=== main ===
#speaker: Speckled Fish #portrait: NPC1_default #layout: DefaultLayout
Psst... they say that you can tell a lot about a fish from their favorite color. What's your favorite color?
    +[Blue]
        -> chosen("Blue")
    +[Black]
        ->chosen("Black")
    +[Red]
        ->chosen("Red")

=== chosen(choices) ===

~ color_choice = choices

{choices}? Hmm... not sure how I feel about that.
-> DONE

== already_chosen ==
#layout: DefaultLayout
{color_choice} is your favorite color... still not sure about that one. {
    -color_choice  == "Blue":
        ~ fishChoice = "red"
    -color_choice == "Black":
        ~ fishChoice = "pink"
    -else:
        ~ fishChoice = "blue" 
        }
See, my favorite color is {fishChoice}. But you wouldn't understand the appeal seeing as you have no taste.
-> END
INCLUDE globals.ink
{alreadySpoke == false: -> main | -> already_spoke}
-> main
=== main ===
#speaker: Jelly #portrait: jelly_default #layout: DefaultLayout
Hello! {
    -color_choice  == "":
        ... 
    -else:
        {color_choice}! What a splendid color. I just can't get enough of it! 
    
        I did a purge of my closet and got rid of anything that didn't spark joy.
    
        And what would you know?  Everything leftover was the color...
        {color_choice}! 
        ~ alreadySpoke = true
        }

->END 

=== already_spoke === 
    See, I don't even have that many items in my closet anyways.
    I don't tend to wear much clothing, but sometimes I wear hats.
    If I'm being honest, it's a little bit embarrassing. 
-> DONE    

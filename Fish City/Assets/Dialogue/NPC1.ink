//Just an example from the video
Hello there! #speaker: NPC 1 #portrait: NPC1_default #layout: Left
-> main

=== main === 
How are you doing?
+ [Happy]
    That's good to hear! 
+ [Sad]
    Oh no!

- I'm the other sprite in this conversation and I don't really care how you feel. #speaker: NPC 2 #portrait: jelly_default #layout: Right

Well, any questions? #speaker: NPC 1 #portrait: NPC1_default #layout: Left
+[Yes]
    -> main
+[No]
    Goodbye!
    -> END
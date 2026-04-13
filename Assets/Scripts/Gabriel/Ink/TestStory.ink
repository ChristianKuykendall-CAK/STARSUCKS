VAR girl = 0
VAR day = 0

{girl == 1: ->Madeleine | {girl == 2: -> Priscilla | -> Guinevere}}

===Madeleine===
{day == 1: -> day1 | {day == 2: -> day2 | -> day3}}

== day1 == 
- Hey! how are you today?
    * Good, how about you?
    -> howAboutYou
    * I'm good.
    -> imGood
    
- (howAboutYou)
    - I'm good! Thanks for asking. 
    - Ba ba ba lin lin.
    -> end
    
- (imGood)
    - Oh, good. 
    -> end

- (end) -> END

== day2 ==
- It's day two Anon!! yay :3
-> END

== day3 ==
- It's day three Anon!! yay :3
-> END



===Priscilla===

-> END



===Guinevere===

-> END
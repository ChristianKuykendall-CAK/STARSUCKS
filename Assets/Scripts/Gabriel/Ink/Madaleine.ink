VAR MadaleineMentioned = false


===Madeleine===

= day1
Hey! how are you today?
    * [Good, how about you?]  -> howAboutYou
    * [I'm good.]
    
- Oh, good.
-> order

- (howAboutYou)
~ lovePointsEarned = lovePointsEarned + 1
I'm good! Thanks for asking.
How long have you been working here? I don't think I've seen you before.
    * [Probably because you're blind] -> blindLol
    * [I just started recently.]
- That explains it.
Well it's nice to meet you! My name is Madaleine.
~ MadaleineMentioned = true
    * [Nice to meet you too!]
-> order

- (blindLol)
~ lovePointsEarned = lovePointsEarned - 1
Um, okay...
-> order



= day2
It's day two Anon!! yay :3
-> order



= day3
It's day three Anon!! yay :3
-> order



= order
Can I get a large iced coffee with B+ blood and sprinkles? Please and thanks! -> DONE

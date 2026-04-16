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
Well it's very nice to meet you! My name is Madaleine.
~ MadaleineMentioned = true
    * [Nice to meet you too! What can i get for you?]
-> order

- (blindLol)
~ lovePointsEarned = lovePointsEarned - 1
Um, okay...
-> order



= day2
Hey again! How are you today?
    * [I'm doing good! you?] -> goodhbu
    * [Alright]

- Glad to hear...
-> order

- (goodhbu)
Good! You did a great job with my coffee last time, I think the other baristas are trying hoard the sugar from me.
    * [I'm glad! I'll be generous with the sugar!] -> giveSugar
    * [Maybe I should too...]

- Hey, don't be like that! I'll come back there and get it myself!
    * [Hahaha it's okay, I'll load it up] -> giveSugar
    * [Please don't you'll break the counter big back]
    
~ lovePointsEarned = lovePointsEarned - 1
- Damn. Whatever...
-> order

- (giveSugar)
~ lovePointsEarned = lovePointsEarned + 1
Yay! I knew I liked you!!
-> order



= day3
It's day three!! I haven't written this dialog yet.
-> order



= order
Can I get a large iced coffee with B+ blood and sprinkles? -> DONE

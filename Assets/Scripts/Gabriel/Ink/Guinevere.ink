VAR GuinevereMentioned = false

===Guinevere===

= day1
Hey there short stack, I just got done with my workout on the other side of the strip. Don't think I've seen you here before.
    * [Yeah, I'm new here] -> newHere
    * [Didn't ask for your life story]
    
    ~ lovePointsEarned = lovePointsEarned - 1
    - Jeez, good thing I don't beat you up haha...
    -> order
    
- (newHere)
    I knew you must've been. \*She suddenly steps back and begins to stretch\*
    * [\*Look away while she stretches\*]
    
    - Well my name is Guinevere, but you can call me Gwen!
    ~ GuinevereMentioned = true
    * [I'ts nice to meet you, Gwen!] -> niceToMeet
    * [ew, gross name]
    
    - I bet yours sucks anyways
    -> order
    
- (niceToMeet)
    ~ lovePointsEarned = lovePointsEarned + 1
    Nice to meet you too!
    -> order


= day2
It's day two!! I haven't written this dialog yet.
-> order



= day3
It's day three!! I haven't written this dialog yet.
-> order



= order
May I have a small Iced coffee with AB+ blood and whipped cream?
-> DONE
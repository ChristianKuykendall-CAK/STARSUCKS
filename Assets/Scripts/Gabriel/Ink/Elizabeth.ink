VAR ElizabethMentioned = false

===Elizabeth===

= day1
Hello. You aren't the usual girl, you're new here.
    * [Yes i am! How can I help you?] -> howCanHelp
    * [Is there a problem with that?]
    
    ~ lovePointsEarned = lovePointsEarned - 1
    - If you keep up that attitude, then yes.
    -> order
    
- (howCanHelp)
My order is pretty simple. I have a meeting in 10 minutes so can you make it quick?
    * [Sure thing! Can I get a name for the order?]
    
- Okay great. The name is Elizabeth.
~ ElizabethMentioned = true
~ lovePointsEarned = lovePointsEarned + 1
    * [Got it, and what would you like?] -> order



= day2
It's day two!! I haven't written this dialog yet.
-> order



= day3
It's day three!! I haven't written this dialog yet.
-> order



= order
I'll have a medium hot coffee with O- blood.
-> DONE
INCLUDE Madaleine.ink
INCLUDE Elizabeth.ink
INCLUDE Guinevere.ink

VAR girl = 1
VAR day = 1

// Story redirector
{girl:
    // Madaleine dialogs
    - 1:
    {day:
        - 1: -> Madeleine.day1
        - 2: -> Madeleine.day2
        - 3: -> Madeleine.day3
    }
    // Elizabeth dialogs
    - 2:
    {day:
        - 1: -> Elizabeth.day1
        - 2: -> Elizabeth.day2
        - 3: -> Elizabeth.day3
    }
    // Guinevere dialogs
    - 3:
    {day:
        - 1: -> Guinevere.day1
        - 2: -> Guinevere.day2
        - 3: -> Guinevere.day3
    }
}

-> END
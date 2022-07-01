Console.WriteLine("Welcome, to the casino!");
bool runprogram = true;
while(runprogram)
{
    Console.WriteLine("How many sides should each die have?");
    if (int.TryParse(Console.ReadLine(), out int sides) && sides > 1 )
    {
        while (true)
        {
            string rollAnswer;
            try
            {
                Console.WriteLine("Would you like to roll the dice? (y/n)");
                rollAnswer = Console.ReadLine().ToLower().Trim();
                if (rollAnswer != "y" && rollAnswer != "n")
                {
                    throw new Exception("Sorry, unaccepted answer.");
                }
                else if (rollAnswer == "y")
                {
                    int[] dice = roll(sides);
                    Console.WriteLine($"You rolled {dice[0]} and {dice[1]}\n{Doubles(dice, sides)}");
                    Console.WriteLine($"Your total is {dice.Sum()}\n{Totals(dice.Sum(), sides)}");
                }
                else if (rollAnswer == "n")
                {
                    Console.WriteLine("Thanks for playing!");
                    runprogram = false;
                    break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    else
    {
        Console.WriteLine("No dice. Try a different number.");
    }
}

//methods

//roll() method, simulates rolling 2 dice
static int[] roll(int sideNumber)
{
    Random die1 = new Random();
    int roll1 = die1.Next(1, sideNumber + 1);
    int roll2 = die1.Next(1, sideNumber + 1);
    int[] rolls = new int[] {roll1, roll2 };
    return rolls;
}

//Doubles() method, displays to user if they rolled a winning double
static string Doubles(int[] dice, int sides)
{
    Dictionary<string, int[]> d6combos = new()
    {
        {"Snake Eyes", new int[]{1,1} },
        {"Ace Deuce", new int[]{1,2} }, 
        {"Box Cars", new int[]{6,6} },
    };
    Dictionary<string, int[]> d2combos = new()
    {
        {"Heads Up!", new int[]{2,2} },
        {"Tails, You lose", new int[]{1,1} },
    };
    Dictionary<string, int[]> d10combos = new()
    {
        {"Not A Chance", new int[]{10,1} },
        {"Maybe, Maybe Not", new int[]{5,10} },
        {"100%", new int[]{10,10} },
    };
    Dictionary<string, int[]> d20combos = new()
    {
        {"Critical Fail", new int[]{1,1} },
        {"Close Call", new int[] {1, 20} },
        {"Critical success", new int[]{20,20} },
    };
    string response = "";
    if(sides == 6)
    foreach (KeyValuePair<string, int[]> kvp in d6combos)
    {
        if ((kvp.Value[0], kvp.Value[1]) == (dice[0], dice[1]) || (kvp.Value[0], kvp.Value[1]) == (dice[1], dice[0]))
        {
            response = kvp.Key;
        }
    }
    else if (sides == 2)
    {
        foreach (KeyValuePair<string, int[]> kvp in d2combos)
        {
            if ((kvp.Value[0], kvp.Value[1]) == (dice[0], dice[1]))
            {
                response = kvp.Key;
            }
        }
    }
    else if (sides == 10)
    {
        foreach (KeyValuePair<string, int[]> kvp in d10combos)
        {
            if ((kvp.Value[0], kvp.Value[1]) == (dice[0], dice[1]))
            {
                response = kvp.Key;
            }
        }
    }
    else if (sides == 20)
    {
        foreach (KeyValuePair<string, int[]> kvp in d20combos)
        {
            if ((kvp.Value[0], kvp.Value[1]) == (dice[0], dice[1]))
            {
                response = kvp.Key;
            }
        }
    }
    return response; 
}

//Totals() method, displays to user if they rolled a winning double
static string Totals(int sum, int sides)
{
    Dictionary<int, string> d6Totals = new()
    {
        {2, "Craps"},
        {3, "Craps"},
        {7, "Win"},
        {11, "Win"},
        {12, "Craps"},
    };
    Dictionary<int, string> d20Totals = new()
    {
        {21, "Black Jack"},
        {40, "Double Damage"}
    };
    string response = "";
    if (d6Totals.ContainsKey(sum) && sides == 6)
    {
        response = d6Totals[sum];
    }
    if (d20Totals.ContainsKey(sum) && sides == 20)
    {
        response = d20Totals[sum];
    }
    return response;
}

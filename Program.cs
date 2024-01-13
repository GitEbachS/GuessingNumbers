// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

List<int> numbers = new List<int>(4);
bool validNumber = false;
int value = 0;
Random random = new Random();
int secretNumber = random.Next(1, 101);
int tries = 0;
int maxTries = 0;
int guessedNumber = -1;
string response = null;

string greeting = @"Welcome to the Guessing Game! Here you can guess the secret number!";
Console.WriteLine(greeting);
MainMenu();

void MainMenu()
{
   
        Console.WriteLine(@"Choose an option:
                        1. Easy- User gets eight guesses.
                        2. Medium- User gets six guesses.
                        3. Hard- User gets four guesses.
                        4. Cheater- User gets unlimited guesses.");
        response = Console.ReadLine();
        if (response == "1")
        {
            maxTries = 8;
        }
        if (response == "2")
        {
        maxTries = 6;
    }
        if (response == "3")
        {
        maxTries = 4;
    }
        if (response == "4")
        {
        maxTries = 100;
    }
    response = null;
    GuessingLevel();
    
};




void GuessingLevel()
{
    Console.WriteLine(@"Please pick a number between 1 & 100.");
    while (response == null && tries <= (maxTries - 1))
    {
        try
        {
            validNumber = int.TryParse(Console.ReadLine().Trim(), out value);
            if (validNumber = true && value >= 1 && value <= 100)
            {
                tries += 1;
                guessedNumber = value;
                if (secretNumber == guessedNumber)
                {
                    Console.WriteLine($"Congratulations! You guessed the secret number, ({secretNumber})!");
                   
                }
                else
                {
                    Console.Write("Your guessed number is not the secret number.");
                    if (guessedNumber < secretNumber && tries <= maxTries)
                    {
                        Console.WriteLine($"Sorry, your number, {guessedNumber}, is less than the secret number. You have {maxTries - tries} tries left!");
                        numbers.Add(guessedNumber);
                        GuessingLevel();
                    }
                    else if (guessedNumber > secretNumber && tries <= maxTries)
                    {
                        Console.WriteLine($"Sorry, your number, {guessedNumber}, is greater than the secret number.You have {maxTries - tries} tries left!");
                        numbers.Add(guessedNumber);
                        GuessingLevel();
                    }
                    else
                    {
                        Console.Write($"You only get {maxTries} guesses.");
                    }
                }
            }
            else
            {
                Console.WriteLine("You have entered an invalid number.");
            }
     
        }
        catch 
        {
            Console.WriteLine("Please type only integers!");
            GuessingLevel();

        }

    }
   
}



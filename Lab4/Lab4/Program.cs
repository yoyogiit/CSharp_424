using System;
namespace Lab4
{  
public interface IPlayer
    {
        int MakeGuess(int lowerBound, int upperBound);
    }

    public class Player : IPlayer
    {
        public int MakeGuess(int lowerBound, int upperBound)
        {
            int guess;
            while (true)
            {
                Console.WriteLine($"Range: ({lowerBound}, {upperBound})");
                Console.Write("Enter your guess: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out guess) && guess >= lowerBound && guess <= upperBound)
                {
                    return guess;
                }
                else
                {
                    Console.WriteLine($"Please enter a valid number between {lowerBound} and {upperBound}.");
                }
            }
        }
    }

    public class Game
    {
        private int secretNumber;
        private int lowerBound;
        private int upperBound;
        private int guessesLeft;
        private IPlayer player;

        public Game(IPlayer player)
        {
            Random random = new Random();
            secretNumber = random.Next(0, 100); // Random number between 0 and 99
            lowerBound = 0;
            upperBound = 99;
            guessesLeft = 7;
            this.player = player;
        }

        public void Play()
        {
            Console.WriteLine("Welcome to the Number Guessing Game!");
            Console.WriteLine("Guess the secret number between 0 and 99.");

            while (guessesLeft > 0)
            {
                int guess = player.MakeGuess(lowerBound, upperBound);

                if (guess == secretNumber)
                {
                    Console.WriteLine("Congratulations! You guessed the correct number!");
                    break;
                }
                else
                {
                    if (guess < secretNumber)
                    {
                        lowerBound = guess + 1;  // Update lower bound
                    }
                    else
                    {
                        upperBound = guess - 1;  // Update upper bound
                    }
                    guessesLeft--;

                    Console.WriteLine($"Wrong guess. {guessesLeft} guesses left.");
                }

                if (lowerBound > upperBound)
                {
                    Console.WriteLine("No more valid numbers left. You lost the game!");
                    break;
                }
            }

            if (guessesLeft == 0)
            {
                Console.WriteLine("Sorry! You've run out of guesses. The secret number was: " + secretNumber);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            IPlayer player = new Player();  // Create a player
            Game game = new Game(player);   // Pass player to the game
            game.Play();                    // Start the game
        }
    }
}

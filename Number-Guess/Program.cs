using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Guess
{
	class Program
	{

		static void Main(string[] args)
		{
			var wantToPlay = true;
			Random rnd = new Random();

			while (wantToPlay)
			{

				int numToGuess = rnd.Next(1, 100); // creates a number between 1 and 100
				Console.WriteLine(numToGuess);
				var guesses = new int[5];
				var results = new string[5];
				var guessCount = 0;
				var maxGuesses = 5;
				var goodGuess = false;

				Console.WriteLine("Guess a number between 1 and 100.  You get 5 tries");
				while ((!goodGuess) && (guessCount < maxGuesses))
				{
					bool isAnInt = false;
					var guessNum = 0;

					Console.Write("Make a Guess: ");
					var userEntry = Console.ReadLine();
					isAnInt = int.TryParse(userEntry, out guessNum);

					// if number entered equals number to guess you win
					if (guessNum == numToGuess)
					{
						Console.WriteLine("Congratulations! You Win!");
						goodGuess = true;
					}
					else
					{
						// If this number has already been tried display message
						if (Array.Exists(guesses, element => element == guessNum))
						{
							Console.WriteLine("Are you senile?? You already tried that number. What a waste!");

						}
						guesses[guessCount] = guessNum;

						// if entry is not between 1 and 100 it is invalid. 
						if ((guessNum < 1) || (guessNum > 100))
						{
							Console.WriteLine("Your guess is not in the specified range. If not an integer, considered 0");
							results[guessCount] = "invalid";
						}
						else if (guessNum < numToGuess)
						// if entry is less than the number to guess, it is too low. 
						{
							Console.WriteLine("Your guess is too low");
							results[guessCount] = "too low";
						}
						else
						// The entry is more than the number to guess, so it is too high. 
						{
							Console.WriteLine("Your guess is too high");
							results[guessCount] = "too high";
						}

						guessCount++;
					}
				}
				// You have used the max number of guesses and they were all wrong. Display failed guesses.
				if (!goodGuess)
				{
					Console.WriteLine("\nYou have reached the guess limit. You Lose!!!");
					Console.WriteLine($"The correct number was {numToGuess}");
					Console.WriteLine("You made the following guesses");
					for (int i = 0; i < 5; i++)
					{
						Console.WriteLine($"Guess #{i + 1} was {guesses[i]} - ({results[i]})");
					}
				}
				Console.Write("\nDo you want to play again? (Y/N)  ");
				var answer = Console.ReadLine();
				if (answer == "N")
				{
					wantToPlay = false;
				}


			}
		}
	}
}

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
				// generate a random number between 1 and 100
				int numToGuess = rnd.Next(1, 100); 
				var guesses = new int[5];
				var results = new string[5];
				var guessCount = 0;
				var maxGuesses = 5;
				var lowGuess = 0;
				var hiGuess = 101;
				var youWon = false;

				Console.WriteLine("Guess a number between 1 and 100.  You get 5 tries");
				while ((!youWon) && (guessCount < maxGuesses))
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
						youWon = true;
					}
					else
					{
						// If this number has already been tried display message
						if (Array.Exists(guesses, element => element == guessNum))
						{
							Console.WriteLine("Are you senile?? You already tried that number!");

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
							// check if lower than prior low guess. Display message.
							if (guessNum < lowGuess)
							{
								Console.WriteLine($"Your prior guess of {lowGuess} was too low, so going lower was a waste!");
							}
							else
							{
								lowGuess = guessNum;
							}
						}
						else
						// The entry is more than the number to guess, so it is too high. 
						{
							Console.WriteLine("Your guess is too high");
							results[guessCount] = "too high";
							// check if higher than prior high guess. Display message.
							if (guessNum > hiGuess)
							{
								Console.WriteLine($"Your prior guess of {hiGuess} was too high, so going higher was a waste!");
							}
							else
							{
								hiGuess = guessNum;
							}
						}

						guessCount++;
					}
				}
				// You have used the max number of guesses and they were all wrong. Display failed guesses.
				if (!youWon)
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
				if (String.Compare(answer, "N", true) == 0)
				{
					wantToPlay = false;
				}


			}
		}
	}
}

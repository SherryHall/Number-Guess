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
				var guesses = new int[5];
				var results = new string[5];
				var guessCount = 0;
				var goodGuess = false;

				Console.WriteLine("Guess a number between 1 and 100.  You get 5 tries");
				while ((!goodGuess) && (guessCount < 5))
				{
					bool isAnInt = false;
					var guessNum = 0;
					int randomInt = 0;

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
						guesses[guessCount] = guessNum;

						// if entry is not between 1 and 100 it is invalid. 
						if ((guessNum < 1) || (guessNum > 100))
						{
							Console.WriteLine("Your guess is not in the specified range. If not an integer, considered 0");
						}
						else if (guessNum < numToGuess)
						// if entry is less than the number to guess it is too low. 
						{
							Console.WriteLine("Your guess is too low");
							results[guessCount] = "low";
						}
						else
						// The entry is more than the number to guess so it is too high. 
						{
							Console.WriteLine("Your guess is too high");
							results[guessCount] = "high";
						}

						guessCount++;
					}

					Console.Write("Press any key to continue ");
					Console.ReadLine();


				}







			}
		}
	}
}

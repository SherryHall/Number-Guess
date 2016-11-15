using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Guess
{
	class Program
	{
		Random rnd = new Random();
		int numToGuess = rnd.Next(1, 100); // creates a number between 1 and 100
		

		static void Main(string[] args)
		{
			var wantToPlay = true;

			while (wantToPlay)
			{
				Random rnd = new Random();
				int numToGuess = rnd.Next(1, 100); // creates a number between 1 and 100



			}
		}
	}
}

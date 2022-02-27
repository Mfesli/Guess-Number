using System;

public class Program
{
	public static void Main()
	{

		/*
		This program written by Mahmut Fesli
		02/27/2022
		*/
		//////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////
		/* 
			This is a simple Guessing Number Program.
			In the first turn, computer will guess your number that you chose randomly.
			In the second turn, you will guess the number that the computer chose randomly.
			The winner is the player that found the number with less try.
		*/
		//////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////
		/*
			I will follow up the Binary Search through Divide and Conquer Algorithm in this program.
			Further information about Binary Search and Divide and Conquer Algorithm, please look at this resource:
			https://www.bbc.co.uk/bitesize/guides/zts8v9q/revision/5
		*/
		//////////////////////////////////////////////////////////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////
		/*
			Here is the Algorithm that I follow for this program:

			First Turn: Coputer will guess the number that user chose randomly
				Computer asks the user "Hold a Number between 1-100"
				Computer uses the Binary Search through Divide and Conquer Algorithm:
					Initial LowNum=1
					Initial HighNum=1000
					Do
					ComputerNumGuess= RoundUp ((HighNum + LowNum - 1)/2)
					Ask is this the user number ? 
						UserAnswer = <1> for Yes, <2> for Guess a Lower Number, <3> Guess a Higher Number
					If UserAnswer = 2:
						HighNum = ComputerNumGuess - 1
					Else If UserAnswer = 3:
						LowNum = ComputerNumGuess +1
					Else 
						Print "Correct Guess."
					Break
					NumberOfCompTry = NumberOfCompTry + 1
					While UserAnswer != 1

			Second Turn: User will guess the number that computer chose randomly
				Computer hold a number randomly between 1- 100:
					Random rnd = new Random();
					int ComputerRandomNumer = rnd.Next(101);
				Computer asks the user "Guess a Number between 1-100"
				Do
				Computer compares the user guess with the number it holds
					If UserAnswer < ComputerRandomNumer
						Print "Please Guess a Higher Number."
					Else If UserAnswer > ComputerRandomNumer
						Print "Please Guess a Lower Number."			
					Else
						Print "Correct Guess."
					Break
					NumberOfUserTry = NumberOfUserTry + 1
					While UserAnswer == ComputerRandomNumer	

			Who is the Winner?
				If NumberOfCompTry = NumberOfUserTry
						Print " Draw "
				Else If NumberOfCompTry < NumberOfUserTry
						Print " The Winner of the game is Computer "
				Else
						Print " The Winner of the game is User "
		*/
		//////////////////////////////////////////////////////////////////////////////////	
		//////////////////////////////////////////////////////////////////////////////////

		//Declaring the variables
		int LowNum = 1;
		int HighNum = 100;
		int ComputerNumGuess;
		string UserAnswer = "0";
		int NumberOfCompTry = 0;
		int UserNumber = 0;
		int NumberOfUserTry = 0;
		int ComputerRandomNumber;
		bool UserReady = false;

		// Turn-1: Computer will guess and find the number that the user chose randomly.
		while (UserReady == false)
		{
			Console.WriteLine("Please hold a number between 1-100 in your mind.\n");
			Console.WriteLine("Are you ready? <Y> for Yes");
			Char AreYouReady = Char.Parse(Console.ReadLine().ToUpper());
			if (AreYouReady == 'Y')
			{ UserReady = true; }
			Console.Clear();
		}
		if (UserReady)
		{
			Console.WriteLine("Allright!!\nLet me start to gueess your number!!\n");
		}

		// Binary Search process is starting.

		while (UserAnswer != "1")
		{
			ComputerNumGuess = (HighNum + LowNum - 1) / 2;
			Console.WriteLine("Is your number " + ComputerNumGuess + "?\n");
			Console.WriteLine("<1> for Yes\n<2> for Guess a Lower Number\n<3> Guess a Higher Number\n");
			UserAnswer = Console.ReadLine();
			Console.Clear();
			switch (UserAnswer)
			{
				case "1": //The number that the computer gussed is same as the number that user hold.
					Console.Clear();
					Console.WriteLine("I found your number in " + (NumberOfCompTry + 1) + " attempts.\n");
					break;

				case "2": //The number that the computer gussed is higher than the number that user hold.
					Console.Clear();
					Console.WriteLine("I am guessing again!!!\n");
					HighNum = ComputerNumGuess - 1;
					break;

				case "3": //The number that the computer gussed is lower than the number that user hold.
					Console.Clear();
					Console.WriteLine("I am guessing again!!!\n");
					LowNum = ComputerNumGuess + 1;
					break;

				default:
					Console.Clear();
					Console.WriteLine("Wrong Enter!!!\n");
					break;
			}
			NumberOfCompTry++;
		}

		// Turn-2: User will guess and find the number that the computer chose randomly.			
		UserReady = false;
		while (UserReady == false)
		{
			Console.WriteLine("Now your turn.\nI hold a number between 1-100\n");
			Console.WriteLine("And you should try to find the number that I hold it.\n");
			Console.WriteLine("Are you ready? <Y> for Yes");
			Char AreYouReady = Char.Parse(Console.ReadLine().ToUpper());
			if (AreYouReady == 'Y')
			{ UserReady = true; }
			Console.Clear();
		}
		if (UserReady)
		{
			Console.WriteLine("Allright!!\nLet us start to game!!\n");
		}
		Random rnd = new();
		ComputerRandomNumber = rnd.Next(101);
		
		Console.WriteLine("Please guess a number between 1-100");
		while (UserNumber != ComputerRandomNumber)
		{
			UserNumber = int.Parse(Console.ReadLine());
			Console.WriteLine(ComputerRandomNumber);
			if (UserNumber < ComputerRandomNumber)
			{
				Console.Clear();
				Console.WriteLine("Please guess a higher number.\n");
			}

			else if (UserNumber > ComputerRandomNumber)
			{
				Console.Clear();
				Console.WriteLine("Please guess a lower number.\n");

			}

			else
			{
				Console.Clear(); 
				Console.WriteLine("You found my number in " + (NumberOfUserTry + 1) + " attempts.\n");
			}
			NumberOfUserTry++;
		}
		// Who is the Winner: Computer will compare the number of Computer and User attempts and find the winner of the game.
			if (NumberOfCompTry == NumberOfUserTry)
				{
					Console.WriteLine("Congrulations. You both tried so hard, but there is no winner of this game.\nThe result is a DRAW!");
				}
			else if (NumberOfUserTry < NumberOfCompTry)
				{
					Console.WriteLine("Congrulations to User.\nYou are the winner of this game with " + NumberOfUserTry + " attempts.\n");
				}
			else
				{
					Console.WriteLine("Congrulations to Computer.\nYou are the winner of this game with " + NumberOfCompTry + " attempts.\n");
				}
	}
}
using System;
using System.Collections.Generic;
using System.Collections;

namespace PigDice
{
	class MainClass
	{
		// declare our global variables
		//private static List<Player> players = null;
		private static int playerNumber = 0;
		private static int playerCounter = 0;
		private static string suffix = "";
		private static int rollNumber = 0;


		public static void Main(string[] args)
		{
			Console.WriteLine("How many players will be playing this game?");

			playerNumber = Int32.Parse(Console.ReadLine());

			// Initialize our list of players
			List<Player> players = new List<Player>();

			while (playerCounter < playerNumber)
			{
				Player guy = new Player();
				int currentPlayer = playerCounter + 1;

				switch (contains(currentPlayer))
				{
					case "1":
						suffix = "st";
						break;
					case "2":
						suffix = "nd";
						break;
					case "3":
						suffix = "rd";
						break;
					default:
						suffix = "th";

						break;
				}

				Console.WriteLine("Please enter the {0} name:", currentPlayer.ToString() + suffix);

				guy.playerName = Console.ReadLine();
				players.Add(guy);

				//Console.WriteLine(players[playerCounter].playerName);
				playerCounter++;
			}


			playGame(players);

		}

		private static void playGame(List<Player> players)
		{
			bool gameOver = false;

			foreach (Player player in players)
			{
				string hold;
				rollNumber = 1;
				player.turnEnded = false;

				while (player.turnEnded != true)
				{
					
					player.RollDice();

					switch (contains(rollNumber))
					{
						case "1":
							suffix = "st";
							break;
						case "2":
							suffix = "nd";
							break;
						case "3":
							suffix = "rd";
							break;
						default:
							suffix = "th";

							break;
					}

					Console.WriteLine("This is the {0} roll for {1}.{2}",
									  rollNumber.ToString() + suffix,
									  player.playerName,
									  Environment.NewLine);

					Console.WriteLine("{0} has rolled a {1}{2}",
									 player.playerName,
									  player.playerTurnScore.ToString(),
									  Environment.NewLine);

					if (player.turnEnded != true)
					{
						//player.playerScore = player.playerScore + player.playerTurnTotal;

						if ((player.playerScore + player.playerTurnTotal) >= 100)
						{
							player.playerScore = player.playerScore + player.playerTurnTotal;
							player.playerTurnTotal = 0;
							gameOver = true;
							break;
						}

						Console.WriteLine("Do you want to hold [h] or continue to roll [r]?");
						hold = Console.ReadLine();

						if (hold == "h")
						{
							player.playerScore = player.playerScore + player.playerTurnTotal;

							Console.WriteLine("{0}'s turn has ended with an overall score of {1}{2}",
								 player.playerName,
								  player.playerTurnTotal,
								  Environment.NewLine);
							
							player.playerTurnTotal = 0;
							break;
						}

						if (player.turnEnded != false)
						{
							Console.WriteLine("You rolled a 1");
						
							Console.WriteLine("{0}'s turn has ended with an overall score of {1}{2}",
								 player.playerName,
								  player.playerTurnTotal,
								  Environment.NewLine);
						}
					}

					rollNumber++;
					Console.ReadKey();
				}

				Console.WriteLine("Your current game score is {0}{1}",
								  player.playerScore.ToString(),
								 Environment.NewLine);

				if (gameOver == true)
				{
					Console.WriteLine("{0} wins!", player.playerName);
					break; 
				}
			}

			if (gameOver == false)
			{
				playGame(players);
			}
		}

		/// <summary>
		/// determine the appropriate suffix for our player
		/// </summary>
		/// <returns>player number as string or a default value for default case</returns>
		/// <param name="x">player number</param>
		private static string contains(int x)
		{
			string val = x.ToString();

			/*
			 * if our number is 2 digits or is the value 0
			 */
			if (val.Length > 1 | x < 1)
			{
				/*
				 * if our number is between 10 and 20 or is zero
				 */
				if ((9 < x && x < 21) | (x < 1))
				{
					val = "11";
				}
			}



			return val;
		}
	}
}

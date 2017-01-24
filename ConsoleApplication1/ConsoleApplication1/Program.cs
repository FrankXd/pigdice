using System;
using System.Collections.Generic;
using System.Collections;

namespace PigDice
{
	class MainClass
	{
        // declare our global variables
        //private static List<Player> players = null;
        public static int playerNumber = 0;
		private static int playerCounter = 0;
		private static string suffix = "";
		private static int rollNumber = 0;


        public static void Main(string[] args)
        {
            Console.WriteLine(@"
                                                        
8888888b. 8888888  .d8888b.  8888888b. 8888888  .d8888b.  8888888888        .d8888b.         d8888 888b     d888 8888888888 
888   Y88b  888   d88P  Y88b 888  ''Y88  888   d88P  Y88b 888              d88P  Y88b       d88888 8888b   d8888 888        
888    888  888   888    888 888    888  888   888    888 888              888    888      d88P888 88888b.d88888 888        
888   d88P  888   888        888    888  888   888        8888888          888            d88P 888 888Y88888P888 8888888    
8888888P'   888   888  88888 888    888  888   888        888              888  88888    d88P  888 888 Y888P 888 888        
888         888   888    888 888    888  888   888    888 888              888    888   d88P   888 888  Y8P  888 888        
888         888   Y88b  d88P 888  .d88P  888   Y88b  d88P 888              Y88b  d88P  d8888888888 888   ""   888 888        
888       8888888  Y8888P88 8888888P'' 8888888  'Y8888P'  8888888888        'Y8888P8  d88P     888 888       888 8888888888 
                                                                                                                            
                                                                                                                            
                                                                                                                            
");

            PlayNum.PNMethod();

        // Initialize our list of players
        List<Player> players = new List<Player>();
  
			while (playerCounter < playerNumber)
			{
				Player guy = new Player();
				int currentPlayer = playerCounter + 1;
                // Gives number of players and rolls its appropriate suffix
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
                    Console.WriteLine("__________________________________________________________");

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
                    Console.WriteLine("");
					Console.WriteLine("This is the {0} roll for {1}.{2}",
									  rollNumber.ToString() + suffix,
									  player.playerName,
									  Environment.NewLine);
                    player.RollDice();
                    Console.WriteLine("");
                    Console.WriteLine("{0} has rolled a dice total of {1}{2}",
									 player.playerName,
									  player.playerTurnScore.ToString(),
									  Environment.NewLine);

					if (player.turnEnded != true)
					{
                        // checks if the current players score is determined as a win
						if ((player.playerScore + player.playerTurnTotal) >= 100)
						{
							player.playerScore = player.playerScore + player.playerTurnTotal;
							player.playerTurnTotal = 0;
							gameOver = true;
                            break;
						}

						Console.WriteLine("Do you want to hold [h] or continue to roll [r]?");
						hold = Console.ReadLine();

                        //asks the player to decide if they should hold their score or roll again
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

                        // when player rolls a 1 on either die turn ends with these statements
						if (player.turnEnded != false)
						{
                            Console.WriteLine("You rolled a 1");
                            player.playerTurnTotal = 0;
                            Console.WriteLine("{0}'s turn has ended with an overall score of {1}{2}",
								 player.playerName,
								  player.playerTurnTotal,
								  Environment.NewLine);
                            
						}
					}
                    //if player rolls again it loops through another roll and adds 1 to rollnumber to calculate the appropriate rollnumber suffix
					rollNumber++;
					Console.ReadKey();
				}

				Console.WriteLine("Your current game score is {0}{1}",
								  player.playerScore.ToString(),
								 Environment.NewLine);

				if (gameOver == true)
				{
					Console.WriteLine("{0} wins!", player.playerName);
                    Console.WriteLine(@"
                                                            
▓██   ██▓ ▒█████   █    ██     █     █░ ██▓ ███▄    █ 
 ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▓█░ █ ░█░▓██▒ ██ ▀█   █ 
  ▒██ ██░▒██░  ██▒▓██  ▒██░   ▒█░ █ ░█ ▒██▒▓██  ▀█ ██▒
  ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░█░ █ ░█ ░██░▓██▒  ▐▌██▒
  ░ ██▒▓░░ ████▓▒░▒▒█████▓    ░░██▒██▓ ░██░▒██░   ▓██░
   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒    ░ ▓░▒ ▒  ░▓  ░ ▒░   ▒ ▒ 
 ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░      ▒ ░ ░   ▒ ░░ ░░   ░ ▒░
 ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░      ░   ░   ▒ ░   ░   ░ ░ 
 ░ ░         ░ ░     ░            ░     ░           ░ 
 ░ ░                                                  
");
                    Console.ReadLine();
					break; 
				}
			}
            // checks if a player has won to end the game
			if (gameOver == false)
			{
                // if game is not over, loops to playGame method and starts the next players turn
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

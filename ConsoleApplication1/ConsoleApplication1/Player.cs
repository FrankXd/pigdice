using System;
using System.Threading;

namespace PigDice
{
	public class Player
	{
		private int turnScore = 0;

		private int turnTotal = 0;

		private int gameScore = 0;

		private Dice firstDice;

		private Dice secondDice;

		private bool turnNotActive = false;

		private bool isWinner = false;

		/// <summary>
		/// Gets or sets the name of the player.
		/// </summary>
		/// <value>The name of the player.</value>
		public string playerName { get; set; }

		/// <summary>
		/// Gets or sets the player score.
		/// Overall score for player.
		/// </summary>
		/// <value>The player score.</value>
		public int playerScore
		{
			get
			{
				return gameScore;
			}
			set
			{
				gameScore = value;
			}
		}
		/// <summary>
		/// Gets or sets the player turn score.
		/// Returns score for each roll
		/// </summary>
		/// <value>The player turn score.</value>
		public int playerTurnScore { 
			get
			{
				return turnScore;
			}
		}

		/// <summary>
		/// Gets or sets the player turn total.
		/// Returns score for total rolls in turn
		/// </summary>
		/// <value>The player turn total.</value>
		public int playerTurnTotal { 
			get {
				return turnTotal;
			} 
			set
			{
				turnTotal = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:PigDice.Player"/> turn ended.
		/// </summary>
		/// <value><c>true</c> if turn ended; otherwise, <c>false</c>.</value>
		public bool turnEnded { 
			get {
				return turnNotActive;
			} 
			set
			{
				turnNotActive = value;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="T:PigDice.Player"/> player wins.
		/// </summary>
		/// <value><c>true</c> if player wins; otherwise, <c>false</c>.</value>
		public bool playerWins
		{
			get
			{
				return isWinner;
			}
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="T:PigDice.Player"/> class.
		/// </summary>
		public Player()
		{
			firstDice = new Dice();
			secondDice = new Dice();
		}


		public void RollDice()
		{
			int firstRoll = 0;
			int secondRoll = 0;

			firstRoll = firstDice.Roll();
            //Pauses in between methods for a certain time so the second roll is never equal to the first
            //opposed to it always rolling two same numbers because two Random methods initiate at the same time or back to back
            Console.Write("Rolling Dice");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(300);
                Console.Write(".");
            }

            secondRoll = secondDice.Roll();

			if (firstRoll == 1 || secondRoll == 1)
			{
				turnScore = 1;
				turnTotal = 0;
				turnNotActive = true;
			}
			else
			{
				turnScore = firstRoll + secondRoll;
				turnTotal = turnTotal + turnScore;
			}

			isWinner = win();
		}

		/// <summary>
		/// Check if the player has won the game.
		/// </summary>
		/// <returns>player won bool</returns>
		public bool win()
		{
			if (gameScore + turnScore >= 100)
			{
				return true;
			}
			else { return false; }
		}
	}
}

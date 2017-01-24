using System;

namespace PigDice
{
	public class Dice
	{
		private Random randomNumber;

        public Dice()
        {
        }
		public int Roll()
		{
			randomNumber = new Random();

			return randomNumber.Next(1,6);
		}
	}
}

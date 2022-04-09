using System;
using System.Text;
using System.Threading;

namespace ProgressBar
{
	internal class Program
	{
		public const int StepsType1 = 40;
		public const int StepsType2 = 50;
		public const int DelayType1 = 200;
		public const int DelayType2 = 100;
		public const int MaxDelay = 500;
		public const int MaxSteps = 25;
		public const string Division1 = "\u2591";
		public const string Division2 = "\u2592";
		public const string Division3 = "\u2593";
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;
			Console.CursorVisible = false;
			
			ProgBarType1(StepsType1);
			Console.WriteLine("\n");
			
			ProgBarType2(StepsType2); 
			Console.WriteLine("\n");
			
			RandBarType1();
			Console.WriteLine("\n");
		}
		#region Printing

		private static void PrintSteps(int steps, int i)
		{
			Console.Write($" {i + 1}/{steps}");
		}

		private static void PrintCharacterAtPos(int curspos, string character)
		{
			Console.CursorLeft = curspos;
			Console.Write(character);
		}

		private static void PrintXCharacters(int amount, string character)
		{
			for (int j = 0; j < amount; j++)
			{
				Console.Write(character);
			}
		}

		#endregion

		#region ProgressBarType1

		private static void ProgBarType1(int steps)
		{
			for (int i = 0; i < steps; i++)
			{
				PrintCharacterAtPos(i, Division3);
				PrintSteps(steps, i);
				Thread.Sleep(DelayType1);
			}
		}

		#endregion

		#region ProgressBarType2

		private static void ProgBarType2(int steps)
		{
			PrintXCharacters(steps, Division1);
			for (int i = 0; i < steps; i++)
			{
				Console.CursorLeft = steps + 1;
				PrintSteps(steps, i);
				Console.CursorLeft = i;
				for (int j = 0; j < 2; j++)
				{
					if(j==0)
						Console.Write(Division3);
					if(j==1&&i!=steps-1)
						Console.Write(Division2);
					Thread.Sleep(DelayType2);
				}
			}
		}

		#endregion

		#region RandomProgressBarType1

		private static void RandBarType1()
		{
			var steps = RandomizeSteps();
			for (int i = 0; i < steps; i++)
			{
				var delay = RandomizeDelay();
				PrintCharacterAtPos(i,Division3);
				Console.Write($" {i+1}/{steps}");
				Console.CursorLeft = 0;
				Thread.Sleep(delay);
			}
		}

		private static int RandomizeDelay()
		{
			Random rnd = new Random();
			var delay = rnd.Next(MaxDelay);
			return delay;
		}

		private static int RandomizeSteps()
		{
			Random rnd = new Random();
			var steps = rnd.Next(MaxSteps);
			return steps;
		}

		#endregion
	}
}

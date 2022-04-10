using System;
using System.ComponentModel;
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
		#endregion

		#region Calculations

		private static int MaybeNextThird(int x, int total)
		{
			if (x+1 > Math.Round(total *(double)2/3))
			{
				return 3;
			}
			if (x+1> Math.Round((double)total/3))
			{
				return 2;
			}
			return 1;
		}

		#endregion

		#region ForegroundColor

		private static void ColorSwitcher(int fraction)
		{
			switch (fraction)
			{
				case 1:
				{
					Console.ForegroundColor = ConsoleColor.Red;
					break;
				}
				case 2:
				{
					Console.ForegroundColor = ConsoleColor.DarkYellow;
					break;
				}
				case 3:
				{
					Console.ForegroundColor = ConsoleColor.Green;
					break;
				}
				default:
				{
					Console.ForegroundColor = ConsoleColor.Gray;
					break;
				}
			}
		}

		#endregion

		#region ProgressBarType1

		private static void ProgBarType1(int steps)
		{
			for (int i = 0; i < steps; i++)
			{
				ColorSwitcher(MaybeNextThird(i, steps));
				PrintCharacterAtPos(i, Division3);
				Console.ForegroundColor = ConsoleColor.Gray;
				PrintSteps(steps, i);
				Thread.Sleep(DelayType1);
			}
		}

		#endregion

		#region ProgressBarType2

		private static void ProgBarType2(int steps)
		{
			for (int i = 0; i < steps; i++)
			{
				ColorSwitcher(MaybeNextThird(i, steps));
				PrintCharacterAtPos(i, Division1);
			}
			for (int i = 0; i < steps; i++)
			{
				Console.CursorLeft = steps + 1;
				Console.ForegroundColor= ConsoleColor.Gray;
				PrintSteps(steps, i);
				Console.CursorLeft = i;
				ColorSwitcher(MaybeNextThird(i, steps));
				for (int j = 0; j < 2; j++)
				{
					if (j==0)
						Console.Write(Division2);
					if (j == 1)
						Console.Write(Division3);
					Thread.Sleep(DelayType2);
					Console.CursorLeft=i;
				}
			}
		}

		#endregion

		#region RandomProgressBarType1

		private static void RandBarType1()
		{
			var steps = RandomizeValue(MaxSteps);
			for (int i = 0; i < steps; i++)
			{
				var delay = RandomizeValue(MaxDelay);
				ColorSwitcher(MaybeNextThird(i, steps));
				PrintCharacterAtPos(i,Division3);
				Console.ForegroundColor = ConsoleColor.Gray;
				PrintSteps(steps, i);
				Console.CursorLeft = 0;
				Thread.Sleep(delay);
			}
		}
		private static int RandomizeValue(int max)
		{
			Random rnd = new Random();
			var value = rnd.Next(max);
			return value;
		}

		#endregion
	}
}

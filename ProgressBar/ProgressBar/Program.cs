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
		}

		#region ProgressBarType1

		private static void ProgBarType1(int steps)
		{
			for (int i = 1; i <= steps; i++)
			{
				for (int j = 0; j < i; j++)
				{
					Console.Write(Division3);
				}
				Console.Write($" {i}/{steps}");
				Console.CursorLeft = 0;
				Thread.Sleep(DelayType1);
			}
		}

		#endregion

		#region ProgressBarType2

		private static void ProgBarType2(int steps)
		{
			for (int i = 0; i < steps; i++)
			{
				Console.Write(Division1);
			}
			for (int i = 0; i < steps; i++)
			{
				Console.CursorLeft = i;
				for (int j = 0; j < 2; j++)
				{
					if(j==0)
						Console.Write(Division3);
					if(j==1&&i!=steps-1)
						Console.Write(Division2);
					Thread.Sleep(DelayType2);
				}
				Console.CursorLeft = steps + 1;
				Console.Write($"{i+1}/{steps}");
			}
		}

		#endregion

		#region RandomProgressBarType1

		private static void RandBarType1()
		{
			var steps = RandomizeSteps();
			var delay = RandomizeDelay();
			PrintStats(steps, delay);
			for (int i = 1; i <= steps; i++)
			{
				for (int j = 0; j < i; j++)
				{
					Console.Write(Division3);
				}
				Console.Write($" {i}/{steps}");
				Console.CursorLeft = 0;
				Thread.Sleep(delay);
			}
		}

		private static void PrintStats(int steps, int delay)
		{
			Console.WriteLine($"Steps:{steps}\tDelay:{delay}");
		}

		private static int RandomizeDelay()
		{
			Random rnd = new Random();
			var delay = rnd.Next(500);
			return delay;
		}

		private static int RandomizeSteps()
		{
			Random rnd = new Random();
			var steps = rnd.Next(25);
			return steps;
		}

		#endregion
	}
}

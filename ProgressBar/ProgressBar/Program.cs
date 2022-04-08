using System;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;

namespace ProgressBar
{
	internal class Program
	{
		public const int steps = 50;
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;
			Console.CursorVisible = false;
			//ProgBar1stType();
			//ProgBar2ndType();
			//RandBar1stType();
		}

		private static void ProgBar1stType()
		{
			for (int i = 1; i <= steps; i++)
			{
				for (int j=0; j < i; j++)
				{
					Console.Write($"\u2593");
				}
				Console.Write($" {i}/{steps}");
				Console.CursorLeft = 0;
				Thread.Sleep(200);
			}
		}

		private static void ProgBar2ndType()
		{
			for (int i = 0; i < steps; i++)
			{
				Console.Write($"\u2591");
			}

			for (int i = 0; i < steps; i++)
			{
				Console.CursorLeft = i;
				for (int j = 0; j < 2; j++)
				{
					if(j==0)
						Console.Write($"\u2593");
					if(j==1&&i!=steps-1)
						Console.Write($"\u2592");
					Thread.Sleep(100);
				}
				Console.CursorLeft = steps + 1;
				Console.Write($"{i+1}/{steps}");
			}
		}

		private static void RandBar1stType()
		{
			Random rnd = new Random();
			var randsteps = rnd.Next(25);
			var randtime = rnd.Next(500);
			for (int i = 1; i <= randsteps; i++)
			{
				for (int j = 0; j < i; j++)
				{
					Console.Write($"\u2593");
				}
				Console.Write($" {i}/{randsteps}");
				Console.CursorLeft = 0;
				Thread.Sleep(randtime);
			}
		}
	}
}

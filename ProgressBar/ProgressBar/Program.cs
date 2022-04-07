using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProgressBar
{
	internal class Program
	{
		public const int steps = 40;
		static void Main(string[] args)
		{
			//ProgBar1stType();
			ProgBar2ndType();
		}

		private static void ProgBar1stType()
		{
			Console.OutputEncoding = Encoding.UTF8;
			Console.CursorVisible = false;
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

		}
	}
}

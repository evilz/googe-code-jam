using System;
using System.Collections.Generic;
using System.IO;

namespace StandingOvation
{
	static class Program
	{
		private const string IN_EXTENSION = ".in";
		private const string OUT_EXTENSION = ".out";

		private const string FILENAME = "A-large-practice";
		//private const string FILENAME = "sample";
		
		static void Main()
		{
			List<Input> cases = Input.Parse(FILENAME + IN_EXTENSION);
			
			using (var sw = File.CreateText(FILENAME + OUT_EXTENSION))
			{
				for (int i = 0; i < cases.Count; i++)
				{
					var solution = Solve(cases[i]);
					Console.WriteLine("Case #{0}: {1}", i + 1, solution);
					sw.WriteLine("Case #{0}: {1}", i + 1, solution);
				}
			}
		}

		static int Solve(Input testCase)
		{
			var invites = 0;
			var standing = 0;
			
			for (var i = 0; i <= testCase.Maxshyness; i++)
			{
				if (standing < i)
				{
					invites += i - standing;
					standing += i - standing;
				}
				standing += testCase.Audience[i];
			}
			return invites;
		}
	}
}
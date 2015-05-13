using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StandingOvation
{
	public struct Input
	{
		public Input(int maxshyness, int[] audience)
		{
			Maxshyness = maxshyness;
			Audience = audience;
		}

		private Input(string maxshyness, string audience)
		{
			Maxshyness = int.Parse(maxshyness);

			Audience = new int[Maxshyness+1];
			for (int i = 0; i <= Maxshyness; i++)
			{
				Audience[i] = int.Parse(audience[i].ToString());
			}
			
		}

		public int Maxshyness { get; }
		public int[] Audience { get; }

		public static List<Input> Parse(string path)
		{
			List<Input> list = new List<Input>();
			using (var stream = File.OpenText(path))
			{
				var caseCount = stream.ExtractValues<int>().First();

				for (int i = 0; i < caseCount; i++)
				{
					var raw = stream.ExtractValues<string>().ToList();
					var testCase = new Input(raw[0], raw[1]);
					list.Add(testCase);
				}
			}
			return list;
		}
	}
}
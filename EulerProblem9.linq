<Query Kind="Program" />

void Main()
{
	SolveForC(SolveForAB()).Dump();
}
	
public static List<Tuple<int, int>> SolveForAB()
{
	var ab = new List<Tuple<int, int>>();
	for (int a = 1; a < 1000; a++)
	{
		for (int b = 1; b < 1000; b++)
		{
			if (500000 - (1000 * a) - (1000 * b) + (a * b) == 0)
			{
				ab.Add(new Tuple<int, int>(a,b));
			}
		}
	}
	return ab;
}
	
public static int SolveForC(List<Tuple<int, int>> abList)
{
	foreach (var ab in abList)
	{
		int a = ab.Item1;
		int b = ab.Item2;
	
		int c = 1000 - a - b;
		if (a*a + b*b == c*c)
		{
			return a*b*c;
		}
	}
	return 0;
}
<Query Kind="Program" />

void Main()
{
	
	Tuple<long, int> highest = new Tuple<long, int>(1, 1);
	for (int i = 1; i < 1000000; i++)
	{
		int depth = 0;
		int collatzCount = CollatzSequenceSize(i, depth);
		highest = highest.Item1 < collatzCount ? new Tuple<long, int>(collatzCount, i) : highest;
	}
	highest.Item2.Dump();
}
	
private static int CollatzSequenceSize(long seed, int depth)
{
	while (seed != 1)
	{
		seed = seed % 2 == 0 ? seed / 2 : (3 * seed) + 1;
		return CollatzSequenceSize(seed, ++depth);
	}
	return depth;
}


// Define other methods and classes here
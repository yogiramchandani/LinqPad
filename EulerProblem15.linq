<Query Kind="Program" />

void Main()
{
	LatticeCount(20).Dump();
}
	
private static long LatticeCount(int x)
{
	// Formula :
	// (2x)!/x!x!	
	long facX = 1; 
	long fac2X = 1;
	var remove = new List<int>();
	Enumerable.Range(1, x).ToList().ForEach(i => facX *= i); // calculate x!
	var x2Fac = Enumerable.Range(x + 1, x).ToList(); // list for 2x!/x!
	x2Fac.ForEach( i =>
	{
		if (facX % i == 0) //start dividing from x!
		{
			facX /= i;
			remove.Add(i);
		}
	});
	
	remove.ForEach(i => x2Fac.Remove(i)); //remove items divisible by x!
	x2Fac.ForEach(i => fac2X *= i);
	return fac2X/facX;
}
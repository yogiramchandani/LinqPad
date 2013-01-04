<Query Kind="Program" />

void Main()
{
	List<int> prime = new List<int> {2, 3, 5, 7, 11, 13};
	var summation = AddPrimes(prime);
	summation.Dump();
}
	
public static long AddPrimes(List<int> primeList)
{
	long summation = long.Parse(primeList.Sum().ToString());
	int seed = primeList.Last();
	Enumerable.
		Range(seed + 1, 2000000 - seed+1).
		ToList().
		ForEach(x =>
					{
						bool isPrime = primeList.All(prime => x%prime != 0);
						if (isPrime)
						{
							primeList.Add(x);
							summation += x;
						}
					});
	return summation;
}
// Define other methods and classes here

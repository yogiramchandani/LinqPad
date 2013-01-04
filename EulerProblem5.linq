<Query Kind="Program" />

public void Main()
{
	int productOfPrimes = 1;
	IEnumerable<int> primes = GetPrimes(Enumerable.Range(1, 20), 1);
	IEnumerable<int> range = Enumerable.Range(11, 20);
	
	range.ToList().ForEach(x => 
	{
		Console.WriteLine("Factorial for {0}", x);
		GetFactorial(x, primes).ForEach(Console.WriteLine);
	});
	Console.WriteLine(productOfPrimes);
}

IEnumerable<int> GetPrimes(IEnumerable<int> raw, int position)
{
	int divider = raw.ElementAt(position);
	IEnumerable<int> processed = raw.Where(x => x == divider || x % divider != 0);
	if (processed.ElementAt(position) * 5 < processed.Last() && position < processed.Count() - 1)
	{
		return GetPrimes(processed, position + 1);
	}
	return processed;
}

List<int> GetFactorial(int number, IEnumerable<int> primes)
{
	List<int> factorials = new List<int>();
	int primeFactor = 1;
	do
	{
		IEnumerable<int> primeFactors = primes.ToList().Where(x => x != 1 && number % x == 0);
		primeFactor = !primeFactors.Any() ? 1 : primeFactors.Max();
		
		factorials.Add(primeFactor);
		number = number / primeFactor;
	} while (primeFactor != 1);
	
	return factorials.;
}
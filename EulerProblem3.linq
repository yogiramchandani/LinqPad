<Query Kind="Program" />

public void Main()
{
	long original = 600851475143;
	
	int maxLimit = 1000;

	int maxFactorial = GetMaxFactorial(maxLimit, original);

	Console.WriteLine(maxFactorial);
}

int GetMaxFactorial(int maxLimit, long original)
{
	int? primeFactor;
	IEnumerable<int> candidateList = Enumerable.Range(1, maxLimit);
	IEnumerable<int> primes = GetPrimes(candidateList, 1);
	int highestPrimeFactor = 1;
	do
	{
		IEnumerable<int> primeFactors = primes.ToList().Where(x => x != 1 && original % x == 0);
		primeFactor = !primeFactors.Any() ? 1 : primeFactors.Max();
		Console.WriteLine("Original: {0}, Prime Factor {1}", original, primeFactor);
		if (highestPrimeFactor < primeFactor) highestPrimeFactor = primeFactor.Value;
		original = original / primeFactor.Value;
	} while (primeFactor.Value != 1);
	
	if(original > maxLimit)
	{
		return GetMaxFactorial(maxLimit * 10, original);
	}
	
	return (int)highestPrimeFactor;
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
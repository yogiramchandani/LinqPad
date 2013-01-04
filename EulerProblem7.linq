<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
</Query>

void Main()
{
	List<int> prime = new List<int> { 2, 3, 5, 7, 11, 13 };
  	while (prime.Count < 10000)
    prime = AddPrimes(prime);
  	prime[10000].Dump();
}

public static List<int> AddPrimes(List<int> primeList)
{
  	int start = primeList.Last();
  	Enumerable.Range(start + 1, 10000).ToList().ForEach(x =>
  	{
      	bool isPrime = primeList.All(prime => x%prime != 0);
      	if (isPrime)
      	{
          	primeList.Add(x);
      	}
  	});
  	return primeList;
}


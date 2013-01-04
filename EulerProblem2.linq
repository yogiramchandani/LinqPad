<Query Kind="Program" />

void Main()
{
	int evenValueSummation = SummationEvenFabonacciTerms(4000000, 2, 1, 0);
	Console.WriteLine(evenValueSummation);
}

int SummationEvenFabonacciTerms(int max, int current, int previous, int sumOfEvens)
{
	if(previous >= max)
	{
		return sumOfEvens;
	}
	if(previous % 2 == 0)
	{
		return SummationEvenFabonacciTerms(max, current + previous, current, sumOfEvens + previous);
	}
	return SummationEvenFabonacciTerms(max, current + previous, current, sumOfEvens);
}

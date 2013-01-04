<Query Kind="Program" />

void Main()
{
	int summation = SummationOfMultiplesof5And3(1000 - 1, 0);
	Console.WriteLine(summation);
}

int SummationOfMultiplesof5And3(int current, int summation)
{
	if(current < 3) 
	{
		return summation;
	}
	if(current % 5 == 0 || current % 3 == 0) 
	{
		return SummationOfMultiplesof5And3(current - 1, summation + current);
	}
	return SummationOfMultiplesof5And3(current - 1, summation);
}
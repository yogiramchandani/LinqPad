<Query Kind="Program" />

public void Main()
{
	int pal = FindGreatestPanlendromicNumber();
	Console.WriteLine(pal);
}
	
	int FindGreatestPanlendromicNumber()
	{
		int max = 0;
		for(int i = 100; i < 1000; i++)
		{
			for(int j = 100; j < 1000; j++)
			{
				int numberUnderTest = i * j;
				if(numberUnderTest > max && IsPalindromicNumber(numberUnderTest))
				{
					max = numberUnderTest;
				}
			}
		}
		return max;
	}
	
	bool IsPalindromicNumber(int numberToTest)
	{
		int numberToReverse = numberToTest;
		int palindrom = 0;
		int remainder = 0;
		while (numberToReverse > 0)
		{
			remainder = numberToReverse % 10;
			palindrom = palindrom * 10 + remainder;
			numberToReverse = numberToReverse / 10;
		}
		return palindrom == numberToTest;
	}
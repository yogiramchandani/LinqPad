<Query Kind="Program" />

		public void Main()
		{
			int countOfNaturalNumbers = 100;
			int sumOfSquares = SumOfSquares(countOfNaturalNumbers);
			int squaresOfSums = SquaresOfSums(countOfNaturalNumbers);
			Console.WriteLine(squaresOfSums - sumOfSquares);
		}


		public int SumOfSquares(int countOfNaturalNumbers)
		{
			List<int> squares = new List<int>(countOfNaturalNumbers);
			squares.AddRange(Enumerable.Range(1, countOfNaturalNumbers).Select(x => x*x));
			return squares.Sum();
		}

		public int SquaresOfSums(int countOfNaturalNumbers)
		{
			List<int> squares = Enumerable.Range(1, countOfNaturalNumbers).ToList();
			int sum = squares.Sum();
			return sum * sum;
		}
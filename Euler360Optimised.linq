<Query Kind="Statements" />

Int64 manhattanWithZ = 0;
Int64 manhattanWithoutZ = 0;
Int64 radius = Int64.Parse(Math.Pow(10,3).ToString());
Int64 radiusSqr = radius * radius;
for (Int64 x = -radius; x <= radius; x++)
{
	Int64 xsqr = x * x;
	for (Int64 y = -radius; y <= radius; y++)
	{
		Int64 ysqr = y * y;
		Int64 totalxy = xsqr + ysqr;
		
		if(y > 0 && totalxy > radiusSqr)
		{
			y = radius + 1;
		}
		
		if(totalxy == radiusSqr)
		{
			Int64 localManhattan = Math.Abs(x) + Math.Abs(y);
			manhattanWithoutZ = manhattanWithoutZ + localManhattan;
		}
		if(totalxy < radiusSqr)
		{
			for (Int64 z = 1; z <= radius; z++)
			{
				Int64 zsqr = z * z;
				Int64 total = totalxy + (zsqr);
				
				if( total == radiusSqr)
				{
					Int64 localManhattan = Math.Abs(x) + Math.Abs(y) + Math.Abs(z);
					manhattanWithZ = manhattanWithZ + localManhattan;
				}
			}
		}
	}
}
((manhattanWithZ * 2) + manhattanWithoutZ).Dump();
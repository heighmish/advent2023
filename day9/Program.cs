var lines = File.ReadLines("big.txt");

var sum = 0;
var sum2 = 0;
foreach (var line in lines)
{
    var history = new Part1().Run(line);
    sum += history;
    sum2 += new Part2().Run(line);
    Console.WriteLine();
}

Console.WriteLine($"{sum}");
Console.WriteLine($"{sum2}");

using Advent2023.Day2;

if (args.Length < 1)
{
    return;
}
var fileName = args[0];
var sum = 0;
var powerSum = 0;
foreach (var line in File.ReadLines(fileName))
{
    Console.WriteLine(line);
    sum += new Processor().Process(line);
    powerSum += new Processor().Part2(line);
}

Console.WriteLine($"Sum: {sum}");
Console.WriteLine($"Power sum: {powerSum}");

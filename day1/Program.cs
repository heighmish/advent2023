using Advent2023.Day1;

if (args.Length < 1)
{
    return;
}
var fileName = args[0];
var sum = 0;
foreach (var line in File.ReadLines(fileName))
{
    sum += new Processor().Process(line);
}

Console.WriteLine($"Sum: {sum}");

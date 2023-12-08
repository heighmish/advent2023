using System.Globalization;

var lines = File.ReadLines("input.txt");

var total = 0;
foreach (var line in lines)
{
    var board = line.Split(":")[1];
    var scratchy = board.Split("|");
    var winners = scratchy[0];
    var numbers = scratchy[1];
    var winnersSet = winners
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(num => Int32.Parse(num))
        .ToHashSet<int>();
    total += numbers
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(num => Int32.Parse(num))
        .Aggregate(
            0,
            (total, next) =>
                winnersSet.Contains(next)
                    ? total == 0
                        ? 1
                        : total * 2
                    : total
        );
}
var total2 = 0;
var cardIndex = 0;
var uhhh = new int[lines.Count()];
Array.Fill(uhhh, 1);
foreach (var line in lines)
{
    var board = line.Split(":")[1];
    var scratchy = board.Split("|");
    var winnersSet = scratchy[0]
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(num => Int32.Parse(num))
        .ToHashSet<int>();
    var matches = scratchy[1]
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(num => Int32.Parse(num))
        .Aggregate(0, (total, next) => winnersSet.Contains(next) ? total + 1 : total);
    Console.WriteLine($"CardIndex: {cardIndex}, Matches {matches}");
    for (var i = 0; i < matches; ++i)
    {
        uhhh[cardIndex + i + 1] += uhhh[cardIndex];
    }
    Console.WriteLine($"Writing {uhhh[cardIndex]} to total: {total2}");
    total2 += uhhh[cardIndex];
    Console.WriteLine($"{String.Join(",", uhhh)}");
    cardIndex++;
}

Console.WriteLine($"Total {total}");
Console.WriteLine($"Total2 {total2}");

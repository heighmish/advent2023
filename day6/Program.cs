var lines = File.ReadLines("large.txt").ToList();

var time = lines[0].Split(":")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
var distance = lines[1].Split(":")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();


Console.WriteLine($"{String.Join(",", time)}, {String.Join(",", distance)}");


var totals = new List<int>();
for (var race = 0; race < time.Count; ++race)
{
    var raceTime = time[race];
    var raceDist = distance[race];

    var raceStrat = 0;
    foreach (var sec in Enumerable.Range(0, raceTime))
    {
        // 0 = 0,
        // 1 => 1 * (Time - 1)
        // 2 => 2 * (Time - 2)
        var moved = sec * (raceTime - sec);
        Console.WriteLine($"Held for {sec} secs, moved {moved} distance");
        if (moved > raceDist)
        {
            raceStrat += 1;
        }
    }
    totals.Add(raceStrat);
}

var combinations = totals.Aggregate(1, (total, next) => total * next);
Console.WriteLine($"Total combinations: {combinations}");

// Part 2
var allTimes = lines[0].Split(":", StringSplitOptions.TrimEntries)[1];
var bigRaceTime = Int128.Parse(allTimes.Replace(" ", ""));
var bigRaces = lines[1].Split(":")[1];
var bigRaceDist = Int128.Parse(bigRaces.Replace(" ", ""));
Console.WriteLine($"time: {bigRaceTime}, distance: {bigRaceDist}");

var sols = 0;

for (Int128 sec = 0; sec < bigRaceTime; ++sec)
{
    var moved = sec * (bigRaceTime - sec);
    if (moved > bigRaceDist)
    {
        sols += 1;
    }
}


Console.WriteLine($"Bigrace: {sols}");
var lines = File.ReadLines("big.txt").ToList<string>();
var instructions = lines[0];
var filteredLines = lines.Where(line => line != string.Empty);

var map = new Dictionary<string, Node>();
string currentElement = "AAA";

var endACount = 0;
foreach (var line in filteredLines.Skip(1))
{
    var (key, value) = ParseInput(line);
    if (key.EndsWith('A'))
    {
        endACount++;
    }
    map.Add(key, value);
}
var stepCount = 0;
Console.WriteLine($"Starting element: {currentElement}");

while (true)
{
    foreach (var instruction in instructions)
    {
        // Console.WriteLine($"CurrentElement: {currentElement}, steps {stepCount}");
        if (currentElement == "ZZZ")
        {
            break;
        }
        if (instruction == 'L')
        {
            currentElement = map[currentElement].Left;
        }
        else if (instruction == 'R')
        {
            currentElement = map[currentElement].Right;
        }
        stepCount++;
    }
    if (currentElement == "ZZZ")
    {
        break;
    }
}

Console.WriteLine($"Steps p1 {stepCount}");

// Part 2
// brute force solution is too slow
var frontier = map.Where(pair => pair.Key.EndsWith('A')).Select(key => key.Key).ToList();
var found = false;
stepCount = 0;
Console.WriteLine($"End A count {endACount}");
while (!found)
{
    if (frontier.All(s => s.EndsWith('Z')))
    {
        Console.WriteLine($"Found at stepcount {stepCount}");
        found = true;
        break;
    }
    foreach (var instruction in instructions)
    {
        var frontier2 = new List<string>();
        if (instruction == 'L')
        {
            foreach (var element in frontier)
            {
                frontier2.Add(map[element].Left);
            }
        }
        else if (instruction == 'R')
        {
            foreach (var element in frontier)
            {
                frontier2.Add(map[element].Right);
            }
        }
        stepCount++;
        if (frontier2.All(s => s.EndsWith('Z')))
        {
            Console.WriteLine($"Found at stepcount {stepCount}");
            found = true;
            break;
        }
        frontier = frontier2;
    }
    Console.WriteLine($"Steps {stepCount}");
}
(string, Node) ParseInput(string str)
{
    // Input of format AAA = (BBB, BBB)
    // Return (AAA, Node)
    var delimiters = new Char[] { '(', ')', ',' };
    var split = str.Split(
        '=',
        StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
    );
    var key = split[0];
    var value = split[1].Split(
        delimiters,
        StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
    );
    var node = new Node { Left = value[0], Right = value[1] };
    return (key, node);
}

struct Node
{
    public string Left;
    public string Right;
}

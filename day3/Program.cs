// Move top down left to right
// In each line get index of all symbols and numbers 
// Do one pass over current numbers and current symbols check if any matches
// Set current numbers and symbols to be previous
var lines = File.ReadLines("input.txt");

var grid = new List<char[]>();
foreach (var line in lines)
{
    grid.Add(line.ToCharArray());
}

var directions = new List<(int, int)> {
    (-1,-1),
    (-1, 0),
    (-1, 1),
    (0, -1),
    (0, 0),
    (0, 1),
    (1,-1),
    (1, 0),
    (1, 1)
};

var count = 0;
var symbolAdjacent = false;
var gigaTotal = 0;
for (var row = 0; row < grid.Count; row++)
{
    for (var col = 0; col < grid.Count; col++)
    {
        var curr = grid[row][col];

        if (Char.IsNumber(curr))
        {
            if (!symbolAdjacent)
            {
                symbolAdjacent = IsSymbolAdjacent(grid, (row, col));
            }
            Console.WriteLine($"Count: {count}, adding {curr - '0'} to count");
            count = count * 10 + curr - '0';
        }
        else
        {
            if (symbolAdjacent)
            {
                Console.WriteLine($"Writing {count} to gigaTotal");
                gigaTotal += count;
            }
            count = 0;
            symbolAdjacent = false;
        }
    }
    if (symbolAdjacent)
    {
        Console.WriteLine($"Writing {count} to gigaTotal");
        gigaTotal += count;
    }
    count = 0;
    symbolAdjacent = false;

}

Console.WriteLine($"Total: {gigaTotal}");
bool IsSymbolAdjacent(List<char[]> grid, (int, int) position)
{
    foreach (var direction in directions)
    {
        var newRow = position.Item1 + direction.Item1;
        var newCol = position.Item2 + direction.Item2;
        // Console.WriteLine($"Checking ({position.Item1}, {position.Item2}), NRow {newRow}, NCol {newCol}");
        if (newRow < 0 || newCol < 0 || newRow > grid.Count - 1 || newCol > grid.Count - 1)
        {
            continue;
        }
        var newChar = grid[newRow][newCol];
        if (!Char.IsNumber(newChar) && newChar != '.')
        {
            Console.WriteLine($"New character {newChar} at ({newRow}, {newCol})");
            return true;
        }
    }
    return false;
}
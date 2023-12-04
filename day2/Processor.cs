namespace Advent2023.Day2;

public class Processor
{
    public int Process(string line)
    {
        var initialSplit = line.Split(':');
        var gameId = Int32.Parse(initialSplit[0].Split(' ')[1]);
        var games = initialSplit[1].Split(';');
        var red = 0;
        var blue = 0;
        var green = 0;
        foreach (var game in games)
        {
            // Console.WriteLine(game);
            var colours = game.Split(',');
            foreach (var colourPair in colours)
            {
                var pair = colourPair.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var number = Int32.Parse(pair[0]);
                var colour = pair[1];
                if (colour == "red")
                {
                    red = Math.Max(red, number);
                }
                else if (colour == "blue")
                {
                    blue = Math.Max(number, blue);
                }
                else if (colour == "green")
                {
                    green = Math.Max(number, green);
                }
            }
        }
        // Console.WriteLine($"Totals: red {red}, green: {green} blue: {blue}");
        if (red <= 12 && green <= 13 && blue <= 14)
        {
            return gameId;
        }
        return 0;
    }

    public int Part2(string line)
    {
        {
            var initialSplit = line.Split(':');
            var gameId = Int32.Parse(initialSplit[0].Split(' ')[1]);
            var games = initialSplit[1].Split(';');
            var red = 0;
            var blue = 0;
            var green = 0;
            foreach (var game in games)
            {
                var colours = game.Split(',');
                foreach (var colourPair in colours)
                {
                    var pair = colourPair.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    var number = Int32.Parse(pair[0]);
                    var colour = pair[1];
                    if (colour == "red")
                    {
                        red = Math.Max(red, number);
                    }
                    else if (colour == "blue")
                    {
                        blue = Math.Max(number, blue);
                    }
                    else if (colour == "green")
                    {
                        green = Math.Max(number, green);
                    }
                }
            }
            return red * blue * green;
        }
    }
}

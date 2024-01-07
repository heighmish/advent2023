using System.ComponentModel.DataAnnotations;

var lines = File.ReadLines("big.txt")
    .Select(line => line.ToCharArray())
    .ToArray();

var frontier = new Queue<(Point, int)>();
var seenSet = new HashSet<Point>();

for (var outer = 0; outer < lines.Length; outer++)
{
    for (var inner = 0; inner < lines[outer].Length; inner++)
    {
        if (lines[outer][inner] == 'S')
        {
            var startingPoint = new Point
            {
                x = inner,
                y = outer
            };
            frontier.Enqueue((startingPoint, 0));
            seenSet.Add(startingPoint);
        }
    }
}

var layers = 0;
while (frontier.Count != 0)
{
    var searchPoint = frontier.Dequeue();
    layers = Math.Max(layers, searchPoint.Item2);
    var nextFrontier = GetPoints(searchPoint.Item1, lines);
    var validPoints = nextFrontier.Where(point => ValidPoint(point, lines));
    foreach (var point in validPoints)
    {
        if (seenSet.Add(point))
        {
            frontier.Enqueue((new Point
            {
                x = point.x,
                y = point.y
            }, searchPoint.Item2 + 1));
        }
    }
}

Console.WriteLine($"Layers: {layers}");

bool ValidPoint(Point point, char[][] lines)
{
    return point.y >= 0
        && point.y < lines.Length
        && point.x >= 0
        && point.x < lines[0].Length;
}

IEnumerable<Point> GetPoints(Point searchPoint, char[][] lines)
{
    var charPoint = lines[searchPoint.y][searchPoint.x];
    var points = new List<Point>();
    if (charPoint == 'S')
    {
        // WOULD NEED TO BOUNDS CHECK THESE IF START POINT WAS ON EDGE
        if (lines[searchPoint.y - 1][searchPoint.x] is '|' or '7' or 'F')
        {
            points.Add(new Point
            {
                y = searchPoint.y - 1,
                x = searchPoint.x
            });
        }

        if (lines[searchPoint.y + 1][searchPoint.x] is '|' or 'L' or 'J')
        {
            points.Add(new Point
            {
                y = searchPoint.y + 1,
                x = searchPoint.x
            });
        }
        if (lines[searchPoint.y][searchPoint.x - 1] is '-' or 'L' or 'F')
        {
            points.Add(new Point
            {
                y = searchPoint.y,
                x = searchPoint.x - 1
            });
        }
        if (lines[searchPoint.y][searchPoint.x + 1] is '-' or 'J' or '7')
        {
            points.Add(new Point
            {
                y = searchPoint.y,
                x = searchPoint.x + 1
            });
        }
    }
    else if (charPoint == '|')
    {
        points.Add(new Point
        {
            y = searchPoint.y - 1,
            x = searchPoint.x
        });

        points.Add(new Point
        {
            y = searchPoint.y + 1,
            x = searchPoint.x
        });
    }
    else if (charPoint == '-')
    {
        points.Add(new Point
        {
            y = searchPoint.y,
            x = searchPoint.x - 1
        });

        points.Add(new Point
        {
            y = searchPoint.y,
            x = searchPoint.x + 1
        });

    }
    else if (charPoint == 'L')
    {
        points.Add(new Point
        {
            y = searchPoint.y - 1,
            x = searchPoint.x
        });

        points.Add(new Point
        {
            y = searchPoint.y,
            x = searchPoint.x + 1
        });


    }
    else if (charPoint == 'J')
    {
        points.Add(new Point
        {
            y = searchPoint.y - 1,
            x = searchPoint.x
        });

        points.Add(new Point
        {
            y = searchPoint.y,
            x = searchPoint.x - 1
        });

    }
    else if (charPoint == '7')
    {
        points.Add(new Point
        {
            y = searchPoint.y + 1,
            x = searchPoint.x
        });

        points.Add(new Point
        {
            y = searchPoint.y,
            x = searchPoint.x - 1
        });

    }
    else if (charPoint == 'F')
    {
        points.Add(new Point
        {
            y = searchPoint.y + 1,
            x = searchPoint.x
        });

        points.Add(new Point
        {
            y = searchPoint.y,
            x = searchPoint.x + 1
        });

    }
    else
    {
        return Enumerable.Empty<Point>();
    }
    return points;
}


public struct Point
{
    public int x;
    public int y;
}

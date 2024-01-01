public class Part1
{
    public int Run(string line)
    {
        var initalPatternList = line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList();

        var lists = new List<List<int>>
        {
            initalPatternList
        };

        while (!lists.Last().All(x => x == 0))
        {
            lists.Add(GetDifferenceList(lists.Last()));
        }

        var sum = 0;

        var lowerRank = 0;
        for (var outer = lists.Count - 1; outer >= 0; outer--)
        {
            // Console.WriteLine($"Outer is: {outer}");
            var lastElement = lists[outer].Last();
            sum = lastElement + lowerRank;
            lowerRank = sum;
        }
        return sum;
    }

    public static List<int> GetDifferenceList(List<int> list)
    {
        var ret = new List<int>();
        var curr = list.First();
        foreach (var num in list.Skip(1))
        {
            ret.Add(num - curr);
            curr = num;
        }
        return ret;
    }
}
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Advent2023.Day1;

public class Processor
{
    public int Process(string line)
    {
        var numbers = new List<string>{"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
        var firstNumber = 'A';
        var firstIndex = -1;
        var lastNumber = 'A';
        var lastIndex = -1;
        var index = 0;
        var s = new StringBuilder();
        foreach (var character in line)
        {
            if (Char.IsNumber(character))
            {
                if (firstNumber == 'A')
                {
                    firstNumber = character;
                    firstIndex = index;
                }
                lastNumber = character;
                lastIndex = index;
            }
            index++;
        }

        for(var i = 0; i < numbers.Count; ++i) {
            var found = line.IndexOf(numbers[i]);
            Console.WriteLine($"FOUND:{numbers[i]} ,{i+1} at {found}");
            // if (found != -1 && found != 0) {
            //     if (found < firstIndex || firstIndex == -1) {
            //         firstIndex = found;
            //         firstNumber = (char)(i+1);
            //     }
            // }
            // var found2 = line.LastIndexOf(numbers[i]);
            // if (found2 != -1 && found != 0) {
            //     if (found2 > lastIndex || lastIndex == -1) {
            //         lastIndex = found;
            //         lastNumber = (char)(i+1);
            //     }
            // }
        }

        var total = new string([firstNumber, lastNumber]);
        Console.WriteLine($"Line: {line}, first: {firstNumber}, last: {lastNumber}");
        return Int32.Parse(total);
    }
}

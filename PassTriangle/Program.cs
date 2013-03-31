using System.IO;
using System.Collections.Generic;
using System;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<string> rawLines = new List<string>();
        using (StreamReader reader = File.OpenText(args[0]))
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            if (null == line)
                continue;

            rawLines.Add(line);
        }

        Console.WriteLine(MainDriver(rawLines));
    }

    private static int MainDriver(List<string> rawLines)
    {
        var triangle = LoadTriangle(rawLines);

        var result = WalkTriangle(triangle);

        return result;
    }

    internal static int WalkTriangle(List<List<int>> triangle)
    {
        //walk it backwards
        var lastRow = triangle[triangle.Count - 1];
        for (int i = triangle.Count - 1; i >= 1; i--)
        {
            var newLastRow = new List<int>();
            
            for (int j = 0; j < triangle[i - 1].Count; j++)
            {
                var leftSum = lastRow[j] +  triangle[i - 1][j];
                var rightSum = lastRow[j + 1] + triangle[i - 1][j]; 
                newLastRow.Add(((leftSum > rightSum) ? leftSum : rightSum));
            }
  
            lastRow = newLastRow;
        }
        
        return lastRow[0];
    }

    internal static List<List<int>> LoadTriangle(List<string> rawLines)
    {
        var triangle = new List<List<int>>();

        foreach (var line in rawLines)
        {
            var triLevel = new List<int>();
            foreach (var item in line.Split(' '))
            {
                if (string.IsNullOrWhiteSpace(item)) continue;
                triLevel.Add(Convert.ToInt32(item));
            }
            triangle.Add(triLevel);
        }

        return triangle;
    }
}
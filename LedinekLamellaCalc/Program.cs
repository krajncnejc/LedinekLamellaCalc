using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

partial class Program
{

    static void Main()
    {
        //Hardcodamo za zdaj koliko želimo ampak se vse lahko da  v UI da se doda dinamično
        int totalLamelWanted = 111;
        int lamelLength = 3060;
        int lamelWidth = 127;

        var bestSolution = FindBestGroups(totalLamelWanted, lamelLength, lamelWidth);

        if (bestSolution == null)
        {
            Console.WriteLine("Konfiguracija je nemogoca");
        }
        else
        {
            int groupNum = 1;
            Console.WriteLine("Najboljsa Resitev:");
            foreach (var group in bestSolution)
            {
                Console.WriteLine($"Skupina {groupNum}: {group.lamPerWidthCount} dolgih × {group.lamPerLongCount} kratkih = {group.totalLamShort} kratkih lamel " + $"| dolžina dolge: {group.longLenght} mm | širina skupine: {group.groupWidth} mm");
                groupNum++;
            }
            Console.WriteLine($"Skupno Lamel: {bestSolution.Sum(x => x.totalLamShort)}");
            Console.WriteLine($"Skupno dolgih Panel: {bestSolution.Sum(x => x.totalLamLong)}");
            Console.WriteLine($"Število skupin Panel: {bestSolution.Count}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Program
{
    public static List<lamelGroup>? FindBestGroups(int totalLamelWanted, int lamelLength, int lamelWidth)
    {
        // omejitve strojev
        int minLong = 6000, maxLong = 16000;
        int minGroupWidth = 800, maxGroupWidth = 1600;

        int minLamelPerGroup = (int)Math.Ceiling((double)minGroupWidth / lamelWidth);
        int maxLamelPerGroup = (int)Math.Floor((double)maxGroupWidth / lamelWidth);

        int minLamelPerLong = (int)Math.Ceiling((double)minLong / lamelLength);
        int maxLamelPerLong = (int)Math.Floor((double)maxLong / lamelLength);

        // ustvarimo vse možne skupine
        var allPossibleGroups = new List<lamelGroup>();
        for (int widthNum = minLamelPerGroup; widthNum <= maxLamelPerGroup; widthNum++)
        {
            for (int lamelPerLong = minLamelPerLong; lamelPerLong <= maxLamelPerLong; lamelPerLong++)
            {
                int longLength = lamelPerLong * lamelLength;
                int groupWidth = widthNum * lamelWidth;

                if (longLength >= minLong && longLength <= maxLong && groupWidth >= minGroupWidth && groupWidth <= maxGroupWidth)//ustvarjajo se dokler ne presežejo omejitve ali pa morajo začeti novo zaradi premalo prostora na prejšni
                {
                    allPossibleGroups.Add(new lamelGroup
                    {
                        lamPerWidthCount = widthNum,
                        lamPerLongCount = lamelPerLong,
                        lamLength = lamelLength,
                        lamWidth = lamelWidth
                    });
                }
            }
        }

        List<lamelGroup>? bestSolution = null;
        int bestTotalLong = int.MaxValue;

        // lokalna rekurzija
        void Search(int remaining, List<lamelGroup> currentGroup)
        {
            if (remaining == 0)
            {
                int totalLong = currentGroup.Sum(g => g.totalLamLong);
                if (totalLong < bestTotalLong)
                {
                    bestTotalLong = totalLong;
                    bestSolution = new List<lamelGroup>(currentGroup);
                }
                return;
            }

            if (remaining < 0 || currentGroup.Count >= 6) return;

            foreach (var g in allPossibleGroups)
            {
                currentGroup.Add(g);
                // odštejemo število kratkih lamel, ne samo dolgih
                Search(remaining - g.totalLamShort, currentGroup);
                currentGroup.RemoveAt(currentGroup.Count - 1);
            }
        }

        Search(totalLamelWanted, new List<lamelGroup>());
        return bestSolution;
    }
}

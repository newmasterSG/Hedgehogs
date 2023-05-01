using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Рedgehogs
{
    public static class Hedgehogs
    {
        public static int Searching(int[] population, int desiredColor)
        {
            int max = population.Max();
            int[][] seen = new int[max + 1][];
            for (int i = 0; i < seen.Length; i++)
            {
                seen[i] = new int[max + 1];
            }

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(population);
            seen[population[0]][population[1]] = 1;

            int[][] colorChanges = new int[][] { new int[] { 1, 2 }, new int[] { 0, 2 }, new int[] { 0, 1 } };

            int steps = 0;
            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    int[] curr = queue.Dequeue();
                    if (curr[desiredColor] == population.Length)
                    {
                        return steps;
                    }
                    for (int j = 0; j < colorChanges.Length; j++)
                    {
                        int[] next = new int[3];
                        next[colorChanges[j][0]] = curr[colorChanges[j][0]];
                        next[colorChanges[j][1]] = curr[colorChanges[j][1]];
                        next[3 - colorChanges[j][0] - colorChanges[j][1]] = curr[3 - colorChanges[j][0] - colorChanges[j][1]] + curr[colorChanges[j][0]] + curr[colorChanges[j][1]];
                        if (next[0] <= max && next[1] <= max && seen[next[0]][next[1]] == 0)
                        {
                            queue.Enqueue(next);
                            seen[next[0]][next[1]] = 1;
                        }
                    }
                }
                steps++;
            }

            if(steps > 0)
            {
                return steps;
            }

            return -1;
        }
    }
}

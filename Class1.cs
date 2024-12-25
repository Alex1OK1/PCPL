using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public class Levenshtine
    {
        public static int Minimum(int a, int b, int c) => (a = a < b ? a : b) < c ? a : c;

        public static int LevenshteinDistance(string firstWord, string secondWord)
        {
            int n = firstWord.Length + 1;
            int m = secondWord.Length + 1;
            int[,] matrixD = new int[n, m];

            for (var i = 0; i < n; i++)
            {
                matrixD[i, 0] = i;
            }

            for (var j = 0; j < m; j++)
            {
                matrixD[0, j] = j;
            }
           /* for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    Console.Write(matrixD[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }*/
            for (var i = 1; i < n; i++)
            {
                for (var j = 1; j < m; j++)
                {
                    var substitutionCost = firstWord[i - 1] == secondWord[j - 1] ? 0 : 1;
                    //Console.WriteLine(firstWord[i - 1]);
                    //Console.WriteLine(secondWord[j - 1]);
                    //Console.WriteLine("-");
                    matrixD[i, j] = Minimum(matrixD[i - 1, j] + 1,         
                                            matrixD[i, j - 1] + 1,        
                                            matrixD[i - 1, j - 1] + substitutionCost);
                }
            }

                    return matrixD[n - 1, m - 1];
        }
    }
}

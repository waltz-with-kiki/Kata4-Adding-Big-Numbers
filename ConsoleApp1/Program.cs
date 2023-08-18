using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Kata
{
    public static string Add(string a, string b)
    {
        // return (BigInteger.Parse(a) + BigInteger.Parse(b)).ToString(); best solution
        // return ((Convert.ToInt64(a) + Convert.ToInt64(b))).ToString();
        char[] stringA = a.Reverse().ToArray();
        char[] stringB = b.Reverse().ToArray();
        int[] ints = new int[a.Length + b.Length];
        int max = a.Length > b.Length ? a.Length : b.Length;



        int j = ints.Length - 1;
        foreach (var item in stringA)
        {
            ints[j] += (int)char.GetNumericValue(item);
            j--;
        }

        j = ints.Length - 1;
        foreach (var item in stringB)
        {
            ints[j] += (int)char.GetNumericValue(item);
            j--;
        }

        for (int i = ints.Length - 1; i >= 0; i--)
        {
            if (ints[i] > 9)
            {
                int item = ints[i] / 10;
                ints[i] = ints[i] - item * 10;
                ints[i - 1] = ints[i - 1] + item;
            }
        }

        var list = ints.SkipWhile(x => x == 0);

        string result = "";

        foreach (var item in list)
        {
            result += item;
        }

        return result;
    }
}
using System;
using System.Collections.Generic;

public static class Bai1
{
    public static List<int> Values { get; } = new List<int>
    {0 , 1 , 2 , 4 , 6 , 8 , 9 , 10 , 15 , 21 , 25 , 30 , 36 , 49 , 64};

    public static List<int> SortedA { get; } = new List<int> { -4, -1, 0, 2, 5, 8, 11, 14 };
    public static List<int> SortedB { get; } = new List<int> { 1, 2, 4, 7, 9, 11, 15 };

    public static bool IsEvenPositive(int n)
    {
        return n > 0 && n % 2 == 0;
    }

    public static bool IsMultipleOfThree(int n)
    {
        return n % 3 == 0;
    }

    public static List<int> CountEvenNumbers(List<int> source)
    {
        List<int> result = new List<int>();
        foreach (int value in source)
        {
            if (value % 2 == 0)
            {
                result.Add(value);
            }
        }
        return result;
    }

    public static int? GetLargestMultipleOfThree(List<int> source)
    {
        int? largest = null;

        foreach (int value in source)
        {
            if (IsMultipleOfThree(value))
            {
                if( largest == null || largest < value)
                {
                    largest = value;
                }
            }
        }

        return largest;
    }

    public static bool HasPairWithSum(List<int> sorted, int target)
    {
        int left = 0;
        int right = sorted.Count - 1;

        while (left < right)
        {
            int sum = sorted[left] + sorted[right];

            if (sum == target)
            {
                return true;
            }

            if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }

        return false;
    }

    public static List<int> GetCommonValues(List<int> a, List<int> b)
    {
        List<int> common = new List<int>();
        int i = 0;
        int j = 0;

        while (i < a.Count && j < b.Count)
        {
            if (a[i] == b[j])
            {
                common.Add(a[i]);
                i++;
                j++;
            }
            else if (a[i] < b[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        return common;
    }
}

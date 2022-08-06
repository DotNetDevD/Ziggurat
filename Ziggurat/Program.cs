using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

class Exercise
{
    static int[,] Ziggurat(int n)
    {
        int dimensional = n + (n - 1);
        int[,] ziggurat = new int[dimensional, dimensional];

        int k = 0;
        bool isBreak = k >= n;

        while (n >= k)
        {
            for (int i = k; i < ziggurat.GetLength(0) - k; i++)
            {
                for (int j = k; j < ziggurat.GetLength(1) - k; j++)
                {
                    ziggurat[i, j] = k + 1;
                    if (isBreak)
                        break;
                }
                if (isBreak)
                    break;
            }
            k++;
        }     
        return ziggurat;
    }

    static void ShowZiggurat(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j]);
            }
            Console.WriteLine();
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество этажей вашего Зиггурата!");
        string result = matrixToString(arrayToMatrix(Ziggurat(int.Parse(Console.ReadLine()))));
        Console.WriteLine(result);
    }

    private static List<List<int>> arrayToMatrix(int[,] array)
    {
        List<List<int>> result = new List<List<int>>();

        for (int i = 0; i < array.GetLength(0); i++)
        {
            List<int> temp = new List<int>();
            for (int j = 0; j < array.GetLength(1); j++)
            {
                temp.Add(array[i, j]);
            }
            result.Add(temp);
        }
        return result;
    }

    private static String matrixToString(List<List<int>> matrix)
    {
        String result = "";

        for (int i = 0; i < matrix.Count; i++)
        {
            result += String.Join(" ", matrix[i].ToArray()) + "\n";
        }

        return result.Length > 0 ? result.Substring(0, result.Length - 1) : result;
    }

}

/*
 Напишите функцию, которая принимает одно целое число n, а возвращает “ступенчатую” матрицу,
 состоящую из n этажей. Этажи нумеруются с первого, ширина каждой ступеньки равна одной строке или столбцу.
    n = 4
    Ожидается на выходе
    1 1 1 1 1 1 1
    1 2 2 2 2 2 1
    1 2 3 3 3 2 1
    1 2 3 4 3 2 1
    1 2 3 3 3 2 1
    1 2 2 2 2 2 1
    1 1 1 1 1 1 1
 */
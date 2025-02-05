using System;
using System.Collections.Generic;

public class RecursionSolutions
{
    // Problem 1: Recursive Squares Sum
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) return 0;
        return n * n + SumSquaresRecursive(n - 1);
    }

    // Problem 2: Permutations Choose
    public static List<string> Permutations(char[] letters, int size)
    {
        List<string> results = new List<string>();
        PermuteHelper(letters, "", size, results);
        return results;
    }

    private static void PermuteHelper(char[] letters, string current, int size, List<string> results)
    {
        if (current.Length == size)
        {
            results.Add(current);
            return;
        }
        
        foreach (char letter in letters)
        {
            if (!current.Contains(letter))
            {
                PermuteHelper(letters, current + letter, size, results);
            }
        }
    }

    // Problem 3: Climbing Stairs
    public static int CountWaysToClimb(int s, Dictionary<int, int> memo = null)
    {
        if (s < 0) return 0;
        if (s == 0) return 1;
        if (memo == null) memo = new Dictionary<int, int>();
        if (memo.ContainsKey(s)) return memo[s];
        
        memo[s] = CountWaysToClimb(s - 1, memo) + CountWaysToClimb(s - 2, memo) + CountWaysToClimb(s - 3, memo);
        return memo[s];
    }

    // Problem 4: Wildcard Binary Patterns
    public static List<string> GenerateBinaryPatterns(string pattern)
    {
        List<string> results = new List<string>();
        GeneratePatternsHelper(pattern.ToCharArray(), 0, results);
        return results;
    }

    private static void GeneratePatternsHelper(char[] pattern, int index, List<string> results)
    {
        if (index == pattern.Length)
        {
            results.Add(new string(pattern));
            return;
        }
        
        if (pattern[index] == '*')
        {
            pattern[index] = '0';
            GeneratePatternsHelper(pattern, index + 1, results);
            pattern[index] = '1';
            GeneratePatternsHelper(pattern, index + 1, results);
            pattern[index] = '*';
        }
        else
        {
            GeneratePatternsHelper(pattern, index + 1, results);
        }
    }

    // Problem 5: Maze Solver
    public static List<string> SolveMaze(Maze maze, int x, int y, List<(int, int)> currPath = null)
    {
        if (currPath == null) currPath = new List<(int, int)>();
        List<string> results = new List<string>();
        
        SolveMazeHelper(maze, x, y, currPath, results);
        return results;
    }

    private static void SolveMazeHelper(Maze maze, int x, int y, List<(int, int)> currPath, List<string> results)
    {
        if (!maze.IsValidMove(currPath, x, y)) return;
        
        currPath.Add((x, y));
        
        if (maze.IsEnd(x, y))
        {
            results.Add(string.Join(" -> ", currPath));
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }
        
        SolveMazeHelper(maze, x + 1, y, currPath, results);
        SolveMazeHelper(maze, x - 1, y, currPath, results);
        SolveMazeHelper(maze, x, y + 1, currPath, results);
        SolveMazeHelper(maze, x, y - 1, currPath, results);
        
        currPath.RemoveAt(currPath.Count - 1);
    }
}
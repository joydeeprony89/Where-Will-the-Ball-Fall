// See https://aka.ms/new-console-template for more information

var grid = new int[5][] { new int[] { 1, 1, 1, -1, -1 }, new int[] { 1, 1, 1, -1, -1 }, new int[] { -1, -1, -1, 1, 1 }, new int[] { 1, 1, 1, 1, -1 },
  new int[] { -1, -1, -1, -1, -1 } };
Solution s = new Solution();
var answer = s.FindBall(grid);
Console.WriteLine(string.Join(",", answer));

// https://youtu.be/nctLXZP2yig
public class Solution
{
  public int[] FindBall(int[][] grid)
  {
    int row = grid.Length; int col = grid[0].Length;
    int[] result = new int[col];
    Array.Fill(result, -1);
    for (int c = 0; c < col; c++)
    {
      Dfs(0, c, c);
    }

    void Dfs(int r, int c, int startingColumn)
    {
      // base condition
      if (r == row)
      {
        result[startingColumn] = c;
        return;
      }

      // if cell has 1 we check next cell has 1 or not ? If yes we move right diagonally = (r+1)(c+1)
      if (grid[r][c] == 1)
      {
        if (c + 1 < col && grid[r][c + 1] == 1)
          Dfs(r + 1, c + 1, startingColumn);
      }
      // if cell has -1 we check previous cell has -1 or not ? If yes we move left diagonally = (r+1)(c-1)
      else if (grid[r][c] == -1)
      {
        if (c - 1 >= 0 && grid[r][c - 1] == -1)
          Dfs(r + 1, c - 1, startingColumn);
      }
    }

    return result;
  }
}
public static class BoardUtility
{

    /// <summary>
    /// Returns true if detects a pattern in horizontal with n numbers 
    /// of pieces to match
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="piece"></param>
    /// <param name="n2match"></param>
    /// <returns></returns>
    public static bool Horizontal(Cell[,] grid, Piece piece, int n2match)
    {
        if (piece == Piece.Empty) return false;

        int rows = grid.GetLength(0);
        int columns = grid.GetLength(1);

        //Horizontal
        for (int c = 0; c < (columns - (n2match - 1)); c++)
        {
            for (int r = 0; r < rows; r++)
            {
                if (grid[r, c].piece == piece &&
                    grid[r, c + 1].piece == piece &&
                    grid[r, c + 2].piece == piece &&
                    grid[r, c + 3].piece == piece)
                {
                    return true;
                }

            }
        }

        return false;
    }

    /// <summary>
    /// Returns true if detects a pattern in vertical with n numbers 
    /// of pieces to match
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="piece"></param>
    /// <param name="n2match"></param>
    /// <returns></returns>
    public static bool Vertical(Cell[,] grid, Piece piece, int n2match)
    {
        if (piece == Piece.Empty) return false;

        int rows = grid.GetLength(0);
        int columns = grid.GetLength(1);

        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < (rows - (n2match - 1)); r++)
            {
                if (grid[r, c].piece == piece &&
                    grid[r + 1, c].piece == piece &&
                    grid[r + 2, c].piece == piece &&
                    grid[r + 3, c].piece == piece)
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Returns true if detects a pattern in positive diagonal slope with n numbers 
    /// of pieces to match
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="piece"></param>
    /// <param name="n2match"></param>
    /// <returns></returns>
    public static bool DiagonalSlope(Cell[,] grid, Piece piece, int n2match)
    {
        if (piece == Piece.Empty) return false;

        int Rows = grid.GetLength(0);
        int Columns = grid.GetLength(1);

        for (int c = 0; c < (Columns - (n2match - 1)); c++)
        {
            for (int r = 0; r < (Rows - (n2match - 1)); r++)
            {
                if (grid[r, c].piece == piece &&
                    grid[r + 1, c + 1].piece == piece &&
                    grid[r + 2, c + 2].piece == piece &&
                    grid[r + 3, c + 3].piece == piece)
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// Returns true if detects a pattern in negative diagonal slope with n numbers 
    /// of pieces to match
    /// </summary>
    /// <param name="grid"></param>
    /// <param name="piece"></param>
    /// <param name="n2match"></param>
    /// <returns></returns>
    public static bool NegativeDiagonalSlope(Cell[,] grid, Piece piece, int n2match)
    {
        if (piece == Piece.Empty) return false;

        int Rows = grid.GetLength(0);
        int Columns = grid.GetLength(1);

        for (int c = 0; c < (Columns - (n2match - 1)); c++)
        {
            for (int r = (n2match - 1); r < Rows; r++)
            {
                if (grid[r, c].piece == piece &&
                    grid[r - 1, c + 1].piece == piece &&
                    grid[r - 2, c + 2].piece == piece &&
                    grid[r - 3, c + 3].piece == piece)
                {
                    return true;
                }
            }
        }

        return false;
    }

}

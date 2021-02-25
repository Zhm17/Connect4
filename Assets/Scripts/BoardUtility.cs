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
    public static bool Horizontal(@int[,] grid, PieceID piece, int n2match)
    {
        if (piece == PieceID.EMPTY) return false;

        int columns = grid.GetLength(0);
        int rows = grid.GetLength(1);
        
        //Horizontal
        for (int c = 0; c < (columns - (n2match - 1)); c++)
        {
            for (int r = 0; r < rows; r++)
            {
                if (grid[c, r].piece == piece &&
                    grid[c + 1, r].piece == piece &&
                    grid[c + 2, r].piece == piece &&
                    grid[c + 3, r].piece == piece)
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
    public static bool Vertical(@int[,] grid, PieceID piece, int n2match)
    {
        if (piece == PieceID.EMPTY) return false;

        int columns = grid.GetLength(0);
        int rows = grid.GetLength(1);

        for (int c = 0; c < columns; c++)
        {
            for (int r = 0; r < (rows - (n2match - 1)); r++)
            {
                if (grid[c, r].piece == piece &&
                    grid[c, r + 1].piece == piece &&
                    grid[c, r + 2].piece == piece &&
                    grid[c, r + 3].piece == piece)
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
    public static bool DiagonalSlope(@int[,] grid, PieceID piece, int n2match)
    {
        if (piece == PieceID.EMPTY) return false;

        int columns = grid.GetLength(0);
        int rows = grid.GetLength(1);
        
        for (int c = 0; c < (columns - (n2match - 1)); c++)
        {
            for (int r = 0; r < (rows - (n2match - 1)); r++)
            {
                if (grid[c, r].piece == piece &&
                    grid[c + 1, r + 1].piece == piece &&
                    grid[c + 2, r + 2].piece == piece &&
                    grid[c + 3, r + 3].piece == piece)
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
    public static bool NegativeDiagonalSlope(@int[,] grid, PieceID piece, int n2match)
    {
        if (piece == PieceID.EMPTY) return false;

        int columns = grid.GetLength(0);
        int rows = grid.GetLength(1);
        
        for (int c = 0; c < (columns - (n2match - 1)); c++)
        {
            for (int r = (n2match - 1); r < rows; r++)
            {
                if (grid[c, r].piece == piece &&
                    grid[c + 1, r - 1].piece == piece &&
                    grid[c + 2, r - 2].piece == piece &&
                    grid[c + 3, r - 3].piece == piece)
                {
                    return true;
                }
            }
        }

        return false;
    }

}

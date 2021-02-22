using System.Collections.Generic;
using UnityEngine;

public class BoardManager : Singleton<BoardManager>
{

    [Header("Columns and Rows")]
    [SerializeField]
    private static int rows = 6;
    public static int Rows
    {
        get
        {
            return rows;
        }
    }

    
    [SerializeField]
    private static int columns = 7;
    public static int Columns
    {
        get
        {
            return columns;
        }
    }


    private static int matchPieces = 4;
    public static int N2Match
    {
        get
        {
            return matchPieces;
        }
    }


    [SerializeField]
    private  Cell[,] grid;
    public Cell[,] Grid
    {
        get
        {
            return grid;
        }
        set
        {
            grid = value;
        }
    }


    protected override void Init()
    {
        CreateBoard();
    }


    private void CreateBoard()
    {
        grid = new Cell[Rows,Columns];

        for (int c = 0; c < Columns;c++)
        {
            for (int r = 0; r < Rows; r++)
            {
                grid[r,c] = new Cell(Piece.Empty);
            }
        }
    }


    /// <summary>
    /// Creates a clean board and deletes all the disc available in hierarchy
    /// </summary>
    public void CleanBoard()
    {
        CreateBoard();
        Spawner.Instance.Clean();
    }


    /// <summary>
    /// Returns the row index of the cell available. Returns -1 when there are no cells available.
    /// </summary>
    /// <param name="colSelected"></param>
    /// <returns></returns>
    public int AreCellsAvailable(int colSelected)
    {
        //cells not available
        if(grid[Rows-1,Columns-1].piece != Piece.Empty)
        {
            return -1;
        } 
        else
        {
            for (int r = 0; r < Rows; r++)
            {
                if (Grid[r,colSelected].piece != Piece.Empty)
                {
                    return (r-1);
                } 
            } 
        }

        return 0;
    }


    /// <summary>
    /// Returns true if all the cells are occupied
    /// </summary>
    /// <returns></returns>
    public bool IsBoardFull()
    {
        int count = 0;
        
        for (int c = 0; c < Columns; c++)
        {
            count = (AreCellsAvailable(c) > -1 )? count: count + 1;
        }

        return (count == Columns) ? true : false;
    }


    public void SetCell(Cell cell, Piece piece)
    {
        cell.piece = piece;
        LookForAPattern(cell.piece);
    }


    /// <summary>
    /// Looks for an Match 4 pattern in Horizontal, Vertical and Diagonal
    /// </summary>
    /// <returns></returns>
    public bool LookForAPattern(Piece piece)
    {
        if(piece == Piece.Empty)
        {
            Debug.Log("Piece is Empty");
            return false;
        }

        //Horizontal
        if (BoardUtility.Horizontal(Grid, piece, N2Match)) return true;

        //Vertical
        if (BoardUtility.Vertical(Grid, piece, N2Match)) return true;

        //Positive Slope Diagonal
        if (BoardUtility.DiagonalSlope(Grid, piece, N2Match)) return true;

        //Negative Slope Diagonal
        if (BoardUtility.NegativeDiagonalSlope(Grid, piece, N2Match)) return true;

        return false;
    }


}

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
    private  @int[,] grid;
    public @int[,] Grid
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


    /// <summary>
    /// Position where the disc will be instantiated
    /// </summary>
    [Header("Disc Initial Position")]
    [SerializeField]
    private static Vector3 discInitialPos = new Vector3(0, 6f, -0.11f);
    public static Vector3 DiscInitialPosition
    {
        get
        {
            return discInitialPos;
        }
    }

    protected override void Init()
    {
        CreateBoard();
    }


    private void CreateBoard()
    {
        grid = new @int[Columns,Rows];

        for (int c = 0; c < Columns;c++)
        {
            for (int r = 0; r < Rows; r++)
            {
                grid[c,r] = new @int(PieceID.EMPTY);
            }
        }
    }


    /// <summary>
    /// Creates a clean board and deletes all the disc available in hierarchy
    /// </summary>
    public void CleanBoard()
    {
        Spawner.Instance.Clean();
        CreateBoard();
       
    }


    /// <summary>
    /// Returns the row index of the cell available. Returns -1 when there are no cells available.
    /// </summary>
    /// <param name="colSelected"></param>
    /// <returns></returns>
    public int AreCellsAvailable(int colSelected)
    {
        
        for (int r = 0; r < Rows; r++)
        {
            if (Grid[colSelected, r].piece == PieceID.EMPTY)
            {
                return r;
            }
        }

        return -1;
    }

    /// <summary>
    /// Return a List<int> with available columns
    /// </summary>
    /// <returns></returns>
    public List<int> AvailableColumns()
    {
        List<int> availableColL = new List<int>();

        for (int c= 0; c < Columns; c++)
        {
            if (IsColumnAvailable(c))
            {
                availableColL.Add(c);
            }
        }

        return availableColL;
    }

    /// <summary>
    /// Ask if a given column has available cells
    /// </summary>
    /// <param name="column"></param>
    /// <returns></returns>
    public bool IsColumnAvailable(int column)
    {
        return (Grid[column, Rows - 1].piece == PieceID.EMPTY);
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


    public void SetCell(Vector2 vect, PieceID piece)
    {
        Grid[(int)vect.x,(int)vect.y].piece = piece;
        LookForAPattern(piece);
    }


    /// <summary>
    /// Looks for an Match 4 pattern in Horizontal, Vertical and Diagonal
    /// </summary>
    /// <returns></returns>
    public bool LookForAPattern(PieceID piece)
    {

        if(piece == PieceID.EMPTY)
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

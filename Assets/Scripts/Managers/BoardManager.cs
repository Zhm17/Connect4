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
        set
        {
            rows = value;
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
        set
        {
            columns = value;
        }
    }


    [SerializeField]
    private Cell[,] grid;
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
        grid = new Cell[rows,columns];

        for (int c = 0; c < columns;c++)
        {
            for (int r = 0; r < rows; r++)
            {
                grid[r,c] = new Cell(Piece.Empty);
            }
        }
    }

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
        if(grid[rows-1,columns-1].piece != Piece.Empty)
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



}

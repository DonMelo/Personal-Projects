using System;
using System.Collections.Generic;

struct int2
{
    public int x;
    public int y;

    public int2(int x,int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class Board
{
    
    Cell[,] cells = new Cell[3, 3] 
    { 
        { new Cell(0), new Cell(1), new Cell(2) },
        { new Cell(3), new Cell(4), new Cell(5) },
        { new Cell(6), new Cell(7), new Cell(8) } 
    };
        Dictionary<int, int2> BoardToArrayPosition = new Dictionary<int, int2>
        {
            {0,new int2(0,0)},
            {1,new int2(1,0)},
            {2,new int2(2,0)},
            {3,new int2(0,1)},
            {4,new int2(1,1)},
            {5,new int2(2,1)},
            {6,new int2(0,2)},
            {7,new int2(1,2)},
            {8,new int2(2,2)}
        };


    public void DrawBoard()
	{

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int l = 0; l < cells.GetLength(1); l++)
            {
				cells[i, l].DrawCell();
            }
        }
	}
    public void ChangeCellValue(CellValue value, int CellPosition) 
    {
        if(!IsCellPositionValid(CellPosition))
        {
            System.Diagnostics.Debug.WriteLine("incorrect cell position");
        }

        BoardToArrayPosition.TryGetValue(CellPosition, out int2 ArrayCoordinates);
        cells[ArrayCoordinates.x, ArrayCoordinates.y].ChangeCellValue(value);

    }

    private bool IsCellPositionValid(int value)
    {
        return BoardToArrayPosition.ContainsKey(value);
        

    }
    public bool CheckWin()
    {

    }
}

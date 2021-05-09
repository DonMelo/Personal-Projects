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
        { new Cell(1), new Cell(4), new Cell(7) },
        { new Cell(2), new Cell(5), new Cell(8) },
        { new Cell(3), new Cell(6), new Cell(9) } 
    };
        Dictionary<int, int2> BoardToArrayPosition = new Dictionary<int, int2>
        {
            {1,new int2(0,0)},
            {2,new int2(1,0)},
            {3,new int2(2,0)},
            {4,new int2(0,1)},
            {5,new int2(1,1)},
            {6,new int2(2,1)},
            {7,new int2(0,2)},
            {8,new int2(1,2)},
            {9,new int2(2,2)}
        };

    
    public void DrawBoard()
	{

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int l = 0; l < cells.GetLength(1); l++)
            {
				cells[i, l].DrawCell();
            }
            Console.WriteLine("");
        }
	}
    public bool ChangeCellValue(CellSign SignValue, int CellPosition) 
    {
        if(!IsCellPositionValid(CellPosition))
        {
            System.Diagnostics.Debug.WriteLine("incorrect cell position");
        }

        BoardToArrayPosition.TryGetValue(CellPosition, out int2 ArrayCoordinates);
        return cells[ArrayCoordinates.x, ArrayCoordinates.y].ChangeCellSign(SignValue);
        
    }

    private bool IsCellPositionValid(int value)
    {
        return BoardToArrayPosition.ContainsKey(value);
        

    }
    public bool CheckWin()
    {
        if (CellSign.cross == cells[0, 0].Sign && CellSign.cross == cells[1, 0].Sign && CellSign.cross == cells[2, 0].Sign ||
            CellSign.cross == cells[0, 1].Sign && CellSign.cross == cells[1, 1].Sign && CellSign.cross == cells[2, 1].Sign ||
            CellSign.cross == cells[0, 2].Sign && CellSign.cross == cells[1, 2].Sign && CellSign.cross == cells[2, 2].Sign ||
            CellSign.cross == cells[0, 0].Sign && CellSign.cross == cells[1, 1].Sign && CellSign.cross == cells[2, 2].Sign ||
            CellSign.cross == cells[0, 2].Sign && CellSign.cross == cells[1, 1].Sign && CellSign.cross == cells[2, 0].Sign ||
            CellSign.cross == cells[0, 0].Sign && CellSign.cross == cells[0, 1].Sign && CellSign.cross == cells[0, 2].Sign ||
            CellSign.cross == cells[1, 0].Sign && CellSign.cross == cells[1, 1].Sign && CellSign.cross == cells[1, 2].Sign ||
            CellSign.cross == cells[2, 0].Sign && CellSign.cross == cells[2, 1].Sign && CellSign.cross == cells[2, 2].Sign
            )
            { 
            return true;
            }
        else if(CellSign.circle == cells[0, 0].Sign && CellSign.circle == cells[1, 0].Sign && CellSign.circle == cells[2, 0].Sign ||
            CellSign.circle == cells[0, 1].Sign && CellSign.circle == cells[1, 1].Sign && CellSign.circle == cells[2, 1].Sign ||
            CellSign.circle == cells[0, 2].Sign && CellSign.circle == cells[1, 2].Sign && CellSign.circle == cells[2, 2].Sign ||
            CellSign.circle == cells[0, 0].Sign && CellSign.circle == cells[1, 1].Sign && CellSign.circle == cells[2, 2].Sign ||
            CellSign.circle == cells[0, 2].Sign && CellSign.circle == cells[1, 1].Sign && CellSign.circle == cells[2, 0].Sign ||
            CellSign.circle == cells[0, 0].Sign && CellSign.circle == cells[0, 1].Sign && CellSign.circle == cells[0, 2].Sign ||
            CellSign.circle == cells[1, 0].Sign && CellSign.circle == cells[1, 1].Sign && CellSign.circle == cells[1, 2].Sign ||
            CellSign.circle == cells[2, 0].Sign && CellSign.circle == cells[2, 1].Sign && CellSign.circle == cells[2, 2].Sign)
            { 
            return true; 
            }
        else
            {
            return false;
            }
        
    }
}

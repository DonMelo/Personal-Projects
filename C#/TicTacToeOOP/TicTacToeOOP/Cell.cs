using System;

public enum CellSign { unasigned=0, cross=1, circle=2 };

public class Cell
{
	public CellSign Sign { get { return sign; } }
	int Position;
	
	CellSign sign = CellSign.unasigned;
	

	public Cell(int position)
	{
		Position = position;
	}
	
	public bool ChangeCellSign(CellSign newValue)
    {
		if (!IsCellSignChangeable(newValue)) 
		{
			Console.WriteLine("incorrect cell value");

			return false;

		}

		sign = newValue;
		return true;


	}
	private bool IsCellSignChangeable(CellSign Value)
    {
		if (CellSign.cross == sign || CellSign.circle == sign)
        {
			return false;
        }
		return true;
	}
	
	public void DrawCell()
    {
		switch (sign)
        {
			case CellSign.unasigned:
				Console.Write(Position);
				break;
			case CellSign.cross:
				Console.Write("X");
				break;
			case CellSign.circle:
				Console.Write("O");
				break;
			default:
				Console.Write("Incorrect Value");
				break;

		}
    }
}

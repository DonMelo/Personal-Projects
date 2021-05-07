using System;

public enum CellValue { unasigned=0, cross=1, circle=2 };

public class Cell
{
	int Position;

	CellValue Value = CellValue.unasigned;
	

	public Cell(int position)
	{
		Position = position;
	}

	public void ChangeCellValue(CellValue newValue)
    {
		if (!IsCellValueCorrect(newValue))
			System.Diagnostics.Debug.WriteLine("incorrect cell value");
		
		Value = newValue;
		


	}
	private bool IsCellValueCorrect(CellValue Value)
    {
		if ((int)Value > 2 || (int)Value < 0)
		{
			return false;
		}
        
		return true;
	}
	
	public void DrawCell()
    {
		switch (Value)
        {
			case CellValue.unasigned:
				Console.WriteLine(Position);
				break;
			case CellValue.cross:
				Console.WriteLine("X");
				break;
			case CellValue.circle:
				Console.WriteLine("O");
				break;
			default:
				Console.WriteLine("Incorrect Value");
				break;

		}
    }
}

using System;
using System.Threading;

public class Game
{
	public Board Board = new Board();
	public Player Player1 = new Player(-1, CellSign.cross, "Player1");
	public Player Player2 = new Player(-1, CellSign.circle, "Player2");

	int AmountOfMovesMade = 0;

	
	public Player PlayerToMove()
    {
		if(AmountOfMovesMade % 2 == 0)
        {
			return Player1;
        }
		return Player2;

	}
	
	bool IsGameOver = false;
   
	public bool Play()
    {
		Console.Clear();
		Board.DrawBoard();
        Player NextPlayerToMove = PlayerToMove();
		Console.WriteLine("Make your Turn " + NextPlayerToMove.name);
		string input = Console.ReadLine();
		int PlayerSelectedPosition = Convert.ToInt32(input);
		bool IsValueChanged = Board.ChangeCellValue(NextPlayerToMove.ChosenSign, PlayerSelectedPosition);
		if (Board.CheckWin())
		      {
			IsGameOver = true;
			Console.WriteLine(NextPlayerToMove.name + " won the game");
			Thread.Sleep(5000);
			
		      }
		if (IsValueChanged) 
			AmountOfMovesMade++;
		return !IsGameOver;
	}
	
}

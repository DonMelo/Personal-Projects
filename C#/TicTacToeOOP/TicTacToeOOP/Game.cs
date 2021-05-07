using System;

public class Game
{
	public Board Board = new Board();
	public Player Player1 = new Player();
	public Player Player2 = new Player();

	int AmountOfMovesMade = 0;

	public Player PlayerToMove()
    {
		if(AmountOfMovesMade % 2 == 0)
        {
			return Player1;
        }
		return Player2;

	}
	public void Play()
    {
		Console.WriteLine("Make your Turn: \n");
		string input = Console.ReadLine();
		int PlayerSelectedPosition = Convert.ToInt32(input);
		Player NextPlayerToMove = PlayerToMove();
		Board.ChangeCellValue(NextPlayerToMove.Choice, PlayerSelectedPosition);
	}
	
}

using System;

public class Player
{
	
	public int ChosenPosition;
	public CellSign ChosenSign;
	public string name;
    
	public Player(int ChosenPosition, CellSign ChosenSign, string PlayerName)
    {
		this.ChosenPosition = ChosenPosition;
		this.ChosenSign = ChosenSign;
		name = PlayerName;

    }

}

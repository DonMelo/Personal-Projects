using System;

namespace TicTacToeOOP
{
    class Program
    {
        static Game TicTacToe = new Game();
        static int Main(string[] args)
        {
            while (TicTacToe.Play())
            {
                
            }
            return 0; 
               
        }
    }
}

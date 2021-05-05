using System;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int choice;
        static int flag;

        /// <summary>
        /// Draws the game board
        /// </summary>
        static void DrawBoard()
        {
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("___|___|___");
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", spaces[6], spaces[7], spaces[8]);
            Console.WriteLine("   |   |   ");
        }

        /// <summary>
        /// Checks if the game was won, tied, or should continue
        /// </summary>
        /// <returns></returns>
        static int CheckWin ()
        {
            if(spaces[0] == spaces[1] &&
                spaces[1] == spaces[2] ||
                spaces[3] == spaces[4] &&
                spaces[4] == spaces[5] ||
                spaces[6] == spaces[7] &&
                spaces[7] == spaces[8] ||
                spaces[0] == spaces[3] &&
                spaces[3] == spaces[6] ||
                spaces[1] == spaces[4] &&
                spaces[4] == spaces[7] ||
                spaces[2] == spaces[5] &&
                spaces[5] == spaces[8] ||
                spaces[0] == spaces[4] &&
                spaces[4] == spaces[8] ||
                spaces[2] == spaces[4] &&
                spaces[4] == spaces[6])
            {
                return 1;
            }
            else if(spaces[0] != '1' &&
                    spaces[1] != '2' &&
                    spaces[2] != '3' &&
                    spaces[3] != '4' &&
                    spaces[4] != '5' &&
                    spaces[5] != '6' &&
                    spaces[6] != '7' &&
                    spaces[7] != '8' &&
                    spaces[8] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }     
        }
        /// <summary>
        /// Draws an X and O on the game board
        /// </summary>
        /// <param name="args"></param>
        static void DrawX (int pos)
        {
            spaces[pos] = 'X';
        }
        static void DrawO(int pos)
        {
            spaces[pos] = 'O';
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1 : X and Player 2 : O" + "\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn");
                }
                else
                {
                    Console.WriteLine("Player 1's turn");
                }
                Console.WriteLine("\n");
                DrawBoard();
                choice = int.Parse(Console.ReadLine()) - 1;

                if (spaces[choice] != 'X' &&
                    spaces[choice] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        DrawO(choice);
                    }
                    else
                    {
                        DrawX(choice);
                    }
                    player++;
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1} \n", choice, spaces[choice]);
                    Console.WriteLine("Please wait 2 seconds board is loading again...");
                    Thread.Sleep(2000);
                }

                flag = CheckWin();
            } while (flag != 1 && flag != -1);

            Console.Clear();
            DrawBoard();
            if(flag == 1)
            {
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Tie Game");
            }
            Console.ReadLine();
        }
    }
}

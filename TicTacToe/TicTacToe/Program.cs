using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Board board = new Board();
            Player player1 = new Player("x", 1);
            Player player2 = new Player("o", 2);
            int turn = 1;
            bool gameOn = true;
            board.ThresholdReached += c_moveMade;
            while (gameOn)
            {
                if(turn == 1)
                {
                    int[] pos = player1.play();
                    board.setCell(pos[0], pos[1], player1.getToken());
                }
                else
                {
                    int[] pos =  player2.play();
                    board.setCell(pos[0], pos[1], player2.getToken());
                }
                Console.Write(board.displayBoard());
                

                if (board.gameState() == player1.getToken())
                {
                    gameOn = false;
                    Console.WriteLine("Game over: player 1 has won");
                    Console.ReadLine();
                } 
                else if(board.gameState() == player2.getToken())
                {
                    gameOn = false;
                    Console.WriteLine("Game over: player 2 has won");
                    Console.ReadLine();
                }
                else if(board.gameState() == "game on")
                {
                    //gameOn = false;
                    Console.WriteLine("Next move");
                    
                }
                else
                {
                    gameOn = false;
                    Console.WriteLine("Game over it was a draw");
                }
                //Console.ReadLine();
                if (board.getTurn() == player1.getToken())
                {
                    turn = 1;
                }
                else
                {
                    turn = 2;
                }
            }

           
            
        }

        public void setTurn(int turn)
        {
           // Console.WriteLine(turn);
            if(turn == 1)
            {
                turn = 2;
            }
            else
            {
                turn = 1;
            }
        }

        public void getMove(Player player)
        {
            player.play();
        }

        static void c_moveMade(object sender, EventArgs e)
        {
            Console.WriteLine("A move wasmade.");
        }
    }
}

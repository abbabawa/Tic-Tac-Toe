using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Board
    {
        private string[,] cells = new string[3, 3];
        private enum tokens{x, o};
        private string turn = "";

        public string displayBoard()
        {
            string board = "|";
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    board += cells[i, j] + "|";
                }
                board += "\n|";
            }
            return board;
        }

        public string getCell(int x, int y)
        {
            return cells[x, y];
        }

        public bool setCell(int x, int y, string token)
        {
            if(cells[x, y] != "x" && cells[x, y] != "o")
            {
                cells[x, y] = token;
                
                if(token == "x")
                {
                    turn = "o";
                }
                else
                {
                    turn = "x";
                }
                
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = 1;
                OnMoveMade(args);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public string gameState()
        {
            int x = 0, o = 0;
            //horizontal
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cells[i, j] == "x")
                        x++;
                    else if (cells[i, j] == "o")
                        o++;
                }
                if (x == 3) return "x";
                if (o == 3) return "o";
                x = 0; o = 0;
            }
            

            //vertical
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (cells[j, i] == "x")
                        x++;
                    else if (cells[j, i] == "o")
                        o++;
                }
                if (x == 3) return "x";
                if (o == 3) return "o";
                x = 0; o = 0;
            }
            

            //diagonal
            for (int i = 0; i < 3; i++)
            {
                for (int j = i; j <= i; j++)
                {
                    if (cells[i, j] == "x")
                        x++;
                    else if (cells[i, j] == "o")
                        o++;
                }
            }
            if (x == 3) return "x";
            if (o == 3) return "o";
            x = 0; o = 0;

            //diagonal
            int k = 1;
            int check = 0;
            for (int i = 2; i >= 0; i--)
            {
                
                for (int j = check; j < k; j++)
                {
                    if (cells[i, j] == "x")
                        x++;
                    else if (cells[i, j] == "o")
                        o++;
                }
                k++;
                check++;
            }
            if (x == 3) return "x";
            if (o == 3) return "o";
            x = 0; o = 0;

            return "game on";
        }

        public string getTurn()
        {
            return turn;
        }

        public event EventHandler ThresholdReached;

        protected virtual void OnMoveMade(EventArgs e)
        {
            EventHandler handler = ThresholdReached;
            handler?.Invoke(this, e);
        }

    }

    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}

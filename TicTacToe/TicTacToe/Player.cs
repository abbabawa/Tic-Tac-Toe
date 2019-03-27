using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Player
    {
        private string token;
        private int num;

        public Player(string token, int num)
        {
            this.token = token;
            this.num = num;
        }

        public string getToken()
        {
            return token;
        }

        public int getNum()
        {
            return num;
        }

        public int[] play()
        {
            //Console.WriteLine($"Player {num}: Enter position to play");
            string value = Console.ReadLine();
            string[] raw = value.Split(' ');
            int num1 = int.Parse(raw[0]);
            int num2 = int.Parse(raw[1]);
            int[] res = { num1, num2 };
            return res;
        }
    }
}

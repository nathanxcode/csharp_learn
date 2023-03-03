using System;
using System.Text;

namespace ConsoleApp2
{

    enum Direction : int
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3
    }
     
    class Board
    {
        public int COLS;
        public int ROWS;
        string[,] board = new string[,] { };
        public Board(int COLS, int ROWS)
        {
            this.COLS = COLS;
            this.ROWS = ROWS;
        }
        public string[,] Gen_board()
        {
            board = new string[COLS, ROWS];

            for (int x = 0; x < COLS; x++)
            {
                for (int y = 0; y < ROWS; y++)
                {
                    if ((x > 0 && x < COLS - 1) && (y > 0 && y < ROWS - 1))
                    {
                        board[x, y] = " ";
                    }
                    else
                    {
                        board[x, y] = "@";
                    }

                    Console.Write(board[x, y]);


                }
                Console.Write("\n");
            }

            return board;
        }

        public void Show()
        {
            for(int x = 0; x < COLS; x++)
            {
                for(int y = 0; y < ROWS; y++)
                {
                    Console.Write(board[x, y]);
                }
                Console.Write("\n");
            }
        }

        public void Update(int x, int y, string chr)
        {
            board[x, y] = chr;
        }


    }
    class Player
    {
        public int pos_x;
        public int pos_y;
        public string str = "P";
        public Player(int pos_x, int pos_y, string str)
        {
            this.pos_x = pos_x;
            this.pos_y = pos_y;
            this.str = str;
        }

        public string GetPlayer()
        {
            return str;
        }

        public void SetPlayerPos(Board board)
        {
            
        }

        public void Move(Board board, Direction dir)
        {
            int past_x = pos_x;
            int past_y = pos_y;

            if (dir == Direction.Up)
            {

                pos_x--;
            }
            else if (dir == Direction.Down)
            {
                pos_x++;
            }
            else if (dir == Direction.Left)
            {
                pos_y--;
            }
            else if (dir == Direction.Right)
            {
                pos_y++;
            }
            board.Update(pos_x, pos_y, "P");
            board.Update(past_x, past_y, " ");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {



            Board board = new Board(24, 48);
            Player p1 = new Player(board.COLS / 2, board.ROWS / 2, "P");
            Direction dir;

            board.Gen_board();

            ConsoleKeyInfo key;
            bool game = true;
            while(game)
            {
                Console.Clear();
                board.Show();

                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Q)
                {
                    game = false;
                }
                if (key.Key == ConsoleKey.Spacebar)
                {
                    board.Update(12, 24, "P");
                    board.Show();
                }
                if (key.Key == ConsoleKey.W)
                {
                    p1.Move(board, Direction.Up );
                }else if (key.Key == ConsoleKey.S)
                {
                    p1.Move(board, Direction.Down);
                }
                else if (key.Key == ConsoleKey.D)
                {
                    p1.Move(board, Direction.Right);
                }
                else if (key.Key == ConsoleKey.A)
                {
                    p1.Move(board, Direction.Left);
                }


            }

        }

    }

}
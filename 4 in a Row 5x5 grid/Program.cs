using System;

namespace _4_in_a_Row_5x5_grid
{
    class Program
    {
        static void Main(string[] args)
        {
            // The Board 5x5 with 0 as Empty , 1 as User, 2 as AI
            int[][] Board = new int[5][];
            Board[0] = new int[5] { 1, 1, 0, 0, 0 };
            Board[1] = new int[5] { 2, 0, 2, 0, 0 };
            Board[2] = new int[5] { 0, 0, 0, 0, 0 };
            Board[3] = new int[5] { 0, 0, 0, 0, 0 };
            Board[4] = new int[5] { 0, 0, 0, 0, 0 };

            int UserInput, AIInput;
            // this int will keep changing to the newest input


            Console.WriteLine(GetAIInput(Board));



            if (Playerfirst())
            {
                // User First
                UserInput = GetUserInput(Board);
            }
            else
            {
                // AI first

            }

            

        }
        static bool Playerfirst()
        {
            Random rng = new Random();
            if (rng.Next(2) == 1)
            {
                return true;
            } else { return false; }
        }
        static int GetUserInput(int[][]Board)
        {
            for(; ; )
            {
                try
                {
                    int x = Convert.ToInt32(Console.ReadLine());
                    if(x<=25 && x >= 1)
                    {
                        if (Simpleif(Board, "{0}", Convert.ToString(x)))
                        {
                            return x;
                        }
                        else
                        {
                            Console.WriteLine("EROR");
                        }
                    }
                    else
                    {
                        Console.WriteLine("EROR");
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("EROR");
                }
            }
        }

        static int GetAIInput(int[][]Board)
        {
            // Can Win 
            for(int i = 0; i < 5; i++)
            {
                if (Simpleif(Board, "b-{0}", Convert.ToString(6), "b-{0}", Convert.ToString(8)))
                {
                    return 1;
                }
            }

            return 0;
        }

        static bool CheckWin(int[][] Board, int turn, bool playerfirst)
        {
            // y = a if user ,y = b if AI
            string y;
            if (playerfirst)
            {
                if (turn % 2 == 1)
                {
                    y = "a";
                }
                else
                {
                    y = "b";
                }
            }
            else
            {
                if (turn % 2 == 0)
                {
                    y = "a";
                }
                else
                {
                    y = "b";
                }
            }

            // if win on a horizontal line
            for (int x = 0; x < 5; x++)
            {
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString((x * 5) + 1), "{0}-{1}", y, Convert.ToString((x * 5) + 2), "{0}-{1}", y, Convert.ToString((x * 5) + 3), "{0}-{1}", y, Convert.ToString((x * 5) + 4)))
                {
                    return true;
                }
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString((x * 5) + 2), "{0}-{1}", y, Convert.ToString((x * 5) + 3), "{0}-{1}", y, Convert.ToString((x * 5) + 4), "{0}-{1}", y, Convert.ToString((x * 5) + 5)))
                {
                    return true;
                }
            }

            // if win on a vertical line
            for (int x = 0; x < 5; x++)
            {
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString(x + 1), "{0}-{1}", y, Convert.ToString(x + 6), "{0}-{1}", y, Convert.ToString(x + 11), "{0}-{1}", y, Convert.ToString(x + 16)))
                {
                    return true;
                }
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString(x + 6), "{0}-{1}", y, Convert.ToString(x + 11), "{0}-{1}", y, Convert.ToString(x + 16), "{0}-{1}", y, Convert.ToString(x + 21)))
                {
                    return true;
                }
            }

            // if win on a diagonal line to the bottom right
            for (; ; ) // just a container
            {
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString(1), "{0}-{1}", y, Convert.ToString(7), "{0}-{1}", y, Convert.ToString(14), "{0}-{1}", y, Convert.ToString(19)))
                {
                    return true;
                }
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString(7), "{0}-{1}", y, Convert.ToString(13), "{0}-{1}", y, Convert.ToString(19), "{0}-{1}", y, Convert.ToString(25)))
                {
                    return true;
                }
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString(6), "{0}-{1}", y, Convert.ToString(12), "{0}-{1}", y, Convert.ToString(18), "{0}-{1}", y, Convert.ToString(24)))
                {
                    return true;
                }
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString(2), "{0}-{1}", y, Convert.ToString(8), "{0}-{1}", y, Convert.ToString(14), "{0}-{1}", y, Convert.ToString(20)))
                {
                    return true;
                }
                break;
            }

            // if win on a diagonal line from the bottom left
            for (; ; ) // just a container
            {
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString(5), "{0}-{1}", y, Convert.ToString(9), "{0}-{1}", y, Convert.ToString(13), "{0}-{1}", y, Convert.ToString(17)))
                {
                    return true;
                }
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString(9), "{0}-{1}", y, Convert.ToString(13), "{0}-{1}", y, Convert.ToString(17), "{0}-{1}", y, Convert.ToString(21)))
                {
                    return true;
                }
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString(4), "{0}-{1}", y, Convert.ToString(8), "{0}-{1}", y, Convert.ToString(12), "{0}-{1}", y, Convert.ToString(16)))
                {
                    return true;
                }
                if (Simpleif(Board, "{0}-{1}", y, Convert.ToString(10), "{0}-{1}", y, Convert.ToString(14), "{0}-{1}", y, Convert.ToString(18), "{0}-{1}", y, Convert.ToString(22)))
                {
                    return true;
                }
                break;
            }
            return false;
        }

        static bool Simpleif(int[][] Board, params string[] Condition)
        {
            bool isittrue = true;
            foreach (string code in Condition)
            {
                if (code.Contains('a'))
                {
                    string[] splited = code.Split("-");
                    if (Board[IPositionY(Convert.ToInt32(splited[1]))][IPositionX(Convert.ToInt32(splited[1]))] != 1)
                    {
                        isittrue = false;
                        break;
                    }
                }
                else
                {
                    if (code.Contains('b'))
                    {
                        string[] splited = code.Split("-");
                        if (Board[IPositionY(Convert.ToInt32(splited[1]))][IPositionX(Convert.ToInt32(splited[1]))] != 2)
                        {
                            isittrue = false;
                            break;
                        }
                    }
                    else
                    {
                        if (Board[IPositionY(Convert.ToInt32(code))][IPositionX(Convert.ToInt32(code))] != 0)
                        {
                            isittrue = false;
                            break;
                        }
                    }
                }
            }
            return isittrue;
        }

        static int IPositionY(int positioncode)
        {
            if (positioncode < 6) { return 0; }
            else
            {
                if (positioncode < 11) { return 1; }
                else
                {
                    if (positioncode < 16) { return 2; }
                    else
                    {
                        if (positioncode < 21) { return 3; }
                        else
                        {
                            return 4;
                        }
                    }
                }
            }
        }

        static int IPositionX(int positioncode)
        {
            if (positioncode % 5 == 1) { return 0; }
            else
            {
                if (positioncode % 5 == 2) { return 1; }
                else
                {
                    if (positioncode % 5 == 3) { return 2; }
                    else
                    {
                        if (positioncode % 5 == 4) { return 3; }
                        else
                        {
                            return 4;
                        }
                    }
                }
            }
        }
    }
}

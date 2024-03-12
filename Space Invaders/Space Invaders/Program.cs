using System;
using System.Threading;

class Program
{
    static int playerX = 10;
    static int playerY = 20;
    static int playerWidth = 3;
    static int enemyX = 5;
    static int enemyY = 5;
    static bool isGameOver = false;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        Thread inputThread = new Thread(MovePlayer);
        inputThread.Start();

        while (!isGameOver)
        {
            Draw();
            Update();
            Thread.Sleep(50);
            Console.Clear();
        }

        Console.WriteLine("Game Over!");
        Console.ReadKey();
    }

    static void MovePlayer()
    {
        while (!isGameOver)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (playerX > 0)
                        playerX--;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (playerX < Console.WindowWidth - playerWidth)
                        playerX++;
                }
            }
        }
    }

    static void Draw()
    {
        Console.SetCursorPosition(playerX, playerY);
        Console.Write("o");

        Console.SetCursorPosition(enemyX, enemyY);
        Console.Write("*");
    }

    static void Update()
    {
        enemyY++;
        if (enemyY == Console.WindowHeight)
        {
            enemyY = 0;
            enemyX = new Random().Next(0, Console.WindowWidth);
        }

        if (enemyX >= playerX && enemyX < playerX + playerWidth && enemyY == playerY)
        {
            isGameOver = true;
        }
    }
}
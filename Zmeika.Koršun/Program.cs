using System;
using System.Collections.Generic;
using System.Media;
using System.Threading;
using System.IO;

namespace Zmeika.Koršun
{
    class Program
    {
        public int xOffset = 25;
        public int yOffset = 8;

        public void game_draw()
        {
            Console.Clear();
            Console.Title = "Snake";
            Console.SetWindowSize(101, 26);

            Walls walls = new Walls(101, 26);
            walls.Draw();

            SoundPlayer spd = new SoundPlayer("C:\\gamemus.wav");
            spd.Play();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            FoodCreator foodCreator = new FoodCreator(101, 26, '¤', ConsoleColor.Green);
            Point food = foodCreator.CreateFood();
            food.Draw();
            Score score = new Score(0, 1);//score =0, level=1
            score.speed = 135;
            score.ScoreWrite();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    score.ScoreUp();
                    score.ScoreWrite();
                    food = foodCreator.CreateFood();
                    food.Draw();              
                    if (score.ScoreUp())
                    {
                        score.speed -= 10;
                    }
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(score.speed);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }
        }


        static void WriteGameOver()
        {
            SoundPlayer spd = new SoundPlayer("C:\\gamemus.wav");
            spd.Stop();
            SoundPlayer sps = new SoundPlayer("C:\\smert.wav");
            sps.Play();
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("     G A M E  O V E R", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

        static void Main(string[] args)
        {
            Start start = new Start();
            if (start.choice() == 1)
            {
                Program prog = new Program();
                prog.game_draw();
            }
            else
            {
                start.Game_stop();
            }

            WriteGameOver();
            Console.ReadLine();

        }
    }
}
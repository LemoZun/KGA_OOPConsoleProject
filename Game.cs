using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{

    public class Game
    {
        public static int screenWidth = 40;
        private int screenHeight = 20;
        private bool isRunning = true;
        
        private int poopSpeed;
        private char[,] screen;
        private Player player;

        public Game()
        {
            screen = new char[screenWidth, screenHeight];
            player = new Player(screenWidth / 2);
        }

        public void Run()
        {
            Console.CursorVisible = false;


            Start();
            while (isRunning)
            {
                Render();
                Input();
                Update();
            }
            End();
        }

        public void Over()
        {
            isRunning = false;
        }


        private void Start()
        {

        }

        private void End()
        {
            Console.Clear();
            Console.WriteLine("게임 오버");
            return;
        }

        private void Render()
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    Console.Write(screen[x, y]);
                }
                Console.WriteLine();
            }
        }
        private void Input()
        {
            if (Console.KeyAvailable) // 키 입력이 있는 지 없는지
            {
                ConsoleKeyInfo key = Console.ReadKey(true); // ? 

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    player.MoveLeft();
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    player.MoveRight();
                }

            }


            //switch(key)
            //{
            //case :
            //    ConsoleKey.UpArrow:
            //        moveY++;
            //case :
            //    ConsoleKey.DownArrow
            //        moveY--;
            //case :
            //    ConsoleKey.LeftArrow
            //        moveX--;
            //case :
            //    ConsoleKey.RightArrow
            //        moveX++;
            //default:

            //}
        }

        private void Update()
        {

            for (int x = 0; x < screenWidth; x++)
            {
                //for //(int y = 0; y < screenHeight; y++) 이거아님 y좌표는 아래로 갈수록 깊어지는 구조
                for (int y = screenHeight - 1; y >0; // y를 내림차순으로 갱신하면 
                    y--)
                {
                    screen[x,y] = screen[x,y - 1];
                }
                screen[x, 0] = ' ';// null; null 안됨, 똥 생성할거니까 맨 위는 비워줘야함
            }




        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{

    public class Game
    {

        private bool isRunning = true;        
        // private int poopSpeed; poop에 구현 해야함
        private Player player;
        private Poop poop;
        private Screen screen;

        public Game()
        {
            screen = new Screen();
            player = new Player(screen.ScreenWidth/2);
            poop = new Poop();
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
            for (int y = 0; y < screen.ScreenHeight; y++)
            {
                for (int x = 0; x < screen.ScreenWidth; x++)
                {
                    Console.Write(screen.Map[x, y]);
                }
                Console.WriteLine();
            }
        }
        private void Input()
        {
            if (Console.KeyAvailable) // 키 입력이 있는 지 없는지
            {
                ConsoleKeyInfo key = Console.ReadKey(true); // 이러면 입력이 없어도 콘솔창이 계속 진행된다고 하는데 원리를 아직 잘 이해 못함

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    player.MoveLeft();
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    player.MoveRight(screen.ScreenWidth);
                }

            }
        }

        private void Update()
        {
            screen.UpdateScreen();
            poop.CreatePoop(screen.Map, screen.ScreenWidth);
            screen.Map[player.Position, screen.ScreenHeight - 1] = '㉯'; 
        }
    }
}

// 범위 넘어가면 터짐 범위 넘어가지 않게 추가 
// 게임 오버 추가
// 점수? 추가 
// 똥 속도와 개체 수 조절 해야함

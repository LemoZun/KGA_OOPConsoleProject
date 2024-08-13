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
                System.Threading.Thread.Sleep(50);                
            }
            End();
        }

        public void Over()
        {
            isRunning = false;            
        }


        private void Start()
        {
            Console.WriteLine("");
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("=                                  =");
            Console.WriteLine("=             운석 피하기          =");
            Console.WriteLine("=                                  =");
            Console.WriteLine("====================================");
            Console.WriteLine();
            Console.WriteLine("    계속하려면 아무키나 누르세요    ");
            Console.ReadKey();
            Console.Clear();
        }

        private void End()
        {
            Console.Clear();
            Console.WriteLine("게임 오버");
            return;
        }

        private void Render()
        {
            screen.PrintScreen();
        }
        private void Input()
        {
            player.PlayerInput(screen.ScreenWidth);
        }
        private void Update()
        {
            screen.Map[player.Position, screen.ScreenHeight - 1] = '㉯';
            //print player, print poop 으로 해보기

            poop.CreatePoop(screen.Map, screen.ScreenWidth);

            screen.UpdateScreen();

            screen.Map[player.Position, screen.ScreenHeight - 1] = '㉯'; // 다시 쓰면 플레이어의 위치는 나오지만 게임오버 안됨
            // 플레이어를 먼저 찍으면 스크린 업데이트 과정에서 플레이어가 사라짐
            

            CheckCollision();
        }
        public void CheckCollision()
        {
            for (int i = 0; i < screen.ScreenWidth; i++)
            {
                if (screen.Map[i, screen.ScreenHeight - 1] == '♨' && i == player.Position)
                {
                    Over();
                    break;
                }
            }
        }
    }
}

// 범위 넘어가면 터짐 범위 넘어가지 않게 추가  o
// 왜 시작하면 플레이어가 맨 왼쪽에 있다가 잠깐 뒤에 중간으로 오지?
// 똥이 피해가는 현상 발생? 정확히는 아래로 내려오다가 어느시점에서 오른쪽으로 감
// 게임 오버 추가
// 게임오버는 나오는데 플레이어가 안보임
// 점수? 추가 
// 똥 속도와 개체 수 조절 해야함

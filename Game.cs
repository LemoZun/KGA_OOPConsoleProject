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
        private Score score;
        private Collision collision;
        
        

        public Game()
        {
            screen = new Screen();
            // player = new Player(screen.ScreenWidth/2); // 화면 중앙에서 시작하게 하고싶은데 
            // 처음에 position 0 위치에서 시작해서 갑자기 가운데로 옴.. 왜?
            player = new Player(0); // 일단 그냥 0번 인덱스에서 시작하도록 함
            poop = new Poop();
            score = new Score();
            collision = new Collision();
            collision.DetectedCollision += Over;
        }

        public void Run()
        {
            Console.CursorVisible = false;


            Start();
            Console.Clear();
            //Render();

            while (isRunning)
            {

                Render();
                Input();                
                Update();
                
                System.Threading.Thread.Sleep(100);                
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
            Console.WriteLine("왼쪽 오른쪽 방향키를 사용해 피하세요.    ");
            // Console.WriteLine("   계속하려면 아무키나 누르세요    ");
            poop.SelectDifficulty();
            // Console.ReadKey();
            Console.Clear();
        }

        private void End()
        {
            Console.Clear();
            Console.WriteLine($"획득한 점수 : {score.Point} 점");
            Console.WriteLine("게임 오버");
            return;
        }

        private void Render()
        {
            //screen.ClearScreen();
            screen.UpdateScreen();   // 빼면  플레이어가 진동함         
            score.Point = screen.PrintScreen(player);
            // screen.PrintPlayer(player);
            poop.CreatePoop(screen.Map, screen.ScreenWidth);
        }
        private void Input()
        {
            player.PlayerInput(screen.ScreenWidth);
        }
        private void Update()
        {
            //screen.PrintPlayer(player);

            //poop.CreatePoop(screen.Map, screen.ScreenWidth);   
            screen.UpdateScreen();
            //score.FlowTimePoint();
            //if (collision.CheckCollision(player, screen,poop))
            //{
            //    Over();
            //}
            collision.CheckCollision(player, screen, poop);
        }

        // private void HappenCollision
    }
}

// 범위 넘어가면 터짐 범위 넘어가지 않게 추가  o
// 왜 시작하면 플레이어가 맨 왼쪽에 있다가 잠깐 뒤에 중간으로 오지? // 
// 똥이 피해가는 현상 발생? 정확히는 아래로 내려오다가 어느시점에서 오른쪽으로 감 // 해결..됐나?
// 플레이어도 계속 와리가리 거림 (기존 위치를 clear하지 않아서 발생. 해결함)
// 게임 오버 추가 (해결)
// 게임오버는 나오는데 플레이어가 실존하지만 실제론 안보임 (해결)
// 점수? 추가 (해결)
// 똥 개체 수 조절 해야함 (난이도 추가)

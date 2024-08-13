using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Screen
    {
        private int screenWidth = 40;
        public int ScreenWidth { get { return screenWidth; } }
        private int screenHeight = 20;
        public int ScreenHeight { get { return screenHeight; } }

        private char[,] map;
        public char[,] Map { get { return map; } set { map = value; } }

        private int temp;
        public int Temp { get { return temp; } set { temp = value; } }

        public Screen()
        {
            map = new char[screenWidth, screenHeight];
        }

        public void UpdateScreen()
        {
            for(int i = 0; i < screenWidth; i++)
            {
                //for //(int y = 0; y < screenHeight; y++) 이거아님 y좌표는 아래로 갈수록 깊어지는 구조
                for (int j = screenHeight-1; j > 0; j--) // y를 내림차순으로 갱신하면
                {
                    // if(map[i,j] != '㉯') //이러면 증식함
                    // if(_player.Position != i && j != screenHeight-1) 이것도 아님
                    
                        map[i, j] = map[i, j - 1];
                    
                    
                }
                map[i, 0] = ' '; // null; null 안됨, 똥 생성할거니까 맨 위는 비워줘야함
            }
        }
    }
}

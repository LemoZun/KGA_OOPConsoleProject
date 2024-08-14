namespace KGA_OOPConsoleProject
{
    public class Screen
    {
        private int screenWidth = Define.ScreenWidth;
        public int ScreenWidth { get { return screenWidth; } }

        private int screenHeight = Define.ScreenHeight;
        public int ScreenHeight { get { return screenHeight; } }

        private char[,] map;
        public char[,] Map { get { return map; } set { map = value; } }

        

        public Screen()
        {
            map = new char[ScreenWidth, screenHeight];
        }

        public void ClearScreen() // 스크린 초기화용
        {
            for(int i = 0; i < screenWidth; i++)
            {
                for(int j = 0; j < screenHeight; j++)
                {
                    map[i, j] = ' ';
                }
            }
        }

        public void UpdateScreen() // 화면의 오브젝트들을 맨 아래줄(인덱스상으론 제일 높은 j)을 제외한
                                    // 나머지 줄을 한칸씩 내려주고 맨 위줄(인덱스상으론 제일 낮은)은 운석을 생성해야하므로 비워줌
        {
            for (int i = 0; i < screenWidth; i++)
            {
                //for //(int y = 0; y < screenHeight; y++) 이거아님 y좌표는 아래로 갈수록 깊어지는 구조
                for (int j = screenHeight - 1; j > 0; j--) // y를 내림차순으로 갱신하면
                {
                    // if(map[i,j] != '㉯') //이러면 증식함
                    // if(_player.Position != i && j != screenHeight-1) 이것도 아님

                    map[i, j] = map[i, j - 1];


                }
                map[i, 0] = ' '; // null; null 안됨, 똥 생성할거니까 맨 위는 비워줘야함
            }
        }
        public void PrintScreen(Player player) // 스크린 출력
        {
            Console.SetCursorPosition(0, 0); // 없으면 여러개가 계속 출력됨
            PrintPlayer(player);
            for (int y = 0; y < screenHeight; y++)
            {
                for (int x = 0; x < screenWidth; x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("0000000001000000000100000000010000000001");
        }


        private int beforePosition = Define.ScreenWidth/2;
        public void PrintPlayer(Player player)
        {
            
            //if(beforePosition != 0)
            //{
            //    map[player.Position, screenHeight - 1] = ' ';
            //}
            map[beforePosition, screenHeight - 1] = ' ';
            map[player.Position, screenHeight - 1] = '㉯';
            beforePosition = player.Position;
        }

    }
}

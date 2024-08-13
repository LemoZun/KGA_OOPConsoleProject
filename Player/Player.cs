using System.Numerics;

namespace KGA_OOPConsoleProject
{

    public class Player
    {
        private int position;
        public int Position { get { return position; } }

        public Player(int position)
        {
            this.position = position;
        }

        public void PlayerInput(int screenWidth)
        {
            if (Console.KeyAvailable) // 키 입력이 있는 지 없는지 // 키 입력이 가능하면 true 불가능하면 false?
            {
                ConsoleKeyInfo key = Console.ReadKey(true); // 이러면 입력이 없어도 콘솔창이 계속 진행된다고 하는데 원리를 아직 잘 이해 못함

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    MoveLeft();
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    MoveRight(screenWidth);
                }
            } 
        }

        // 맵 끝이면 못가는것도 해야함
        public void MoveLeft()
        {
            if (Position > 0) position--;
        }

        public void MoveRight(int _screenWidth)
        {
            if (Position < _screenWidth-1) position++; // 스크린 클래스도 만들어야겠다 
        }

    }
}

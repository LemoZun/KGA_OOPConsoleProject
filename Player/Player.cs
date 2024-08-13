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

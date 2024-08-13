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

        public void MoveRight()
        {
            position++;
            
        }






    }




}

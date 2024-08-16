using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    
    public class Collision
    {
        public event Action DetectedCollision;
        
        public void CheckCollision(Player player, Screen screen, Poop poop)
        {
            for (int i = 0; i < screen.ScreenWidth; i++)
            {
                if (i == player.Position && screen.Map[i, screen.ScreenHeight - 1] == poop.PoopShape)
                {    
                    //return true; //이벤트가 아니었을때
                    DetectedCollision?.Invoke();
                }
            }
            //return false;
        }
    }
}

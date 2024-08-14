using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public static class Collision
    {
        //굳이 충돌체크 메서드를 두려고 충돌크래스를 구현하는게 더 복잡해지는거같은데
        public static bool CheckCollision(Player player, Screen screen)
        {
            for (int i = 0; i < screen.ScreenWidth; i++)
            {
                if (i == player.Position && screen.Map[i, screen.ScreenHeight - 1] == '㉧')
                {   //♨ 
                    return true;
                }
                
            }
            return false;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Poop
    {
        static public void CreatePoop(char[,] _screen, int _screenWidth)
        {
            int poopDensityControl;
            Random rand = new Random();
            poopDensityControl= rand.Next(0, 100);
            if (poopDensityControl > 30)
            {
                _screen[rand.Next(0, _screenWidth), 0] = '♨'; // 똥생성
            }

        }
       
    }
}

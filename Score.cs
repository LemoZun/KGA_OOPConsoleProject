using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace KGA_OOPConsoleProject
{
    public class Score
    {
        private int point;
        public int  Point { get { return point; } private set { point = value; } }
        public DateTime birthTime;
        public const int pointPerSecond = 100;

        public Score()
        {
            Point = 0;
            birthTime = DateTime.Now; // 처음 생성됐을때 시간을 저장
        }
        
        public void FlowTimePoint()
        {
            TimeSpan currentTime = DateTime.Now - birthTime; //현재 시간과 게임을 처음 시작했을때의 시간의 차
            Point = (int)(currentTime.TotalSeconds * 100)/100;
            Console.WriteLine($"{Point*100}점");
        }
        public void GainPoint()
        {
            
            point += 10;
        }
    }
}

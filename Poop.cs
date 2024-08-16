using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGA_OOPConsoleProject
{
    public class Poop
    {
        private char poopShape = '㉧';
        public char PoopShape
        {  get { return poopShape; } private set { poopShape = value; } }

        private int difficultyLevel;
        public int DifficultyLevel { get { return difficultyLevel; } private set { difficultyLevel = value; } }

        public void SelectDifficulty() 
        {
            bool progress = false;
            while(!progress)
            {
                Console.WriteLine(" 난이도를 1~9 까지 중 정해주세요   ");
                bool toDetermine = int.TryParse(Console.ReadLine(), out int temp); // 게터 세터 프로퍼티는 out 으로 전달 불가 (왜?)   // ref도 안되네 //
                                                                                   //사실 그냥 difficultyLevel 써도 되긴 함
                DifficultyLevel = temp; 
                if(toDetermine == false || DifficultyLevel <= 0 ||  DifficultyLevel > 9)
                {
                    Console.WriteLine("1~9 까지의 난이도를 입력해주세요.");
                    Console.Clear();
                    
                }
                else progress = true;
            }            
        }

        public void CreatePoop(char[,] _screen, int _screenWidth)
        {
            int poopDensityControl;
            Random rand = new Random();
            
            poopDensityControl = rand.Next(0, 11);
            if (poopDensityControl < DifficultyLevel) // 똥 생성 확률 
            {
                _screen[rand.Next(0, _screenWidth), 0] = poopShape; // 똥생성
            }

        }
       
    }
}

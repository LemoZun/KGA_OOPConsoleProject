namespace KGA_OOPConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Score score = new Score();
            //while (true)
            //{
            //    score.FlowTimePoint();
            //    System.Threading.Thread.Sleep(1000);

            //}
            //Console.WriteLine("♨");
            Game game = new Game();
            game.Run();
        }
    }
}

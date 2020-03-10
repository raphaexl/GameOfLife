using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Life life;

            life = new Life();
            life.Run();
        }
    }
}

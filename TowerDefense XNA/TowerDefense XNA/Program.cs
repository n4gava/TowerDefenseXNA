using System;

namespace TowerDefense_XNA
{
#if WINDOWS || XBOX
    static class Program
    {
        static void Main(string[] args)
        {
            using (TowerDefenseXNA game = new TowerDefenseXNA())
            {
                game.Run();
            }
        }
    }
#endif
}


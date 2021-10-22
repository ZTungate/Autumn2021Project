using System;

namespace LevelCreator
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new LevelCreator())
                game.Run();
        }
    }
}

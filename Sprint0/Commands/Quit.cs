using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class Quit : ICommand
    {
        private Game1 myGame;

        public Quit(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.quit();
        }
    }
}

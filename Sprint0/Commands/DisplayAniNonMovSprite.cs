using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class DisplayAniNonMovSprite : ICommand
    {
        private Game1 myGame;

        public DisplayAniNonMovSprite(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.sprite = new AnimatedStillSprite(myGame);

        }
    }
}

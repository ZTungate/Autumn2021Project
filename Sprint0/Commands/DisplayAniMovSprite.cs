using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class DisplayAniMovSprite : ICommand
    {
        private Game1 myGame;

        public DisplayAniMovSprite(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.sprite = new AnimatedMovingSprite(myGame);
        }
    }
}

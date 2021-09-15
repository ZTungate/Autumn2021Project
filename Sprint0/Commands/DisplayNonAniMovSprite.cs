using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class DisplayNonAniMovSprite : ICommand
    {
        private Game1 myGame;

        public DisplayNonAniMovSprite(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.sprite = new NonAnimatedMovingSprite(myGame);
        }
    }
}

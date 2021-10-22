using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprint3
{
    class DisplayNonAniNonMovSprite : ICommand
    {
        private Game1 myGame;

        public DisplayNonAniNonMovSprite (Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {

            myGame.sprite = new NonAnimatedStillSprite(myGame);


        }
    }
}

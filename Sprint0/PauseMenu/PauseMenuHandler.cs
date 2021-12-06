using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.PauseMenu
{
    public class PauseMenuHandler
    {

        private Game1 game;
        float volume;
        Boolean[] cursor;
        Boolean options = false;
        public PauseMenuHandler(Game1 game)
        {
            cursor[0] = true;
            this.game = game;
            volume = game.soundManager.volume;
        }

        public void increaseVolume()
        {
            if(volume < 1)
            {
                volume += 0.2f;
            }
        }
        public void decreaseVolume()
        {
            if (volume > 0)
            {
                volume -= 0.2f;
            }
        }
        public void toogleOptions()
        {
            options = !options;
        }

        public void Draw(SpriteBatch batch)
        {

        }
    }
}

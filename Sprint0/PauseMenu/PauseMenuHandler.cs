using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.PauseMenu
{
    public class PauseMenuHandler
    {
        private static float VOLSCALE = 0.2f;
        private static float VOLFULL = 1f;
        private static float VOLOFF = 1f;
        private Game1 game;
        float volume;
        Boolean[] cursor = new Boolean[3];
        Boolean options = false;
        public PauseMenuHandler(Game1 game)
        {
            cursor[0] = true;
            this.game = game;
            volume = game.soundManager.volume;
        }

        public void increaseVolume()
        {
            if(volume < VOLFULL)
            {
                volume += VOLSCALE;
            }
        }
        public void decreaseVolume()
        {
            if (volume > VOLOFF)
            {
                volume -= VOLSCALE;
            }
        }
        public void toogleOptions()
        {
            options = !options;
        }

        public void Draw(SpriteBatch batch)
        {
            if (game.Paused())
            {
                if (options)
                {
                    
                }
                else
                {

                }
            }
        }
    }
}

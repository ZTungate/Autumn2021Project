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
        public PauseMenuHandler(Game1 game)
        {
            cursor[0] = true;
            this.game = game;
            volume = game.soundManager.volume;
        }
    }
}

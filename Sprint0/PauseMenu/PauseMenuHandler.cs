using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.PauseMenu
{
    public class PauseMenuHandler
    {

        private Game1 game;
        float volume;
        public PauseMenuHandler(Game1 game)
        {
            this.game = game;
            volume = game.soundManager.volume;
        }
    }
}

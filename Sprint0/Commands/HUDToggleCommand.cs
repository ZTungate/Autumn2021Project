using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Commands
{
    class HUDToggleCommand : ICommand
    {
        Game1 game;
        public HUDToggleCommand(Game1 game1)
        {
            this.game = game1;
        }
        public void Execute()
        {
            game.inventoryOpen = !game.inventoryOpen;
            game.hudHandler.ToggleFullscreen();
            game.togglePause();
        }
    }
}

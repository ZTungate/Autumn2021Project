using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Commands
{
    class InventoryLeftCommand : ICommand
    {
        Game1 game;
        public InventoryLeftCommand(Game1 game1)
        {
            this.game = game1;
        }
        public void Execute()
        {
            game.hudHandler.moveCursorLeft();
        }
    }
}

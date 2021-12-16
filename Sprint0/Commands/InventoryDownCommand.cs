using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Commands
{
    class InventoryDownCommand : ICommand
    {
        Game1 game;
        public InventoryDownCommand(Game1 game1)
        {
            this.game = game1;
        }
        public void Execute()
        {
            game.hudHandler.moveCursorDown();
        }
    }
}

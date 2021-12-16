using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Commands
{
    class InventoryRightCommand : ICommand
    {
        Game1 game;
        public InventoryRightCommand(Game1 game1)
        {
            this.game = game1;
        }
        public void Execute()
        {
            game.hudHandler.moveCursorRight();
        }
    }
}

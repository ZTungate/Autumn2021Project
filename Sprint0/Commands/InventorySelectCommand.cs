using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Commands
{
    class InventorySelectCommand : ICommand
    {
        Game1 game;
        public InventorySelectCommand(Game1 game1)
        {
            this.game = game1;
        }
        public void Execute()
        {
            if (game.link.LinkInventory.GetItemList().Count > 1) {
                game.hudHandler.selectItem();
            }
        }
    }
}

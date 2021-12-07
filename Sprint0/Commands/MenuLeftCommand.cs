using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Commands
{
    class MenuLeftCommand : ICommand
    {
        Game1 game;
        public MenuLeftCommand(Game1 game1)
        {
            this.game = game1;
        }
        public void Execute()
        {
            if (game.Paused() && !game.inventoryOpen)
            {
                if (game.menuHandler.options)
                {
                    if (!game.menuHandler.optionCursor)
                    {
                        game.menuHandler.decreaseVolume();
                    }
                    else
                    {
                        game.menuHandler.decreaseDifficulty();
                    }
                }
            }
        }
    }
}

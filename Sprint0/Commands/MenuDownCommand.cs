using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Commands
{
    class MenuDownCommand : ICommand
    {
        Game1 game;
        public MenuDownCommand(Game1 game1)
        {
            this.game = game1;
        }
        public void Execute()
        {
            if (game.Paused())
            {
                if (game.menuHandler.options)
                {
                    game.menuHandler.selectNextOptions();
                }
                else
                {
                    game.menuHandler.selectNext();
                }
            }

        }
    }
}

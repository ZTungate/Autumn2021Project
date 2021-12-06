using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Commands
{
    class MenuUpCommand : ICommand
    {
        Game1 game;
        public MenuUpCommand(Game1 game1)
        {
            this.game = game1;
        }
        public void Execute()
        {
            if (game.Paused())
            {
                if (game.menuHandler.options)
                {
                    
                }
                else
                {
                    game.menuHandler.selectNext();
                }
            }
        }
    }
}

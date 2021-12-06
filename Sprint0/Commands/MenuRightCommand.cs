using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Commands
{
    class MenuRightCommand : ICommand
    {
        Game1 game;
        public MenuRightCommand(Game1 game1)
        {
            this.game = game1;
        }
        public void Execute()
        {

        }
    }
}

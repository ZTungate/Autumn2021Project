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

        }
    }
}

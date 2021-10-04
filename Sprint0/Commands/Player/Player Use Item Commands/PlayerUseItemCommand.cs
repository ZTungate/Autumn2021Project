using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerUseItemCommand : ICommand
    {
        private Game1 game;
        public PlayerUseItemCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {


            game.link.state.useItem(game);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Sprint3.Helpers;
using Sprint3.Player;

namespace Sprint3.Commands
{
    public class PlayerRightIdleCommand : ICommand
    {
        private Game1 game;
        public PlayerRightIdleCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.link.state = new RightIdleLinkState(game.link, game.link.sprite);
        }
    }
}

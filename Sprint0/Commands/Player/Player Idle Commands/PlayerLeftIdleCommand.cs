using System;
using System.Collections.Generic;
using System.Text;
using Sprint3.Helpers;
using Sprint3.Player;

namespace Sprint3.Commands
{
    public class PlayerLeftIdleCommand : ICommand
    {
        private Game1 game;
        public PlayerLeftIdleCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.link.state = new LeftIdleLinkState(game.link, game.link.sprite);
        }
    }
}

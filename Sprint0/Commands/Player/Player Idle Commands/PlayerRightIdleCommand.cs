using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
using Poggus.Player;

namespace Poggus.Commands
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
            game.link.State.Idle();
        }
    }
}

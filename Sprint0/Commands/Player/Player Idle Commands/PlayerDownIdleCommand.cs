using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
using Poggus.Player;

namespace Poggus.Commands
{
    public class PlayerDownIdleCommand : ICommand
    {
        private Game1 game;
        public PlayerDownIdleCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.link.State.Idle();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
using Poggus.Player;

namespace Poggus.Commands
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
            game.link.State.Idle();
        }
    }
}

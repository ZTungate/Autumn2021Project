using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;

namespace Poggus.Commands
{
    public class PlayerUpMoveCommand : ICommand
    {
        private Game1 game;
        public PlayerUpMoveCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //Call on link's state to move up.
            game.link.State.Move(Player.Direction.up);
        }
    }
}

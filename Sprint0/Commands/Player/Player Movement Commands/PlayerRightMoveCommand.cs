using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;

namespace Poggus.Commands
{
    public class PlayerRightMoveCommand : ICommand
    {
        private Game1 game;
        public PlayerRightMoveCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //Have link's current state move right.
            game.link.State.Move(Player.Direction.right);
        }
    }
}

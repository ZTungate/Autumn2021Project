using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;

namespace Poggus.Commands
{
    public class PlayerLeftMoveCommand : ICommand
    {
        private Game1 game;
        public PlayerLeftMoveCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //Have link's current state move left
            game.link.State.Move(Player.Direction.left);
        }
    }
}

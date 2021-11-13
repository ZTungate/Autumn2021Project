using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;

namespace Poggus.Commands
{
    public class PlayerDownMoveCommand : ICommand
    {
        private Game1 game;
        public PlayerDownMoveCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //Have link's current state move down.
            game.link.State.Move(Player.Direction.down);
        }
    }
}

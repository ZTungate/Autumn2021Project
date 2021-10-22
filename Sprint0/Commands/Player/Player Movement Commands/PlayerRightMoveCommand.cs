using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
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
            game.link.state.Move(Player.direction.right);
        }
    }
}

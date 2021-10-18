using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
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
            game.link.state.Move(Player.direction.left);
        }
    }
}

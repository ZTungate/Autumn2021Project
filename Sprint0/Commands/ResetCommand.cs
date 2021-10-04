using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;
namespace Sprint2.Commands
{
    public class ResetCommand : ICommand
    {
        private Game1 game;
        public ResetCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.reset();
        }
    }
}

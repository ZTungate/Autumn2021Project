using System;
using System.Collections.Generic;
using System.Text;
using Sprint3.Helpers;
namespace Sprint3.Commands
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
            game.Reset();
        }
    }
}

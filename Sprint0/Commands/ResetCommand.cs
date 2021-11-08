using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
namespace Poggus.Commands
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

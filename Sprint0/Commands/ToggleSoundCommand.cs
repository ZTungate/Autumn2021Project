
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
namespace Poggus.Commands
{
    public class ToggleSoundCommand : ICommand
    {
        private Game1 game;
        public ToggleSoundCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.toggleSound();
        }
    }
}

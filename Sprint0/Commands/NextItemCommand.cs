using System;
using System.Collections.Generic;
using System.Text;
using Sprint3.Helpers;

namespace Sprint3.Commands
{
    public class NextItemCommand : ICommand
    {
        private Game1 game;
        public NextItemCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currentItem = CustomMath.MathMod(this.game.currentItem + 1, this.game.items.Count);
        }
    }
}

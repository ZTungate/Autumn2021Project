using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;
namespace Sprint2.Commands
{
    public class PreviousItemCommand : ICommand
    {
        private Game1 game;
        public PreviousItemCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currentItem = CustomMath.MathMod(this.game.currentItem - 1, this.game.items.Count);
        }
    }
}

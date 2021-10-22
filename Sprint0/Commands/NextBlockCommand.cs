using System;
using System.Collections.Generic;
using System.Text;
using Sprint3.Helpers;
namespace Sprint3.Commands
{
    public class NextBlockCommand : ICommand
    {
        private Game1 game;
        public NextBlockCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currentBlock = game.blockSpriteFactory.NextSprite();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;
namespace Sprint2.Commands
{
    public class PreviousBlockCommand : ICommand
    {
        private Game1 game;
        public PreviousBlockCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.currentBlock = game.blockSpriteFactory.PreviousSprite();
        }
    }
}

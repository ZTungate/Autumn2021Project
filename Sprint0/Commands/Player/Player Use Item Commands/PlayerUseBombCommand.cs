﻿using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerUseBombCommand : ICommand
    {
        private Game1 game;
        public PlayerUseBombCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {


            game.link.BombAttack();
            
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerUpMoveCommand : ICommand
    {
        private Game1 game;
        public PlayerUpMoveCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //Call on link's state to move up.
            game.link.state.Move(Player.direction.up);
        }
    }
}

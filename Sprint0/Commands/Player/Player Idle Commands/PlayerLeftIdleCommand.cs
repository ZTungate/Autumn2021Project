﻿using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;
using Sprint2.Player;

namespace Sprint2.Commands
{
    public class PlayerLeftIdleCommand : ICommand
    {
        private Game1 game;
        public PlayerLeftIdleCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.link.state = new LeftIdleLinkState(game.link, game.link.sprite);
        }
    }
}

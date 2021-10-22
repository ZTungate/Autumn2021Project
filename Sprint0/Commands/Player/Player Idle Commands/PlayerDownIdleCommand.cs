﻿using System;
using System.Collections.Generic;
using System.Text;
using Sprint3.Helpers;
using Sprint3.Player;

namespace Sprint3.Commands
{
    public class PlayerDownIdleCommand : ICommand
    {
        private Game1 game;
        public PlayerDownIdleCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.link.state = new DownIdleLinkState(game.link, game.link.sprite);
        }
    }
}

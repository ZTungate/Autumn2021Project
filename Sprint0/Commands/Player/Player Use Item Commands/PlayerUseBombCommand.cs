﻿using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;
using Sprint2.Player;
using static Sprint0.Projectiles.ProjectileConstants;

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
            //Call useItem on link's current state.
            game.link.UseItem(ProjectileTypes.bomb);
        }
    }
}

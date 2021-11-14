using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
using Poggus.Player;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Commands
{
    public class PlayerUseRegBoomerangCommand : ICommand
    {
        private Game1 game;
        public PlayerUseRegBoomerangCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //Call useItem on link's current state.
            game.link.UseItem(ProjectileTypes.linkBoomerang);
        }
    }
}

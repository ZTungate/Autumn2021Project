using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
using Poggus.Player;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Commands
{
    public class PlayerUseBlueArrowCommand : ICommand
    {
        private Game1 game;
        public PlayerUseBlueArrowCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //Call useItem on link's current state.
            if (game.link.LinkInventory.GetRupeeCount() > 0)
            {
                game.link.UseItem(ProjectileTypes.blueArrow);
                game.link.LinkInventory.DecrementRupees();
            }
        }
    }
}

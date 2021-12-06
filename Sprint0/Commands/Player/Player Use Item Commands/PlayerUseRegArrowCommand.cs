using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
using Poggus.Player;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Commands
{
    public class PlayerUseRegArrowCommand : ICommand
    {
        private Game1 game;
        public PlayerUseRegArrowCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //Call useItem on link's current state.
            if (game.link.LinkInventory.GetRupeeCount() > 0)
            {
                game.link.UseItem(ProjectileTypes.redArrow);
                game.link.LinkInventory.DecrementRupees();
            }
        }
    }
}

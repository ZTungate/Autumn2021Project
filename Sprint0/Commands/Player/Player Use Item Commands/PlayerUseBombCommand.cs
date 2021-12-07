using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
using Poggus.Player;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Commands
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
            if (game.link.LinkInventory.GetBombCount() > 0)
            {
                game.link.UseItem(ProjectileTypes.bomb);
                game.link.LinkInventory.DecrementBombs();
            }
        }
    }
}

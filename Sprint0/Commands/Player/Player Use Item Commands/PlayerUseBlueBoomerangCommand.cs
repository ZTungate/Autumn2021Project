using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;
using Sprint2.Player;

namespace Sprint2.Commands
{
    public class PlayerUseBlueBoomerangCommand : ICommand
    {
        private Game1 game;
        public PlayerUseBlueBoomerangCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            //Call useItem on link's current state.
            game.link.state.UseItem();

            //Call the link's attack method to spawn the projectile.
            game.link.BlueBoomerangAttack();
        }
    }
}

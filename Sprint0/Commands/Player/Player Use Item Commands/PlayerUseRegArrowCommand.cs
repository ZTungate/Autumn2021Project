using System;
using System.Collections.Generic;
using System.Text;
using Sprint3.Helpers;
using Sprint3.Player;

namespace Sprint3.Commands
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
            game.link.state.UseItem();

            //Call the link's attack method to spawn the projectile.
            game.link.RegArrowAttack();
        }
    }
}

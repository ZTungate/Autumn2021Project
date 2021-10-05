using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

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


            game.link.BlueBoomerangAttack();
            
        }
    }
}

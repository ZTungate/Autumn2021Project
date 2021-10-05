using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
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


            game.link.BlueArrowAttack();
            
        }
    }
}

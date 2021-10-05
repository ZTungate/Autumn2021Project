using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerUseFireCommand : ICommand
    {
        private Game1 game;
        public PlayerUseFireCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {


            game.link.FireAttack();
            
        }
    }
}

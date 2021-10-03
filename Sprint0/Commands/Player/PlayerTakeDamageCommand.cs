using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerTakeDamageCommand: ICommand
    {
        private Game1 game;
        public PlayerTakeDamageCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.link.takeDamage();
            /*game.link.state = new RightIdleLinkState();*/
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Sprint3.Helpers;
using Sprint3.Player;

namespace Sprint3.Commands
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
/*            game.link = new DamagedLink(game.link, game);*/ //Decorator for taking damage (State design pattern)
            /*game.link.state = new RightIdleLinkState();*/
        }
    }
}

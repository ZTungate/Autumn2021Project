using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;
using Poggus.Player;

namespace Poggus.Commands
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
            //Dummy damage
            game.link.TakeDamage(1, Collisions.ColDirections.None);
/*            game.link = new DamagedLink(game.link, game);*/ //Decorator for taking damage (State design pattern)
            /*game.link.state = new RightIdleLinkState();*/
        }
    }
}

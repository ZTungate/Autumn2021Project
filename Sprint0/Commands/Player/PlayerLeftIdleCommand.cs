using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerLeftIdleCommand : ICommand
    {
        private Game1 game;
        public PlayerLeftIdleCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.link.sprite = game.linkSpriteFactory.LeftIdleLinkSprite(game.link);
            /*game.link.state = new RightIdleLinkState();*/
        }
    }
}

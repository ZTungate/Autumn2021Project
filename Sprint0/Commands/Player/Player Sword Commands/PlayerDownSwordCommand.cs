using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerDownSwordCommand : ICommand
    {
        private Game1 game;
        public PlayerDownSwordCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            /*if (game.link.canMove)
            {*/
                game.link.sprite = game.linkSpriteFactory.DownSwordLinkSprite(game.link);
                /*game.link.state = new RightMovingLinkState();*/
            /*}*/
        }
    }
}

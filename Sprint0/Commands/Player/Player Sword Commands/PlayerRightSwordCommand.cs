using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerRightSwordCommand : ICommand
    {
        private Game1 game;
        public PlayerRightSwordCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            /*if (game.link.canMove)
            {*/
                game.link.sprite = game.linkSpriteFactory.RightSwordLinkSprite(game.link);
                /*game.link.state = new RightMovingLinkState();*/
            /*}*/
        }
    }
}

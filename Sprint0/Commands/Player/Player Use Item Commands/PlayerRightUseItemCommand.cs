using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerRightUseItemCommand : ICommand
    {
        private Game1 game;
        public PlayerRightUseItemCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            game.link.sprite = game.linkSpriteFactory.RightUseItemLinkSprite(game.link);
            /*game.link.state = new RightMovingLinkState();*/
        }
    }
}

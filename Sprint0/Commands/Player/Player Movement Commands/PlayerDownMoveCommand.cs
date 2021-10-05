using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerDownMoveCommand : ICommand
    {
        private Game1 game;
        public PlayerDownMoveCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            /*if (game.link.canMove)
            {*/
            game.link.facing = Player.direction.down;
            game.link.sprite = game.linkSpriteFactory.DownMovingLinkSprite(game.link);
                /*game.link.state = new RightMovingLinkState();*/
            /*}*/
        }
    }
}

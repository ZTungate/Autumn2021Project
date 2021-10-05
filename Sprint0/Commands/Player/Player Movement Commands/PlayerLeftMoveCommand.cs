using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerLeftMoveCommand : ICommand
    {
        private Game1 game;
        public PlayerLeftMoveCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            /*if (game.link.canMove)
            {*/
            game.link.facing = Player.direction.left;

            game.link.sprite = game.linkSpriteFactory.LeftMovingLinkSprite(game.link);
                /*game.link.state = new RightMovingLinkState();*/
            /*}*/
        }
    }
}

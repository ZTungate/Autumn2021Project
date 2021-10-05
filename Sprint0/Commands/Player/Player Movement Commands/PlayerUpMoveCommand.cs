using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerUpMoveCommand : ICommand
    {
        private Game1 game;
        public PlayerUpMoveCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {
            /*if (game.link.canMove)
            {*/
            game.link.facing = Player.direction.up;

            game.link.sprite = game.linkSpriteFactory.UpMovingLinkSprite(game.link);
                /*game.link.state = new RightMovingLinkState();*/
            /*}*/
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerSwordCommand : ICommand
    {
        private Game1 game;
        public PlayerSwordCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {

            switch (game.link.facing) {
                case Player.direction.up:
                    game.link.sprite = game.linkSpriteFactory.UpSwordLinkSprite(game.link);

                    break;
                case Player.direction.down:
                    game.link.sprite = game.linkSpriteFactory.DownSwordLinkSprite(game.link);

                    break;
                case Player.direction.left:
                    game.link.sprite = game.linkSpriteFactory.LeftSwordLinkSprite(game.link);

                    break;
                case Player.direction.right:
                    game.link.sprite = game.linkSpriteFactory.RightSwordLinkSprite(game.link);

                    break;
                default:
                    break;
            }
        }
    }
}

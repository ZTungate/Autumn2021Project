using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;
using Sprint2.Player;

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
                    //                    game.link.sprite = game.linkSpriteFactory.UpSwordLinkSprite(game.link);
                    game.link.state = new UpSwordLinkState(game.link,game.link.sprite);
                    break;
                case Player.direction.down:
                    //game.link.sprite = game.linkSpriteFactory.DownSwordLinkSprite(game.link);
                    game.link.state = new DownSwordLinkState(game.link, game.link.sprite);
                    break;
                case Player.direction.left:
                    //game.link.sprite = game.linkSpriteFactory.LeftSwordLinkSprite(game.link);
                    game.link.state = new LeftSwordLinkState(game.link, game.link.sprite);
                    break;
                case Player.direction.right:
                    //game.link.sprite = game.linkSpriteFactory.RightSwordLinkSprite(game.link);
                    game.link.state = new RightSwordLinkState(game.link, game.link.sprite);
                    break;
                default:
                    break;
            }
        }
    }
}

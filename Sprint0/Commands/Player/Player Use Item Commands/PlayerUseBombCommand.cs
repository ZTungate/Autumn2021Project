using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Commands
{
    public class PlayerUseBombCommand : ICommand
    {
        private Game1 game;
        public PlayerUseBombCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {

            switch (game.link.facing) {
                case Player.direction.up:
                    game.link.sprite = game.linkSpriteFactory.UpUseItemLinkSprite(game.link);

                    break;
                case Player.direction.down:
                    game.link.sprite = game.linkSpriteFactory.DownUseItemLinkSprite(game.link);

                    break;
                case Player.direction.left:
                    game.link.sprite = game.linkSpriteFactory.LeftUseItemLinkSprite(game.link);

                    break;
                case Player.direction.right:
                    game.link.sprite = game.linkSpriteFactory.RightUseItemLinkSprite(game.link);

                    break;
                default:
                    break;
            }
            game.link.BombAttack();
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;
using Sprint2.Player;

namespace Sprint2.Commands
{
    public class PlayerUseBlueBoomerangCommand : ICommand
    {
        private Game1 game;
        public PlayerUseBlueBoomerangCommand(Game1 game)
        {
            this.game = game;
        }
        public void Execute()
        {

            switch (game.link.facing)
            {
                //Set link's state to the relevant item using state for current player direction.
                case Player.direction.up:
                    game.link.state = new UpItemUsingLinkState(game.link, game.link.sprite);

                    break;
                case Player.direction.down:
                    game.link.state = new DownItemUsingLinkState(game.link, game.link.sprite);

                    break;
                case Player.direction.left:
                    game.link.state = new LeftItemUsingLinkState(game.link, game.link.sprite);

                    break;
                case Player.direction.right:
                    game.link.state = new RightItemUsingLinkState(game.link, game.link.sprite);

                    break;
                default:
                    //Should never occur, link is always facing one of the four directions.
                    break;
            }
            game.link.BlueBoomerangAttack();

        }
    }
}

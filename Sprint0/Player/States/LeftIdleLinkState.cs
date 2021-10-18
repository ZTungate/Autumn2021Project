using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
    public class LeftIdleLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;
        public LeftIdleLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new LeftIdleLinkSprite(sprite.Texture, link);
            link.sprite = mySprite;
        }

        public void takeDamage()
        {
            //Call on link to take damage. Does this need to be here? Might not be necesary in the state itself.
            link.takeDamage();
        }

        public void Update(GameTime gameTime)
        {
            //Nothing needs updated in an idle state?
        }

        public void useItem(Game1 game)
        {
            //game.link.sprite = game.linkSpriteFactory.RightUseItemLinkSprite(game.link);
        }
    }
}
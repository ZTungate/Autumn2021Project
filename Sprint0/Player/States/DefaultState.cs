using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
    public class DefaultState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;
        public DefaultState(ILink Link, ISprite sprite)
        {
            /* 
             * This state is for first initialization where no textures are loaded for sprites yet.
             * This state replaces itself with rightIdleState at first update (after textures are loaded and Link gets a default sprite).
             */
            link = Link;
        }

        public void takeDamage()
        {
            //Call on link to take damage. Does this need to be here? Might not be necesary in the state itself.
            link.takeDamage();
        }

        public void Update(GameTime gameTime)
        {
            //Replace this state with a right idle state.
            link.state = new RightIdleLinkState(link, link.sprite);
        }

        public void useItem(Game1 game)
        {
            //game.link.sprite = game.linkSpriteFactory.RightUseItemLinkSprite(game.link);
        }
    }
}
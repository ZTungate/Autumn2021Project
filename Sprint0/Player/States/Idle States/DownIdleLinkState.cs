using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sprint2.Player
{
    public class DownIdleLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;
        public DownIdleLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new DownIdleLinkSprite(sprite.Texture, link);
            link.sprite = mySprite;
        }

        public void TakeDamage()
        {
            //Call on link to take damage. Does this need to be here? Might not be necesary in the state itself.
            link.takeDamage();
        }

        public void Update(GameTime gameTime)
        {
            //Nothing needs updated in an idle state?
        }

        public void UseItem()
        {
            //Change link to an item using state.
            link.state = new DownItemUsingLinkState(link, mySprite);
        }
    }
}
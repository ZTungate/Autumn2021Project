using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Sprint0.Projectiles.ProjectileConstants;

namespace Sprint2.Player
{
    public class UpIdleLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;
        public UpIdleLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new UpIdleLinkSprite(sprite.Texture, link);
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

        public void UseItem(ProjectileTypes item)
        {
            link.state = new UpItemUsingLinkState(link, mySprite, item);
        }

        public void SwordAttack()
        {
            link.state = new UpSwordLinkState(link, mySprite);
        }

        public void Move(direction direction)
        {
            //If told to move in the direction this state is facing, switch to a moving state. Otherwise, switch to an idle state in that direction.
            switch (direction)
            {
                case direction.down:
                    //Change to down idle stae if told to move down.
                    link.state = new DownIdleLinkState(link, mySprite);
                    break;
                case direction.right:
                    //Change to a right idle state if told to move right.
                    link.state = new RightIdleLinkState(link, mySprite);
                    break;
                case direction.left:
                    //Change to a left idle state if told to move left.
                    link.state = new LeftIdleLinkState(link, mySprite);
                    break;
                case direction.up:
                    //Change to an up moving state if told to move up.
                    link.state = new UpMovingLinkState(link, mySprite);
                    break;
            }
        }
    }
}
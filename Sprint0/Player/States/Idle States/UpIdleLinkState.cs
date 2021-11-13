using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
    public class UpIdleLinkState : ILinkState
    {
        private ILink link;
        private ISprite mySprite;
        public UpIdleLinkState(ILink Link, ISprite sprite)
        {
            link = Link;
            mySprite = new UpIdleLinkSprite(sprite.Texture, link);
            link.Sprite = mySprite;
        }

        /*public void TakeDamage()
        {
            //Call on link to take damage. Does this need to be here? Might not be necesary in the state itself.
            link.TakeDamage();
        }*/

        public void Update(GameTime gameTime)
        {
            //Nothing needs updated in an idle state?
        }

        public void UseItem(ProjectileTypes item)
        {
            link.State = new UpItemUsingLinkState(link, mySprite, item);
        }

        public void SwordAttack()
        {
            link.State = new UpSwordLinkState(link, mySprite);
        }

        public void Move(Direction direction)
        {
            //If told to move in the direction this state is facing, switch to a moving state. Otherwise, switch to an idle state in that direction.
            switch (direction)
            {
                case Direction.down:
                    //Change to down idle stae if told to move down.
                    link.State = new DownIdleLinkState(link, mySprite);
                    break;
                case Direction.right:
                    //Change to a right idle state if told to move right.
                    link.State = new RightIdleLinkState(link, mySprite);
                    break;
                case Direction.left:
                    //Change to a left idle state if told to move left.
                    link.State = new LeftIdleLinkState(link, mySprite);
                    break;
                case Direction.up:
                    //Change to an up moving state if told to move up.
                    link.State = new UpMovingLinkState(link, mySprite);
                    break;
            }
        }

        public void PickUp(AbstractItem item)
        {
            //No Implementation needed.
        }
    }
}
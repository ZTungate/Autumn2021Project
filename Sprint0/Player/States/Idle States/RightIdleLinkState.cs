using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Items;
using System;
using static Sprint0.Projectiles.ProjectileConstants;

namespace Sprint2.Player
{
	public class RightIdleLinkState : ILinkState
	{
        private ILink link;
        private ISprite mySprite;
        public RightIdleLinkState(ILink Link, ISprite sprite)
		{
            link = Link;
            mySprite = new RightIdleLinkSprite(sprite.Texture, link);
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
            link.state = new RightItemUsingLinkState(link, mySprite, item);
        }

        public void SwordAttack()
        {
            link.state = new RightSwordLinkState(link, mySprite);
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
                    //Change to a right moving state if told to move right.
                    link.state = new RightMovingLinkState(link, mySprite);
                    break;
                case direction.left:
                    //Change to a left idle state if told to move left.
                    link.state = new LeftIdleLinkState(link, mySprite);
                    break;
                case direction.up:
                    //Change to an up idle state if told to move up.
                    link.state = new UpIdleLinkState(link, mySprite);
                    break;
            }
        }

        public void PickUp(AbstractItem item)
        {
            //No Implementation needed.
        }
    }
}
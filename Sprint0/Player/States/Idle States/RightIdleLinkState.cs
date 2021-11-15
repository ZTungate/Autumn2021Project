using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items;
using System;
using static Poggus.Projectiles.ProjectileConstants;

namespace Poggus.Player
{
	public class RightIdleLinkState : ILinkState
	{
        private ILink link;
        private ISprite mySprite;
        public RightIdleLinkState(ILink Link, ISprite sprite)
		{
            link = Link;
            mySprite = new RightIdleLinkSprite(sprite.Texture, link);
            mySprite.Color = sprite.Color;
            link.Sprite = mySprite;
        }

        public void Update(GameTime gameTime)
        {
            //Nothing needs updated in an idle state?
        }

        public void UseItem(ProjectileTypes item)
        {
            link.State = new RightItemUsingLinkState(link, mySprite, item);
        }

        public void SwordAttack()
        {
            link.State = new RightSwordLinkState(link, mySprite);
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
                    //Change to a right moving state if told to move right.
                    link.State = new RightMovingLinkState(link, mySprite);
                    break;
                case Direction.left:
                    //Change to a left idle state if told to move left.
                    link.State = new LeftIdleLinkState(link, mySprite);
                    break;
                case Direction.up:
                    //Change to an up idle state if told to move up.
                    link.State = new UpIdleLinkState(link, mySprite);
                    break;
            }
        }
        public void Idle()
        {
            //Already idle, no implementation needed
        }

        public void Die()
        {
            //Chane link to a dead state
            link.State = new DeadLinkState(link, mySprite);
        }
        public void PickUp(AbstractItem item)
        {
            //No Implementation needed.
        }
    }
}
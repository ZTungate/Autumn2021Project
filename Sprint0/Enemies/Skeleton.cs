using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class Skeleton
    {
        public ISkeletonState state;

        public ISprite mySprite = EnemySpriteFactory.Instance.CreateSkeletonSprite();

        public Skeleton()
        {
            state = new BaseSkeletonState(this);
        }

    }


    public class BaseSkeletonState : ISkeletonState
    {
        private Skeleton skeleton;

        public BaseSkeletonState(Skeleton skeleton)
        {
            this.skeleton = skeleton;
           //skeleton.mySprite =; //TODO Get skeleton sprite from game1's factory.
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw the sprite in the provided spritebatch using skeleton's texture, the current frame's source rect, the x and y position of the skeleton, and make it white (non-tinted)
            spriteBatch.Draw(
                skeleton.mySprite.Texture,
                skeleton.mySprite.SourceRect[skeleton.mySprite.CurrentFrame],
                new Rectangle((int)skeleton.mySprite.Position.X, (int)skeleton.mySprite.Position.Y, skeleton.mySprite.SourceRect[skeleton.mySprite.CurrentFrame].Width, skeleton.mySprite.SourceRect[skeleton.mySprite.CurrentFrame].Height),
                Color.White);
        }

    }
        
}

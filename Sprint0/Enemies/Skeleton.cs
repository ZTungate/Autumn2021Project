﻿using Microsoft.Xna.Framework;
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
        private GameTime gameTime;

        private int interval = 40;
        private int timer = 0;

        public BaseSkeletonState(Skeleton skeleton)
        {
            this.skeleton = skeleton;
           //skeleton.mySprite =; //TODO Get skeleton sprite from game1's factory.
        }

        public void Update()
        {
            skeleton.mySprite.Update(gameTime);

            //Timer to prevent from moving too fast, should unify with the timer in sprite.Update();
            if(timer < interval)
            {
                timer+= 5;
            }
            else
            {
                timer = 0;
                skeleton.mySprite.Position = randomMove();
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw the sprite in the provided spritebatch
            spriteBatch.Draw(
                skeleton.mySprite.Texture, //Use the sprite's texture
                //Use position stored in mySprite
                new Rectangle((int)skeleton.mySprite.Position.X, (int)skeleton.mySprite.Position.Y, skeleton.mySprite.SourceRect[skeleton.mySprite.CurrentFrame].Width, skeleton.mySprite.SourceRect[skeleton.mySprite.CurrentFrame].Height),
                //Get the relevant sourceRect from the current frome
                skeleton.mySprite.SourceRect[skeleton.mySprite.CurrentFrame],
                //Paint the skeleton white (don't tint)
                Color.White);
        }

        public Vector2 randomMove()
        {
            Vector2 pos = skeleton.mySprite.Position;

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(4);

            if (i == 0)
            {
                pos.X += 5;
            }
            else if (i == 1)
            {
                pos.Y += 5;
            }
            else if (i== 2)
            {
                pos.X -= 5;
            }
            else
            {
                pos.Y -= 5;
            }
            return pos;

        }

    }
        
}

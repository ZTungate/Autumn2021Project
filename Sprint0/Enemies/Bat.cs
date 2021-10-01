﻿using Microsoft.Xna.Framework;
using Sprint0.Helpers;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class Bat : IEnemy
    {
        //ISprite for the enemy
        ISprite mySprite;
        public ISprite Sprite
        {
            //Allow sprite to be set by the spriteFactory, and return mySprite when requested.
            get => mySprite;
            set => mySprite = value;
        }

        public EnemyTypes Type
        {
            //Return Bat if type is ever asked for.
            get => EnemyTypes.Bat;
        }

        public void Update(GameTime gameTime)
        {
            int lastFrame = mySprite.CurrentFrame;
            mySprite.Update(gameTime);

            //Move the bat if the animation frame changed
            if (lastFrame != mySprite.CurrentFrame)
            {
                mySprite.Position = BatRandomMove();
            }
        }
        public Bat()
        {
            //Nothing special about the bat object itself, no implementation required
        }

        //Placeholder movement method, will require reworking when actual level exists.
        public Vector2 BatRandomMove()
        {
            Vector2 pos = mySprite.Position;

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(4);

            if (i == 0)
            {
                //Move right/Up if i = 0
                pos.X += 3;
                pos.Y += 3;
            }
            else if (i == 1)
            {
                //Move right/down if i = 1
                pos.X += 3;
                pos.Y -= 3;
            }
            else if (i == 2)
            {
                //Move left/up if i = 2
                pos.X -= 3;
                pos.Y += 3;
            }
            else if (i == 3)
            {
                //Move left/down if i = 3
                pos.X -= 3;
                pos.Y -= 3;
            }
            //Return the modified position.
            return pos;

        }
    }
}
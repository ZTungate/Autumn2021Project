﻿using Microsoft.Xna.Framework;
using Sprint2.Helpers;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class Bat : IEnemy
    {
        //ISprite for the enemy
        ISprite mySprite;
        //Position of the bat.
        Vector2 pos;
        //State of the bat (not used yet for this enemy type)
        IEnemyState state;
        public ISprite Sprite
        {
            //Allow sprite to be set by the spriteFactory, and return mySprite when requested.
            get => mySprite;
            set => mySprite = value;
        }
        public Vector2 Position
        {
            get => pos;
            set => pos = value;
        }

        public Vector2 oldPosition { get; set; }

        public IEnemyState State
        {
            //This will not be used until damage states are added.
            get => state;
            set => state = value;
        }
        public EnemyTypes Type
        {
            //Return Bat if type is ever asked for.
            get => EnemyTypes.Bat;
        }

        public void Update(GameTime gameTime)
        {
            oldPosition = pos;


            int lastFrame = mySprite.CurrentFrame;
            mySprite.Update(gameTime);

            //Move the bat if the animation frame changed
            if (lastFrame != mySprite.CurrentFrame)
            {
                pos = BatRandomMove();
                mySprite.Position = pos;
            }
        }
        public Bat(Vector2 pos)
        {
            //Assign an arbitrary starting positon for the bat.
            this.pos = pos;
        }

        //Placeholder movement method, will require reworking when actual level exists.
        public Vector2 BatRandomMove()
        {
            Vector2 newPosition = pos;

            //Get a random number from 0-3
            Random rand = new Random();
            int i = rand.Next(4);

            if (i == 0)
            {
                //Move right/Up if i = 0
                newPosition.X += EnemyConstants.batMoveSpeed;
                newPosition.Y += EnemyConstants.batMoveSpeed;
            }
            else if (i == 1)
            {
                //Move right/down if i = 1
                newPosition.X += EnemyConstants.batMoveSpeed;
                newPosition.Y -= EnemyConstants.batMoveSpeed;
            }
            else if (i == 2)
            {
                //Move left/up if i = 2
                newPosition.X -= EnemyConstants.batMoveSpeed;
                newPosition.Y += EnemyConstants.batMoveSpeed;
            }
            else if (i == 3)
            {
                //Move left/down if i = 3
                newPosition.X -= EnemyConstants.batMoveSpeed;
                newPosition.Y -= EnemyConstants.batMoveSpeed;
            }
            //Return the modified position.
            return newPosition;

        }
    }
}
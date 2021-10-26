﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using Sprint2.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class PickUpLinkSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 128f; 
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 2;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }
        private AbstractItem myItem;
        ILink player;
        public PickUpLinkSprite(Texture2D spriteSheet, ILink player, AbstractItem item)
        {
            this.player = player;
            myItem = item;
            Texture = spriteSheet;  //Set the texture2D to the provided spriteSheet (already initialized by factory)
            SourceRect = new Rectangle[2];
            
            SourceRect[0] = new Rectangle(213 , 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(230, 11, 16, 16);
            /*Position = pos;*/     //Sets the position to Link's position
        }

        public void Update(GameTime gameTime)
        {
            // Implement animation changes here

            //Animate the sprites (pulled from animatedStillSprite.cs)
            if (Timer > Interval)
            {
                CurrentFrame++;


                if (CurrentFrame > FrameCount - 1) { //hold the pick up item frame until update
                    CurrentFrame = 1;
                }

                Timer = 0;
            }
            else
            {
                //Increment timer by the elapsed time in game.
                Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, player.position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), (int)LinkConstants.scaleX, SpriteEffects.None, 1);
            //draw item above link
            Vector2 itemPos = new Vector2(player.position.X + (player.position.X - myItem.GetSprite().SourceRect[CurrentFrame].X)/2, player.position.Y - myItem.GetSprite().SourceRect[CurrentFrame].Y);
            myItem.SetRectangle(new Rectangle((int)(myItem.GetRectangle().X + itemPos.X), (int)(myItem.GetRectangle().Y + itemPos.Y), myItem.GetRectangle().Width, myItem.GetRectangle().Height));
            //TODO: Draw item 
            //myItem.Draw()

        }

    }
}

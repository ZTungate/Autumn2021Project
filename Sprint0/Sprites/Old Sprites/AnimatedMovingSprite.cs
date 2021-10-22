using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    public class AnimatedMovingSprite : IAnimatedSprite
    {

        public bool rightSlide = true;

        private Game1 myGame;

        public float newX;

        public float Timer { get; set; } = 0f;

        public float Interval { get; set; } = 40f;
        public int CurrentFrame { get; set; } = 0;

        public int FrameCount { get; private set; } = 34;

        public float SpriteSpeed { get; set; } = 100f;

        public Texture2D Texture { get; set; }

        public Rectangle[] SourceRect { get; set; }

        public Vector2 Position { get; set; }

        public AnimatedMovingSprite(Game1 game)
        {

            myGame = game; 

            Texture = myGame.Content.Load<Texture2D>("waterBall");


            SourceRect = new Rectangle[34];

            for (int i = 0; i < FrameCount; i++) { //create an array of the different sprites from the sprite sheet
                SourceRect[i] = new Rectangle(0, i * Texture.Height / FrameCount, Texture.Width, Texture.Height / FrameCount);
            }

            Position = new Vector2(myGame._graphics.PreferredBackBufferWidth / 2 - SourceRect[0].Width / 2, myGame._graphics.PreferredBackBufferHeight / 2 - SourceRect[0].Height / 2);

        }

        public void Update(GameTime gameTime)
        {

            if (rightSlide) { //slide the sprite side to side
                if (Position.X < 2 * myGame._graphics.PreferredBackBufferWidth / 3) {
                    newX = Position.X + SpriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Position = new Vector2(newX, myGame._graphics.PreferredBackBufferHeight / 2 - SourceRect[0].Height / 2);
                }
                else {
                    rightSlide = false;
                }

            }
            else {
                if (Position.X > myGame._graphics.PreferredBackBufferWidth / 5) {
                    newX = Position.X - SpriteSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Position = new Vector2(newX, myGame._graphics.PreferredBackBufferHeight / 2 - SourceRect[0].Height / 2);
                }
                else {
                    rightSlide = true;
                }
            }


            if (Timer > Interval) { //animate the sprites
                CurrentFrame++;

                if (CurrentFrame > FrameCount - 1) {
                    CurrentFrame = 0;
                }
                Timer = 0;
            }
            else {
                Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width, SourceRect[CurrentFrame].Height);
            spriteBatch.Draw(Texture,destRect,SourceRect[CurrentFrame],Color.White);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class RightIdleLinkSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 40f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 2;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public RightIdleLinkSprite(Texture2D spriteSheet)
        {
            //Set the texture2D to the provided spriteSheet (already initialized by factory)
            Texture = spriteSheet;
            SourceRect = new Rectangle[2];

            //Set the two frames for the skeleton animation
            SourceRect[0] = new Rectangle(1, 11, 16, 16);
            SourceRect[1] = new Rectangle(1, 11, 16, 16);

            //Dummy position, needs to be fixed by adding pos relevant to the enemy. TODO fix
            Position = new Vector2(100,100);
        }

        public void Update(GameTime gameTime)
        {

        }


    }
}

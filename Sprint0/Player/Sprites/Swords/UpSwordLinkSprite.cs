using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class UpSwordLinkSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        public int scale = 2;

        ILink player;
        public UpSwordLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[5])
        {
            this.player = player;
            SourceRect[0] = new Rectangle(1, 97, 16, 27);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(18, 97, 16, 27);
            SourceRect[2] = new Rectangle(35, 97, 16, 27);
            SourceRect[3] = new Rectangle(52, 97, 16, 27);
            SourceRect[4] = new Rectangle(69, 11, 16, 16);  //Set the frame for right idle link
            this.Interval = 64f;
            /*Position = pos;*/     //Sets the position to Link's position
        }

        public override void Update(GameTime gameTime)
        {
            // Implement animation changes here
            //Animate the sprites (pulled from animatedStillSprite.cs)
            this.FrameStep(gameTime);
        }

        /*public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame%FrameCount].Width*scale, SourceRect[CurrentFrame%FrameCount].Height*scale);
            
            spriteBatch.Draw(Texture, new Vector2(player.position.X, player.position.Y + 32), SourceRect[CurrentFrame % FrameCount], player.color, 0, new Vector2(0, SourceRect[CurrentFrame % FrameCount].Height), scale, SpriteEffects.None, 1);

        }*/

    }
}

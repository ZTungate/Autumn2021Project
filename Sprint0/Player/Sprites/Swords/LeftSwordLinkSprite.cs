using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Player;
using Poggus.Main;

namespace Poggus.Player
{
    public class LeftSwordLinkSprite : AbstractSprite
    {
        ILink player;
        public LeftSwordLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[5])
        {
            this.player = player;
            
            SourceRect[0] = new Rectangle(1, 77, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(18, 77, 27, 16);
            SourceRect[2] = new Rectangle(46, 77, 23, 16);
            SourceRect[3] = new Rectangle(70, 77, 19, 16);
            SourceRect[4] = new Rectangle(35, 11, 16, 16);  //Set the frame for right idle link
            this.Interval = LinkConstants.swordAnimInterval;
            this.effects = SpriteEffects.FlipHorizontally;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Rectangle rect)
        {
            //LayerDepth set to 1, normally this would mean this object will always been drawn in front but because of Begin() call in Game1 objects are drawn in the order their Draw() method is called
            Rectangle worldRect = rect;
            if (!IsUISprite) { worldRect = new Rectangle(rect.Location + Camera.main.GetPosition(), rect.Size); }
            spriteBatch.Draw(Texture, worldRect, SourceRect[CurrentFrame], Color, Camera.main.GetRotation(), new Vector2(SourceRect[CurrentFrame % FrameCount].Width - LinkConstants.linkSize, 0), effects, 1);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Player;
using Poggus.Main;

namespace Poggus.Player
{
    public class UpSwordLinkSprite : AbstractSprite
    {
        ILink player;
        public UpSwordLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[5])
        {
            this.player = player;
            SourceRect[0] = new Rectangle(1, 97, 16, 27);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(18, 97, 16, 27);
            SourceRect[2] = new Rectangle(35, 97, 16, 27);
            SourceRect[3] = new Rectangle(52, 97, 16, 27);
            SourceRect[4] = new Rectangle(69, 11, 16, 16);  //Set the frame for right idle link
            this.Interval = LinkConstants.swordAnimInterval;
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
            spriteBatch.Draw(Texture, worldRect, SourceRect[CurrentFrame], Color, Camera.main.GetRotation(), new Vector2(0, SourceRect[CurrentFrame % FrameCount].Height - LinkConstants.linkSize), effects, 1);
        }
    }
}

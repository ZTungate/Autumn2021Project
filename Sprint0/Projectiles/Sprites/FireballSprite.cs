using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class FireballSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        public FireballSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            //Set the two frames for the bat animation
            SourceRect[0] = new Rectangle(231, 59, 8, 16);
            SourceRect[1] = new Rectangle(240, 59, 8, 16);
            SourceRect[2] = new Rectangle(249, 59, 8, 16);
            SourceRect[3] = new Rectangle(258, 59, 8, 16);
            this.Interval = ProjectileConstants.fireballAnimInterval;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }
}

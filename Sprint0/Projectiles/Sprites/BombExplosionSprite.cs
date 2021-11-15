using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class BombExplosionSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        public int counter = 0;
        public BombExplosionSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[3])
        {
            //Set the 3 frames for the explosion animation.
            SourceRect[0] = new Rectangle(138, 185, 16, 16);
            SourceRect[1] = new Rectangle(155, 185, 16, 16);
            SourceRect[2] = new Rectangle(172, 185, 16, 16);
            this.Interval = ProjectileConstants.bombExplosionLife / 3;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }
}

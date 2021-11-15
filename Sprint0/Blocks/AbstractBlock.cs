using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Poggus.Blocks.Sprites;
using Poggus;

namespace Poggus.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        public ISprite Sprite { get; set; }
        public Rectangle DestRect { get; set; }
        public bool Walkable { set;  get; }
        public bool Moveable { set;  get; }

        private BlockType blockType;
        public AbstractBlock(BlockType type, Point pos, Point size)
        {
            this.blockType = type;
            this.DestRect = new Rectangle(pos, size);
        }
        public AbstractBlock(BlockType type, Point pos)
        {
            this.blockType = type;
            this.DestRect = new Rectangle(pos, new Point(64,(int)(64 * Game1.heightScalar)));
        }
        public void CreateSprite()
        {
            this.Sprite = BlockSpriteFactory.Instance.GetBlockSprite(blockType);
        }
        public void Update(GameTime gameTime)
        {
            //no-op
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, DestRect);
        }
        public Point GetPosition()
        {
            return this.DestRect.Location;
        }
        public void SetPosition(Point pos)
        {
            this.DestRect = new Rectangle(pos, DestRect.Size);
        }
        public BlockType GetBlockType()
        {
            return this.blockType;
        }
    }
}

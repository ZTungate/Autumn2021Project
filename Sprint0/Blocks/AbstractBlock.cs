using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Poggus.Blocks;
using Poggus;
using Poggus.Blocks.Sprites;

namespace Poggus.Blocks
{
    abstract class ConcreteBlock : IBlock
    {
        public ISprite Sprite { get; set; }
        public Rectangle DestRect { get; set; }
        public bool Walkable { get; }
        public bool Moveable { get; }

        private BlockType blockType;
        public ConcreteBlock(BlockType type, Point pos, Point size)
        {
            this.blockType = type;
            this.DestRect = new Rectangle(pos, size);
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

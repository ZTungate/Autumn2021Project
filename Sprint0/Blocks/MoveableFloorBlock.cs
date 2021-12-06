using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Blocks
{
    class MoveableFloorBlock : AbstractBlock
    {
        private static int velocity = 1;
        private static int BLOCK_SIZE_Y = (int)(64 * Game1.heightScalar);
        public MoveableFloorBlock(Point pos) : base(BlockType.MoveableFloorBlock, pos)
        {
            this.Moveable = true;
        }

        public override void MoveUp()
        {
            int X = this.GetPosition().X;
            int Y = this.GetPosition().Y;
            int holderY = Y - BLOCK_SIZE_Y;
            while(Y > holderY)
            {
                Y -= velocity;
                this.SetPosition(new Point(X, Y));
                if (velocity > 4)
                {
                    velocity -= 4;
                }
                else
                {
                    velocity = 1;
                }
            }
            this.Moveable = false;
            
        }
    }
}

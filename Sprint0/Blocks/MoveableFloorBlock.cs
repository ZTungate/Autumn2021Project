using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Blocks
{
    public class MoveableFloorBlock : AbstractBlock
    {
        private static int velocity = 1;
        private static int BLOCK_SIZE_Y = (int)(64 * Game1.heightScalar);
        private bool isMovingUp = false;
        private bool isMovingDown = false;
        private int destinationY;
        public MoveableFloorBlock(Point pos) : base(BlockType.MoveableFloorBlock, pos)
        {
            this.Moveable = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (isMovingUp) {
                if (GetPosition().Y > destinationY) {
                    DestRect = new Rectangle(DestRect.Location + new Point(0, -2), DestRect.Size);
                }
                else {
                    isMovingUp = false;
                }
            }
            if (isMovingDown)
            {
                if (GetPosition().Y < destinationY)
                {
                    DestRect = new Rectangle(DestRect.Location + new Point(0, 2), DestRect.Size);
                }
                else
                {
                    isMovingUp = false;
                }
            }
        }

        public override void MoveUp()
        {

            isMovingUp = true;
            int X = this.GetPosition().X;
            int Y = this.GetPosition().Y;
            destinationY = Y - BLOCK_SIZE_Y;
            this.Moveable = false;
            
        }
        public override void MoveDown()
        {

            isMovingDown = true;
            int X = this.GetPosition().X;
            int Y = this.GetPosition().Y;
            destinationY = Y + BLOCK_SIZE_Y;
            this.Moveable = false;

        }
    }
}

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
        private static int BLOCK_SIZE_X = 64;
        private bool isMovingUp = false;
        private bool isMovingDown = false;
        private bool isMovingLeft = false;
        private bool isMovingRight = false;
        private int destinationY;
        private int destinationX;
        public bool opensDoor;
        public Point doorDirToOpen;
        public Point dirToMoveToOpen;
        private Point startPoint;

        public MoveableFloorBlock(Point pos) : base(BlockType.MoveableFloorBlock, pos)
        {
            this.Moveable = true;
            this.startPoint = pos;
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
                    isMovingDown = false;
                }
            }
            if (isMovingRight)
            {
                if (GetPosition().X > destinationX)
                {
                    DestRect = new Rectangle(DestRect.Location + new Point(2, 0), DestRect.Size);
                }
                else
                {
                    isMovingRight = false;
                }
            }
            if (isMovingLeft)
            {
                if (GetPosition().X < destinationX)
                {
                    DestRect = new Rectangle(DestRect.Location + new Point(-2, 0), DestRect.Size);
                }
                else
                {
                    isMovingLeft = false;
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
        public override void MoveRight()
        {

            isMovingRight = true;
            int X = this.GetPosition().X;
            int Y = this.GetPosition().Y;
            destinationX = X + BLOCK_SIZE_Y;
            this.Moveable = false;

        }
        public override void MoveLeft()
        {

            isMovingLeft = true;
            int X = this.GetPosition().X;
            int Y = this.GetPosition().Y;
            destinationX = X - BLOCK_SIZE_Y;
            this.Moveable = false;

        }
    }
}

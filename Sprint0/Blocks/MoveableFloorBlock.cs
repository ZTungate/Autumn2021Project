using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Blocks
{
    public class MoveableFloorBlock : AbstractBlock
    {
        private static int velocity = 1;
        private bool isMovingUp = false;
        private bool isMovingDown = false;
        private bool isMovingLeft = false;
        private bool isMovingRight = false;
        private int destinationX;
        private int destinationY;

        public bool opensDoor;
        public Point doorDirToOpen;
        public Point dirToMoveToOpen;
        public bool movedInDir;

        public MoveableFloorBlock(Point pos) : base(BlockType.MoveableFloorBlock, pos)
        {
            this.Moveable = true;
        }

        public override void Update(GameTime gameTime)
        {
            if(opensDoor && (isMovingDown || isMovingLeft || isMovingRight || isMovingUp))
            {
                Game1.instance.GetDungeon().GetCurrentLevel().GetDoorFromDirection(doorDirToOpen).OpenDoor();
            }
            if (isMovingUp) {
                if (GetPosition().Y > destinationY) {
                    DestRect = new Rectangle(DestRect.Location + new Point(0, -2), DestRect.Size);
                    if(dirToMoveToOpen == new Point(0,1))
                    {
                        movedInDir = true;
                    }
                }
                else {
                    isMovingUp = false;
                }
            }
            else if (isMovingDown)
            {
                if (GetPosition().Y < destinationY)
                {
                    DestRect = new Rectangle(DestRect.Location + new Point(0, 2), DestRect.Size);
                    if (dirToMoveToOpen == new Point(0, -1))
                    {
                        movedInDir = true;
                    }
                }
                else
                {
                    isMovingDown = false;
                }
            }
            else if (isMovingRight) {
                if (GetPosition().X < destinationX) {
                    DestRect = new Rectangle(DestRect.Location + new Point(2, 0), DestRect.Size);
                    if (dirToMoveToOpen == new Point(1, 0))
                    {
                        movedInDir = true;
                    }
                }
                else {
                    isMovingRight = false;
                }
            }
            else if (isMovingLeft) {
                if (GetPosition().X > destinationX) {
                    DestRect = new Rectangle(DestRect.Location + new Point(-2, 0), DestRect.Size);
                    if (dirToMoveToOpen == new Point(-1, 0))
                    {
                        movedInDir = true;
                    }
                }
                else {
                    isMovingLeft = false;
                }
            }
        }

        public override void MoveUp()
        {

            isMovingUp = true;
            int Y = GetPosition().Y;
            destinationY = Y - BLOCK_SIZE_Y;
            this.Moveable = false;
            
        }
        public override void MoveDown()
        {

            isMovingDown = true;
            int Y = GetPosition().Y;
            destinationY = Y + BLOCK_SIZE_Y;
            this.Moveable = false;

        }

        public override void MoveRight()
        {

            isMovingRight = true;
            int X = GetPosition().X;
            destinationX = X + BLOCK_SIZE_X;
            this.Moveable = false;

        }

        public override void MoveLeft()
        {

            isMovingLeft = true;
            int X = GetPosition().X;
            destinationX = X - BLOCK_SIZE_X;
            this.Moveable = false;

        }
    }
}

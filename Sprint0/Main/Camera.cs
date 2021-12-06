using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.Main
{
    public class Camera
    {
        public static Camera main = new Camera(Point.Zero, new Point(0,175), 0);
        Point position,offset;
        float rotation;

        Point moveTo;
        bool moveToNext;
        float moveToSpeed;

        Point originalPosition;
        public Camera(Point position, Point constantOffset, float rotation)
        {
            this.position = position + constantOffset;
            this.originalPosition = this.position;
            this.offset = constantOffset;
            this.rotation = rotation;
        }
        public void Reset()
        {
            this.position = originalPosition;
            this.moveToNext = false;
            this.moveTo = Point.Zero;
        }
        public void Update(GameTime gameTime)
        {
            if (moveToNext)
            {
                Point flippedPosition = (new Point(-position.X, -position.Y) + offset);
                Vector2 dirVector = (moveTo - flippedPosition).ToVector2();
                dirVector = new Vector2(dirVector.X == 0 ? 0 : dirVector.X / Math.Abs(dirVector.X), dirVector.Y == 0 ? 0 : dirVector.Y / Math.Abs(dirVector.Y));
                Point dirScaled = new Point((int)(dirVector.X * moveToSpeed), (int)(dirVector.Y * moveToSpeed));

                Translate(new Point(-dirScaled.X, -dirScaled.Y));
                flippedPosition = (new Point(-position.X, -position.Y) + offset);
                if ((moveTo - flippedPosition).ToVector2().LengthSquared() <= ((moveToSpeed / 2)  * (moveToSpeed / 2)))
                {
                    position = (new Point(-moveTo.X, -moveTo.Y) + offset);
                    moveToNext = false;

                    Game1.instance.GetDungeon().GetCurrentLevel().DoEnemySpawnAnimation();
                }
            }
        }
        public void SetPosition(Point pos)
        {
            position = (new Point(-pos.X, -pos.Y) + offset);
        }
        public void BeginMoveTo(Point pos, float moveToSpeed)
        {
            this.moveTo = pos;
            this.moveToSpeed = moveToSpeed;
            moveToNext = true;
        }
        public void Translate(Point translateAmt)
        {
            this.position += translateAmt;
        }
        public Point GetPosition()
        {
            return this.position;
        }
        public float GetRotation()
        {
            return this.rotation;
        }
        public Point GetOffset()
        {
            return this.offset;
        }
        public bool IsMoving()
        {
            return this.moveToNext;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LevelCreator.Sprites.Factories;

namespace LevelCreator.Sprites
{
    public class LineSprite : ISprite
    {
        private Point p1, p2;
        private Color color;
        public LineSprite(Color color, Point p1)
        {
            this.color = color;
            this.p1 = p1;
        }
        public LineSprite(Color color, Point p1, Point p2)
        {
            this.color = color;
            this.p1 = p1;
            this.p2 = p2;
        }
        public void Draw(SpriteBatch spriteBatch, Rectangle destRect)
        {
            Rectangle r = new Rectangle((int)p1.X, (int)p1.Y, (int)((p2 - p1).ToVector2().Length()) + destRect.Width, destRect.Width);
            Vector2 v = Vector2.Normalize((p1 - p2).ToVector2());
            float angle = (float)Math.Acos(Vector2.Dot(v, -Vector2.UnitX));
            if (p1.Y > p2.Y) angle = MathHelper.TwoPi - angle;
            spriteBatch.Draw(GeneralFactory.instance.GetWhiteSquare(), r, null, color, angle, Vector2.Zero, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            //no-op
        }
        public void SetP1(Point p1)
        {
            this.p1 = p1;
        }
        public void SetP2(Point p2)
        {
            this.p2 = p2;
        }
        public Point GetP1()
        {
            return this.p1;
        }
        public Point GetP2()
        {
            return this.p2;
        }
        public static Vector2 FindNearestPointOnLine(Vector2 origin, Vector2 end, Vector2 point)
        {
            //Get heading
            Vector2 heading = (end - origin);
            float magnitudeMax = heading.Length();
            heading.Normalize();

            //Do projection from the point but clamp it
            Vector2 lhs = point - origin;
            float dotP = Vector2.Dot(lhs, heading);
            dotP = Math.Clamp(dotP, 0f, magnitudeMax);
            return origin + heading * dotP;
        }
        public static float Distance(Point p1, Point p2)
        {
            return (float)Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
        }
    }
}

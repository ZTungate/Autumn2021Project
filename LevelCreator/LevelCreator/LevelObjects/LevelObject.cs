using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using LevelCreator.Sprites;
using Microsoft.Xna.Framework.Graphics;

namespace LevelCreator.LevelObjects
{
    public class LevelObject
    {
        private Rectangle myRect;
        private ISprite mySprite;
        private LevelObjectInfo myInfo;
        public LevelObject(Rectangle rect, ISprite sprite, LevelObjectInfo myInfo)
        {
            this.myRect = rect;
            this.mySprite = sprite;
            this.myInfo = myInfo;
        }
        public LevelObject(LevelObject levelObject)
        {
            this.myRect = levelObject.myRect;
            this.mySprite = levelObject.mySprite;
            this.myInfo = levelObject.myInfo;
        }
        public void SetPos(Point p)
        {
            this.myRect.X = p.X;
            this.myRect.Y = p.Y;
        }
        public int GetX()
        {
            return this.myRect.X;
        }
        public int GetY()
        {
            return this.myRect.Y;
        }
        public bool IsPointOver(Point p)
        {
            return myRect.Contains(p);
        }
        public void Draw(SpriteBatch batch, float order)
        {
            mySprite.Draw(batch, myRect, order);
        }
        public Rectangle GetRectangle()
        {
            return this.myRect;
        }
        public void SetRectangle(Rectangle rect)
        {
            this.myRect = rect;
        }
        public LevelObjectInfo GetInfo()
        {
            return this.myInfo;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace LevelCreator.LevelObjects
{
    public class LevelObjectInfo
    {
        string spriteSheetName;
        Rectangle sourceRectangle;
        string objectName;
        public LevelObjectInfo(string spriteSheetName, Rectangle sourceRectangle, string objectName)
        {
            this.spriteSheetName = spriteSheetName;
            this.sourceRectangle = sourceRectangle;
            this.objectName = objectName;
        }
        public string GetSpriteSheetName()
        {
            return this.spriteSheetName;
        }
        public Rectangle GetSourceRectangle()
        {
            return sourceRectangle;
        }
        public string GetName()
        {
            return this.objectName;
        }
    }
}

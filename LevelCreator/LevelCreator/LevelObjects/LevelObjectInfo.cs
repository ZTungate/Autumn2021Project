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
        LevelObjectType type;
        public LevelObjectInfo(string spriteSheetName, Rectangle sourceRectangle, string objectName, string type)
        {
            this.spriteSheetName = spriteSheetName;
            this.sourceRectangle = sourceRectangle;
            this.objectName = objectName;
            this.type = LevelObjectTypeHelper.TypeToString(type);
        }
        public LevelObjectType GetLevelObjectType()
        {
            return this.type;
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

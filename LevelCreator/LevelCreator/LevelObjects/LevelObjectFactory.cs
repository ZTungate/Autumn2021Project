using System;
using System.Collections.Generic;
using System.Text;
using LevelCreator.Sprites.Factories;
using LevelCreator.Sprites;
using Microsoft.Xna.Framework;
namespace LevelCreator.LevelObjects
{
    class LevelObjectFactory
    {
        public static LevelObjectFactory instance = new LevelObjectFactory();
        Dictionary<string, LevelObjectInfo> infoDictionary = new Dictionary<string, LevelObjectInfo>();
        public void AddLevelObjectInfo(string s, LevelObjectInfo info)
        {
            infoDictionary.TryAdd(s, info);
        }
        public LevelObjectInfo GetLevelObjectInfo(string s)
        {
            LevelObjectInfo info;
            infoDictionary.TryGetValue(s, out info);
            return info;
        }
        public LevelObjectInfo CreateLevelObjectInfo(string name, string type, string spriteSheet, string xString, string yString, string widthString, string heightString)
        {
            int x = int.Parse(xString);
            int y = int.Parse(yString);
            int width = int.Parse(widthString);
            int height = int.Parse(heightString);
            return new LevelObjectInfo(spriteSheet.ToUpper(), new Microsoft.Xna.Framework.Rectangle(x, y, width, height), name, type);
        }
        public LevelObject CreateNewLevelObject(string name, Rectangle rect)
        {
            LevelObjectInfo info = infoDictionary[name];
            ISprite sprite = GeneralFactory.instance.GenerateSprite(info.GetSpriteSheetName(), info.GetSourceRectangle());
            LevelObject levelObject = new LevelObject(rect, sprite, info);

            return levelObject;
        }
    }
}

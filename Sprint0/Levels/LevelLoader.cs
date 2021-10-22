using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Sprint3.Blocks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3.Levels
{
    public class LevelLoader
    {
        public static LevelLoader instance = new LevelLoader();
        private Level tempLevel;
        public void LoadAllLevels()
        {
            string dir = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string[] fileNames = Directory.GetFiles(dir + "\\Levels");
            foreach (string fileName in fileNames)
            {
                tempLevel = new Level(null, new Point(0, 0));
                StreamReader reader = File.OpenText(fileName);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    int equalPos = line.IndexOf("=");
                    int commaPos = line.IndexOf(",");
                    string blockName = line.Substring(0, equalPos);
                    string xPos = line.Substring(equalPos + 1, commaPos - equalPos-1);
                    string yPos = line.Substring(commaPos + 1);
                    
                    blockName += "Sprite";
                    int x = int.Parse(xPos);
                    int y = int.Parse(yPos);

                    Type objectType = Type.GetType("Sprint2.Blocks." + blockName);

                    Object[] objectParams = new Object[2];
                    objectParams[0] = BlockSpriteFactory.Instance.GetBlockSpriteSheet();
                    objectParams[1] = new Vector2(x, y);

                    object instance = Activator.CreateInstance(objectType, objectParams);

                    tempLevel.AddBlock(new Point(x, y), (IBlocks)instance);
                }
                reader.Close();
            }
        }
        public void DrawLevels(SpriteBatch batch)
        {
            tempLevel.Draw(batch);
        }
    }
}

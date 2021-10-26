using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Sprint2;

namespace Sprint0.Levels
{
    class DungeonLoader
    {
        public static DungeonLoader instance = new DungeonLoader();
        public Dictionary<string, Dungeon> dungeonDictionary = new Dictionary<string, Dungeon>();
        public void LoadDungeons()
        {
            string dir = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string[] fileNames = Directory.GetFiles(dir + "\\Dungeons");
            foreach(string file in fileNames)
            {
                StreamReader reader = File.OpenText(file);
                string dungeonName = reader.ReadLine();

                Dungeon newDungeon = new Dungeon(dungeonName, Game1.instance._graphics.PreferredBackBufferWidth, Game1.instance._graphics.PreferredBackBufferHeight);
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    int colonPos = line.IndexOf(":");
                    int commaPos = line.IndexOf(",");
                    string levelName = line.Substring(0, colonPos);
                    string xString = line.Substring(colonPos + 1, (commaPos-colonPos)-1);
                    string yString = line.Substring(commaPos + 1);

                    int x = int.Parse(xString);
                    int y = int.Parse(yString);

                    Level level = LevelLoader.instance.GetLevel(levelName);

                    newDungeon.AddLevel(new Point(x,y),level);
                }
                newDungeon.UpdateLevelDoors(LevelLoader.instance.gameScaleX, LevelLoader.instance.gameScaleY);

                newDungeon.SetCurrentLevel(new Point(0, 0));
                newDungeon.UpdateLevelContentPositions();

                dungeonDictionary.Add(dungeonName, newDungeon);
                Game1.instance.SetDungeon(newDungeon);
            }
        }
    }
}

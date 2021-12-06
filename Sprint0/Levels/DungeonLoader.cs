using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Poggus;

namespace Poggus.Levels
{
    class DungeonLoader
    {
        public static DungeonLoader instance = new DungeonLoader();
        public Dictionary<string, Dungeon> dungeonDictionary = new Dictionary<string, Dungeon>();
        public void LoadDungeons()
        {
            dungeonDictionary.Clear();
            string dir = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string[] fileNames = Directory.GetFiles(dir + "\\Dungeons");
            foreach(string file in fileNames)
            {
                StreamReader reader = File.OpenText(file);
                string dungeonName = reader.ReadLine();

                Dungeon newDungeon = new Dungeon(dungeonName, Game1.instance._graphics.PreferredBackBufferWidth,(int)(Game1.instance._graphics.PreferredBackBufferHeight * Game1.heightScalar));
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    int colonPos = line.IndexOf(":");
                    int commaPos = line.IndexOf(",");
                    int openParen = line.IndexOf("(");

                    int closedParen = line.IndexOf(")");

                    string levelName = line.Substring(0, colonPos);
                    string xString = line.Substring(colonPos + 1, (commaPos - colonPos) - 1);
                    string yString;
                    if(openParen == -1)
                    {
                        yString = line.Substring(commaPos + 1);
                    }
                    else
                    {
                        yString = line.Substring(commaPos + 1, (openParen - commaPos) - 1);
                    }

                    int x = int.Parse(xString);
                    int y = int.Parse(yString);
                    Level level = LevelLoader.instance.GetLevel(levelName);

                    if (closedParen != -1)
                    {
                        string levelConditions = line.Substring(openParen + 1, closedParen - openParen - 1);

                        Point doorDir = Point.Zero;
                        DoorType doorType = DoorType.Open;
                        for (int i = 0; i < levelConditions.Length; i++)
                        {
                            char ch = levelConditions[i];
                            if (ch == 'U')
                            {
                                char doorTypeChar = levelConditions[i + 2];
                                doorDir = new Point(0, 1);
                                if (doorTypeChar == 'K')
                                {
                                    doorType = DoorType.Key;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                if (doorTypeChar == 'X')
                                {
                                    doorType = DoorType.Closed;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                if (doorTypeChar == 'H')
                                {
                                    doorType = DoorType.Hole;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                i += 3;
                            }
                            else if (ch == 'D')
                            {
                                char doorTypeChar = levelConditions[i + 2];
                                doorDir = new Point(0, -1);
                                if (doorTypeChar == 'K')
                                {
                                    doorType = DoorType.Key;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                if (doorTypeChar == 'X')
                                {
                                    doorType = DoorType.Closed;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                if (doorTypeChar == 'H')
                                {
                                    doorType = DoorType.Hole;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                i += 3;
                            }
                            else if (ch == 'L')
                            {
                                char doorTypeChar = levelConditions[i + 2];
                                doorDir = new Point(-1, 0);
                                if (doorTypeChar == 'K')
                                {
                                    doorType = DoorType.Key;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                if (doorTypeChar == 'X')
                                {
                                    doorType = DoorType.Closed;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                if (doorTypeChar == 'H')
                                {
                                    doorType = DoorType.Hole;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                i += 3;
                            }
                            else if (ch == 'R')
                            {
                                char doorTypeChar = levelConditions[i + 2];
                                doorDir = new Point(1, 0);
                                if (doorTypeChar == 'K')
                                {
                                    doorType = DoorType.Key;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                if (doorTypeChar == 'X')
                                {
                                    doorType = DoorType.Closed;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                if (doorTypeChar == 'H')
                                {
                                    doorType = DoorType.Hole;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                i += 3;
                            }
                            else if (ch == 'S')
                            {

                            }
                            else if (ch == 'B')
                            {

                            }
                        }
                    }

                    newDungeon.AddLevel(new Point(x,y),level);
                }
                newDungeon.UpdateLevelDoors(Game1.gameScaleX, Game1.gameScaleY);

                newDungeon.SetCurrentLevel(new Point(0, 0));
                newDungeon.UpdateLevelContentPositions();

                dungeonDictionary.Add(dungeonName, newDungeon);
                Game1.instance.SetDungeon(newDungeon);
            }
        }
        public void ResetDungeon()
        {
            dungeonDictionary.Clear();
        }
    }
}

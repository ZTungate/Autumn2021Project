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

                    if(line.IndexOf("~") != -1)
                    {
                        level.displayInMinimap = false;
                    }
                    if (closedParen != -1)
                    {
                        string levelConditions = line.Substring(openParen + 1, closedParen - openParen - 1);

                        Point doorDir = Point.Zero;
                        DoorType doorType = DoorType.Open;
                        for (int i = 0; i < levelConditions.Length; i++)
                        {
                            char ch = levelConditions[i];
                            int doorTypePos = i + 2;
                            if (ch == 'U' || ch == 'D' || ch == 'L' || ch == 'R')
                            {
                                char doorTypeChar = 'K';
                                if (ch == 'U')
                                {
                                    doorTypeChar = levelConditions[i + 2];
                                    doorDir = new Point(0, 1);

                                    i += 2;
                                }
                                else if (ch == 'D')
                                {
                                    doorTypeChar = levelConditions[i + 2];
                                    doorDir = new Point(0, -1);
                                    i += 2;
                                }
                                else if (ch == 'L')
                                {
                                    doorTypeChar = levelConditions[i + 2];
                                    doorDir = new Point(-1, 0);

                                    i += 2;
                                }
                                else if (ch == 'R')
                                {
                                    doorTypeChar = levelConditions[i + 2];
                                    doorDir = new Point(1, 0);
                                    i += 2;
                                }

                                if (doorTypeChar == 'K')
                                {
                                    doorType = DoorType.Key;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                if (doorTypeChar == 'X')
                                {
                                    doorType = DoorType.RoomClear;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                if (doorTypeChar == 'H')
                                {
                                    doorType = DoorType.Hole;
                                    level.AddDoorCondition(doorDir, doorType);
                                }
                                if (doorTypeChar == 'B')
                                {
                                    doorType = DoorType.Closed;
                                    level.AddDoorCondition(doorDir, doorType);

                                    int firstComma = levelConditions.IndexOf(",", doorTypePos + 1);
                                    int secondComma = levelConditions.IndexOf(",", firstComma + 1);
                                    string dirToMoveX = levelConditions.Substring(doorTypePos + 1, firstComma - (doorTypePos + 1));
                                    string dirToMoveY = levelConditions.Substring(firstComma + 1, secondComma - firstComma - 1);
                                    int dirX = int.Parse(dirToMoveX);
                                    int dirY = int.Parse(dirToMoveY);

                                    Blocks.IBlock[] blocks = level.moveableBlockList.ToArray();
                                    foreach (Blocks.IBlock block in blocks)
                                    {
                                        if (block is Blocks.MoveableFloorBlock)
                                        {
                                            Blocks.MoveableFloorBlock moveBlock = (Blocks.MoveableFloorBlock)block;
                                            moveBlock.opensDoor = true;
                                            moveBlock.doorDirToOpen = doorDir;
                                            moveBlock.dirToMoveToOpen = new Point(dirX, dirY);
                                        }
                                    }
                                }
                            }
                            else if (ch == 'S')
                            {
                                int nextComma = levelConditions.IndexOf(",", i);
                                string levelX = levelConditions.Substring(i + 2, nextComma - (i + 2));
                                string levelY = levelConditions.Substring(nextComma + 1);
                                int levelXVal = int.Parse(levelX);
                                int levelYVal = int.Parse(levelY);
                                Blocks.IBlock[] blocks = level.GetBlockArray();
                                foreach (Blocks.IBlock block in blocks)
                                {
                                    if (block is Blocks.Stair)
                                    {
                                        Blocks.Stair stairBlock = (Blocks.Stair)block;
                                        stairBlock.referenceLevelPoint = new Point(levelXVal, levelYVal);
                                    }
                                }
                            }
                            else if (ch == 'Q')
                            {
                                int nextComma = levelConditions.IndexOf(",", i);
                                string customSpawnX = levelConditions.Substring(i + 2, nextComma - (i + 2));
                                string customSpawnY = levelConditions.Substring(nextComma + 1);
                                int spawnX = int.Parse(customSpawnX);
                                int spawnY = int.Parse(customSpawnY);
                                level.hasCustomSpawn = true;
                                level.customSpawnLocation = new Point((int)(spawnX * Blocks.AbstractBlock.BLOCK_SIZE_X), (int)(spawnY * Blocks.AbstractBlock.BLOCK_SIZE_Y));
                                i = levelConditions.Length - 1;
                            }
                            else if (ch == 'Y')
                            {
                                int nextComma = levelConditions.IndexOf(",", i);
                                int finalComma = levelConditions.IndexOf(",", nextComma + 1);
                                string backSpawnX = levelConditions.Substring(i + 2, nextComma - (i + 2));
                                string backSpawnY = levelConditions.Substring(nextComma + 1, finalComma - nextComma - 1);
                                int spawnX = int.Parse(backSpawnX);
                                int spawnY = int.Parse(backSpawnY);
                                level.hasCustomSpawn = true;
                                level.returnSpawn = new Point((int)(spawnX * Blocks.AbstractBlock.BLOCK_SIZE_X), (int)(spawnY * Blocks.AbstractBlock.BLOCK_SIZE_Y));

                                i = finalComma;
                            }
                            else if (ch == 'P')
                            {
                                int nextComma = levelConditions.IndexOf(",", i);
                                int finalComma = levelConditions.IndexOf(",", nextComma + 1);
                                string backLevelX = levelConditions.Substring(i + 2, nextComma - (i + 2));
                                string backLevelY = levelConditions.Substring(nextComma + 1, finalComma - nextComma - 1);
                                int backX = int.Parse(backLevelX);
                                int backY = int.Parse(backLevelY);
                                level.hasCustomSpawn = true;
                                level.returnLevelPoint = new Point(backX, backY);

                                i = finalComma;
                            }
                            else if(ch == 'W')
                            {
                                string textString = levelConditions.Substring(i + 2);
                                TextSprite textSprite = new TextSprite(UI.HUDSpriteFactory.instance.hudFont, textString, Color.White, level.GetPosition() + new Point(4 * Blocks.AbstractBlock.BLOCK_SIZE_X, 2 * Blocks.AbstractBlock.BLOCK_SIZE_Y));
                                textSprite.IsUISprite = false;
                                level.textList.Add(textSprite);
                                i = levelConditions.Length;
                            }
                        }
                    }

                    newDungeon.AddLevel(new Point(x,y),level);
                }
                newDungeon.UpdateLevelDoors(Game1.gameScaleX, Game1.gameScaleY);
                newDungeon.ConstructLevelBounds();

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

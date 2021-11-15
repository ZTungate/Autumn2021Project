using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Levels.Sprites;
using Poggus;

namespace Poggus.Levels
{
    public class Dungeon
    {
        public static float screnScaleX, screenScaleY;

        string dungeonName;
        Dictionary<Point, Level> levelDictionary = new Dictionary<Point, Level>();
        Point currentLevelPoint;
        Level currentLevel;
        int levelWidth, levelHeight;
        public Dungeon(string name, int levelWidth, int levelHeight)
        {
            this.dungeonName = name;
            this.levelWidth = levelWidth;
            this.levelHeight = levelHeight;
        }
        public Dictionary<Point, Level> GetLevelDictionary()
        {
            return this.levelDictionary;
        }
        public static Point[] directions = { new Point(0, 1), new Point(1, 0), new Point(0, -1), new Point(-1, 0) };
        public static Dictionary<Point, DoorDirectionEnum> doorDir = new Dictionary<Point, DoorDirectionEnum>
        {
            {directions[0],DoorDirectionEnum.Up},
            {directions[1],DoorDirectionEnum.Right},
            {directions[2],DoorDirectionEnum.Down},
            {directions[3],DoorDirectionEnum.Left},
        };
        public void UpdateLevelDoors(float scaleX, float scaleY)
        {
            foreach(KeyValuePair<Point,Level> entry in levelDictionary)
            {
                foreach (Point dir in directions) 
                {
                    if (levelDictionary.ContainsKey(entry.Key + dir))
                    {
                        Vector2 doorPos = Vector2.Zero;
                        int scaledDoorWidth = (int)(DoorFactory.instance.doorSize.X * scaleX);
                        int scaledDoorHeight = (int)(DoorFactory.instance.doorSize.Y * scaleY);
                        if (dir == new Point(0, 1))
                        {
                            doorPos = new Vector2(Game1.instance._graphics.PreferredBackBufferWidth / 2f - scaledDoorWidth / 2, 0);
                        }
                        if (dir == new Point(1, 0))
                        {
                            doorPos = new Vector2(Game1.instance._graphics.PreferredBackBufferWidth - DoorFactory.instance.doorSize.X * scaleX, Game1.instance._graphics.PreferredBackBufferHeight/2f - scaledDoorHeight / 2);
                        }
                        if (dir == new Point(0, -1))
                        {
                            doorPos = new Vector2(Game1.instance._graphics.PreferredBackBufferWidth/2f - scaledDoorWidth / 2, Game1.instance._graphics.PreferredBackBufferHeight - DoorFactory.instance.doorSize.Y * scaleY);
                        }
                        if (dir == new Point(-1, 0))
                        {
                            doorPos = new Vector2(0, Game1.instance._graphics.PreferredBackBufferHeight / 2f - scaledDoorHeight/2);
                        }
                        entry.Value.AddDoor(DoorFactory.instance.GetNewOpenDoor(doorPos.ToPoint(), new Point(scaledDoorWidth, scaledDoorHeight), doorDir[dir]), doorDir[dir]);
                    }
                }
            }
        }
        public void UpdateCurrent(GameTime gameTime)
        {
            currentLevel.Update(gameTime);
        }
        public void SwitchLevel(Point direction)
        {
            Point nextLevelPoint = currentLevelPoint + direction;
            if (levelDictionary.ContainsKey(nextLevelPoint))
            {
                SetCurrentLevel(nextLevelPoint);
            }
        }
        public void UpdateLevelContentPositions(Point direction)
        {
            foreach (KeyValuePair<Point, Level> entry in levelDictionary)
            {
                entry.Value.UpdateContentPosition(direction);
            }
        }
        public void UpdateLevelContentPositions()
        {
            foreach(KeyValuePair<Point,Level> entry in levelDictionary)
            {
                entry.Value.UpdateContentPosition(new Point(entry.Key.X * levelWidth, entry.Key.Y * levelHeight));
            }
        }
        public void SetCurrentLevel(Point levelPoint)
        {
            Point dir = levelPoint - currentLevelPoint;
            currentLevelPoint = levelPoint;
            this.currentLevel = levelDictionary[levelPoint];
            UpdateLevelContentPositions(new Point(-dir.X * levelWidth, -dir.Y * levelHeight));
        }
        public Level GetCurrentLevel()
        {
            return this.currentLevel;
        }
        public bool AddLevel(Point p, Level level)
        {
            return this.levelDictionary.TryAdd(p, level);
        }
        public void DrawCurrent(SpriteBatch batch)
        {
            this.currentLevel.Draw(batch);
        }
        public void DrawAll(SpriteBatch batch)
        {
            foreach(KeyValuePair<Point,Level> entry in levelDictionary)
            {
                entry.Value.Draw(batch);
            }
        }
    }
}

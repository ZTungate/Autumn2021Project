using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Levels
{
    public class Dungeon
    {
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
        public void UpdateLevelContentPositions()
        {
            foreach(KeyValuePair<Point,Level> entry in levelDictionary)
            {
                entry.Value.UpdateContentPosition(new Point(entry.Key.X * levelWidth, entry.Key.Y * levelHeight));
            }
        }
        public void SetCurrentLevel(Point levelPoint)
        {
            currentLevelPoint = levelPoint;
            this.currentLevel = levelDictionary[levelPoint];
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

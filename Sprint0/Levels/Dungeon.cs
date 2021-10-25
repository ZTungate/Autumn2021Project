using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint0.Levels
{
    public class Dungeon
    {
        Dictionary<Point, Level> levelDictionary = new Dictionary<Point, Level>();
        Level currentLevel;
        public Dungeon()
        {

        }
        public Level GetCurrentLevel()
        {
            return this.currentLevel;
        }
        public void LoadDungeon()
        {

        }
    }
}

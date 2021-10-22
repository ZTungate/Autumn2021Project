using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using Microsoft.Xna.Framework;
using LevelCreator.LevelObjects;
using Microsoft.Xna.Framework.Graphics;

namespace LevelCreator
{
    public class Level
    {
        private string levelName;
        Dictionary<Point, LevelObject> blocks;
        public Level(string levelName)
        {
            this.levelName = levelName;
            blocks = new Dictionary<Point, LevelObject>();
        }
        public void Draw(SpriteBatch batch)
        {
            foreach(KeyValuePair<Point,LevelObject> entry in blocks)
            {
                entry.Value.Draw(batch);
            }
        }
        public bool AddBlock(Point pos, LevelObject levelObj)
        {
            return blocks.TryAdd(pos, levelObj);
        }
        public bool RemoveBlock(Point pos)
        {
            return blocks.Remove(pos);
        }
        public KeyValuePair<Point,LevelObject> GetEntryContainingPosition(Point p)
        {
            foreach(KeyValuePair<Point, LevelObject> entry in blocks)
            {
                if (entry.Value.IsPointOver(p)) return entry;
            }
            return new KeyValuePair<Point, LevelObject>(new Point(0,0), null);
        }
        public void GenerateLevelXml()
        {
            /*FileStream stream = File.Create(outputLocation + levelName + ".xml");
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = XmlWriter.Create(stream, settings);*/
            StreamWriter writer = File.CreateText(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "\\Levels\\" + levelName + ".data");
            foreach(KeyValuePair<Point, LevelObject> entry in blocks)
            {
                writer.WriteLine(entry.Value.GetInfo().GetName() + "=" + entry.Key.X + "," + entry.Key.Y);
            }
            writer.Close();
        }
    }
}

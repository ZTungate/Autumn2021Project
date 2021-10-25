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
        List<LevelObject> enemies;
        List<LevelObject> items;
        public Level(string levelName)
        {
            this.levelName = levelName;
            blocks = new Dictionary<Point, LevelObject>();
            items = new List<LevelObject>();
            enemies = new List<LevelObject>();
        }
        public void Draw(SpriteBatch batch)
        {
            foreach(KeyValuePair<Point,LevelObject> entry in blocks)
            {
                entry.Value.Draw(batch, 0.0f);
            }
            foreach(LevelObject levelObject in enemies)
            {
                levelObject.Draw(batch, 0.1f);
            }
            foreach(LevelObject levelObject in items)
            {
                levelObject.Draw(batch, 0.2f);
            }
        }
        public void AddItem(LevelObject item)
        {
            this.items.Add(item);
        }
        public void AddEnemy(LevelObject enemy)
        {
            this.enemies.Add(enemy);
        }
        public bool AddBlock(Point pos, LevelObject levelObj)
        {
            return blocks.TryAdd(pos, levelObj);
        }
        public bool RemoveBlock(Point pos)
        {
            return blocks.Remove(pos);
        }
        public bool RemoveItem(Point pos)
        {
            for(int i = items.Count - 1; i >= 0; i--)
            {
                LevelObject item = items[i];
                if (item.GetRectangle().Contains(pos))
                {
                    items.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public bool RemoveEnemy(Point pos)
        {
            for (int i = enemies.Count-1; i >= 0; i--)
            {
                LevelObject enemy = enemies[i];
                if (enemy.GetRectangle().Contains(pos))
                {
                    enemies.RemoveAt(i);
                    return true;
                }
            }
            return false;
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
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            XmlWriter writer = XmlWriter.Create(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "\\Levels\\" + levelName + ".xml", settings);

            writer.WriteStartElement(null, "root", levelName);

            writer.WriteStartElement(null, "Blocks", null);
            foreach (KeyValuePair<Point, LevelObject> entry in blocks)
            {
                writer.WriteStartElement(null, "Block", null);
                writer.WriteElementString("Object", entry.Value.GetInfo().GetName());
                writer.WriteElementString("Location", entry.Key.X/3 + "," + entry.Key.Y/3);
                writer.WriteElementString("Conditions"," ");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement(null, "Items", null);
            foreach (LevelObject item in items)
            {
                writer.WriteStartElement(null, "Item", null);
                writer.WriteElementString("Object", item.GetInfo().GetName());
                writer.WriteElementString("Location", item.GetX()/3 + "," + item.GetY()/3);
                writer.WriteElementString("Conditions", " ");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement(null, "Enemies", null);
            foreach (LevelObject enemy in enemies)
            {
                writer.WriteStartElement(null, "Enemy", null);
                writer.WriteElementString("Object", enemy.GetInfo().GetName());
                writer.WriteElementString("Location", enemy.GetX()/3 + "," + enemy.GetY()/3);
                writer.WriteElementString("Conditions", " ");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteEndElement();

            writer.Close();
        }
    }
}

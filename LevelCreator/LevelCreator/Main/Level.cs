using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using Microsoft.Xna.Framework;
using LevelCreator.LevelObjects;
using Microsoft.Xna.Framework.Graphics;
using LevelCreator.Sprites;
using LevelCreator.Sprites.Factories;

namespace LevelCreator
{
    public class Level
    {
        ISprite background;
        private string levelName;
        Dictionary<Point, LevelObject> blocks;
        List<LevelObject> enemies;
        List<LevelObject> items;
        List<LineSprite> bounds;
        public Level(string levelName)
        {
            background = GeneralFactory.instance.GetBackground();
            this.levelName = levelName;
            blocks = new Dictionary<Point, LevelObject>();
            items = new List<LevelObject>();
            enemies = new List<LevelObject>();
            bounds = new List<LineSprite>();
        }
        public void Draw(SpriteBatch batch)
        {
            background.Draw(batch, new Rectangle(0, 0, 256 * 3, 176 * 3));

            foreach (KeyValuePair<Point,LevelObject> entry in blocks)
            {
                entry.Value.Draw(batch);
            }
            foreach (LevelObject levelObject in items)
            {
                levelObject.Draw(batch);
            }
            foreach (LevelObject levelObject in enemies)
            {
                levelObject.Draw(batch);
            }
            foreach(LineSprite line in bounds)
            {
                line.Draw(batch, new Rectangle(0, 0, 4, 0));
            }
        }
        public List<LineSprite> GetBoundList()
        {
            return this.bounds;
        }
        public void AddBound(LineSprite bound)
        {
            this.bounds.Add(bound);
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
        public void GenerateLevelXml(string name)
        {
            this.levelName = name;

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
                writer.WriteElementString("Location", item.GetX() / 3 + "," + item.GetY() / 3);
                writer.WriteElementString("Conditions", " ");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteStartElement(null, "Enemies", null);
            foreach (LevelObject enemy in enemies)
            {
                writer.WriteStartElement(null, "Enemy", null);
                writer.WriteElementString("Object", enemy.GetInfo().GetName());
                writer.WriteElementString("Location", enemy.GetX() / 3 + "," + enemy.GetY() / 3);
                writer.WriteElementString("Conditions", " ");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();

            writer.WriteEndElement();

            writer.Close();
        }
        public static Level LoadLevel(string levelName)
        {
            string dir = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            XmlReaderSettings settings = new XmlReaderSettings();
            FileStream stream;
            try
            {
                stream = File.OpenRead(dir + "\\Levels\\" + levelName + ".xml");
            }
            catch(Exception e)
            {
                return null;
            }
            XmlReader reader = XmlReader.Create(stream);

            reader.ReadToDescendant("root");
            string levelNameFromFile = reader.GetAttribute("xmlns");
            Level newLevel = new Level(levelNameFromFile);

            while (reader.Read())
            {
                if (reader.IsStartElement() && reader.Name == "Block")
                {
                    reader.ReadToDescendant("Object");
                    string blockName = reader.ReadElementContentAsString();

                    reader.ReadToDescendant("Location");
                    reader.MoveToContent();
                    string location = reader.ReadElementContentAsString();
                    int commaLoc = location.IndexOf(",");
                    string xString = location.Substring(0, commaLoc);
                    string yString = location.Substring(commaLoc + 1);
                    int x = int.Parse(xString) * 3;
                    int y = int.Parse(yString) * 3;

                    reader.ReadToDescendant("Conditions");
                    reader.MoveToContent();
                    string conditions = reader.ReadElementContentAsString();

                    LevelObjectInfo info = LevelObjectFactory.instance.GetLevelObjectInfo(blockName);
                    LevelObject levelObject = LevelObjectFactory.instance.CreateNewLevelObject(blockName, new Rectangle(x, y, info.GetSourceRectangle().Width * 3, info.GetSourceRectangle().Height * 3));
                    newLevel.AddBlock(new Point(x,y), levelObject);
                }
                if (reader.IsStartElement() && reader.Name == "Item")
                {
                    reader.ReadToDescendant("Object");
                    string itemName = reader.ReadElementContentAsString();

                    reader.ReadToDescendant("Location");
                    reader.MoveToContent();
                    string location = reader.ReadElementContentAsString();
                    int commaLoc = location.IndexOf(",");
                    string xString = location.Substring(0, commaLoc);
                    string yString = location.Substring(commaLoc + 1);
                    int x = int.Parse(xString) * 3;
                    int y = int.Parse(yString) * 3;

                    reader.ReadToDescendant("Conditions");
                    reader.MoveToContent();
                    string conditions = reader.ReadElementContentAsString();

                    LevelObjectInfo info = LevelObjectFactory.instance.GetLevelObjectInfo(itemName);
                    LevelObject levelObject = LevelObjectFactory.instance.CreateNewLevelObject(itemName, new Rectangle(x, y, info.GetSourceRectangle().Width * 3, info.GetSourceRectangle().Height * 3));
                    newLevel.AddItem(levelObject);
                }
                if (reader.IsStartElement() && reader.Name == "Enemy")
                {
                    reader.ReadToDescendant("Object");
                    string enemyName = reader.ReadElementContentAsString();

                    reader.ReadToDescendant("Location");
                    reader.MoveToContent();
                    string location = reader.ReadElementContentAsString();
                    int commaLoc = location.IndexOf(",");
                    string xString = location.Substring(0, commaLoc);
                    string yString = location.Substring(commaLoc + 1);
                    int x = int.Parse(xString) * 3;
                    int y = int.Parse(yString) * 3;

                    reader.ReadToDescendant("Conditions");
                    reader.MoveToContent();
                    string conditions = reader.ReadElementContentAsString();

                    LevelObjectInfo info = LevelObjectFactory.instance.GetLevelObjectInfo(enemyName);
                    LevelObject levelObject = LevelObjectFactory.instance.CreateNewLevelObject(enemyName, new Rectangle(x, y, info.GetSourceRectangle().Width * 3, info.GetSourceRectangle().Height * 3));
                    newLevel.AddEnemy(levelObject);
                }
                reader.MoveToElement();
            }
            return newLevel;
        }
    }
}

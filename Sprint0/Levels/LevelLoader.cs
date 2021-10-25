using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Sprint2.Blocks;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using Sprint2;
using Microsoft.Xna.Framework.Content;

namespace Sprint0.Levels
{
    public class LevelLoader
    {
        public static LevelLoader instance = new LevelLoader();
        private ISprite defaultBackground;
        private Dictionary<string, Level> levels = new Dictionary<string, Level>();
        public void LoadAllLevels(ContentManager content)
        {
            defaultBackground = new BackgroundSprite(content.Load<Texture2D>("BlockSpriteSheet"));
            defaultBackground.Position = new Vector2(0, 0);

            string dir = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string[] fileNames = Directory.GetFiles(dir + "\\Levels");
            XmlReaderSettings settings = new XmlReaderSettings();

            foreach (string fileName in fileNames)
            {
                Level newLevel = new Level(null, Point.Zero);

                XmlReader reader = XmlReader.Create(File.OpenRead(fileName), settings);
                reader.ReadToDescendant("root");
                string levelName = reader.GetAttribute("xmlns");
                System.Diagnostics.Debug.WriteLine(levelName);

                while (reader.Read())
                {
                    if (reader.IsStartElement() && reader.Name == "Block")
                    {
                        System.Diagnostics.Debug.Write("Block: ");
                        reader.ReadToDescendant("Object");
                        string blockName = reader.ReadElementContentAsString();
                        blockName += "Sprite";

                        reader.ReadToDescendant("Location");
                        reader.MoveToContent();
                        string location = reader.ReadElementContentAsString();
                        int commaLoc = location.IndexOf(",");
                        string xString = location.Substring(0, commaLoc);
                        string yString = location.Substring(commaLoc + 1);
                        int x = int.Parse(xString);
                        int y = int.Parse(yString);

                        reader.ReadToDescendant("Conditions");
                        reader.MoveToContent();
                        string conditions = reader.ReadElementContentAsString();

                        Object[] objectParams = new Object[2];
                        objectParams[0] = BlockSpriteFactory.Instance.GetBlockSpriteSheet();
                        objectParams[1] = new Vector2(x * 2, y * 2);

                        Type objectType = Type.GetType("Sprint2.Blocks." + blockName);
                        object instance = Activator.CreateInstance(objectType, objectParams);

                        newLevel.AddBlock(new Point(x,y), (IBlock)instance);
                    }
                    if (reader.IsStartElement() && reader.Name == "Item")
                    {
                        System.Diagnostics.Debug.Write("Item: ");
                        reader.ReadToDescendant("Object");
                        System.Diagnostics.Debug.Write(reader.ReadElementContentAsString() + "   ");

                        reader.ReadToDescendant("Location");
                        reader.MoveToContent();
                        System.Diagnostics.Debug.Write(reader.ReadElementContentAsString() + "   ");

                        reader.ReadToDescendant("Conditions");
                        reader.MoveToContent();
                        System.Diagnostics.Debug.Write(reader.ReadElementContentAsString() + "\n");

                        //newLevel.AddItem();

                    }
                    if (reader.IsStartElement() && reader.Name == "Enemy")
                    {
                        System.Diagnostics.Debug.Write("Enemy: ");
                        reader.ReadToDescendant("Object");
                        System.Diagnostics.Debug.Write(reader.ReadElementContentAsString() + "   ");

                        reader.ReadToDescendant("Location");
                        reader.MoveToContent();
                        System.Diagnostics.Debug.Write(reader.ReadElementContentAsString() + "   ");

                        reader.ReadToDescendant("Conditions");
                        reader.MoveToContent();
                        System.Diagnostics.Debug.Write(reader.ReadElementContentAsString() + "\n");

                        //newLevel.AddEnemy();
                    }
                    reader.MoveToElement();
                }

                levels.Add(levelName, newLevel);
            }
        }
        public void DrawLevels(SpriteBatch batch)
        {
            defaultBackground.Draw(batch);
            foreach(KeyValuePair<string, Level> entry in levels)
            {
                entry.Value.Draw(batch);
            }
        }
    }
}

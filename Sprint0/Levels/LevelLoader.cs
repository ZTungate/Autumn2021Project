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
                        float scaleX = (float)Game1.instance._graphics.PreferredBackBufferWidth / defaultBackground.SourceRect[0].Width;
                        float scaleY = (float)Game1.instance._graphics.PreferredBackBufferHeight / defaultBackground.SourceRect[0].Height;
                        objectParams[1] = new Vector2(x * scaleX, y * scaleY);

                        Type objectType = Type.GetType("Sprint2.Blocks." + blockName);
                        object instance = Activator.CreateInstance(objectType, objectParams);
                        IBlock newBlock = (IBlock)instance;
                        newBlock.destRect = new Rectangle(newBlock.destRect.X, newBlock.destRect.Y, (int)(newBlock.sourceRect.Width*scaleX), (int)(newBlock.sourceRect.Height*scaleY));

                        newLevel.AddBlock(new Point(x,y), newBlock);
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
        public Level GetLevel(string name)
        {
            Level outLevel;
            levels.TryGetValue(name, out outLevel);
            return outLevel;
        }
        public void DrawLevels(SpriteBatch batch)
        {
            foreach(KeyValuePair<string, Level> entry in levels)
            {
                entry.Value.Draw(batch);
            }
        }
        public ISprite GetBackgroundSprite()
        {
            return this.defaultBackground;
        }
    }
}

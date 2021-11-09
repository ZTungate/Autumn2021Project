using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Poggus.Blocks;
using Microsoft.Xna.Framework.Graphics;
using System.Xml;
using Poggus;
using Microsoft.Xna.Framework.Content;
using Poggus.Items;
using Poggus.Enemies;
using Poggus.Player;

namespace Poggus.Levels
{
    public class LevelLoader
    {
        public static LevelLoader instance = new LevelLoader();
        public float gameScaleX, gameScaleY;
        private Texture2D blockSpriteSheet;
        private Dictionary<string, Level> levels = new Dictionary<string, Level>();
        public void LoadAllLevels(ContentManager content)
        {
            blockSpriteSheet = content.Load<Texture2D>("BlockSpriteSheet");

            BackgroundSprite defaultBackground = new BackgroundSprite(blockSpriteSheet);

            string dir = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            string[] fileNames = Directory.GetFiles(dir + "\\Levels");
            XmlReaderSettings settings = new XmlReaderSettings();

            gameScaleX = (float)Game1.instance._graphics.PreferredBackBufferWidth / defaultBackground.SourceRect[0].Width;
            gameScaleY = (float)Game1.instance._graphics.PreferredBackBufferHeight / defaultBackground.SourceRect[0].Height;

            foreach (string fileName in fileNames)
            {
                Level newLevel = new Level(Game1.instance.link, Point.Zero);

                XmlReader reader = XmlReader.Create(File.OpenRead(fileName), settings);
                reader.ReadToDescendant("root");
                string levelName = reader.GetAttribute("xmlns");

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
                        int x = int.Parse(xString);
                        int y = int.Parse(yString);

                        reader.ReadToDescendant("Conditions");
                        reader.MoveToContent();
                        string conditions = reader.ReadElementContentAsString();

                        Object[] objectParams = new Object[1];
                        float scaleX = (float)Game1.instance._graphics.PreferredBackBufferWidth / defaultBackground.SourceRect[0].Width;
                        float scaleY = (float)Game1.instance._graphics.PreferredBackBufferHeight / defaultBackground.SourceRect[0].Height;
                        objectParams[0] = new Point((int)(x * scaleX), (int)(y * scaleY));
                        Type objectType = Type.GetType("Poggus.Blocks." + blockName);
                        object instance = Activator.CreateInstance(objectType, objectParams);
                        AbstractBlock newBlock = (AbstractBlock)instance;
                        newBlock.CreateSprite();
                        
                        //create sprite

                        newLevel.AddBlock(new Point(x,y), newBlock);
                    }
                    if (reader.IsStartElement() && reader.Name == "Item")
                    {
                        reader.ReadToDescendant("Object");
                        string itemName = reader.ReadElementContentAsString();
                        itemName += "Item";

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

                        Object[] objectParams = new Object[1];
                        float scaleX = (float)Game1.instance._graphics.PreferredBackBufferWidth / defaultBackground.SourceRect[0].Width;
                        float scaleY = (float)Game1.instance._graphics.PreferredBackBufferHeight / defaultBackground.SourceRect[0].Height;
                        objectParams[0] = new Rectangle((int)(x * scaleX), (int)(y * scaleY), (int)(16*scaleX), (int)(16*scaleY));
                        Type itemType = Type.GetType("Poggus.Items." + itemName);
                        object instance = Activator.CreateInstance(itemType, objectParams);
                        AbstractItem item = (AbstractItem)instance;
                        item.CreateSprite(scaleX, scaleY);

                        newLevel.AddItem(item);
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
                        int x = int.Parse(xString);
                        int y = int.Parse(yString);

                        reader.ReadToDescendant("Conditions");
                        reader.MoveToContent();
                        string conditions = reader.ReadElementContentAsString();

                        Object[] objectParams = new Object[1];
                        float scaleX = (float)Game1.instance._graphics.PreferredBackBufferWidth / defaultBackground.SourceRect[0].Width;
                        float scaleY = (float)Game1.instance._graphics.PreferredBackBufferHeight / defaultBackground.SourceRect[0].Height;
                        objectParams[0] = new Point((int)(x * scaleX), (int)(y*scaleY));
                        Type enemyType = Type.GetType("Poggus.Enemies." + enemyName);
                        object instance = Activator.CreateInstance(enemyType, objectParams);
                        IEnemy enemy = (IEnemy)instance;
                        enemy.Sprite = EnemySpriteFactory.Instance.MakeSprite(enemy);

                        EnemyConstants.scaleX = scaleX;
                        EnemyConstants.scaleY = scaleY;

                        newLevel.AddEnemy(enemy);
                    }
                    if (reader.IsStartElement() && reader.Name == "Bound")
                    {
                        float scaleX = (float)Game1.instance._graphics.PreferredBackBufferWidth / defaultBackground.SourceRect[0].Width;
                        float scaleY = (float)Game1.instance._graphics.PreferredBackBufferHeight / defaultBackground.SourceRect[0].Height;

                        LinkConstants.scaleX = scaleX;
                        LinkConstants.scaleY = scaleY;

                        reader.ReadToDescendant("Start");
                        reader.MoveToContent();
                        string location = reader.ReadElementContentAsString();
                        int commaLoc = location.IndexOf(",");
                        string xString = location.Substring(0, commaLoc);
                        string yString = location.Substring(commaLoc + 1);
                        int startX = (int)(int.Parse(xString) * scaleX);
                        int startY = (int)(int.Parse(yString) * scaleY);

                        reader.ReadToDescendant("End");
                        reader.MoveToContent();
                        location = reader.ReadElementContentAsString();
                        commaLoc = location.IndexOf(",");
                        xString = location.Substring(0, commaLoc);
                        yString = location.Substring(commaLoc + 1);
                        int endX = (int)(int.Parse(xString) * scaleX);
                        int endY = (int)(int.Parse(yString) * scaleY);

                        newLevel.AddNewBoundingBox(new Point(startX, startY), new Point(endX, endY));
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
        public ISprite GetNewBackgroundSprite()
        {
            return new BackgroundSprite(blockSpriteSheet);
        }
    }
}

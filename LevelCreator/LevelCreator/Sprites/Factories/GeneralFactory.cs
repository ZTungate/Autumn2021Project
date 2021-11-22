using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace LevelCreator.Sprites.Factories
{
    public class GeneralFactory
    {
        public static GeneralFactory instance = new GeneralFactory();
        ISprite background;
        ISprite textFieldSprite;
        ISprite buttonSprite;
        Texture2D whiteSquare;
        SpriteFont font;
        Dictionary<string, Texture2D> spriteSheets = new Dictionary<string, Texture2D>();
        public Texture2D GetSpriteSheet(string name)
        {
            Texture2D outTex;
            spriteSheets.TryGetValue(name, out outTex);
            return outTex;
        }
        public virtual void LoadAllContent(ContentManager content)
        {
            //spriteSheet = content.Load<Texture2D>(imageName);
            font = content.Load<SpriteFont>("Arial");
            spriteSheets.Add("BLOCKSPRITESHEET",content.Load<Texture2D>("BlockSpriteSheet"));
            spriteSheets.Add("ENEMYSPRITESHEET", content.Load<Texture2D>("EnemySpriteSheet"));
            spriteSheets.Add("BOSSSPRITESHEET", content.Load<Texture2D>("BossSpriteSheet"));
            spriteSheets.Add("ITEMSPRITESHEET", content.Load<Texture2D>("ItemSpriteSheet"));
            spriteSheets.Add("NPCSPRITESHEET", content.Load<Texture2D>("NPCSpriteSheet"));

            whiteSquare = content.Load<Texture2D>("WhiteSquare");


            buttonSprite = new ConcreteSprite(content.Load<Texture2D>("BlockSpriteSheet"), new Rectangle(0,0,1,1), Color.White);
            textFieldSprite = new ConcreteSprite(content.Load<Texture2D>("BlockSpriteSheet"), new Rectangle(625, 517, 1, 1), Color.White);
            background = new ConcreteSprite(content.Load<Texture2D>("BlockSpriteSheet"), new Rectangle(1, 178, 256, 176), Color.White);
        }
        public ISprite GenerateSprite(string spriteSheet, Rectangle sourceRectangle)
        {
            return new ConcreteSprite(spriteSheets[spriteSheet], sourceRectangle, Color.White);
        }
        public ISprite GetBackground()
        {
            return this.background;
        }
        public ISprite GetTextFieldSprite()
        {
            return this.textFieldSprite;
        }
        public SpriteFont GetFont()
        {
            return font;
        }
        public ISprite GetButtonSprite()
        {
            return this.buttonSprite;
        }
        public Texture2D GetWhiteSquare()
        {
            return this.whiteSquare;
        }
    }
}

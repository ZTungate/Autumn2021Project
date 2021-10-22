using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using LevelCreator.LevelObjects;
using Microsoft.Xna.Framework;


namespace LevelCreator.Sprites
{
    abstract class AbstractSpriteFactory
    {
        protected Texture2D spriteSheet;
        protected string imageName;

        private Dictionary<string, ISprite> spriteDictionary;

        protected AbstractSpriteFactory(string imageName)
        {
            spriteDictionary = new Dictionary<string, ISprite>();
            this.imageName = imageName;
        }

        public virtual void LoadAllTextures(ContentManager content)
        {
            spriteSheet = content.Load<Texture2D>(imageName);
            AddAllSprites();
        }
        public virtual void AddAllSprites()
        {
            //no-op
        }
        public bool AddSprite(string levelObject, ISprite sprite)
        {
            return spriteDictionary.TryAdd(levelObject, sprite);
        }
        public ISprite GetSprite(string levelObject)
        {
            ISprite outSprite;
            spriteDictionary.TryGetValue(levelObject, out outSprite);
            return outSprite;
        }
    }
}

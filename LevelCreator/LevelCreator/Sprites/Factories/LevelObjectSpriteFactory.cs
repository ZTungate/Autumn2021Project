using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using LevelCreator.LevelObjects;

namespace LevelCreator.Sprites
{
    class LevelObjectSpriteFactory : AbstractSpriteFactory
    {
        protected static AbstractSpriteFactory instance = new LevelObjectSpriteFactory();
        public static AbstractSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LevelObjectSpriteFactory() : base("BlockSpriteSheet")
        {

        }
        public override void AddAllSprites()
        {
            //AddSprite(LevelObjectEnum.StairBlock, new StairSprite(spriteSheet, new Point(32,32)));
        }
    }
}

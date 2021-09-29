using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class LinkSpriteFactory
    {
        private Texture2D linkSpriteSheet;

        private static LinkSpriteFactory instance = new LinkSpriteFactory();

        public static LinkSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private LinkSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            linkSpriteSheet = content.Load<Texture2D>("LinkSpriteSheet");
        }

        //TODO Add CreateSprite methods for each enemy type
        public ISprite CreateSkeletonSprite()
        {
            return new SkeletonSprite(linkSpriteSheet);
        }

        public ISprite CreateSlimeSprite()
        {
            return new SlimeSprite(linkSpriteSheet);
        }
    }
}

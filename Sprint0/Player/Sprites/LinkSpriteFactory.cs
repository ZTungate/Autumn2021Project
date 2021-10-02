using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
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
        public ISprite RightIdleLinkSprite(Vector2 linkPosition)
        {
            return new RightIdleLinkSprite(linkSpriteSheet, linkPosition);
        }

        public ISprite LeftIdleLinkSprite(Vector2 linkPosition)
        {
            return new LeftIdleLinkSprite(linkSpriteSheet, linkPosition);
        }

        public ISprite RightMovingLinkSprite(Vector2 linkPosition)
        {
            return new RightMovingLinkSprite(linkSpriteSheet, linkPosition);
        }

    }
}

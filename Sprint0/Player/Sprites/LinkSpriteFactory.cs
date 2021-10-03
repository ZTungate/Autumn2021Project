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

        //TODO Add CreateSprite methods for each Link Sprite type

        public ISprite UpIdleLinkSprite(Link player)
        {
            return new UpIdleLinkSprite(linkSpriteSheet, player);
        }
        public ISprite RightIdleLinkSprite(Link player)
        {
            return new RightIdleLinkSprite(linkSpriteSheet, player);
        }

        public ISprite LeftIdleLinkSprite(Link player)
        {
            return new LeftIdleLinkSprite(linkSpriteSheet, player);
        }

        public ISprite DownIdleLinkSprite(Link player)
        {
            return new DownIdleLinkSprite(linkSpriteSheet, player);
        }

        public ISprite UpMovingLinkSprite(Link player)
        {
            return new UpMovingLinkSprite(linkSpriteSheet, player);
        }

        public ISprite RightMovingLinkSprite(Link player)
        {
            return new RightMovingLinkSprite(linkSpriteSheet, player);
        }

        public ISprite LeftMovingLinkSprite(Link player)
        {
            return new LeftMovingLinkSprite(linkSpriteSheet, player);
        }

        public ISprite DownMovingLinkSprite(Link player)
        {
            return new DownMovingLinkSprite(linkSpriteSheet, player);
        }

        public ISprite RightUseItemLinkSprite(Link player)
        {
            return new RightUseItemLinkSprite(linkSpriteSheet, player);
        }

    }
}

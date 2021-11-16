using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Player
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

        public ISprite UpIdleLinkSprite(ILink player)
        {
            return new UpIdleLinkSprite(linkSpriteSheet, player);
        }
        public ISprite RightIdleLinkSprite(ILink player)
        {
            return new RightIdleLinkSprite(linkSpriteSheet, player);
        }

        public ISprite LeftIdleLinkSprite(ILink player)
        {
            return new LeftIdleLinkSprite(linkSpriteSheet, player);
        }

        public ISprite DownIdleLinkSprite(ILink player)
        {
            return new DownIdleLinkSprite(linkSpriteSheet, player);
        }

        public ISprite UpMovingLinkSprite(ILink player)
        {
            return new UpMovingLinkSprite(linkSpriteSheet, player);
        }

        public ISprite RightMovingLinkSprite(ILink player)
        {
            return new RightMovingLinkSprite(linkSpriteSheet, player);
        }

        public ISprite LeftMovingLinkSprite(ILink player)
        {
            return new LeftMovingLinkSprite(linkSpriteSheet, player);
        }

        public ISprite DownMovingLinkSprite(ILink player)
        {
            return new DownMovingLinkSprite(linkSpriteSheet, player);
        }

        public ISprite RightUseItemLinkSprite(ILink player)
        {
            return new RightUseItemLinkSprite(linkSpriteSheet, player);
        }
        public ISprite LeftUseItemLinkSprite(ILink player)
        {
            return new LeftUseItemLinkSprite(linkSpriteSheet, player);
        }

        public ISprite UpUseItemLinkSprite(ILink player)
        {
            return new UpUseItemLinkSprite(linkSpriteSheet, player);
        }
        public ISprite DownUseItemLinkSprite(ILink player)
        {
            return new DownUseItemLinkSprite(linkSpriteSheet, player);
        }
        public ISprite DownSwordLinkSprite(ILink player)
        {
            return new DownSwordLinkSprite(linkSpriteSheet, player);
        }

        public ISprite UpSwordLinkSprite(ILink player)
        {
            return new UpSwordLinkSprite(linkSpriteSheet, player);
        }

        public ISprite RightSwordLinkSprite(ILink player)
        {
            return new RightSwordLinkSprite(linkSpriteSheet, player);
        }

        public ISprite LeftSwordLinkSprite(ILink player)
        {
            return new LeftSwordLinkSprite(linkSpriteSheet, player);
        }
    }
}

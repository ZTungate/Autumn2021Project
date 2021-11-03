using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Items.ItemSprites;

namespace Sprint2.Items
{
    public class ItemSpriteFactory
    {
        private Texture2D itemSpriteSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        private Dictionary<ItemEnum, AbstractSprite> itemSpriteDictionary;

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {
            itemSpriteDictionary = new Dictionary<ItemEnum, AbstractSprite>();
        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("ItemSpriteSheet");
            //For each item in the enum add its corresponding item sprite class to the dictionary
            itemSpriteDictionary.Add(ItemEnum.Arrow, new ArrowSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Bomb, new BombItemSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Boomerang, new StationaryBoomerangSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Bow, new BowSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Clock, new ClockSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Compass, new CompassSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Fairy, new FairySprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.HeartContainer, new HeartContainerSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Heart, new HeartSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Key, new KeySprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Rupee, new RupeeSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.TriforcePiece, new TriforcePieceSprite(itemSpriteSheet));
        }
        public AbstractSprite GetItemSprite(ItemEnum item)
        {
            //Get corresponding item sprite of given item enum
            return itemSpriteDictionary[item];
        }
    }
}

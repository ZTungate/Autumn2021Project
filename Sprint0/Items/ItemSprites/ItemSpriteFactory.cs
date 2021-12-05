using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Items.ItemSprites;

namespace Poggus.Items.ItemSprites
{
    public class ItemSpriteFactory
    {
        private Texture2D itemSpriteSheet, npcSpriteSheet;

        private static ItemSpriteFactory instance = new ItemSpriteFactory();

        private Dictionary<ItemEnum, ISprite> itemSpriteDictionary;

        public static ItemSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private ItemSpriteFactory()
        {
            itemSpriteDictionary = new Dictionary<ItemEnum, ISprite>();
        }

        public void LoadAllTextures(ContentManager content)
        {
            itemSpriteSheet = content.Load<Texture2D>("ItemSpriteSheet");
            npcSpriteSheet = content.Load<Texture2D>("NPCSheet");
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
            itemSpriteDictionary.Add(ItemEnum.HalfHeart, new HalfHeartSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.EmptyHeart, new EmptyHeartSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Key, new KeySprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Rupee, new RupeeSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Sword, new SwordSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.TriforcePiece, new TriforcePieceSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Map, new MapItemSprite(itemSpriteSheet));
            itemSpriteDictionary.Add(ItemEnum.Fire, new FireItemSprite(npcSpriteSheet));

        }
        public ISprite GetItemSprite(ItemEnum item)
        {
            ISprite outSprite;
            itemSpriteDictionary.TryGetValue(item, out outSprite);
            if (outSprite != null)
            {
                Object[] objectParams = { outSprite.Texture };
                return (ISprite)Activator.CreateInstance(outSprite.GetType(), objectParams);
            }
            return null;
        }
    }
}

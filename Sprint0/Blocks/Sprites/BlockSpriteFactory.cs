using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Helpers;

namespace Poggus.Blocks.Sprites
{
    public class BlockSpriteFactory
    {
        public static BlockSpriteFactory instance = new BlockSpriteFactory();

        private Texture2D blockSpriteSheet;

        private Dictionary<BlockType, ISprite> blockSpriteDictionary = new Dictionary<BlockType, ISprite>();

        public static BlockSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private BlockSpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            blockSpriteSheet = content.Load<Texture2D>("BlockSpriteSheet"); //loads the texture atlas
            
            blockSpriteDictionary.Add(BlockType.BlackBox, new BlackBoxSprite(blockSpriteSheet));
            blockSpriteDictionary.Add(BlockType.EntryFloor, new EntryFloorSprite(blockSpriteSheet));
            blockSpriteDictionary.Add(BlockType.FloorBlock, new FloorBlockSprite(blockSpriteSheet));
            blockSpriteDictionary.Add(BlockType.Floor, new FloorSprite(blockSpriteSheet));
            blockSpriteDictionary.Add(BlockType.Ladder, new LadderSprite(blockSpriteSheet));
            blockSpriteDictionary.Add(BlockType.LeftStatue, new LeftStatueSprite(blockSpriteSheet));
            blockSpriteDictionary.Add(BlockType.MarioBrick, new MarioBrickSprite(blockSpriteSheet));
            blockSpriteDictionary.Add(BlockType.MoveableFloorBlock, new MoveableFloorBlockSprite(blockSpriteSheet));
            blockSpriteDictionary.Add(BlockType.RightStatue, new RightStatueSprite(blockSpriteSheet));
            blockSpriteDictionary.Add(BlockType.Stair, new StairSprite(blockSpriteSheet));
            blockSpriteDictionary.Add(BlockType.Water, new WaterSprite(blockSpriteSheet));

        }
        public ISprite GetBlockSprite(BlockType type)
        {
            ISprite outSprite;
            blockSpriteDictionary.TryGetValue(type, out outSprite);
            if (outSprite != null)
            {
                Object[] objectParams = { outSprite.Texture };
                return (ISprite)Activator.CreateInstance(outSprite.GetType(), objectParams);
            }
            return null;
        }
    }
}

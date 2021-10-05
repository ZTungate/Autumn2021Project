using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Helpers;

namespace Sprint2.Blocks
{
    public class BlockSpriteFactory
    {
        private Texture2D blockSpriteSheet;

        private List<IBlocks> blockList = new List<IBlocks>();

        private static int blockTracker;

        private static BlockSpriteFactory instance = new BlockSpriteFactory();
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
            //loads all the block sprites into a list
            blockList.Add(CreateFloorTile());
            blockList.Add(CreateBlackBox());
            blockList.Add(CreateEntryFloorTile());
            blockList.Add(CreateFloorBlockTile());
            blockList.Add(CreateLadderTile());
            blockList.Add(CreateLeftStatue());
            blockList.Add(CreateRightStatue());
            blockList.Add(CreateBrickTile());
            blockList.Add(CreateStairTile());
            blockList.Add(CreateWaterTile());
        }

        //returns the next sprite in the list
        public IBlocks NextSprite()
        {
            blockTracker++;
            return blockList[CustomMath.MathMod(blockTracker, blockList.Count)];
        }

        //returns the previous sprite in the list
        public IBlocks PreviousSprite()
        {
            blockTracker--;
            return blockList[CustomMath.MathMod(blockTracker, blockList.Count)];
        }

        //returns the current sprite
        public IBlocks CurrentSprite()
        {
            return blockList[blockTracker];
        }

        //resets the list to the initial state
        public void Reset()
        {
            blockTracker = 0;
        }

        //flowing methods return a sprite object for the block
        public IBlocks CreateBlackBox()
        {
            return new BlackBoxSprite(blockSpriteSheet, new Vector2(200, 300));
        }
        public IBlocks CreateEntryFloorTile()
        {
            return new EntryFloorSprite(blockSpriteSheet, new Vector2(200, 300));
        }
        public IBlocks CreateFloorBlockTile()
        {
            return new FloorBlockSprite(blockSpriteSheet, new Vector2(200, 300));
        }
        public IBlocks CreateLadderTile()
        {
            return new LadderSprite(blockSpriteSheet, new Vector2(200, 300));
        }
        public IBlocks CreateLeftStatue()
        {
            return new LeftStatueSprite(blockSpriteSheet, new Vector2(200, 300));
        }
        public IBlocks CreateRightStatue()
        {
            return new RightStatueSprite(blockSpriteSheet, new Vector2(200, 300));
        }
        public IBlocks CreateBrickTile()
        {
            return new MarioBrickSprite(blockSpriteSheet, new Vector2(200, 300));
        }
        public IBlocks CreateStairTile()
        {
            return new StairSprite(blockSpriteSheet, new Vector2(200, 300));
        }
        public IBlocks CreateWaterTile()
        {
            return new WaterSprite(blockSpriteSheet, new Vector2(200, 300));
        }
        public IBlocks CreateFloorTile()
        {
            return new FloorSprite(blockSpriteSheet, new Vector2(200, 300));
        }
    }
}

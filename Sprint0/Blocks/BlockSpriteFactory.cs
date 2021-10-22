using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint3.Helpers;

namespace Sprint3.Blocks
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
            blockList.Add(CreateFloorTile(new Vector2(200, 300)));
            blockList.Add(CreateBlackBox(new Vector2(200, 300)));
            blockList.Add(CreateEntryFloorTile(new Vector2(200, 300)));
            blockList.Add(CreateFloorBlockTile(new Vector2(200, 300)));
            blockList.Add(CreateLadderTile(new Vector2(200, 300)));
            blockList.Add(CreateLeftStatue(new Vector2(200, 300)));
            blockList.Add(CreateRightStatue(new Vector2(200, 300)));
            blockList.Add(CreateBrickTile(new Vector2(200, 300)));
            blockList.Add(CreateStairTile(new Vector2(200, 300)));
            blockList.Add(CreateWaterTile(new Vector2(200, 300)));
        }
        public Texture2D GetBlockSpriteSheet()
        {
            return this.blockSpriteSheet;
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
        public IBlocks CreateBlackBox(Vector2 dest)
        {
            return new BlackBoxSprite(blockSpriteSheet, dest);
        }
        public IBlocks CreateEntryFloorTile(Vector2 dest)
        {
            return new EntryFloorSprite(blockSpriteSheet, dest);
        }
        public IBlocks CreateFloorBlockTile(Vector2 dest)
        {
            return new FloorBlockSprite(blockSpriteSheet, dest);
        }
        public IBlocks CreateLadderTile(Vector2 dest)
        {
            return new LadderSprite(blockSpriteSheet, dest);
        }
        public IBlocks CreateLeftStatue(Vector2 dest)
        {
            return new LeftStatueSprite(blockSpriteSheet, dest);
        }
        public IBlocks CreateRightStatue(Vector2 dest)
        {
            return new RightStatueSprite(blockSpriteSheet, dest);
        }
        public IBlocks CreateBrickTile(Vector2 dest)
        {
            return new MarioBrickSprite(blockSpriteSheet, dest);
        }
        public IBlocks CreateStairTile(Vector2 dest)
        {
            return new StairSprite(blockSpriteSheet, dest);
        }
        public IBlocks CreateWaterTile(Vector2 dest)
        {
            return new WaterSprite(blockSpriteSheet, dest);
        }
        public IBlocks CreateFloorTile(Vector2 dest)
        {
            return new FloorSprite(blockSpriteSheet, dest);
        }
    }
}

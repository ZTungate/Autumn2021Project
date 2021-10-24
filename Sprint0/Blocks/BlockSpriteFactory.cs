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

        private List<IBlock> blockList = new List<IBlock>();

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
        public IBlock NextSprite()
        {
            blockTracker++;
            return blockList[CustomMath.MathMod(blockTracker, blockList.Count)];
        }

        //returns the previous sprite in the list
        public IBlock PreviousSprite()
        {
            blockTracker--;
            return blockList[CustomMath.MathMod(blockTracker, blockList.Count)];
        }

        //returns the current sprite
        public IBlock CurrentSprite()
        {
            return blockList[blockTracker];
        }

        //resets the list to the initial state
        public void Reset()
        {
            blockTracker = 0;
        }

        //flowing methods return a sprite object for the block
        public IBlock CreateBlackBox(Vector2 dest)
        {
            return new BlackBoxSprite(blockSpriteSheet, dest);
        }
        public IBlock CreateEntryFloorTile(Vector2 dest)
        {
            return new EntryFloorSprite(blockSpriteSheet, dest);
        }
        public IBlock CreateFloorBlockTile(Vector2 dest)
        {
            return new FloorBlockSprite(blockSpriteSheet, dest);
        }
        public IBlock CreateLadderTile(Vector2 dest)
        {
            return new LadderSprite(blockSpriteSheet, dest);
        }
        public IBlock CreateLeftStatue(Vector2 dest)
        {
            return new LeftStatueSprite(blockSpriteSheet, dest);
        }
        public IBlock CreateRightStatue(Vector2 dest)
        {
            return new RightStatueSprite(blockSpriteSheet, dest);
        }
        public IBlock CreateBrickTile(Vector2 dest)
        {
            return new MarioBrickSprite(blockSpriteSheet, dest);
        }
        public IBlock CreateStairTile(Vector2 dest)
        {
            return new StairSprite(blockSpriteSheet, dest);
        }
        public IBlock CreateWaterTile(Vector2 dest)
        {
            return new WaterSprite(blockSpriteSheet, dest);
        }
        public IBlock CreateFloorTile(Vector2 dest)
        {
            return new FloorSprite(blockSpriteSheet, dest);
        }
    }
}

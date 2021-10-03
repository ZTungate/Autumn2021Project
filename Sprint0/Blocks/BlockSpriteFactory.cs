using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

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
            blockSpriteSheet = content.Load<Texture2D>("BlockSpriteSheet");
            blockList.Add(CreateFloorTile());
        }

        public IBlocks NextSprite()
        {
            blockTracker++;
            return blockList[blockTracker % blockList.Count];
        }

        public IBlocks PreviousSprite()
        {
            blockTracker++;
            return blockList[blockTracker % blockList.Count];
        }

        public IBlocks CreateFloorTile()
        {
            return new FloorSprite(blockSpriteSheet, new Vector2(200, 300));
        } 
        //TODO add the other ten block sprites
    }
}

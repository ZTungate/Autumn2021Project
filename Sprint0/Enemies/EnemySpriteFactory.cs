using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class EnemySpriteFactory
    {
        private Texture2D enemySpriteSheet;

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        public static EnemySpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private EnemySpriteFactory()
        {
        }

        public void LoadAllTextures(ContentManager content)
        {
            enemySpriteSheet = content.Load<Texture2D>("EnemySpriteSheet");
        }

        //TODO Add CreateSprite methods for each enemy type
        public ISprite CreateSkeletonSprite()
        {
            return new SkeletonSprite(enemySpriteSheet);
        }
    }
}

using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemies;
using Sprint0.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class EnemySpriteFactory
    {
        private Texture2D enemySpriteSheet;
        private Texture2D bossSheet;

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        List<ISprite> enemySprites = new List<ISprite>();

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
            bossSheet = content.Load<Texture2D>("EnemyBossSheet");
        }

        //TODO Add CreateSprite methods for each enemy type
        public ISprite CreateSkeletonSprite()
        {
            //Create a new skeleton sprite, save it to the enemySprites list and return it for external use.
            ISprite newSprite = new SkeletonSprite(enemySpriteSheet);
            enemySprites.Add(newSprite);
            return newSprite;
        }

        public ISprite CreateSlimeSprite()
        {
            //Create a new slime sprite, save it to the enemySprites list and return it for external use.
            ISprite newSprite = new SlimeSprite(enemySpriteSheet);
            enemySprites.Add(newSprite);
            return newSprite;
        }

        public ISprite CreateBatSprite()
        {
            //Create a new bat sprite, save it to the enemySprites list and return it for external use.
            ISprite newSprite = new BatSprite(enemySpriteSheet);
            enemySprites.Add(newSprite);
            return newSprite;
        }

        public ISprite CreateDragonSprite()
        {
            ISprite newSprite = new DragonSprite(bossSheet);
            enemySprites.Add(newSprite);
            return newSprite;
        }

        public void drawEnemies(SpriteBatch spriteBatch)
        {
            foreach(ISprite enemySprite in enemySprites)
            {
                enemySprite.Draw(spriteBatch);
            }
        }

        public ISprite makeSprite(IEnemy enemy)
        {
            switch (enemy.Type)
            {
                //Create the relevant sprite given the enemy's type.
                case EnemyTypes.Bat:
                    return CreateBatSprite();
                case EnemyTypes.Dragon:
                    return CreateDragonSprite();
                case EnemyTypes.Skeleton:
                    return CreateSkeletonSprite();
                case EnemyTypes.Slime:
                    return CreateSlimeSprite();
                default:
                    //This should never happen, every enemy has a type.
                    return null;
            }
        }

    }
}

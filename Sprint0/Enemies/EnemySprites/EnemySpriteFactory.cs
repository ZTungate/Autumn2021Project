using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Enemies;
using Poggus.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies.Sprites
{
    public class EnemySpriteFactory
    {
        private Texture2D enemySpriteSheet;
        private Texture2D bossSheet;
        private Texture2D NPCSheet;

        private static EnemySpriteFactory instance = new EnemySpriteFactory();

        Dictionary<EnemyType,ISprite> enemyDictionary = new Dictionary<EnemyType,ISprite>();

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
            NPCSheet = content.Load<Texture2D>("NPCSheet");

            enemyDictionary.Add(EnemyType.Bat, new BatSprite(enemySpriteSheet));
            enemyDictionary.Add(EnemyType.BladeTrap, new BladeTrapSprite(enemySpriteSheet));
            enemyDictionary.Add(EnemyType.Dragon, new DragonSprite(bossSheet));
            enemyDictionary.Add(EnemyType.Grabber, new GrabberSprite(enemySpriteSheet));
            enemyDictionary.Add(EnemyType.OldMan, new OldManSprite(NPCSheet));
            enemyDictionary.Add(EnemyType.Skeleton, new SkeletonSprite(enemySpriteSheet));
            enemyDictionary.Add(EnemyType.Slime, new SlimeSprite(enemySpriteSheet));
            enemyDictionary.Add(EnemyType.Thrower, new LeftThrowerSprite(enemySpriteSheet));
        }
        public ISprite GetEnemySprite(EnemyType type)
        {
            ISprite outSprite;
            enemyDictionary.TryGetValue(type, out outSprite);
            if (outSprite != null)
            {
                Object[] objectParams = { outSprite.Texture };
                return (ISprite)Activator.CreateInstance(outSprite.GetType(), objectParams);
            }
            return null;
        }
    }
}

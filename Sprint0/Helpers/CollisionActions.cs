using Microsoft.Xna.Framework;
using Poggus.Collisions;
using Poggus.Enemies;
using Poggus.Levels;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Helpers
{
    class CollisionActions
    {
        public static void HurtLink(ILink link, IEnemy enemy, ColDirections dir, Game1 myGame)
        {
            //Get the current difficulty value and dungeon
            int difficulty = myGame.menuHandler.difficulty + 1;
            Dungeon myDungeon = myGame.GetDungeon();

            //Deal damage to link according to what enemy hit him
            switch (enemy.EnemyType)
            {
                case EnemyType.Bat:
                    link.TakeDamage(EnemyConstants.batDamage * difficulty, dir);
                    break;
                case EnemyType.BladeTrap:
                    link.TakeDamage(EnemyConstants.bladeTrapDamage * difficulty, dir);
                    break;
                case EnemyType.Dragon:
                    link.TakeDamage(EnemyConstants.dragonDamage * difficulty, dir);
                    break;
                case EnemyType.Grabber:
                    link.TakeDamage(EnemyConstants.grabberDamage * difficulty, dir);
                    link.SetPosition(LinkConstants.originPos);
                    myDungeon.SetCurrentLevel(new Point(0, 0));
                    Main.Camera.main.SetPosition(myDungeon.GetCurrentLevel().GetPosition());
                    break;
                case EnemyType.Skeleton:
                    link.TakeDamage(EnemyConstants.skeletonDamage * difficulty, dir);
                    break;
                case EnemyType.Slime:
                    link.TakeDamage(EnemyConstants.slimeDamage * difficulty, dir);
                    break;
                case EnemyType.Thrower:
                    link.TakeDamage(EnemyConstants.throwerDamage * difficulty, dir);
                    break;
            }
        }
    }
}

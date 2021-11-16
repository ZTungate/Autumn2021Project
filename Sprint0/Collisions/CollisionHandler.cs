using Microsoft.Xna.Framework;
using Poggus.Levels;
using Poggus;
using Poggus.Blocks;
using Poggus.Commands;
using Poggus.Enemies;
using Poggus.Items;
using Poggus.Player;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Poggus.Levels.Sprites;
using Poggus.Main;
using Poggus.Sound;

namespace Poggus.Collisions
{
    public class CollisionHandler
    {
        private Game1 myGame;
        private ILink myLink;
        private Dungeon myDungeon;
        private CollisionDetection detector;
        public List<ICollision> collides;
        public SoundManager SoundManager { get; set; }


        public CollisionHandler(Game1 game)
        {
            myGame = game;

            myDungeon = myGame.GetDungeon();

            myLink = myGame.link;

            collides = new List<ICollision>();

            detector = myGame.detector;
        }
        
        public void Update()
        {
            collides.Clear();
            
            //handle link enemy collision
            foreach (IEnemy ene in myDungeon.GetCurrentLevel().GetEnemyList()) {
                L2ECollision eneLink = (L2ECollision)detector.detectCollision(myLink, ene);
                if (eneLink.IsCollision) {
                    //If link is attacking, damage the enemy he contacts.
                    if (eneLink.Link1.State is DownSwordLinkState || eneLink.Link1.State is RightSwordLinkState || eneLink.Link1.State is UpSwordLinkState || eneLink.Link1.State is LeftSwordLinkState) {
                        ene.TakeDamage(LinkConstants.swordDamage);
                        SoundManager.sound.playEnemyHit();
                    }
                    else {
                        //Link gets hurt, damage him based on the enemy contacted.
                        switch (eneLink.enemy2.EnemyType)
                        {
                            case EnemyType.Bat:
                                eneLink.Link1.TakeDamage(EnemyConstants.batDamage);
                                break;
                            case EnemyType.BladeTrap:
                                eneLink.Link1.TakeDamage(EnemyConstants.bladeTrapDamage);
                                break;
                            case EnemyType.Dragon:
                                eneLink.Link1.TakeDamage(EnemyConstants.dragonDamage);
                                break;
                            case EnemyType.Grabber:
                                eneLink.Link1.TakeDamage(EnemyConstants.grabberDamage);
                                break;
                            case EnemyType.Skeleton:
                                eneLink.Link1.TakeDamage(EnemyConstants.skeletonDamage);
                                break;
                            case EnemyType.Slime:
                                eneLink.Link1.TakeDamage(EnemyConstants.slimeDamage);
                                break;
                            case EnemyType.Thrower:
                                eneLink.Link1.TakeDamage(EnemyConstants.throwerDamage);
                                break;
                        }
                    }
                }
            }

            //handle link projectile collision
            foreach (IProjectile proj in myGame.projectileFactory.getProjs()) {
                P2LCollision projLink = (P2LCollision)detector.detectCollision(proj, myLink);
                if (projLink.IsCollision && (projLink.proj1 is FireballProjectile || projLink.proj1 is BoomerangProjectile)) {
                    //check if shield face projectile
                    if (projLink.link2.State is DownIdleLinkState && projLink.direction is ColDirections.South && projLink.proj1 is BoomerangProjectile) {
                        //Set the boomerang to continue to live only as long as it has already (this will perfectly return it to the thrower)
                        projLink.proj1.Life = ProjectileConstants.boomerangLife - projLink.proj1.Life;
                    }
                    else if (projLink.link2.State is RightIdleLinkState && projLink.direction is ColDirections.East && projLink.proj1 is BoomerangProjectile) {
                        projLink.proj1.Life = ProjectileConstants.boomerangLife - projLink.proj1.Life;
                    }
                    else if (projLink.link2.State is LeftIdleLinkState && projLink.direction is ColDirections.West && projLink.proj1 is BoomerangProjectile) {
                        projLink.proj1.Life = ProjectileConstants.boomerangLife - projLink.proj1.Life;
                    }
                    else if (projLink.link2.State is UpIdleLinkState && projLink.direction is ColDirections.North && projLink.proj1 is BoomerangProjectile) {
                        projLink.proj1.Life = ProjectileConstants.boomerangLife - projLink.proj1.Life;
                    }
                    else {//hurt link by the damage of the projectile that hit him.
                        if(projLink.proj1 is BoomerangProjectile)
                        {
                            projLink.link2.TakeDamage(ProjectileConstants.throwerBoomerangDamage);
                        }
                        else
                        {
                            //Kill the fireball and hurt link
                            projLink.proj1.Life = 0;
                            projLink.link2.TakeDamage(ProjectileConstants.fireballDamage);
                        }
                        
                    }

                }else if(projLink.IsCollision && projLink.proj1 is LinkBoomerangProjectile && projLink.proj1.Life <= ProjectileConstants.boomerangLife / 2)
                {
                    //Kill a link boomerang if it collides with him while returning.
                    projLink.proj1.Life = 0;
                }
            }

            //handle link block collision
            foreach (IBlock block in myDungeon.GetCurrentLevel().GetBlockArray()) {
                L2BCollision linkBlock = (L2BCollision)detector.detectCollision(myLink, block);
                if (linkBlock.IsCollision && !linkBlock.block2.Walkable) {
                    myLink.SetPosition(myLink.OldPosition);
                }
            }

            //room bounds
            Rectangle[] bounds = myGame.GetDungeon().GetCurrentLevel().GetBoundsAsArray();
            foreach(Rectangle rectangle in bounds)
            {
                L2RCollision boundLink = (L2RCollision)detector.detectCollision(myLink, rectangle);
                if (boundLink.IsCollision)
                {
                    myLink.SetPosition(myLink.OldPosition);
                }
                
                foreach (IEnemy ene in myDungeon.GetCurrentLevel().GetEnemyList())
                {
                    E2RCollision boundEnemy = (E2RCollision)detector.detectCollision(ene, rectangle);
                    if (boundEnemy.IsCollision)
                    {
                        ene.SetPosition(ene.oldPosition);
                    }
                }
                foreach (IProjectile proj in myGame.projectileFactory.getProjs()) {
                    P2RCollision boundProj = (P2RCollision)detector.detectCollision(proj, rectangle);
                    if (boundProj.IsCollision)
                    {
                        proj.Life = 0;
                    }
                }

            }

            //handle block projectile collision
            foreach (IProjectile proj in myGame.projectileFactory.getProjs()) {
                foreach (IBlock block in myDungeon.GetCurrentLevel().GetBlockArray()) {
                    P2BCollision projBlock = (P2BCollision)detector.detectCollision(block, proj);
                    if (projBlock.IsCollision && !projBlock.block2.Walkable) {
                        projBlock.proj1.Life = 0;
                    }
                }
            }            

            //handle enemy block collision
            foreach (IBlock block in myDungeon.GetCurrentLevel().GetBlockArray()) {
                foreach (IEnemy ene in myDungeon.GetCurrentLevel().GetEnemyList()) {
                    E2BCollision eneBlock = (E2BCollision)detector.detectCollision(ene, block);
                    if (eneBlock.IsCollision && !eneBlock.block2.Walkable && !(eneBlock.enemy1 is Bat)) {
                        ene.SetPosition(ene.oldPosition);
                    }
                }
            }

            //handle enemy projectile collision
            List<IEnemy> eneToRemove = new List<IEnemy>();

            foreach (IProjectile proj in myGame.projectileFactory.getProjs()) {
                if (!(proj is ArrowPoofProjectile)) {
                    foreach (IEnemy ene in myDungeon.GetCurrentLevel().GetEnemyList()) {
                        P2ECollision projEne = (P2ECollision)detector.detectCollision(proj, ene);
                        if (projEne.IsCollision && (projEne.proj1 is LinkBoomerangProjectile) && (projEne.enemy2 is Slime || projEne.enemy2 is Bat)) {
                            //If the projectile was a boomerang and the enemy was a bat or slime, kill it.
                            eneToRemove.Add(projEne.enemy2);
                        }
                        else if (projEne.IsCollision) {
                            //For any non-enemy projectile, have the enemy take damage and kill the projectile.
                            IProjectile projectile = projEne.proj1;
                            if (projectile is LinkBoomerangProjectile) {
                                //Stun the enemy and set link's boomerang to return.
                                projEne.enemy2.StunTimer = ProjectileConstants.boomerangStunTime;
                                projEne.proj1.Life = ProjectileConstants.boomerangLife / 2;
                            }
                            else if (projectile is RegArrowProjectile) {
                                projEne.enemy2.TakeDamage(ProjectileConstants.redArrowDamage);
                                projEne.proj1.Life = 0;
                            }
                            else if (projectile is BlueArrowProjectile) {
                                projEne.enemy2.TakeDamage(ProjectileConstants.redArrowDamage);
                                projEne.proj1.Life = 0;
                            }
                            else if (projectile is BombProjectile) {
                                projEne.enemy2.TakeDamage(ProjectileConstants.bombDamage);
                                projEne.proj1.Life = 0;
                            }
                            else if (projectile is BombExplosionProjectile)
                            {
                                projEne.enemy2.TakeDamage(ProjectileConstants.bombDamage);
                            }
                            else if (projectile is SwordBeamExplosionProjectile || projectile is SwordBeamProjectile) {
                                projEne.enemy2.TakeDamage(ProjectileConstants.swordBeamDamage);
                                projEne.proj1.Life = 0;
                            }
                            else if (projectile is FireProjectile) {
                                projEne.enemy2.TakeDamage(ProjectileConstants.fireDamage);
                                projEne.proj1.Life = 0;
                            }
                        }

                        //Kill any enemies with health <= 0;
                        if (projEne.enemy2.Health <= 0) {
                            eneToRemove.Add(projEne.enemy2);
                        }
                    }
                }
            }
            //remove enemies from the room
            foreach (IEnemy ene in eneToRemove) {
                myDungeon.GetCurrentLevel().RemoveEnemy(ene);
            }

            //handle link item collision
            List<AbstractItem> itemToRemove = new List<AbstractItem>();

            foreach (AbstractItem item in myDungeon.GetCurrentLevel().GetItemList()) {
                L2ICollision itemLink = (L2ICollision)detector.detectCollision(myLink, item);
                if (itemLink.IsCollision) {
                    itemToRemove.Add(itemLink.Item2);
                    if(itemLink.Item2 is TriforcePieceItem) {
                        
                        new PlayerPickUpCommand(myGame, itemLink.Item2).Execute();
                        
                        
                    }
                }
            }
            //remove items from the room
            foreach (AbstractItem item in itemToRemove) {
                myDungeon.GetCurrentLevel().RemoveItem(item);
                
            }

            LevelDoor[] doors = myGame.GetDungeon().GetCurrentLevel().GetDoorListAsArray(); 
            foreach (LevelDoor door in doors) 
            { 
                L2RCollision boundLink = (L2RCollision)detector.detectCollision(myLink, door.destRect); 
                if (boundLink.IsCollision) 
                { 
                    Point dir = Dungeon.directions[(int)door.GetDirection()];

                    Point nextPoint = myGame.GetDungeon().GetCurrentLevel().GetPosition() + new Point(dir.X, -dir.Y) * myGame.GetDungeon().GetLevelSize();
                    
                    myGame.GetDungeon().SwitchLevel(dir);
                    Rectangle linkRect = myLink.DestRect;

                    Point linkNewPos = Point.Zero; 
                    if (dir == new Point(0, 1))
                    { 
                        LevelDoor oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(0, -1)); 
                        linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width/2 - linkRect.Width/2, oppositeDoor.destRect.Y - (linkRect.Height)); 
                    } 
                    if (dir == new Point(1, 0)) 
                    { 
                        LevelDoor oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(-1, 0)); 
                        linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width, oppositeDoor.destRect.Y + oppositeDoor.destRect.Height / 2 - linkRect.Height/2); 
                    } 
                    if (dir == new Point(0, -1)) 
                    { 
                        LevelDoor oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(0, 1)); 
                        linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width/2 - linkRect.Width/2, oppositeDoor.destRect.Y + oppositeDoor.destRect.Height); 
                    } 
                    if (dir == new Point(-1, 0)) 
                    { 
                        LevelDoor oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(1, 0)); 
                        linkNewPos = new Point(oppositeDoor.destRect.X - (linkRect.Width), oppositeDoor.destRect.Y + oppositeDoor.destRect.Height/2 - linkRect.Height/2); 
                    }
                    myGame.GetDungeon().GetCurrentLevel().GetLink().SetPosition(linkNewPos);
                    
                    Camera.main.BeginMoveTo(nextPoint, 10);
                } 
            }

            //TODO: handle link movable block collision

        }


    }
}

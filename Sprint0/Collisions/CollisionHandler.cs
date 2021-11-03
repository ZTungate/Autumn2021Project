using Microsoft.Xna.Framework;
using Sprint0.Levels;
using Sprint2;
using Sprint2.Blocks;
using Sprint2.Commands;
using Sprint2.Enemies;
using Sprint2.Items;
using Sprint2.Player;
using Sprint2.Projectiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Sprint0.Levels.Sprites;

namespace Sprint0.Collisions
{
    public class CollisionHandler
    {
        private Game1 myGame;
        private ILink myLink;
        private Dungeon myDungeon;
        private CollisionDetection detector;
        public List<ICollision> collides;


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
                    //if in sword state, slap enemy
                    if (eneLink.Link1.state is DownSwordLinkState || eneLink.Link1.state is RightSwordLinkState || eneLink.Link1.state is UpSwordLinkState || eneLink.Link1.state is LeftSwordLinkState) { 
                        //TODO: enemy take damage
                        //eneLink.enemy2.takeDamage
                        //or
                        //myLevel.enemies.Remove(eneLink.enemy2)
                    }
                    else {
                        new PlayerTakeDamageCommand(myGame).Execute();
                    }
                }
            }

            //handle link projectile collision
            foreach (IProjectile proj in myGame.projectileFactory.getProjs()) {
                P2LCollision projLink = (P2LCollision)detector.detectCollision(proj, myLink);
                if (projLink.IsCollision && (projLink.proj1 is FireballProjectile || projLink.proj1 is BoomerangProjectile)) {
                    projLink.proj1.Life = 0;
                    //check if shield face projectile
                    if (projLink.link2.state is DownIdleLinkState && projLink.direction is ColDirections.South) {
                        //TODO: Proj bounce off shield
                    }
                    else if (projLink.link2.state is RightIdleLinkState && projLink.direction is ColDirections.East) {

                    }
                    else if (projLink.link2.state is LeftIdleLinkState && projLink.direction is ColDirections.West) {

                    }
                    else if (projLink.link2.state is UpIdleLinkState && projLink.direction is ColDirections.North) {

                    }
                    else {//hurt link
                        new PlayerTakeDamageCommand(myGame).Execute();
                    }

                }
            }

            //handle link block collision
            foreach (IBlock block in myDungeon.GetCurrentLevel().GetBlockArray()) {
                L2BCollision linkBlock = (L2BCollision)detector.detectCollision(myLink, block);
                if (linkBlock.IsCollision && !linkBlock.block2.Walkable) {
                    myLink.SetPosition(myLink.oldPosition);
                }
            }

            //room bounds
            Rectangle[] bounds = myGame.GetDungeon().GetCurrentLevel().GetBoundsAsArray();
            foreach(Rectangle rectangle in bounds)
            {
                L2RCollision boundLink = (L2RCollision)detector.detectCollision(myLink, rectangle);
                if (boundLink.IsCollision)
                {
                    myLink.SetPosition(myLink.oldPosition);
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
                foreach (IEnemy ene in myDungeon.GetCurrentLevel().GetEnemyList()) {
                    P2ECollision projEne = (P2ECollision)detector.detectCollision(proj, ene);
                    if (projEne.IsCollision && !(projEne.proj1 is FireballProjectile || projEne.proj1 is BoomerangProjectile)) {
                        eneToRemove.Add(projEne.enemy2);
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
                    myGame.GetDungeon().SwitchLevel(dir); 
                    Point linkNewPos = Point.Zero; 
                    if (dir == new Point(0, 1)) 
                    { 
                        LevelDoor oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(0, -1)); 
                        linkNewPos = new Point(oppositeDoor.destRect.X, oppositeDoor.destRect.Y - oppositeDoor.destRect.Size.Y - 5); 
                    } 
                    if (dir == new Point(1, 0)) 
                    { 
                        LevelDoor oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(-1, 0)); 
                        linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Size.X + 5, oppositeDoor.destRect.Y); 
                    } 
                    if (dir == new Point(0, -1)) 
                    { 
                        LevelDoor oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(0, 1)); 
                        linkNewPos = new Point(oppositeDoor.destRect.X, oppositeDoor.destRect.Y + oppositeDoor.destRect.Size.Y + 5); 
                    } 
                    if (dir == new Point(-1, 0)) 
                    { 
                        LevelDoor oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(1, 0)); 
                        linkNewPos = new Point(oppositeDoor.destRect.X - oppositeDoor.destRect.Size.X - 5, oppositeDoor.destRect.Y); 
                    }
                    myGame.GetDungeon().GetCurrentLevel().GetLink().SetPosition(linkNewPos); 
                } 
            }

            //TODO: handle link movable block collision

        }


    }
}

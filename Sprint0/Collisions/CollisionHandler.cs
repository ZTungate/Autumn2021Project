using Microsoft.Xna.Framework;
using Sprint0.Levels;
using Sprint2;
using Sprint2.Blocks;
using Sprint2.Commands;
using Sprint2.Enemies;
using Sprint2.Player;
using Sprint2.Projectiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Sprint0.Collisions
{
    public class CollisionHandler
    {
        private Game1 myGame;
        private ILink myLink;
        private Dungeon myDungeon;
        private Level myLevel;
        private CollisionDetection detector;
        public List<ICollision> collides;


        public CollisionHandler(Game1 game)
        {
            myGame = game;

            myDungeon = myGame.GetDungeon();

            //myLevel = myDungeon.GetCurrentLevel();

            myLink = myGame.link;

            collides = new List<ICollision>();

            detector = myGame.detector;
        }
        
        public void Update()
        {
            collides.Clear();

            collides.Add(detector.detectCollision(myLink, myGame.currentBlock));

            //handle link enemy collision
            foreach (IEnemy ene in myGame.enemies) {
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

            //handle block projectile collision
            foreach (IProjectile proj in myGame.projectileFactory.getProjs()) {
                //foreach (IBlock block in myLevel.blocks) {
                //    P2BCollision projBlock = (P2BCollision)detector.detectCollision(block, proj);
                //    if (projBlock.IsCollision) {
                //        projLink.proj1.Life = 0;
                //    }
                //}
            }            

            //handle link block collision
            //foreach (KeyValuePair<Point, IBlock> block in myLevel.blocks) {
            //    collides.Add(detector.detectCollision(myLink, block.Value));
            //}

            //handle link item collision
            //foreach (IItem item in myLevel.items) {
            //    collides.Add(detector.detectCollision(myLink, item));
            //}

            //TODO: handle link movable block collision


            foreach (ICollision col in collides) {
                if (col.IsCollision) {
                    if (col is L2BCollision) {
                        myLink.position = myLink.oldPosition;
                    }
                }
            }
        }


    }
}

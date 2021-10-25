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
        private Dictionary<ICollision, ICommand> collisionMappings;
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



        private void setResponse()
        {
            //this.collisionMappings.Add(new L2ECollision(ColDirections.North, true, myGame.link, myGame.enemies[0]), new PlayerTakeDamageCommand(myGame));
            //this.collisionMappings.Add(new L2ECollision(ColDirections.East, true, myGame.link, myGame.enemies[0]), new PlayerTakeDamageCommand(myGame));
            //this.collisionMappings.Add(new L2ECollision(ColDirections.South, true, myGame.link, myGame.enemies[0]), new PlayerTakeDamageCommand(myGame));
            //this.collisionMappings.Add(new L2ECollision(ColDirections.West, true, myGame.link, myGame.enemies[0]), new PlayerTakeDamageCommand(myGame));

        }

        
        public void Update()
        {
            collides.Clear();



            collides.Add(detector.detectCollision(myLink, myGame.currentBlock));

            //handle link enemy collision
            foreach (IEnemy ene in myGame.enemies) {
                L2ECollision eneLink = (L2ECollision)detector.detectCollision(myLink, ene);
                if (eneLink.IsCollision) {
                    new PlayerTakeDamageCommand(myGame).Execute();
                }
            }
            //handle link projectile collision
            foreach (IProjectile proj in myGame.projectileFactory.getProjs()) {
                //collides.Add(detector.detectCollision(proj, myLink));
                P2LCollision projLink = (P2LCollision)detector.detectCollision(proj, myLink);
                if (projLink.IsCollision) {
                    projLink.proj1.Life = 0;
                    //check if shield face projectile
                    if (projLink.link2.state is DownIdleLinkState && projLink.direction is ColDirections.South) {

                    }
                    else if (projLink.link2.state is RightIdleLinkState && projLink.direction is ColDirections.East) {

                    }
                    else if (projLink.link2.state is LeftIdleLinkState && projLink.direction is ColDirections.West) {

                    }
                    else if (projLink.link2.state is UpIdleLinkState && projLink.direction is ColDirections.North) {

                    }
                    else {
                        new PlayerTakeDamageCommand(myGame).Execute();
                    }

                }
            }




            //handle link block collision
            //foreach (KeyValuePair<Point, IBlock> block in myLevel.blocks) {
            //    collides.Add(detector.detectCollision(myLink, block.Value));
            //}

            foreach (ICollision col in collides) {
                if (col.IsCollision) {
                    if (col is L2BCollision) {
                        myLink.position = myLink.oldPosition;
                    }
                    if (col is P2LCollision) {

                    }


                }
            }
        }


    }
}

using Sprint2;
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
        private CollisionDetection detector;
        private Dictionary<ICollision, ICommand> collisionMappings;
        public List<ICollision> collides;


        public CollisionHandler(Game1 game)
        {
            myGame = game;

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


            foreach (IEnemy ene in myGame.enemies) {
                collides.Add(detector.detectCollision(myLink, ene));
            }

            foreach (IProjectile proj in myGame.projectileFactory.getProjs()) {
                collides.Add(detector.detectCollision(myLink, proj));
            }

            foreach (ICollision col in collides) {
                if (col.IsCollision) {
                    if (col is L2ECollision) {
                        new PlayerTakeDamageCommand(myGame).Execute();
                    }
                    if (col is L2BCollision) {
                        myLink.position = myLink.oldPosition;
                    }

                }
            }
        }


    }
}

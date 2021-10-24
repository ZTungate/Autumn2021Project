using Sprint2;
using Sprint2.Commands;
using Sprint2.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collisions
{
    public class CollisionHandler
    {
        private Game1 myGame;
        private CollisionDetection detector;
        private Dictionary<ICollision, ICommand> collisionMappings;
        public List<ICollision> collides;


        public CollisionHandler(Game1 game)
        {
            myGame = game;

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

            foreach (IEnemy ene in myGame.enemies) {
                collides.Add(detector.detectCollision(myGame.link, ene));
            }

            foreach (ICollision col in collides) {
                if (col.IsCollision) {
                    new PlayerTakeDamageCommand(myGame).Execute();

                }
            }
        }


    }
}

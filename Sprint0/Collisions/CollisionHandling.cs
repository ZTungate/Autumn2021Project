using Sprint3.Commands;
using Sprint3.Collisions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Collisions
{
    class CollisionHandling
    {
        private Game1 myGame;
        private Dictionary<Tuple<Type, Type, ICollision>, ICommand> collisionMappings;

        public CollisionHandling(Game1 game)
        {
            myGame = game;

            setResponse();
        }

        private void setResponse()
        {
            Type linkType = typeof(Player.ILink);

            Type enemyType = typeof(Enemies.IEnemy);

            ICollision ene = new detectCollision(myGame.link, myGame.enemies[0]);

            collisionMappings.Add(new Tuple<Type, Type, ICollision>(linkType, enemyType, ), new PlayerTakeDamageCommand(myGame));
        }
    }
}

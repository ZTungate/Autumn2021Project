using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Helpers;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Collisions;

namespace Poggus.Enemies
{
    //This probably needs to be somewhere else.
    public interface IEnemy
    {
        public void Update(GameTime gameTime);
        public void Draw(SpriteBatch batch);

        public ISprite Sprite { get; set; }
        public EnemyType EnemyType { get; }

        public Rectangle DestRect{ get; set; }
        public Rectangle ColliderRect { get; set; }
        public bool interactable { get; set; }

        public Point oldPosition { get; set; }

        public IEnemyState State { get; set; } //May not need this in interface if it only applies to 1 enemy

        public int Health { get; set; }
        public int StunTimer { get; set; }
        public void changeDifficulty(int oldDifficulty, int newDifficulty);
        public Point GetPosition();
        public void SetPosition(Point pos);
        public void TakeDamage(int damageAmount, ColDirections damageDirection);
    }
}

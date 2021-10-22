using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Sprint2.Projectiles;
namespace Sprint2.Player
{

    public class Link : ILink {

        //Game class contains a sprite factory, which creates each sprite with a source rectangle. this is saved in spriteBatch
        //spritebatch is passed down to the state in the player class (this file), which is sent to the state. The state actually draws the image.

        public ILinkState state { get; set; }
        public Vector2 position { get; set; }
        public ISprite sprite { get; set; }
        public Color color { get; set; }

        public direction facing {get; set;}

        public Boolean canAttack { get; set; }

        float damageTimer;
        Color[] damageColors = new Color[2] { Color.Red, Color.Blue };
        public float Timer = 0f;
        float damageFlashRate = 50f;
        public bool canMove = true;
        public bool isDamaged = false;
        int colorIndex = 0;
        float invincibilityFramesDuration = 2000f;
        float hitStunDuration = 500f;

        public ProjectileFactory projectile;


        public Link(ProjectileFactory ProjectileFactory)
        {
            state = new InitialLinkState(this,null); //start the player in the right idle state, initial sprite is null, will be fixed during content loading in game1
            position = new Vector2(20, 20);  //Link's initial position
            facing = direction.right;
            canAttack = true;
            colorIndex = 0;

            color = Color.White;

            projectile = ProjectileFactory;

        }

        public void Update(GameTime gameTime)
        {
            if (isDamaged)
            {

                damageTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if(invincibilityFramesDuration - damageTimer % damageFlashRate == 0)
                {
                    colorIndex++;
                    color = damageColors[colorIndex % damageColors.Length];
                }


                if (damageTimer % (damageFlashRate) > damageFlashRate * 2)
                {
                    colorIndex++;
                }
                if (damageTimer <= 50f)
                { //damage invincibility time
                    isDamaged = false;
                    color = Color.White;
                }
                else if (damageTimer < (invincibilityFramesDuration-hitStunDuration)) //hit stun duration
                {
                    canMove = true;
                }
                damageTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            }
            else
            {
                canMove = true;
                colorIndex = 0;
            }
            state.Update(gameTime);
            sprite.Update(gameTime);
            /*playerState.Update();*/
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);   //draw the player sprite
            /*playerState.Draw(SpriteBatch);*/
        }

        public void takeDamage()
        {
            if (!isDamaged) {
                isDamaged = true;
                canMove = false;
                color = Color.Red;
                damageTimer = invincibilityFramesDuration;
            }
            /*state.takeDamage();*/

        }

        public void UseItem()
        {
            state.UseItem();
        }

        public void move(Vector2 moveDirection)
        {
            if (canMove) 
            {
                canAttack = true;
                position += moveDirection;
            }   
        }
        /*        public void moveUp(float speed)
                {
                    position += new Vector2(0, -speed);
                }

                public void moveRight(float speed)
                {
                    position += new Vector2(speed, 0);
                }

                public void moveLeft(float speed)
                {
                    position += new Vector2(-speed, 0);
                }

                public void moveDown(float speed)
                {
                    position += new Vector2(0, speed);
                }*/
        public void Reset()
        {
            //This may not work, since the state does not determine the sprite
            state = new InitialLinkState(this, sprite); //start the player in the right idle state
            position = new Vector2(20, 20);  //Link's initial position

            colorIndex = 0;

            color = Color.White;
        }

        //Attacks

        public void SwordAttack() //move internal code to state, have a timer to prevent sword spam
        {
            if (canAttack)
            {
                switch (facing)
                {
                    case Player.direction.up:
                        state = new UpSwordLinkState(this, sprite);
                        break;
                    case Player.direction.down:
                        state = new DownSwordLinkState(this, sprite);
                        break;
                    case Player.direction.left:
                        state = new LeftSwordLinkState(this, sprite);
                        break;
                    case Player.direction.right:
                        state = new RightSwordLinkState(this, sprite);
                        break;
                    default:
                        break;
                }
            }
        }

        public void RegBoomerangAttack()
        {
            //Create a new boomerang moving the direction given at 3 pixels per tick.
            switch (facing) {
                case direction.right:
                    projectile.NewBoomerang(position, 3 * new Vector2(1, 0));
                    break;
                case direction.left:
                    projectile.NewBoomerang(position, 3 * new Vector2(-1, 0));
                    break;
                case direction.down:
                    projectile.NewBoomerang(position, 3 * new Vector2(0, 1));
                    break;
                case direction.up:
                    projectile.NewBoomerang(position, 3 * new Vector2(0, -1));
                    break;
            }
        }

        public void BlueBoomerangAttack()
        {
            //Create a new boomerang moving the direction given at 3 pixels per tick.
            switch (facing) {
                case direction.right:
                    projectile.NewBlueBoomerang(position, 6 * new Vector2(1, 0));
                    break;
                case direction.left:
                    projectile.NewBlueBoomerang(position, 6 * new Vector2(-1, 0));
                    break;
                case direction.down:
                    projectile.NewBlueBoomerang(position, 6 * new Vector2(0, 1));
                    break;
                case direction.up:
                    projectile.NewBlueBoomerang(position, 6 * new Vector2(0, -1));
                    break;

            }
        }

        public void RegArrowAttack()
        {
            //Create a new boomerang moving the direction given at 3 pixels per tick.
            projectile.NewRegArrow(position, 6 * new Vector2(1, 0), facing);

        }

        public void BlueArrowAttack()
        {
            //Create a new boomerang moving the direction given at 3 pixels per tick.
            projectile.NewBlueArrow(position, 6 * new Vector2(1, 0), facing);

        }

        public void BombAttack()
        {
            //Create a new bomb
            switch (facing) {
                case direction.right:
                    projectile.NewBomb(new Vector2(position.X + sprite.SourceRect[sprite.CurrentFrame].Width * 2, position.Y));
                    break;
                case direction.left:
                    projectile.NewBomb(new Vector2(position.X - sprite.SourceRect[sprite.CurrentFrame].Width, position.Y));
                    break;
                case direction.down:
                    projectile.NewBomb(new Vector2(position.X , position.Y + sprite.SourceRect[sprite.CurrentFrame].Height * 2));
                    break;
                case direction.up:
                    projectile.NewBomb(new Vector2(position.X, position.Y - sprite.SourceRect[sprite.CurrentFrame].Height * 2));
                    break;

            }

        }

        public void FireAttack()
        {
            //Create a new boomerang moving the direction given at 3 pixels per tick.
            switch (facing) {
                case direction.right:
                    projectile.NewFire(position, 6 * new Vector2(1, 0));
                    break;
                case direction.left:
                    projectile.NewFire(position, 6 * new Vector2(-1, 0));
                    break;
                case direction.down:
                    projectile.NewFire(position, 6 * new Vector2(0, 1));
                    break;
                case direction.up:
                    projectile.NewFire(position, 6 * new Vector2(0, -1));
                    break;

            }
        }
    }
    
}
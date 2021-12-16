using Microsoft.Xna.Framework;
using Poggus.Levels;
using Poggus.Blocks;
using Poggus.Commands;
using Poggus.Enemies;
using Poggus.Items;
using Poggus.Player;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using Poggus.Main;
using Poggus.Sound;
using Poggus.Helpers;

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
                L2ECollision eneLink = (L2ECollision)detector.detectCollision(ene, myLink);
                if (eneLink.IsCollision && myLink.collideWithBounds && ene.interactable) {
                    //Link gets hurt, damage him based on the enemy contacted.
                    CollisionActions.HurtLink(eneLink.Link1, eneLink.enemy2, eneLink.direction, myGame);
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
                        SoundManager.sound.playShieldSound();
                    }
                    else if (projLink.link2.State is RightIdleLinkState && projLink.direction is ColDirections.East && projLink.proj1 is BoomerangProjectile) {
                        projLink.proj1.Life = ProjectileConstants.boomerangLife - projLink.proj1.Life;
                        SoundManager.sound.playShieldSound();
                    }
                    else if (projLink.link2.State is LeftIdleLinkState && projLink.direction is ColDirections.West && projLink.proj1 is BoomerangProjectile) {
                        projLink.proj1.Life = ProjectileConstants.boomerangLife - projLink.proj1.Life;
                        SoundManager.sound.playShieldSound();
                    }
                    else if (projLink.link2.State is UpIdleLinkState && projLink.direction is ColDirections.North && projLink.proj1 is BoomerangProjectile) {
                        projLink.proj1.Life = ProjectileConstants.boomerangLife - projLink.proj1.Life;
                        SoundManager.sound.playShieldSound();
                    }
                    else {//hurt link by the damage of the projectile that hit him.
                        if(projLink.proj1 is BoomerangProjectile)
                        {
                            projLink.link2.TakeDamage(ProjectileConstants.throwerBoomerangDamage, projLink.direction);
                        }
                        else
                        {
                            //Kill the fireball and hurt link
                            projLink.proj1.Life -= ProjectileConstants.boomerangLife;
                            projLink.link2.TakeDamage(ProjectileConstants.fireballDamage, projLink.direction);
                        }
                        
                    }

                }else if(projLink.IsCollision && projLink.proj1 is LinkBoomerangProjectile && projLink.proj1.Life <= ProjectileConstants.boomerangLife / 2)
                {
                    //Kill a link boomerang if it collides with him while returning.
                    projLink.proj1.Life -= ProjectileConstants.boomerangLife;
                }
            }

            //handle link block collision
            foreach (IBlock block in myDungeon.GetCurrentLevel().GetBlockArray()) {
                L2BCollision linkBlock = (L2BCollision)detector.detectCollision(myLink, block);
                if (linkBlock.IsCollision && !linkBlock.block2.Walkable) {
                    myLink.SetPosition(myLink.OldPosition);
                }
                else
                {

                    if (linkBlock.IsCollision && block is Stair)
                    {
                        Stair stairBlock = (Stair)block;
                        myDungeon.SetCurrentLevel(stairBlock.referenceLevelPoint);

                        myLink.SetPosition(myDungeon.GetCurrentLevel().GetPosition() + myDungeon.GetCurrentLevel().customSpawnLocation);
                        Main.Camera.main.SetPosition(myDungeon.GetCurrentLevel().GetPosition());
                        Game1.instance.GetDungeon().GetCurrentLevel().DoEnemySpawnAnimation();
                    }
                }
            }
            foreach (IBlock moveable in myDungeon.GetCurrentLevel().moveableBlockList)
            {
                L2BCollision linkBlock = (L2BCollision)detector.detectCollision(myLink, moveable);
                if (linkBlock.IsCollision) {
                    myLink.SetPosition(myLink.OldPosition);

                    if (linkBlock.block2.Moveable) {
                        SoundManager.sound.playSecret();
                        if (linkBlock.direction is ColDirections.South) {
                            linkBlock.block2.MoveUp();
                        }
                        else if (linkBlock.direction is ColDirections.North) {
                            linkBlock.block2.MoveDown();
                        }
                        else if (linkBlock.direction is ColDirections.East) {
                            linkBlock.block2.MoveLeft();
                        }
                        else if (linkBlock.direction is ColDirections.West) {
                            linkBlock.block2.MoveRight();
                        }
                    }
                }
            }
            //room bounds
            Rectangle[] bounds = myGame.GetDungeon().GetCurrentLevel().GetBoundsAsArray();
            foreach(Rectangle rectangle in bounds)
            {
                L2RCollision boundLink = (L2RCollision)detector.detectCollision(myLink, rectangle);
                if (boundLink.IsCollision && myLink.collideWithBounds)
                {
                    if (myGame.GetDungeon().GetCurrentLevel().hasCustomSpawn)
                    {
                        Point returnPoint = myGame.GetDungeon().GetCurrentLevel().returnSpawn;
                        myGame.GetDungeon().SetCurrentLevel(myGame.GetDungeon().GetCurrentLevel().returnLevelPoint);
                        myLink.SetPosition(myGame.GetDungeon().GetCurrentLevel().GetPosition() + returnPoint);

                        Main.Camera.main.SetPosition(myDungeon.GetCurrentLevel().GetPosition());
                        Game1.instance.GetDungeon().GetCurrentLevel().DoEnemySpawnAnimation();
                    }
                    else
                    {
                        myLink.SetPosition(myLink.OldPosition);
                    }
                }
                
                foreach (IEnemy ene in myDungeon.GetCurrentLevel().GetEnemyList())
                {
                    E2RCollision boundEnemy = (E2RCollision)detector.detectCollision(ene, rectangle);
                    if (boundEnemy.IsCollision && !(boundEnemy.enemy1 is Grabber))
                    {
                        ene.SetPosition(ene.oldPosition);
                    }
                }
                foreach (IProjectile proj in myGame.projectileFactory.getProjs()) {
                    P2RCollision boundProj = (P2RCollision)detector.detectCollision(proj, rectangle);
                    if (boundProj.IsCollision && !(proj is EnemyPoofProjectile))
                    {
                        //Boomerangs bounce off the walls, other projectiles just break.
                        if (boundProj.proj1 is BoomerangProjectile || boundProj.proj1 is LinkBoomerangProjectile)
                        {
                            boundProj.proj1.Life /= 2;
                        }
                        else
                        {
                            proj.Life = 0;
                        }
                    }
                }

            }

            //handle block projectile collision
            foreach (IProjectile proj in myGame.projectileFactory.getProjs()) {
                foreach (IBlock block in myDungeon.GetCurrentLevel().GetBlockArray()) {
                    P2BCollision projBlock = (P2BCollision)detector.detectCollision(block, proj);
                    if (projBlock.IsCollision && !projBlock.block2.Walkable) {
                       // projBlock.proj1.Life = 0;
                    }
                }
            }            

            //handle enemy block collision
            foreach (IBlock block in myDungeon.GetCurrentLevel().GetBlockArray()) {
                foreach (IEnemy ene in myDungeon.GetCurrentLevel().GetEnemyList()) {
                    E2RCollision eneBlock = (E2RCollision)detector.detectCollision(ene, block.DestRect);
                    if (eneBlock.IsCollision && !block.Walkable && !(eneBlock.enemy1 is Bat)) {
                        ene.SetPosition(ene.oldPosition);
                    }
                }
            }
            foreach(IBlock moveBlock in myDungeon.GetCurrentLevel().moveableBlockList)
            {
                foreach (IEnemy ene in myDungeon.GetCurrentLevel().GetEnemyList())
                {
                    E2RCollision eneBlock = (E2RCollision)detector.detectCollision(ene, moveBlock.DestRect);
                    if (eneBlock.IsCollision && !(eneBlock.enemy1 is Bat))
                    {
                        ene.SetPosition(ene.oldPosition);
                    }
                }
            }

            foreach(IProjectile proj in myGame.projectileFactory.getProjs())
            {
                foreach(LevelDoor door in myDungeon.GetCurrentLevel().GetDoorListAsArray())
                {
                    if(door.doorType == DoorType.Hole && door.isClosed)
                    {
                        P2RCollision projRect = (P2RCollision)detector.detectCollision(proj, door.destRect);
                        if (projRect.IsCollision && proj is BombExplosionProjectile)
                        {
                            door.BlowUp();
                        }
                    }
                }
            }

            //handle enemy projectile collision
            List<IEnemy> eneToRemove = new List<IEnemy>();
            
            foreach (IProjectile proj in myGame.projectileFactory.getProjs()) {
                //if (!(proj is ArrowPoofProjectile)) {
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
                            projEne.enemy2.TakeDamage(ProjectileConstants.redArrowDamage, ColDirections.None);
                            projEne.proj1.Life = 0;
                            /*SoundManager.sound.playEnemyHit();*/
                        }
                        else if (projectile is BlueArrowProjectile) {
                            projEne.enemy2.TakeDamage(ProjectileConstants.blueArrowDamage, ColDirections.None);
                            projEne.proj1.Life = 0;
                            /*SoundManager.sound.playEnemyHit();*/
                        }
                        else if (projectile is BombProjectile) {
                            projEne.enemy2.TakeDamage(ProjectileConstants.bombDamage, ColDirections.None);
                            projEne.proj1.Life = 0;
                            /*SoundManager.sound.playEnemyHit();*/
                        }
                        else if (projectile is BombExplosionProjectile)
                        {
                            projEne.enemy2.TakeDamage(ProjectileConstants.bombDamage, ColDirections.None);
                            /*SoundManager.sound.playEnemyHit();*/
                        }
                        else if (projectile is SwordBeamExplosionProjectile || projectile is SwordBeamProjectile) {
                            projEne.enemy2.TakeDamage(ProjectileConstants.swordBeamDamage, ColDirections.None);
                            projEne.proj1.Life = 0;
                            /*SoundManager.sound.playEnemyHit();*/
                        }
                        else if (projectile is FireProjectile) {
                            projEne.enemy2.TakeDamage(ProjectileConstants.fireDamage, ColDirections.None);
                            projEne.proj1.Life = 0;
                            /*SoundManager.sound.playEnemyHit();*/
                        }
                        else if(projectile is SwordStabProjectile)
                        {
                            projEne.enemy2.TakeDamage(ProjectileConstants.swordBeamDamage, projEne.direction);
                            /*SoundManager.sound.playEnemyHit();*/
                        }
                        else if(projectile is BoomerangProjectile && projEne.enemy2 is Thrower && projectile.Life < ProjectileConstants.boomerangLife/2)
                        {
                            projectile.Life = 0;
                        }
                    }

                    //Kill any enemies with health <= 0;
                    if (projEne.enemy2.Health <= 0) {
                        SoundManager.sound.playEnemyDeath();
                        eneToRemove.Add(projEne.enemy2);

                        if (projEne.enemy2 is Dragon)
                        {
                            //Spawn a heart container when the dragon dies.
/*                            AbstractItem heartContainer = new HeartContainerItem(projEne.enemy2.GetPosition());
                            heartContainer.CreateSprite();
                            myDungeon.GetCurrentLevel().AddItem(heartContainer);*/
                        }
                        else
                        {
                            //Sometimes spawn a rupee when an enemy is killed.
                            Random rand = new Random();
                            if (rand.Next(EnemyConstants.rupeeDropRate) <= 3)
                            {
                                var itemType = rand.Next(EnemyConstants.numItemDropTypes);
                                switch (itemType) {
                                    case 0:
                                        AbstractItem rupee = new RupeeItem(projEne.enemy2.GetPosition());
                                            rupee.CreateSprite();
                                        myDungeon.GetCurrentLevel().AddItem(rupee);
                                        break;
                                    case 1:
                                        AbstractItem bomb = new BombItem(projEne.enemy2.GetPosition());
                                        bomb.CreateSprite();
                                        myDungeon.GetCurrentLevel().AddItem(bomb);
                                        break;
                                    case 2:
                                        AbstractItem heart = new HeartItem(projEne.enemy2.GetPosition());
                                        heart.CreateSprite();
                                        myDungeon.GetCurrentLevel().AddItem(heart);
                                        break;

                                }
                                
                            }
                        }
                    }
                }
                //}
            }
            //remove enemies from the room
            foreach (IEnemy ene in eneToRemove) {
                myGame.projectileFactory.NewEnemyPoof(ene.DestRect.Location,ene.DestRect.Size);
                myDungeon.GetCurrentLevel().RemoveEnemy(ene);
            }

            //handle link item collision
            List<AbstractItem> itemToRemove = new List<AbstractItem>();

            foreach (AbstractItem item in myDungeon.GetCurrentLevel().GetItemList()) {
                L2ICollision itemLink = (L2ICollision)detector.detectCollision(myLink, item);
                if (itemLink.IsCollision && item.interactable) {
                    itemToRemove.Add(itemLink.Item2);
                    if (itemLink.Item2 is BombItem)
                    {
                        if (itemLink.Link1.LinkInventory.GetBombCount() == 0)
                        {
                            new PlayerPickUpCommand(myGame, itemLink.Item2).Execute();
                            itemLink.Link1.LinkInventory.AddItem(itemLink.Item2);
                            itemLink.Link1.hasPickedUpBombs = true;
                        }
                        itemLink.Link1.LinkInventory.IncrementBombs();

                        SoundManager.sound.playItemPickup();
                    }
                    else if (itemLink.Item2 is ArrowItem)
                    {
                        itemLink.Link1.LinkInventory.IncrementArrows();
                        SoundManager.sound.playItemPickup();
                    }
                    else if (itemLink.Item2 is KeyItem)
                    {
                        itemLink.Link1.LinkInventory.IncrementKeys();
                        SoundManager.sound.playItemPickup();
                    }
                    else if (itemLink.Item2 is RupeeItem)
                    {
                        itemLink.Link1.LinkInventory.IncrementRupees();
                        SoundManager.sound.playRupeePickup();
                    }
                    else if (itemLink.Item2 is BowItem)
                    {
                        itemLink.Link1.LinkInventory.AddItem(itemLink.Item2);
                        new PlayerPickUpCommand(myGame, itemLink.Item2).Execute();
                    }
                    else if (itemLink.Item2 is SwordItem) {
                        new PlayerPickUpCommand(myGame, itemLink.Item2).Execute();
                    }
                    else if (itemLink.Item2 is BoomerangItem)
                    {
                        itemLink.Link1.LinkInventory.AddItem(itemLink.Item2);
                        new PlayerPickUpCommand(myGame, itemLink.Item2).Execute();

                        SoundManager.sound.playItemPickup();
                    }
                    else if (itemLink.Item2 is CompassItem)
                    {
                        itemLink.Link1.LinkInventory.AddCompass();
                        SoundManager.sound.playItemPickup();
                    }
                    else if(itemLink.Item2 is MapItem)
                    {
                        itemLink.Link1.LinkInventory.AddMap();
                        SoundManager.sound.playItemPickup();
                    }
                    else if(itemLink.Item2 is FairyItem)
                    {
                        itemLink.Link1.Health = itemLink.Link1.maxHealth;
                        SoundManager.sound.playItemPickup();
                    }
                    else if(itemLink.Item2 is HeartItem)
                    {
                        SoundManager.sound.playHeartPickup();
                        itemLink.Link1.Health+= 2;
                        if (itemLink.Link1.Health > itemLink.Link1.maxHealth)
                        {
                            itemLink.Link1.Health = itemLink.Link1.maxHealth;
                        }
                    }
                    else if (itemLink.Item2 is TriforcePieceItem) {
                        new PlayerPickUpCommand(myGame, itemLink.Item2).Execute();
                    }else if (itemLink.Item2 is HeartContainerItem)
                    {
                        SoundManager.sound.playItemPickup();
                        itemLink.Link1.maxHealth+=2;
                        itemLink.Link1.Health += 2;
                    }else if(itemLink.Item2 is ClockItem)
                    {
                        SoundManager.sound.playItemPickup();
                        foreach (IEnemy enemy in myDungeon.GetCurrentLevel().GetEnemyList())
                        {
                            enemy.StunTimer = EnemyConstants.clockStunTime;
                        }
                    }else if(itemLink.Item2 is FireItem)
                    {
                        itemToRemove.Remove(itemLink.Item2);
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
                foreach (IEnemy ene in myDungeon.GetCurrentLevel().GetEnemyList())
                {
                    E2RCollision boundEnemy = (E2RCollision)detector.detectCollision(ene, door.destRect);
                    if (boundEnemy.IsCollision)
                    {
                        if (!(boundEnemy.enemy1 is Grabber))
                        {
                            ene.SetPosition(ene.oldPosition);
                        }
                    }
                }
                //Boundary and door collisions
                L2RCollision boundLink = (L2RCollision)detector.detectCollision(myLink, door.collider);
                if (boundLink.IsCollision && myLink.collideWithBounds)
                {
                    Point dir = Dungeon.directions[(int)door.GetDirection()];
                    Point nextPoint = myGame.GetDungeon().GetCurrentLevel().GetPosition() + new Point(dir.X, -dir.Y) * myGame.GetDungeon().GetLevelSize();
                    Level nextLevel = myGame.GetDungeon().GetLevelFromCurrent(dir);
                    if (!door.isClosed)
                    {
                        myGame.GetDungeon().SwitchLevel(dir);
                        Rectangle linkRect = myLink.DestRect;

                        Point linkNewPos = Point.Zero;
                        LevelDoor oppositeDoor = null;
                        if (dir == new Point(0, 1))
                        {
                            oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(0, -1));
                            linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width / 2 - linkRect.Width / 2, oppositeDoor.destRect.Y - (linkRect.Height));
                            myLink.SetPosition(new Point(linkNewPos.X, myLink.GetPosition().Y));

                        }
                        if (dir == new Point(1, 0))
                        {
                            oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(-1, 0));
                            linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width, oppositeDoor.destRect.Y + oppositeDoor.destRect.Height / 2 - linkRect.Height / 2);
                            myLink.SetPosition(new Point(myLink.GetPosition().X, linkNewPos.Y));
                        }
                        if (dir == new Point(0, -1))
                        {
                            oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(0, 1));
                            linkNewPos = new Point(oppositeDoor.destRect.X + oppositeDoor.destRect.Width / 2 - linkRect.Width / 2, oppositeDoor.destRect.Y + oppositeDoor.destRect.Height - linkRect.Height / 2 + 5);
                            myLink.SetPosition(new Point(linkNewPos.X, myLink.GetPosition().Y));
                        }
                        if (dir == new Point(-1, 0))
                        {
                            oppositeDoor = myGame.GetDungeon().GetCurrentLevel().GetDoorFromDirection(new Point(1, 0));
                            linkNewPos = new Point(oppositeDoor.destRect.X - (linkRect.Width), oppositeDoor.destRect.Y + oppositeDoor.destRect.Height / 2 - linkRect.Height / 2);
                            myLink.SetPosition(new Point(myLink.GetPosition().X, linkNewPos.Y));
                        }
                        if(oppositeDoor != null && oppositeDoor.isClosed)
                        {
                            if(oppositeDoor.doorType == DoorType.Hole)
                            {
                                oppositeDoor.BlowUp();
                            }
                            else
                            {
                                oppositeDoor.OpenDoor();
                            }
                        }

                        myGame.GetDungeon().GetCurrentLevel().GetLink().StartMoveToNewRoom(linkNewPos);
                        myGame.link.State.Idle();

                        Camera.main.BeginMoveTo(nextPoint, 10);
                    }
                    else
                    {
                        myLink.SetPosition(myLink.OldPosition);
                        if (door.doorType == DoorType.Key && myLink.LinkInventory.GetKeyCount() > 0)
                        {
                            myLink.LinkInventory.DecrementKeys();
                            door.OpenDoor();
                        }
                    }
                }
            }

            //TODO: handle link movable block collision

        }


    }
}

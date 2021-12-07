using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Blocks;
using Poggus.Enemies;
using Poggus.Items;

namespace Poggus.Levels.Generation
{
    public class DungeonGenerator
    {
        Random rand;
        int seed;
        public DungeonGenerator(int seed)
        {
            this.seed = seed;
            rand = new Random(seed);
        }
        public DungeonGenerator()
        {
            //Create a random seed based on changing system time
            seed = System.DateTime.Now.Minute + System.DateTime.Now.Second + System.DateTime.Now.Millisecond;
            rand = new Random(seed);
        }
        public Dungeon GenerateDungeon()
        {
            Dungeon newDungeon = new Dungeon("Dungeon: " + seed, Game1.instance._graphics.PreferredBackBufferWidth, (int)(Game1.instance._graphics.PreferredBackBufferHeight * Game1.heightScalar));
            Dictionary<char, string[]> rules = new Dictionary<char, string[]>();
            rules.Add('X', new string[] { "UW", "DW", "RW", "LW", "TXX", "{X"});
            rules.Add('T', new string[] { "XTX" , "}XT"});

            GenerateNewRoomLayout(newDungeon, "TX", 8, rules);

            Dictionary<Point, Level> dungeonLevels = newDungeon.GetLevelDictionary();
            newDungeon.UpdateLevelPositionOnly();

            foreach (KeyValuePair<Point,Level> entry in dungeonLevels)
            {
                GenerateRoom(entry.Value);
            }

            newDungeon.UpdateLevelDoors(Game1.gameScaleX, Game1.gameScaleY);

            newDungeon.SetCurrentLevel(new Point(0, 0));
            newDungeon.UpdateLevelContentPositions();
            return newDungeon;
        }
        private void GenerateNewRoomLayout(Dungeon dungeon, string axiom, int numIterations, Dictionary<char,string[]> rules)
        {
            dungeon.AddLevel(Point.Zero, new Level(Game1.instance.link, Point.Zero));

            string generatedString = ReplaceAxiom(axiom, numIterations, rules);

            Point savedPoint = Point.Zero;
            Point currentPoint = Point.Zero;
            foreach(char ch in generatedString)
            {
                if(ch == '{')
                {
                    savedPoint = currentPoint;
                }
                if(ch == '}')
                {
                    currentPoint = savedPoint;
                }
                if(ch == 'L')
                {
                    currentPoint += new Point(-1, 0);
                }
                if (ch == 'R')
                {
                    currentPoint += new Point(1, 0);
                }
                if (ch == 'U')
                {
                    currentPoint += new Point(0, 1);
                }
                if (ch == 'D')
                {
                    currentPoint += new Point(0, -1);
                }
                if(ch == 'W')
                {
                    dungeon.AddLevel(currentPoint, new Level(Game1.instance.link, new Point(0, 0)));
                }
            }
        }
        private string ReplaceAxiom(string axiom, int numIterations, Dictionary<char,string[]> rules)
        {
            string workingString = axiom;
            string finalString = "";
            for(int i = 0; i < numIterations; i++)
            {
                finalString = "";

                int stringLength = workingString.Length;
                for(int j = 0; j < stringLength; j++)
                {
                    if(rules.ContainsKey(workingString[j]))
                    {
                        //Randomly change string selected (allows one ruleset to generate an infinite number of dungeon)
                        int index = rand.Next(rules[workingString[j]].Length);
                        finalString += rules[workingString[j]][index];
                    }
                    else
                    {
                        finalString += workingString[j];
                    }
                }
                workingString = finalString;
            }

            return finalString;
        }
        private void GenerateRoom(Level level)
        {
            Poggus.Generation.OpenSimplexNoise noise = new Poggus.Generation.OpenSimplexNoise(seed);
            Point startPoint = new Point((int)(32 * Game1.gameScaleX), (int)(32 * Game1.gameScaleY));
            bool water = rand.Next(2) == 0;
            EnemyType enemyRoomType = GetRandomEnemyType();
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    double val = noise.Evaluate((level.GetPosition().X + i) / GenerationConstants.featureSize, (level.GetPosition().Y + j) / GenerationConstants.featureSize);
                    Point posInRoom = startPoint + new Point((int)(i * GenerationConstants.blockScaleX * Game1.gameScaleX), (int)(j * GenerationConstants.blockScaleY * Game1.gameScaleY));
                    Point blockPos = startPoint + new Point(i * GenerationConstants.blockScaleX, j * GenerationConstants.blockScaleY);
                    if (val > -0.2f || i == 5 || i == 6 || j == 3 )
                    {
                        AbstractBlock newBlock = new Floor(posInRoom);
                        newBlock.CreateSprite();
                        level.AddBlock(startPoint + new Point(i * GenerationConstants.blockScaleX, j * GenerationConstants.blockScaleY), newBlock);

                        if(rand.Next(GenerationConstants.enemySpawnChance) == 0)
                        {
                            level.AddEnemy(CreateEnemyFromType(enemyRoomType, posInRoom + new Point(GenerationConstants.blockScaleX / 2, -GenerationConstants.blockScaleY / 2)));
                        }
                        if(rand.Next(GenerationConstants.itemSpawnChance) == 0)
                        {
                            level.AddItem(CreateRandomItem(posInRoom + new Point(GenerationConstants.blockScaleX / 2, -GenerationConstants.blockScaleY / 2)));
                        }
                    }
                    else
                    {
                        if (water)
                        {
                            AbstractBlock newBlock = new Water(posInRoom);
                            newBlock.CreateSprite();
                            level.AddBlock(blockPos, newBlock);
                        }
                        else
                        {
                            AbstractBlock newBlock = new FloorBlock(posInRoom);
                            newBlock.CreateSprite();
                            level.AddBlock(blockPos, newBlock);
                        }
                    }
                }
            }
        }
        public AbstractItem CreateRandomItem(Point pos)
        {
            AbstractItem item;
            if(rand.Next(GenerationConstants.bombChance) == 0)
            {
                item = new BombItem(pos);
            }
            else if (rand.Next(GenerationConstants.heartChance) == 0)
            {
                item = new HeartItem(pos);
            }
            else if(rand.Next(GenerationConstants.heartContainerChance) == 0)
            {
                item = new HeartContainerItem(pos);
            }
            else if(rand.Next(GenerationConstants.fairyChance) == 0)
            {
                item = new FairyItem(pos);
            }
            else if(rand.Next(GenerationConstants.mapChance) == 0)
            {
                item = new MapItem(pos);
            }
            else
            {
                item = new RupeeItem(pos);
            }
            item.CreateSprite();
            return item;
        }
        public EnemyType GetRandomEnemyType()
        {
            EnemyType type;
            if(rand.Next(GenerationConstants.batChance) == 0)
            {
                type = EnemyType.Bat;
            }
            else if(rand.Next(GenerationConstants.throwerChance) == 0)
            {
                type = EnemyType.Thrower;
            }
            else if(rand.Next(GenerationConstants.skeletonChance) == 0)
            {
                type = EnemyType.Skeleton;
            }
            else if(rand.Next(GenerationConstants.bladeChance) == 0)
            {
                type = EnemyType.BladeTrap;
            }
            else
            {
                type = EnemyType.Slime;
            }
            return type;
        }
        public AbstractEnemy CreateEnemyFromType(EnemyType enemyType, Point pos)
        {
            AbstractEnemy enemy;
            if (enemyType == EnemyType.Bat)
            {
                enemy = new Bat(pos);
            }
            else if(enemyType == EnemyType.Skeleton)
            {
                enemy = new Skeleton(pos);
            }
            else if(enemyType == EnemyType.BladeTrap)
            {
                enemy = new BladeTrap(pos);
            }
            else if(enemyType == EnemyType.Thrower)
            {
                enemy = new Thrower(pos);
            }
            else
            {
                enemy = new Slime(pos);
            }

            enemy.CreateSprite();
            return enemy;
        }
    }
}

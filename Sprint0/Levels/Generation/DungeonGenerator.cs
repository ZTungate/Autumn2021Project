using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Blocks;

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
            float featureSize = 5f;
            bool water = rand.Next(2) == 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    double val = noise.Evaluate((level.GetPosition().X + i) / featureSize, (level.GetPosition().Y + j) / featureSize);
                    if (val > -0.2f || i == 5 || i == 6 || j == 3 )
                    {
                        AbstractBlock newBlock = new Floor(startPoint + new Point((int)(i * 16 * Game1.gameScaleX), (int)(j * 16 * Game1.gameScaleY)));
                        newBlock.CreateSprite();
                        level.AddBlock(startPoint + new Point(i * 16, j * 16), newBlock);
                    }
                    else
                    {
                        if (water)
                        {
                            AbstractBlock newBlock = new Water(startPoint + new Point((int)(i * 16 * Game1.gameScaleX), (int)(j * 16 * Game1.gameScaleY)));
                            newBlock.CreateSprite();
                            level.AddBlock(startPoint + new Point(i * 16, j * 16), newBlock);
                        }
                        else
                        {
                            AbstractBlock newBlock = new FloorBlock(startPoint + new Point((int)(i * 16 * Game1.gameScaleX), (int)(j * 16 * Game1.gameScaleY)));
                            newBlock.CreateSprite();
                            level.AddBlock(startPoint + new Point(i * 16, j * 16), newBlock);
                        }
                    }
                }
            }
        }

    }
}

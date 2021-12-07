using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Levels.Generation
{
    static class GenerationConstants
    {
        public static float featureSize = 5f;
        public static int blockScaleX = 16, blockScaleY = 16;
        //Chance = (1 / value)
        public static int itemSpawnChance = 75, enemySpawnChance = 50;
        public static int bombChance = 25, mapChance = 20, keyChance = 20, arrowChance = 5, fairyChance = 50,heartChance = 10,heartContainerChance = 15;
        public static int slimeChance = 5, batChance = 5, skeletonChance = 8, throwerChance = 10, bladeChance = 20;
    }
}

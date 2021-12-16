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
        public static int itemSpawnChance = 75, enemySpawnChance = 35;
        public static int bombChance = 25, mapChance = 20, keyChance = 20, arrowChance = 5, fairyChance = 50,heartChance = 10,heartContainerChance = 15, bowChance = 75;
        public static int slimeChance = 5, batChance = 5, skeletonChance = 4, throwerChance = 3, bladeChance = 5;
        public static int chanceLockedDoor = 75, chanceClearRoomDoor = 75, chanceHoleDoor = 100;
        public static int chanceSand = 20,moveBlockChance = 200;
    }
}

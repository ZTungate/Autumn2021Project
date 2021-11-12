using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Inventory
{
    public class Inventory
    {
        private const int ITEMS = 20; //const that is very temporary

        private int arrows = 0;
        private int bombs = 0;
        private int rubies = 0;
        protected bool hasMap = false;
        protected bool hasCompass = false;

        protected int Arrows { get => arrows; set => arrows = value; }
        protected int Bombs { get => bombs; set => bombs = value; }
        protected int Rubies { get => rubies; set => rubies = value; }

        public Inventory()
        {
            
        }


        public void incrementArrows(int Amount)
        {
            Arrows += Amount;
        }

        public void decrementArrows(int Amount)
        {
            Arrows -= Amount;
        }

        public int getArrowCount()
        {
            return Arrows;
        }

        public void incrementBombs(int Amount)
        {
            Bombs += Amount;
        }

        public void decrementBombs(int Amount)
        {
            Bombs -= Amount;
        }

        public int getBombCount()
        {
            return Bombs;
        }

        public void incrementRubies(int Amount)
        {
            Rubies += Amount;
        }

        public void decrementRubies(int Amount)
        {
            Rubies -= Amount;
        }

        public int getRubyCount()
        {
            return Rubies;
        }

        public bool getMapState()
        {
            return hasMap;
        }

        public void addMap()
        {
            hasMap = true;
        }
        public bool getCompassState()
        {
            return hasCompass;
        }

        public void addCompass()
        {
            hasCompass = true;
        }

    }
}

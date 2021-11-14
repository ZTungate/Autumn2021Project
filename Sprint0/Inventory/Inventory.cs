using Poggus.Items;
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
        private int rupee = 0;
        protected bool hasMap = false;
        protected bool hasCompass = false;
        protected List<AbstractItem> itemList = new List<AbstractItem>();
        protected int Arrows { get => arrows; set => arrows = value; }
        protected int Bombs { get => bombs; set => bombs = value; }
        protected int Rupees { get => rupee; set => rupee = value; }

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

        public void incrementRupees(int Amount)
        {
            Rupees += Amount;
        }

        public void decrementRupees(int Amount)
        {
            Rupees -= Amount;
        }

        public int getRupeeCount()
        {
            return Rupees;
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
        public void addItem(AbstractItem toAdd)
        {
            itemList.Add(toAdd);

        }
        public void removeItem(AbstractItem toRemove)
        {
            itemList.Remove(toRemove);

        }
        public bool checkItem(AbstractItem check)
        {
            return itemList.Contains(check);

        }
    }
}

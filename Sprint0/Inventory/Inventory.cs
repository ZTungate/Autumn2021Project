﻿using Poggus.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Inventory
{
    public class Inventory
    {
        

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


        public void IncrementArrows()
        {
            Arrows++;
        }

        public void DecrementArrows()
        {
            Arrows--;
        }

        public int GetArrowCount()
        {
            return Arrows;
        }

        public void IncrementBombs()
        {
            Bombs ++;
        }

        public void DecrementBombs()
        {
            Bombs--;
        }

        public int GetBombCount()
        {
            return Bombs;
        }

        public void IncrementRupees()
        {
            Rupees++;
        }

        public void DecrementRupees()
        {
            Rupees--;
        }

        public int GetRupeeCount()
        {
            return Rupees;
        }

        public bool GetMapState()
        {
            return hasMap;
        }

        public void AddMap()
        {
            hasMap = true;
        }
        public bool GetCompassState()
        {
            return hasCompass;
        }

        public void AddCompass()
        {
            hasCompass = true;
        }
        public void AddItem(AbstractItem toAdd)
        {
            itemList.Add(toAdd);

        }
        public void RemoveItem(AbstractItem toRemove)
        {
            itemList.Remove(toRemove);

        }
        public bool CheckItem(AbstractItem check)
        {
            return itemList.Contains(check);

        }
    }
}

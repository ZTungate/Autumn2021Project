﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Enemies
{
    public interface IBoomerangThrowerState
    {
        public void TurnUp();
        public void TurnDown();
        public void TurnLeft();
        public void TurnRight();
        public Vector2 AttackDirection();
        public void Update();
    }
}

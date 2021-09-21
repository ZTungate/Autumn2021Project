﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public interface ISkeletonState
    {
        //Commands to change location of the skeleton, animation/sprite does not change based on position or direction
        //Wrong place for these? commented out for now
        //void MoveUp();
        //void MoveDown();
        //void MoveLeft();
        //void MoveRight();
        void Update();
        void Draw(SpriteBatch spriteBatch);

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public interface ISkeletonState
    {
        //Commands to change location of the skeleton, animation/sprite does not change based on position or direction
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Update();

    }
}

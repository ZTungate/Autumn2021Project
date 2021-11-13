using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Helpers
{
    public static class CustomMath
    {
        public static int MathMod(int a, int b)
        {
            return (a % b + b) % b;
        }
    }
}

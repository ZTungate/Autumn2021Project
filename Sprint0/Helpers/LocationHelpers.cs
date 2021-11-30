using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Helpers
{
    class LocationHelpers
    {
        public static Point GetCenter(Rectangle srcRectangle)
        {
            int x = srcRectangle.X + (srcRectangle.Width / 2);
            int y = srcRectangle.Y + (srcRectangle.Height / 2);
            return new Point(x, y);
        }

        public static Point GetLocationCenteredSpawnRight(Rectangle spawningObjectRectangle,Point toSpawnSize)
        {
            int y = spawningObjectRectangle.Y + (spawningObjectRectangle.Height / 2) - (toSpawnSize.Y / 2);
            int x = spawningObjectRectangle.X + spawningObjectRectangle.Width;
            return new Point(x,y);
        }
        public static Point GetLocationCenteredSpawnLeft(Rectangle spawningObjectRectangle, Point toSpawnSize)
        {
            int y = spawningObjectRectangle.Y + (spawningObjectRectangle.Height / 2) - (toSpawnSize.Y / 2);
            int x = spawningObjectRectangle.X - toSpawnSize.X;
            return new Point(x, y);
        }
        public static Point GetLocationCenteredSpawnDown(Rectangle spawningObjectRectangle, Point toSpawnSize)
        {
            int y = spawningObjectRectangle.Y + spawningObjectRectangle.Height;
            int x = spawningObjectRectangle.X + (spawningObjectRectangle.Width / 2) - (toSpawnSize.X / 2);
            return new Point(x, y);
        }
        public static Point GetLocationCenteredSpawnUp(Rectangle spawningObjectRectangle, Point toSpawnSize)
        {
            int y = spawningObjectRectangle.Y - toSpawnSize.Y;
            int x = spawningObjectRectangle.X + (spawningObjectRectangle.Width / 2) - (toSpawnSize.X / 2);
            return new Point(x, y);
        }

        public static Point GetLocationLeftJustifiedSpawnUp(Rectangle spawningObjectRectangle, Point toSpawnSize)
        {
            int y = spawningObjectRectangle.Y - toSpawnSize.Y;
            int x = spawningObjectRectangle.X;
            return new Point(x, y);
        }
    }
}

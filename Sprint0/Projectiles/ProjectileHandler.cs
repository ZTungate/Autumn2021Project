using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Projectiles
{
    public class ProjectileHandler
    {
        private List<IProjectile> projectiles;

        private static ProjectileHandler instance = new ProjectileHandler();

        public static ProjectileHandler Instance
        {
            get
            {
                return instance;
            }
        }

    }
}

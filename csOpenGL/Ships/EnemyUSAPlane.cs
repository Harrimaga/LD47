using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Ships
{
    class EnemyUSAPlane : EnemyPlane
    {

        public EnemyUSAPlane(Vector2 position, Movement movement, int spawnNumber, int maxPlanes) : base(Enums.Nation.USA, position, 5, 25, 25, 120, movement, spawnNumber, maxPlanes)
        {
            projectileSpeed = 12;
        }

        public override void Shoot()
        {

        }


    }
}

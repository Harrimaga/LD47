using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Ships
{
    class TestEnemy : EnemyPlane
    {

        public TestEnemy(Vector2 position, Movement movement, int spawnNumber, int maxPlanes) : base(Enums.Nation.Germany, position, 5, 48, 48, 120, movement, spawnNumber, maxPlanes)
        {
            projectileSpeed = 12;
        }

        public override void Shoot()
        {
            
        }
    }
}

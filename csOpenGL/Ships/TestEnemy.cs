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

        public TestEnemy(Vector2 position, Movement movement, int spawnNumber, int maxPlanes) : base(Enums.Nation.Germany, position, 5, 25, 25, 120, movement, spawnNumber, maxPlanes)
        {
            projectileSpeed = 20;
        }

        public override void Shoot()
        {
            
        }
    }
}

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

        public TestEnemy(Vector2 position) : base(Enums.Nation.Germany, position, 5, 25, 25)
        {

        }

        public override void AIMovement()
        {
            position.Y += (float)Globals.delta;
        }

        public override void Shoot()
        {
            
        }


    }
}

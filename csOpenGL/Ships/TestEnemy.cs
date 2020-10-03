using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Ships
{
    class TestEnemy : Plane
    {

        public TestEnemy(Vector2 position) : base(Enums.Nation.USA, position, 1, 25, 25)
        {

        }

        public override void AIMovement()
        {
            position.Y += (float)Globals.delta;
        }

        public override void Shoot()
        {
            
        }

        public override void ShootAt(Plane target)
        {
            
        }

        public override void Update(double delta)
        {
            
        }


        public override void Draw()
        {
            sprite.Draw(position.X, position.Y, true, 0, 1, 1, 1, 1);
        }


    }
}

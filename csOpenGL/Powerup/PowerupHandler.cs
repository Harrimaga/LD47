using LD47.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Powerup
{
    public class PowerupHandler
    {

        public int powerupsAvailable = 3;

        public PowerupHandler()
        {

        }

        public void EnemyDeath(Plane plane)
        {
            if (Globals.random.Next(100) < (plane is AA ? 40 : 20))
            {
                int p = Globals.random.Next(powerupsAvailable);

                switch (p)
                {
                    case 0:
                        Globals.currentLevel.powerups.Add(new Restore(plane.position.X, plane.position.Y, 50, 50, 0, 1, new Sprite(50, 50, 0, 1)));
                        break;
                    case 1:
                        Globals.currentLevel.powerups.Add(new ShotSpeed(plane.position.X, plane.position.Y, 20, 20, 0, 1, new Sprite(20, 20, 0, 1)));
                        break;
                    case 2:
                        Globals.currentLevel.powerups.Add(new Multishot(plane.position.X, plane.position.Y, 10, 10, 0, 1, new Sprite(10, 10, 0, 1)));
                        break;
                    default:
                        Globals.currentLevel.powerups.Add(new Restore(plane.position.X, plane.position.Y, 5, 5, 0, 1, new Sprite(5, 5, 0, 1)));
                        break;
                }
            }
        }
    }
}

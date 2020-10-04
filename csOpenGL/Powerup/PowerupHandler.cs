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
            if (Globals.random.NextDouble() * 100 < (plane is AA ? 15 * (2/Globals.difficulty) : 7.5 * (2 / Globals.difficulty)))
            {
                int p = Globals.random.Next(powerupsAvailable);

                switch (p)
                {
                    case 0:
                        Globals.currentLevel.powerups.Add(new Restore(plane.position.X, plane.position.Y, 32, 32, 0, 1, new AnimatedSprite(32, 32, 18, 10)));
                        break;
                    case 1:
                        Globals.currentLevel.powerups.Add(new ShotSpeed(plane.position.X, plane.position.Y, 32, 32, 0, 1, new AnimatedSprite(32, 32, 17, 10)));
                        break;
                    case 2:
                        Globals.currentLevel.powerups.Add(new Multishot(plane.position.X, plane.position.Y, 32, 32, 0, 1, new AnimatedSprite(32, 32, 16, 10)));
                        break;
                    default:
                        Globals.currentLevel.powerups.Add(new Restore(plane.position.X, plane.position.Y, 32, 32, 0, 1, new AnimatedSprite(32, 32, 18, 10)));
                        break;
                }
            }
        }
    }
}

using LD47.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Powerup
{
    public class ShotSpeed : Pickupable
    {
        public ShotSpeed(float x, float y, int width, int height, float dx, float dy, AnimatedSprite sprite) : base(x, y, width, height, dx, dy, sprite)
        {

        }

        protected override void OnCollision(Player player)
        {
            player.shootCD *= 0.85;

            base.OnCollision(player);
        }
    }
}

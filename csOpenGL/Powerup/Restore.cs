using LD47.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Powerup
{
    public class Restore : Pickupable
    {
        public Restore(float x, float y, int width, int height, float dx, float dy, AnimatedSprite sprite) : base(x, y, width, height, dx, dy, sprite)
        {

        }

        protected override void OnCollision(Player player)
        {
            player.health += 1;
            if (player.health > 10)
            {
                player.health = 10;
            }

            base.OnCollision(player);
        }
    }
}

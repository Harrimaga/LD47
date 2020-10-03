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
        public Restore(float x, float y, int width, int height, float dx, float dy, Sprite sprite) : base(x, y, width, height, dx, dy, sprite)
        {

        }

        protected override void OnCollision(Player player)
        {
            // @NOTICE: This means that you could overheal, but I'll allow that for now
            player.health += 1;
        }
    }
}

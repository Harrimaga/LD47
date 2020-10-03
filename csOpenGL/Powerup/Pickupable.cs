using LD47.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Powerup
{
    public abstract class Pickupable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Dx { get; set; }
        public float Dy { get; set; }
        public Sprite Sprite { get; set; }

        public virtual void Draw()
        {
            Sprite.Draw(X, Y);
        }

        public virtual void Update()
        {
            X = (float)Globals.delta * Dx;
            Y = (float)Globals.delta * Dy;

            Player player = Globals.player;

            if (player.)
        }
    }
}

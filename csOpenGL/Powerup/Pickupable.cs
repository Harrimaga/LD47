using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Powerup
{
    abstract class Pickupable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public Sprite Sprite { get; set; }

        public virtual void Draw()
        {

        }

        public virtual void Update()
        {

        }
    }
}

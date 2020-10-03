using LD47.Ships;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Weapons
{
    public class Projectile
    {
        private Plane origin;
        private Vector2 speed;
        private Vector2 position;
        private Sprite sprite;

        public Projectile(Plane origin, Vector2 speed, Vector2 position, int w, int h, int tex)
        {
            this.origin = origin;
            this.speed = speed;
            this.position = position;
            sprite = new Sprite(w, h, 0, tex);
        }

        public void Update(double delta)
        {
            position += new Vector2((float)(speed.X * delta), (float)(speed.Y * delta));
        }

        public void Draw()
        {
            sprite.Draw(position.X, position.Y);
        }
    }
}

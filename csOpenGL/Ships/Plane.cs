using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Ships
{
    public abstract class Plane
    {
        protected Enums.Nation nation;
        public Vector2 position;
        public int health, tex, w, h;
        protected AnimatedSprite sprite;

        public Plane(Enums.Nation nation, Vector2 position, int tex, int w, int h, int health = 1)
        {
            this.nation = nation;
            this.position = position;
            this.health = health;
            this.tex = tex;
            this.w = w;
            this.h = h;


            sprite = new AnimatedSprite(w, h, tex, 5);
        }

        public abstract void AIMovement();
        public abstract void Update(double delta);
        public abstract void Draw();
        public abstract void Shoot();
        public abstract void ShootAt(Plane target);
    }
}

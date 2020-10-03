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
        protected Vector2 position;
        protected int health, tex, w, h;
        protected Sprite sprite;

        public Plane(Enums.Nation nation, Vector2 position, int tex, int w, int h, int health = 1)
        {
            this.nation = nation;
            this.position = position;
            this.health = health;
            this.tex = tex;


            sprite = new Sprite(w, h, 0, tex);
        }

        public abstract void AIMovement();
        public abstract void Update(double delta);
        public abstract void Draw();
        public abstract void Shoot();
        public abstract void ShootAt(Plane target);
    }
}

using OpenTK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    
    public class Explosion
    {
        private AnimatedSprite sprite;
        private Vector2 position;
        private float rotation;
        private double ttl = 30;

        public Explosion(int w, int h, Vector2 position)
        {
            sprite = new AnimatedSprite(w, h, Textures.Explosion, 5);
            this.position = position;
            rotation = (float)(Globals.random.NextDouble() * Math.PI * 2);
        }

        public void Draw()
        {
            sprite.Draw(position.X, position.Y, true, rotation);
        }

        public void Update()
        {
            if (ttl <= 0)
            {
                Globals.currentLevel.explosions.Remove(this);
            }

            ttl -= Globals.delta;
        }
    }
}

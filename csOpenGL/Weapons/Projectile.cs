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

        public bool Update(double delta)
        {
            position += new Vector2((float)(speed.X * delta), (float)(speed.Y * delta));
            if(!Globals.checkCol(1920/2 - 400, 45, 800, Level.gameHeight, position.X, position.Y, sprite.w, sprite.h))
            {
                return true;
            }
            if(origin is Player)
            {
                foreach(Plane p in Globals.currentLevel.planes)
                {
                    if(Globals.checkCol((int)position.X, (int)position.Y, sprite.w, sprite.h, (int)p.position.X, (int)p.position.Y, p.w, p.h))
                    {
                        p.health--;
                        return true;
                    }
                }
            }
            else
            {
                if (Globals.checkCol((int)position.X, (int)position.Y, sprite.w, sprite.h, (int)Globals.player.position.X, (int)Globals.player.position.Y, Globals.player.w, Globals.player.h))
                {
                    Globals.player.health--;
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            sprite.Draw(position.X, position.Y);
        }
    }
}

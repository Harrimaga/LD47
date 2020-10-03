using LD47.Ships;
using LD47.Waves;
using LD47.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    public class Level
    {
        public const int gameHeight = 1000;
        public Texture background;
        public double timePassed = 0;
        public List<EnemyWave> waves;
        public List<Plane> planes;
        public List<Projectile> projectiles;

        public Level(int background)
        {
            this.background = Textures.Get(background);
            waves = new List<EnemyWave>();
            planes = new List<Plane>();
            waves.Add(new BasicWave<TestEnemy>(120, 120, 5, new OpenTK.Vector2(200, 45)));
            projectiles = new List<Projectile>();
            //waves.Add(new EnemyWave(12, 2, 2));
        }

        public void addPlane(Plane p)
        {
            planes.Add(p);
        }

        public void Update()
        {
            timePassed += Globals.delta;
            // background updating
            if (timePassed > background.totH-gameHeight)
            {
                timePassed = background.totH - gameHeight;
            }
            if(timePassed < 0)
            {
                timePassed = 0;
            }
            // Enemy spawning
            for(int i = 0; i < waves.Count; i++)
            {
                if(waves[i].update(timePassed))
                {
                    waves.RemoveAt(i);
                    i--;
                }
            }
            foreach(Plane p in planes)
            {
                p.Update(Globals.delta);
            }

            foreach (Projectile p in projectiles)
            {
                p.Update(Globals.delta);
            }
        }

        public void draw()
        {
            background.AddToList(1920 / 2 - 400, 45, 1, 1, 1, 1, (int)timePassed , background.totW, gameHeight);
            foreach(Plane p in planes)
            {
                p.Draw();
            }

            foreach (Projectile p in projectiles)
            {
                p.Draw();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    class Level
    {
        public const int gameHeight = 1000;
        public Texture background;
        public double timePassed = 0;
        public List<EnemyWave> waves;

        public Level(int background)
        {
            this.background = Textures.Get(background);
            waves = new List<EnemyWave>();
            //waves.Add(new EnemyWave(120, 2, 20));
            //waves.Add(new EnemyWave(12, 2, 2));
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

        }

        public void draw()
        {
            background.AddToList(45, 45, 1, 1, 1, 1, (int)timePassed , background.totW, gameHeight);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    class Level
    {
        public const int gameHeight = 900;
        public Texture background;
        public double backscroll = 0;

        public Level(int background)
        {
            this.background = Textures.Get(background);
        }

        public void Update()
        {
            backscroll += Globals.delta;
            if(backscroll > background.totH-gameHeight)
            {
                backscroll = background.totH - gameHeight;
            }
            if(backscroll < 0)
            {
                backscroll = 0;
            }
        }

        public void draw()
        {
            background.AddToList(90, 90, 1, 1, 1, 1, (int)backscroll , background.totW, gameHeight);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47
{
    public class AnimatedSprite : Sprite
    {
        double time;
        double animationTime;
        int spriteNum;

        public AnimatedSprite(int w, int h, int texture, double animationTime) : base(w, h, 0, texture)
        {
            time = 0;
            spriteNum = 0;
            this.animationTime = animationTime;
        }

        public override void Draw(float x, float y, bool cam = true, float rot = 0, float r = 1, float g = 1, float b = 1, float a = 1)
        {
            time += Globals.delta;
            if (time >= animationTime)
            {
                spriteNum++;

                if (spriteNum > texture.wNum - 1)
                {
                    spriteNum = 0;
                }
                time = 0;
            }

            num = spriteNum;

            base.Draw(x, y, cam, rot, r, g, b, a);
        }
    }
}

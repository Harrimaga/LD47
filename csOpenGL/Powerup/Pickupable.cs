using LD47.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Powerup
{
    public abstract class Pickupable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Dx { get; set; }
        public float Dy { get; set; }
        public AnimatedSprite Sprite { get; set; }

        protected Pickupable(float x, float y, int width, int height, float dx, float dy, AnimatedSprite sprite)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Dx = dx;
            Dy = dy;
            Sprite = sprite;
        }

        public virtual void Draw()
        {
            Sprite.Draw(X, Y);
        }

        public void Update()
        {
            X += (float)Globals.delta * Dx;
            Y += (float)Globals.delta * Dy;

            Player player = Globals.player;

            if ( Globals.checkCol(player.position.X, player.position.Y, player.w, player.h, X, Y, Width, Height) )
            {
                OnCollision(player);
            }
        }

        protected virtual void OnCollision(Player player) 
        {
            Globals.currentLevel.powerups.Remove(this);
        }
    }
}

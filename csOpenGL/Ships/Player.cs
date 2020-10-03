using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Ships
{
    public class Player : Plane
    {
        private Hotkey left = new Hotkey(true).AddKey(Key.A).AddKey(Key.Left);
        private Hotkey right = new Hotkey(true).AddKey(Key.D).AddKey(Key.Right);
        private Hotkey up = new Hotkey(true).AddKey(Key.W).AddKey(Key.Up);
        private Hotkey down = new Hotkey(true).AddKey(Key.S).AddKey(Key.Down);
        private Hotkey space = new Hotkey(false).AddKey(Key.Space);


        public Player(Enums.Nation nation) : base(nation, new Vector2(1920/2, 1080/2), 3, 64, 64, 3)
        {

        }

        public override void AIMovement()
        {
            
        }

        public override void Draw()
        {
            sprite.Draw(position.X, position.Y, true, 0, 1, 1, 1, 1);
        }

        public override void Shoot()
        {
            Globals.projectiles.Add(new Weapons.Projectile(this, new Vector2(0, -10), position + new Vector2(w / 2 - 2, -10), 4, 8, 4));
        }

        public override void ShootAt(Plane target)
        {
            
        }

        public override void Update(double delta)
        {
            if (left.IsDown()) position.X -= (float)(10 * delta);
            if (right.IsDown()) position.X += (float)(10 * delta);
            if (up.IsDown()) position.Y -= (float)(10 * delta);
            if (down.IsDown()) position.Y += (float)(10 * delta);
            if (space.IsDown()) Shoot();
        }
    }
}

using OpenTK;
using OpenTK.Graphics.ES20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Ships
{
    public class AA : EnemyPlane
    {
        public float ShotInterval { get; set; }
        private float ShotDelta { get; set; }
        public AA(Enums.Nation nation, Vector2 position, int tex, int w, int h, int health = 1, float shotInterval = 25f) : base(nation, position, tex, w, h, health, null, 0)
        {
            ShotDelta = 0;
            ShotInterval = shotInterval;
        }

        public override void AIMovement()
        {
            position.Y += (float) Globals.delta;
        }

        public override void Draw()
        {
            sprite.Draw(position.X, position.Y);
        }

        public override void Shoot()
        {
        }

        public override void ShootAt(Plane target)
        {
            var x = target.position.X - position.X;
            var y = target.position.Y - position.Y;
            double angle = Math.Atan( y / x );
            float xspeed = (float) Math.Cos(angle) * 15;
            float yspeed = (float) Math.Sin(angle) * 15;
            Globals.currentLevel.projectiles.Add(new Weapons.Projectile(this, new Vector2(xspeed, yspeed), position + new Vector2(w / 2, h / 2) - new Vector2(3, 3), 6, 6, 1));
        }

        public override void Update(double delta)
        {
            AIMovement();
            ShotDelta += (float)delta;
            if (ShotDelta > ShotInterval)
            {
                ShootAt(Globals.player);
                ShotDelta -= ShotInterval;
            }
        }

        public override void OnDeath()
        {
            
        }
    }
}

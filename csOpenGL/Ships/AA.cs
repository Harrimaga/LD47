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
        public AA(Enums.Nation nation, Vector2 position, int tex, int w, int h, int health = 1, float shotInterval = 65f) : base(nation, position, tex, w, h, health, null, 0, 0)
        {
            ShotDelta = 0;
            ShotInterval = shotInterval / (float)((Globals.difficulty - 1) / 6 + 1);
        }

        public override void AIMovement()
        {
            if (!Globals.stoppedScrolling)
            {
                position.Y += (float)Globals.delta;
            }
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
            Vector2 tar = (target.position + new Vector2(target.w/2, target.h/2)) - (position + new Vector2(w / 2, h / 2));
            tar.Normalize();
            Globals.currentLevel.projectiles.Add(new Weapons.Projectile(this, tar*12, position + new Vector2(w / 2, h / 2) - new Vector2(6, 12), 12, 24, 15));
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
            Globals.currentLevel.explosions.Add(new Explosion(w, h, position));
            Globals.levelScore += (ulong)(350 * Globals.difficulty);
        }
    }
}

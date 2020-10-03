using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Ships
{
    public abstract class EnemyPlane : Plane
    {

        public double attackInterval, attackTimer;

        public EnemyPlane(Enums.Nation nation, Vector2 position, int tex, int w, int h, double attackInterval, int health = 1) : base(nation, position + new Vector2(1920/2 -400, 45), tex, w, h, health)
        {
            this.attackInterval = attackInterval/Globals.difficulty;
            attackTimer = 0;
        }

        public override void Draw()
        {
            sprite.Draw(position.X, position.Y, true, 0, 1, 1, 1, 1);
        }

        public override void Update(double delta)
        {
            attackTimer += delta;
            AIMovement();
            if(attackTimer >= attackInterval)
            {
                attackTimer -= attackInterval;
                ShootAt(Globals.player);
            }
        }

        public override void ShootAt(Plane target)
        {
            Globals.projectiles.Add(new Weapons.Projectile(this, new Vector2(0, 20), position + new Vector2(w / 2, h / 2) - new Vector2(3, 3), 6, 6, 1));
        }

    }
}

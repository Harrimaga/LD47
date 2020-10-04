﻿using OpenTK;
using System;

namespace LD47.Ships
{
    public abstract class EnemyPlane : Plane
    {

        public double attackInterval, attackTimer;
        public float rotation = 0, projectileSpeed;
        public bool rotates = true;

        public EnemyPlane(Enums.Nation nation, Vector2 position, int tex, int w, int h, double attackInterval, int health = 1) : base(nation, position + new Vector2(1920 / 2 - 400, 45), tex, w, h, health)
        {
            this.attackInterval = attackInterval / Globals.difficulty;
            attackTimer = 0;
        }

        public override void Draw()
        {
            sprite.Draw(position.X, position.Y, true, rotation, 1, 1, 1, 1);
        }

        public override void Update(double delta)
        {
            attackTimer += delta;
            Vector2 prev = position;
            AIMovement();
            if (rotates)
            {
                prev -= position;
                prev.Normalize();
                rotation = (float)Math.Atan2(-prev.X, prev.Y);
            }
            else
            {
                rotation = (float)Math.PI;
            }


            if (attackTimer >= attackInterval)
            {
                attackTimer -= attackInterval;
                ShootAt(Globals.player);
            }
        }

        public override void ShootAt(Plane target)
        {
            Globals.currentLevel.projectiles.Add(new Weapons.Projectile(this, new Vector2(projectileSpeed*(float)Math.Sin(rotation), -projectileSpeed * (float)Math.Cos(rotation)), position + new Vector2(w / 2, h / 2) - new Vector2(3, 3), 6, 6, 1));
        }

        public override void OnDeath()
        {
            Globals.levelScore += (ulong)(100 * Globals.difficulty);
        }

    }
}

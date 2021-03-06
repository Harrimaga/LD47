﻿using OpenTK;
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
        private Hotkey space = new Hotkey(true).AddKey(Key.Space);
        private Hotkey e = new Hotkey(false).AddKey(Key.E);
        public int BombsLeft { get; set; }

        public double shootCD = 20;
        public int multishot = 1;
        private double shootTime = 20;


        public Player(Enums.Nation nation) : base(nation, new Vector2(1920/2, 1080/2), 3, 64, 64, 5)
        {
            BombsLeft = 5;
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
            if (shootTime > shootCD)
            {
                if (multishot > 3)
                {
                    float angle = (float)Math.PI / (multishot + 1);

                    for (int i = 0; i < multishot; i++)
                    {
                        float shotAngle = angle * (i + 1);
                        Vector2 dir = new Vector2((float)Math.Cos(shotAngle), -(float)Math.Sin(shotAngle));
                        dir *= 10;
                        Globals.currentLevel.projectiles.Add(new Weapons.Projectile(this, dir, position + new Vector2(w / 2 - 6, -10), 12, 24, 4));
                    }
                }

                else
                {
                    Vector2 shotPos = new Vector2(w / 2 + 8 - (multishot - 1) * 5, -10);
                    for (int i = 0; i < multishot; i++)
                    {
                        Globals.currentLevel.projectiles.Add(new Weapons.Projectile(this, new Vector2(0, -10), position + shotPos + new Vector2((i - 1) * 10 - 6, 0), 12, 24, 4));
                    }
                }
                

                shootTime = 0;
            }
        }

        public override void ShootAt(Plane target)
        {
            
        }

        public override void Update(double delta)
        {
            shootTime += delta;
            foreach(Plane p in Globals.currentLevel.planes)
            {
                if(!(p is AA))
                {
                    if(Globals.checkCol(position.X, position.Y, w, h, p.position.X, p.position.Y, p.w, p.h))
                    {
                        health--;
                        p.health--;
                    }
                }
            }
            if (left.IsDown())
            {
                position.X -= (float)(10 * delta);
                if (position.X < 1920 / 2 - 400)
                {
                    position.X = 1920 / 2 - 400;
                }
            }

            if (right.IsDown())
            {
                position.X += (float)(10 * delta);
                if (position.X > 1920 / 2 + 400 - 64)
                {
                    position.X = 1920 / 2 + 400 - 64;
                }
            }

            if (up.IsDown())
            {
                position.Y -= (float)(10 * delta);
                if (position.Y < 45)
                {
                    position.Y = 45;
                }
            }

            if (down.IsDown())
            {
                position.Y += (float)(10 * delta);
                if (position.Y > 1080 - 109)
                {
                    position.Y = 1080 - 109;
                }
            }

            if (space.IsDown()) Shoot();
            //if (e.IsDown()) multishot++;
        }

        public override void OnDeath()
        {
            
        }

    }
}

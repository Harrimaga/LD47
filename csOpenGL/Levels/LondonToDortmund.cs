﻿using LD47.Ships;
using LD47.Waves;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD47.Levels
{
    class LondonToDortmund : Level
    {

        public LondonToDortmund() : 
            base(
                Textures.MapLondonDortmund
                , new Dictionary<string, Vector2>
                {
                    { "London", new Vector2(420, 300) },
                    { "Middelburg", new Vector2(428, 6000-2981) },
                    { "Vlissingen", new Vector2(473, 6000-3008) },
                    { "Oostkapelle", new Vector2(342, 6000-3025) },
                    { "Antwerp", new Vector2(751, 6000-2418) },
                    { "Breda", new Vector2(316, 6000-2190) },
                    { "Tilburg", new Vector2(348, 6000-1991) },
                    { "Den Bosch", new Vector2(197, 6000-1811) },
                    { "Eindhoven", new Vector2(499, 6000-1714) },
                    { "Nijmegen", new Vector2(68, 6000-1474) },
                    { "Venlo", new Vector2(567, 6000-1273) },
                    { "Krefeld", new Vector2(610, 6000-958) },
                    { "Dusseldorf", new Vector2(722, 6000-843) },
                    { "Duisburg", new Vector2(508, 6000-855) },
                    { "Gelschenkirchen", new Vector2(399, 6000-742) },
                    { "Wuppertal", new Vector2(683, 6000-538) },
                    { "Dortmund", new Vector2(434, 6000-544) },
                    { "Wesel", new Vector2(243, 6000-923) },
                    { "Bocholt", new Vector2(49, 6000-925) },
                    { "Dumen", new Vector2(52, 6000-763) }
                }
                , 600
            )
        {
            date = "June 12th 1943";
        }

        public override void AddWaves()
        {
            waves = new List<EnemyWave>();
            waves.Add(new BasicWave<TestEnemy>(120, 60, 4, new Vector2(400, -27), Arch));
            if (Globals.difficulty >= 2)
            {
                waves.Add(new AAWave(300, 1, 0, new Vector2(200, -30), Textures.GERAABoat));
            }
            waves.Add(new BasicWave<TestEnemy>(450, 35, 3, new Vector2(0, 200), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(5, 2))));
            waves.Add(new BasicWave<TestEnemy>(462, 35, 3, new Vector2(800, 200), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(-5, 2))));

            waves.Add(new AAWave(673, 1, 0, new Vector2(700, -30), Textures.GERAABoat));
            if(Globals.difficulty >= 2)
            {
                waves.Add(new AAWave(1350, 1, 0, new Vector2(100, -30), Textures.GERAABoat));
            }
            waves.Add(new LineWave<TestEnemy>(1200, 15, 6, new Vector2(50, -10), new Vector2(135, 0), (int i, double timeAlive, int max) => { return new Vector2(1, 3); }));
            waves.Add(new LineWave<TestEnemy>(1230, 15, 6, new Vector2(750, -10), new Vector2(-135, 0), (int i, double timeAlive, int max) => { return new Vector2(-1, 3); }));
            waves.Add(new LineWave<TestEnemy>(1700, 0, 4, new Vector2(800, 100), new Vector2(0, 100), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(-5, 0.2f), 15)));
            waves.Add(new AAWave(1480, 1, 0, new Vector2(750, -30), Textures.GERAAGround));
            waves.Add(new AAWave(1900, 1, 0, new Vector2(550, -30), Textures.GERAAGround));
            if (Globals.difficulty >= 1.75)
            {
                waves.Add(new AAWave(1970, 1, 0, new Vector2(330, -30), Textures.GERAAGround));
            }
            if (Globals.difficulty >= 2.5)
            {
                waves.Add(new AAWave(2080, 1, 0, new Vector2(180, -30), Textures.GERAAGround));
            }
            waves.Add(new LineWave<TestEnemy>(2550, 25, 8, new Vector2(50, -10), new Vector2(90, 0), (int i, double timeAlive, int max) => { return new Vector2(0, 3); }));
            waves.Add(new LineWave<TestEnemy>(2850, 25, 8, new Vector2(750, -10), new Vector2(-90, 0), (int i, double timeAlive, int max) => { return new Vector2(0, 3); }));
            waves.Add(new AAWave(3000, 1, 0, new Vector2(275, -30), Textures.GERAAGround));
            if (Globals.difficulty >= 1.5)
            {
                waves.Add(new AAWave(2970, 1, 0, new Vector2(390, -30), Textures.GERAAGround));
            }
            waves.Add(new LineWave<TestEnemy>(3250, 0, 6, new Vector2(50, -10), new Vector2(100, 0), Arch));
            if (Globals.difficulty >= 1.25)
            {
                waves.Add(new BasicWave<TestEnemy>(3300, 0, 4, new Vector2(0, -10), (int i, double timeAlive, int max) => Arch(i, timeAlive, max, new Vector2(max, 0))));
            }
            if (Globals.difficulty >= 1.5)
            {
                waves.Add(new BasicWave<TestEnemy>(3350, 0, 4, new Vector2(780, -10), (int i, double timeAlive, int max) => Arch(i, timeAlive, max, new Vector2(-max, 0))));
            }
            waves.Add(new LineWave<TestEnemy>(3550, 0, 5, new Vector2(800, 100), new Vector2(0, 80), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(-5, 0.2f), 15)));
            waves.Add(new LineWave<TestEnemy>(3590, 0, 5, new Vector2(-10, 100), new Vector2(0, 80), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(5, 0.2f), 15)));
            waves.Add(new AAWave(3740, 1, 0, new Vector2(580, -30), Textures.GERAAGround));
            if (Globals.difficulty >= 1.25)
            {
                waves.Add(new AAWave(3755, 1, 0, new Vector2(510, -30), Textures.GERAAGround));
            }
            waves.Add(new LineWave<TestEnemy>(4100, 0, 3, new Vector2(800, 100), new Vector2(0, 80), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(-5, 0.2f), 15)));
            if (Globals.difficulty >= 1.25)
            {
                waves.Add(new LineWave<TestEnemy>(4175, 0, 3, new Vector2(-10, 100), new Vector2(0, 80), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(5, 0.2f), 15)));
            }

            if (Globals.difficulty >= 1.5)
            {
                waves.Add(new LineWave<TestEnemy>(4375, 0, 4, new Vector2(800, 100), new Vector2(0, 80), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(-5, 0.2f), 15)));
            }
            waves.Add(new LineWave<TestEnemy>(4450, 0, 4, new Vector2(-10, 100), new Vector2(0, 80), (int i, double timeAlive, int max) => ArchDown(i, timeAlive, max, new Vector2(5, 0.2f), 15)));
            
            waves.Add(new LineWave<TestEnemy>(4550, 0, 4, new Vector2(50, -10), new Vector2(170, 0), (int i, double timeAlive, int max) => { return new Vector2(0, 4); }));

            waves.Add(new AAWave(4600, 1, 0, new Vector2(150, -30), Textures.GERAAGround));
            if(Globals.difficulty >= 1.25)
                waves.Add(new AAWave(4650, 1, 0, new Vector2(700, -30), Textures.GERAAGround));
            if(Globals.difficulty >= 1.75)
                waves.Add(new AAWave(4750, 1, 0, new Vector2(250, -30), Textures.GERAAGround));
            if(Globals.difficulty >= 2.5)
                waves.Add(new AAWave(4775, 1, 0, new Vector2(675, -30), Textures.GERAAGround));
        }

        private Vector2 Arch(int i, double timeAlive, int max)
        {
            Vector2 v = (new Vector2(max / 2 - i, max));
            v.Normalize();
            return (3 * v);
        }

        private Vector2 Arch(int i, double timeAlive, int max, Vector2 baseDirection)
        {
            Vector2 v = (new Vector2(max / 2 - i, max)) + baseDirection;
            v.Normalize();
            return (3 * v);
        }

        private Vector2 ArchDown(int i, double timeAlive, int max, Vector2 baseDirection, double archFactor = 1)
        {
            baseDirection.X /= (float)(1 + timeAlive * archFactor / 60);
            baseDirection.Normalize();
            return baseDirection * 4;
        }

    }
}
